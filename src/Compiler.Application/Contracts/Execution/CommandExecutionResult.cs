namespace Compiler.Application.Contracts.Execution;

public class CommandExecutionResult
{
    public bool Success { get; set; }
    public int ExitCode { get; set; }
    public string Command { get; set; } = string.Empty;
    public string Output { get; set; } = string.Empty;
    public string Error { get; set; } = string.Empty;
}
