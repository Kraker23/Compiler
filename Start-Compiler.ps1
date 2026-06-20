[CmdletBinding()]
param(
    [ValidateSet('Debug', 'Release')]
    [string]$Configuration = 'Debug'
)

$ErrorActionPreference = 'Stop'

$root = Split-Path -Parent $MyInvocation.MyCommand.Path
$webProject = Join-Path $root 'src\Compiler.Web\Compiler.Web.csproj'
$trayProject = Join-Path $root 'src\Compiler.Tray\Compiler.Tray.csproj'
$publishRoot = Join-Path $root 'artifacts\published'
$webPublish = Join-Path $publishRoot 'Web'
$trayPublish = Join-Path $publishRoot 'Tray'
$sharedDataPath = Join-Path $publishRoot 'SharedData'
$runStatePath = Join-Path $publishRoot '.run'
$webPidPath = Join-Path $runStatePath 'web.pid'
$trayPidPath = Join-Path $runStatePath 'tray.pid'

function Get-HasAnyJson {
    param([string]$Path)

    if (-not (Test-Path $Path)) {
        return $false
    }

    $jsonFiles = Get-ChildItem -Path $Path -Filter '*.json' -File -ErrorAction SilentlyContinue
    return ($jsonFiles | Measure-Object).Count -gt 0
}

function Copy-JsonIfMissing {
    param(
        [string]$SourcePath,
        [string]$TargetPath
    )

    if (-not (Test-Path $SourcePath)) {
        return
    }

    Get-ChildItem -Path $SourcePath -Filter '*.json' -File -ErrorAction SilentlyContinue | ForEach-Object {
        $targetFile = Join-Path $TargetPath $_.Name
        if (-not (Test-Path $targetFile)) {
            Copy-Item -Path $_.FullName -Destination $targetFile -Force
        }
    }
}

& (Join-Path $root 'Stop-Compiler.ps1') -Force

New-Item -ItemType Directory -Path $publishRoot -Force | Out-Null
New-Item -ItemType Directory -Path $sharedDataPath -Force | Out-Null
New-Item -ItemType Directory -Path $runStatePath -Force | Out-Null

Write-Host 'Publicando Web...' -ForegroundColor Cyan
dotnet publish $webProject -c $Configuration -o $webPublish
if ($LASTEXITCODE -ne 0) {
    throw 'La publicacion de Web fallo. Se cancela el arranque.'
}

Write-Host 'Publicando Tray...' -ForegroundColor Cyan
dotnet publish $trayProject -c $Configuration -o $trayPublish
if ($LASTEXITCODE -ne 0) {
    throw 'La publicacion de Tray fallo. Se cancela el arranque.'
}

$webDataPath = Join-Path $webPublish 'Data'
$trayDataPath = Join-Path $trayPublish 'Data'

if (-not (Get-HasAnyJson -Path $sharedDataPath)) {
    Write-Host 'Inicializando SharedData desde datos existentes...' -ForegroundColor Cyan
    Copy-JsonIfMissing -SourcePath $webDataPath -TargetPath $sharedDataPath
    Copy-JsonIfMissing -SourcePath $trayDataPath -TargetPath $sharedDataPath
}

Write-Host 'Iniciando aplicaciones publicadas...' -ForegroundColor Cyan
$webProcess = Start-Process -FilePath dotnet -ArgumentList @('Compiler.Web.dll') -WorkingDirectory $webPublish -WindowStyle Hidden -PassThru
$trayProcess = Start-Process -FilePath dotnet -ArgumentList @('Compiler.Tray.dll') -WorkingDirectory $trayPublish -WindowStyle Hidden -PassThru

Set-Content -Path $webPidPath -Value $webProcess.Id -Encoding ascii
Set-Content -Path $trayPidPath -Value $trayProcess.Id -Encoding ascii
Write-Host 'Arranque solicitado.' -ForegroundColor Green