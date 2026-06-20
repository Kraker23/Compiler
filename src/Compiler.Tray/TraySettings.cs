namespace Compiler.Tray;

public sealed class TraySettings
{
    public string WebUrl { get; set; } = "http://localhost:5000/proyectos";
    public bool AutoOpenWebOnStart { get; set; }
}