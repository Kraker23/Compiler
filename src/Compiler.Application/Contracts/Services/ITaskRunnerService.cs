using Compiler.Application.Contracts.Execution;

namespace Compiler.Application.Contracts.Services;

public interface ITaskRunnerService
{
    Task<TaskExecutionResult> CopyProyectoAsync(Guid idProyecto, CancellationToken cancellationToken = default);
    Task<TaskExecutionResult> CopyAplicacionAsync(Guid idAplicacion, CancellationToken cancellationToken = default);
    Task<TaskExecutionResult> BuildProyectoAsync(Guid idProyecto, CancellationToken cancellationToken = default);
    Task<TaskExecutionResult> BuildAplicacionAsync(Guid idAplicacion, CancellationToken cancellationToken = default);
    Task<TaskExecutionResult> BuildAndCopyProyectoAsync(Guid idProyecto, CancellationToken cancellationToken = default);
    Task<TaskExecutionResult> BuildAndCopyAplicacionAsync(Guid idAplicacion, CancellationToken cancellationToken = default);
}
