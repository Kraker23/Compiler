using Compiler.Application.Contracts.Execution;
using System.Diagnostics;
using System.Text;

namespace Compiler.Infrastructure.Execution;

public class CommandRunner : ICommandRunner
{
    public async Task<CommandExecutionResult> RunAsync(string command, CancellationToken cancellationToken = default)
    {
        var outputBuilder = new StringBuilder();
        var errorBuilder = new StringBuilder();

        var startInfo = new ProcessStartInfo
        {
            FileName = "cmd.exe",
            Arguments = $"/c {command}",
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        using var process = new Process { StartInfo = startInfo };
        process.OutputDataReceived += (_, e) =>
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                outputBuilder.AppendLine(e.Data);
            }
        };
        process.ErrorDataReceived += (_, e) =>
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                errorBuilder.AppendLine(e.Data);
            }
        };

        process.Start();
        process.BeginOutputReadLine();
        process.BeginErrorReadLine();
        await process.WaitForExitAsync(cancellationToken);

        var exitCode = process.ExitCode;
        // xcopy returns 0 for no files copied and 1 for files copied successfully.
        var success = exitCode == 0 || exitCode == 1;

        return new CommandExecutionResult
        {
            Success = success,
            ExitCode = exitCode,
            Command = command,
            Output = outputBuilder.ToString(),
            Error = errorBuilder.ToString()
        };
    }
}
