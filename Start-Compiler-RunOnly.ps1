[CmdletBinding()]
param()

$ErrorActionPreference = 'Stop'

$root = Split-Path -Parent $MyInvocation.MyCommand.Path
$publishRoot = Join-Path $root 'artifacts\published'
$webPublish = Join-Path $publishRoot 'Web'
$trayPublish = Join-Path $publishRoot 'Tray'
$runStatePath = Join-Path $publishRoot '.run'
$webPidPath = Join-Path $runStatePath 'web.pid'
$trayPidPath = Join-Path $runStatePath 'tray.pid'

if (-not (Test-Path $webPublish) -or -not (Test-Path $trayPublish)) {
    throw 'No se encontraron las aplicaciones publicadas en artifacts\published. Ejecuta primero Start-Compiler.ps1.'
}

New-Item -ItemType Directory -Path $runStatePath -Force | Out-Null

Write-Host 'Iniciando aplicaciones publicadas...' -ForegroundColor Cyan
$webProcess = Start-Process -FilePath dotnet -ArgumentList @('Compiler.Web.dll') -WorkingDirectory $webPublish -WindowStyle Hidden -PassThru
$trayProcess = Start-Process -FilePath dotnet -ArgumentList @('Compiler.Tray.dll') -WorkingDirectory $trayPublish -WindowStyle Hidden -PassThru

Set-Content -Path $webPidPath -Value $webProcess.Id -Encoding ascii
Set-Content -Path $trayPidPath -Value $trayProcess.Id -Encoding ascii
Write-Host 'Arranque solicitado.' -ForegroundColor Green