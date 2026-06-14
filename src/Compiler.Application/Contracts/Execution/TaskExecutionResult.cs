namespace Compiler.Application.Contracts.Execution;

public class TaskExecutionResult
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
    public List<CommandExecutionResult> Steps { get; set; } = [];
}
