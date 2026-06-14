using Compiler.Application.Contracts.Execution;
using Compiler.Application.Contracts.Services;
using Compiler.Domain.Entities;
using Compiler.Domain.Extenders;

namespace Compiler.Application.Services;

public class TaskRunnerService(
    IProyectoService proyectoService,
    IAplicacionService aplicacionService,
    IArchivoExclusionService exclusionService,
    ICommandRunner commandRunner) : ITaskRunnerService
{
    public async Task<TaskExecutionResult> BuildProyectoAsync(Guid idProyecto, CancellationToken cancellationToken = default)
    {
        var proyecto = proyectoService.GetProyecto(idProyecto);
        if (proyecto == null)
        {
            return new TaskExecutionResult
            {
                Success = false,
                Message = "Proyecto no encontrado."
            };
        }

        var resultado = new TaskExecutionResult();
        var aplicaciones = aplicacionService.GetAplicaciones(proyecto.aplicaciones ?? []);

        foreach (var app in aplicaciones)
        {
            var paso = await BuildAplicacionInternalAsync(app, cancellationToken);
            resultado.Steps.Add(paso);
        }

        resultado.Success = resultado.Steps.Count > 0 && resultado.Steps.All(x => x.Success);
        resultado.Message = resultado.Success
            ? $"Compilacion completada para proyecto '{proyecto.nombre}'."
            : $"Compilacion finalizada con errores para proyecto '{proyecto.nombre}'.";

        return resultado;
    }

    public async Task<TaskExecutionResult> BuildAplicacionAsync(Guid idAplicacion, CancellationToken cancellationToken = default)
    {
        var app = aplicacionService.GetAplicacion(idAplicacion);
        if (app == null)
        {
            return new TaskExecutionResult
            {
                Success = false,
                Message = "Aplicacion no encontrada."
            };
        }

        var paso = await BuildAplicacionInternalAsync(app, cancellationToken);

        return new TaskExecutionResult
        {
            Success = paso.Success,
            Message = paso.Success
                ? $"Compilacion completada para aplicacion '{app.nombre}'."
                : $"Compilacion con error para aplicacion '{app.nombre}'.",
            Steps = [paso]
        };
    }

    public async Task<TaskExecutionResult> BuildAndCopyProyectoAsync(Guid idProyecto, CancellationToken cancellationToken = default)
    {
        var build = await BuildProyectoAsync(idProyecto, cancellationToken);
        if (!build.Success)
        {
            return build;
        }

        var copy = await CopyProyectoAsync(idProyecto, cancellationToken);
        return MergeResults(build, copy, "Compilar y copiar completado.", "Compilar y copiar finalizado con errores.");
    }

    public async Task<TaskExecutionResult> BuildAndCopyAplicacionAsync(Guid idAplicacion, CancellationToken cancellationToken = default)
    {
        var build = await BuildAplicacionAsync(idAplicacion, cancellationToken);
        if (!build.Success)
        {
            return build;
        }

        var copy = await CopyAplicacionAsync(idAplicacion, cancellationToken);
        return MergeResults(build, copy, "Compilar y copiar completado.", "Compilar y copiar finalizado con errores.");
    }

    public async Task<TaskExecutionResult> CopyProyectoAsync(Guid idProyecto, CancellationToken cancellationToken = default)
    {
        var proyecto = proyectoService.GetProyecto(idProyecto);
        if (proyecto == null)
        {
            return new TaskExecutionResult
            {
                Success = false,
                Message = "Proyecto no encontrado."
            };
        }

        var resultado = new TaskExecutionResult();
        var aplicaciones = aplicacionService.GetAplicaciones(proyecto.aplicaciones ?? []);

        foreach (var app in aplicaciones)
        {
            var paso = await CopyAplicacionInternalAsync(app, cancellationToken);
            resultado.Steps.Add(paso);
        }

        resultado.Success = resultado.Steps.Count > 0 && resultado.Steps.All(x => x.Success);
        resultado.Message = resultado.Success
            ? $"Copiado completado para proyecto '{proyecto.nombre}'."
            : $"Copiado finalizado con errores para proyecto '{proyecto.nombre}'.";

        return resultado;
    }

    public async Task<TaskExecutionResult> CopyAplicacionAsync(Guid idAplicacion, CancellationToken cancellationToken = default)
    {
        var app = aplicacionService.GetAplicacion(idAplicacion);
        if (app == null)
        {
            return new TaskExecutionResult
            {
                Success = false,
                Message = "Aplicacion no encontrada."
            };
        }

        var paso = await CopyAplicacionInternalAsync(app, cancellationToken);

        return new TaskExecutionResult
        {
            Success = paso.Success,
            Message = paso.Success
                ? $"Copiado completado para aplicacion '{app.nombre}'."
                : $"Copiado con error para aplicacion '{app.nombre}'.",
            Steps = [paso]
        };
    }

    private async Task<CommandExecutionResult> BuildAplicacionInternalAsync(Aplicacion aplicacion, CancellationToken cancellationToken)
    {
        var command = BuildCompileCommand(aplicacion);
        if (string.IsNullOrWhiteSpace(command))
        {
            return new CommandExecutionResult
            {
                Success = false,
                Command = string.Empty,
                Error = $"No hay comando de compilacion ni ubicacion valida para '{aplicacion.nombre}'."
            };
        }

        try
        {
            return await commandRunner.RunAsync(command, cancellationToken);
        }
        catch (Exception ex)
        {
            return new CommandExecutionResult
            {
                Success = false,
                Command = command,
                Error = ex.Message
            };
        }
    }

    private async Task<CommandExecutionResult> CopyAplicacionInternalAsync(Aplicacion aplicacion, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(aplicacion.carpetaCompilado) || string.IsNullOrWhiteSpace(aplicacion.carpetaPublicacion))
        {
            return new CommandExecutionResult
            {
                Success = false,
                Command = "xcopy",
                Error = $"Rutas invalidas para aplicacion '{aplicacion.nombre}'."
            };
        }

        try
        {
            Directory.CreateDirectory(aplicacion.carpetaPublicacion);

            var exclusionPath = Path.Combine(Path.GetTempPath(), $"compiler-excluded-{Guid.NewGuid():N}.txt");
            var exclusions = exclusionService.GetArchivoExclusiones(aplicacion.archivosExcluidos ?? []);
            File.WriteAllText(exclusionPath, exclusions.getArchivosToString());

            var command = BuildCopyCommand(aplicacion.carpetaCompilado, aplicacion.carpetaPublicacion, exclusionPath);
            var result = await commandRunner.RunAsync(command, cancellationToken);

            TryDeleteTempFile(exclusionPath);
            return result;
        }
        catch (Exception ex)
        {
            return new CommandExecutionResult
            {
                Success = false,
                Command = "xcopy",
                Error = ex.Message
            };
        }
    }

    private static string BuildCopyCommand(string source, string destination, string exclusionFile)
    {
        return $"xcopy \"{source}\" \"{destination}\" /E /Y /D /exclude:\"{exclusionFile}\"";
    }

    private static string BuildCompileCommand(Aplicacion aplicacion)
    {
        if (!string.IsNullOrWhiteSpace(aplicacion.comandoCompilado))
        {
            return aplicacion.comandoCompilado.Trim();
        }

        if (!string.IsNullOrWhiteSpace(aplicacion.ubicacionAplicacion))
        {
            return $"dotnet build \"{aplicacion.ubicacionAplicacion}\"";
        }

        return string.Empty;
    }

    private static TaskExecutionResult MergeResults(TaskExecutionResult first, TaskExecutionResult second, string successMessage, string errorMessage)
    {
        var result = new TaskExecutionResult
        {
            Success = first.Success && second.Success,
            Message = first.Success && second.Success ? successMessage : errorMessage,
            Steps = []
        };

        result.Steps.AddRange(first.Steps);
        result.Steps.AddRange(second.Steps);
        return result;
    }

    private static void TryDeleteTempFile(string path)
    {
        try
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
        catch
        {
        }
    }
}
