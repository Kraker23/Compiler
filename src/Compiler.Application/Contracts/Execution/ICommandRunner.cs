namespace Compiler.Application.Contracts.Execution;

public interface ICommandRunner
{
    Task<CommandExecutionResult> RunAsync(string command, CancellationToken cancellationToken = default);
}
