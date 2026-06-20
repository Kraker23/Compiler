[CmdletBinding()]
param(
    [switch]$Force
)

$ErrorActionPreference = 'Stop'

$root = Split-Path -Parent $MyInvocation.MyCommand.Path
$publishRoot = Join-Path $root 'artifacts\published'
$webPublish = Join-Path $publishRoot 'Web'
$trayPublish = Join-Path $publishRoot 'Tray'
$runStatePath = Join-Path $publishRoot '.run'
$webPidPath = Join-Path $runStatePath 'web.pid'
$trayPidPath = Join-Path $runStatePath 'tray.pid'

function Stop-ProcessByPidFile {
    param(
        [string]$PidPath,
        [switch]$Force
    )

    if (-not (Test-Path $PidPath)) {
        return $false
    }

    $rawPid = Get-Content -Path $PidPath -Raw -ErrorAction SilentlyContinue
    if ($null -eq $rawPid) {
        $rawPid = ''
    }
    $pidValue = 0
    if (-not [int]::TryParse($rawPid.Trim(), [ref]$pidValue)) {
        Remove-Item -Path $PidPath -Force -ErrorAction SilentlyContinue
        return $false
    }

    try {
        $proc = Get-Process -Id $pidValue -ErrorAction Stop
        $null = $proc.CloseMainWindow()
        Stop-Process -Id $pidValue -Force:$Force -ErrorAction SilentlyContinue
    }
    catch {
    }

    Remove-Item -Path $PidPath -Force -ErrorAction SilentlyContinue
    return $true
}

function Get-CompilerProcesses {
    param([string]$DllName)

    Get-CimInstance Win32_Process |
        Where-Object { $_.CommandLine -like "*dotnet*" -and $_.CommandLine -like "*$DllName*" }
}

if (-not (Test-Path $publishRoot)) {
    Write-Host 'No existe la carpeta artifacts\\published. No hay procesos publicados que detener.' -ForegroundColor Yellow
    return
}

$stoppedTrayByPid = Stop-ProcessByPidFile -PidPath $trayPidPath -Force:$Force
$stoppedWebByPid = Stop-ProcessByPidFile -PidPath $webPidPath -Force:$Force

$trayProcesses = Get-CompilerProcesses -DllName 'Compiler.Tray.dll'
$webProcesses = Get-CompilerProcesses -DllName 'Compiler.Web.dll'

if (-not $stoppedTrayByPid -and $trayProcesses) {
    Write-Host 'Deteniendo Tray...' -ForegroundColor Cyan
    foreach ($process in $trayProcesses) {
        try {
            $handle = Get-Process -Id $process.ProcessId -ErrorAction Stop
            if ($handle.MainWindowHandle -ne 0) {
                $null = $handle.CloseMainWindow()
            }

            if (-not $handle.HasExited) {
                Stop-Process -Id $handle.Id -Force:$Force
            }
        }
        catch {
            Stop-Process -Id $process.ProcessId -Force:$Force -ErrorAction SilentlyContinue
        }
    }
}

if (-not $stoppedWebByPid -and $webProcesses) {
    Write-Host 'Deteniendo Web...' -ForegroundColor Cyan
    foreach ($process in $webProcesses) {
        Stop-Process -Id $process.ProcessId -Force:$Force -ErrorAction SilentlyContinue
    }
}

Write-Host 'Detencion solicitada.' -ForegroundColor Green