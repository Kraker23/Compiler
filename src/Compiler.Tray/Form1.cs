using Compiler.Application.Contracts.Services;
using Compiler.Domain.Entities;
using System.Diagnostics;

namespace Compiler.Tray;

public partial class Form1 : Form
{
    private readonly IProyectoService proyectoService;
    private readonly ITaskRunnerService taskRunnerService;
    private readonly NotifyIcon notifyIcon;
    private readonly ContextMenuStrip trayMenu;
    private bool permitirCerrar;

    public Form1(IProyectoService proyectoService, ITaskRunnerService taskRunnerService)
    {
        this.proyectoService = proyectoService;
        this.taskRunnerService = taskRunnerService;
        InitializeComponent();

        trayMenu = new ContextMenuStrip();
        notifyIcon = new NotifyIcon
        {
            Icon = SystemIcons.Application,
            Text = "Compiler Next",
            Visible = true,
            ContextMenuStrip = trayMenu
        };

        notifyIcon.DoubleClick += (_, _) => MostrarVentana();
        Load += (_, _) => ConfigurarTray();
        FormClosing += OnFormClosing;
        WindowState = FormWindowState.Minimized;
        ShowInTaskbar = false;
    }

    private void ConfigurarTray()
    {
        trayMenu.Items.Clear();

        var proyectos = proyectoService.GetProyectos();
        if (proyectos.Count == 0)
        {
            trayMenu.Items.Add(new ToolStripMenuItem("Sin proyectos") { Enabled = false });
        }
        else
        {
            foreach (var proyecto in proyectos)
            {
                trayMenu.Items.Add(CrearItemProyecto(proyecto));
            }
        }

        trayMenu.Items.Add(new ToolStripSeparator());
        trayMenu.Items.Add(new ToolStripMenuItem("Abrir Web", null, (_, _) => AbrirWeb()));
        trayMenu.Items.Add(new ToolStripMenuItem("Refrescar", null, (_, _) => ConfigurarTray()));
        trayMenu.Items.Add(new ToolStripMenuItem("Salir", null, (_, _) => CerrarAplicacion()));
    }

    private ToolStripMenuItem CrearItemProyecto(Proyecto proyecto)
    {
        var itemProyecto = new ToolStripMenuItem(proyecto.nombre);
        itemProyecto.DropDownItems.Add(new ToolStripMenuItem("Copiar", null, async (_, _) => await CopiarProyectoAsync(proyecto)));
        itemProyecto.DropDownItems.Add(new ToolStripMenuItem("Compilar", null, async (_, _) => await CompilarProyectoAsync(proyecto)));
        itemProyecto.DropDownItems.Add(new ToolStripMenuItem("Copiar y Compilar", null, async (_, _) => await CompilarYCopiarProyectoAsync(proyecto)));
        return itemProyecto;
    }

    private async Task CopiarProyectoAsync(Proyecto proyecto)
    {
        await EjecutarProyectoAsync(() => taskRunnerService.CopyProyectoAsync(proyecto.id), "Copiado completado", "Copiado con errores");
    }

    private async Task CompilarProyectoAsync(Proyecto proyecto)
    {
        await EjecutarProyectoAsync(() => taskRunnerService.BuildProyectoAsync(proyecto.id), "Compilacion completada", "Compilacion con errores");
    }

    private async Task CompilarYCopiarProyectoAsync(Proyecto proyecto)
    {
        await EjecutarProyectoAsync(() => taskRunnerService.BuildAndCopyProyectoAsync(proyecto.id), "Compilar y copiar completado", "Compilar y copiar con errores");
    }

    private async Task EjecutarProyectoAsync(Func<Task<Compiler.Application.Contracts.Execution.TaskExecutionResult>> action, string successTitle, string errorTitle)
    {
        try
        {
            var result = await action();
            notifyIcon.BalloonTipTitle = result.Success ? successTitle : errorTitle;
            notifyIcon.BalloonTipText = result.Message;
            notifyIcon.ShowBalloonTip(3000);
        }
        catch (Exception ex)
        {
            notifyIcon.BalloonTipTitle = "Error";
            notifyIcon.BalloonTipText = ex.Message;
            notifyIcon.ShowBalloonTip(3000);
        }
    }

    private void MostrarVentana()
    {
        ShowInTaskbar = true;
        WindowState = FormWindowState.Normal;
        Show();
        Activate();
    }

    private static void AbrirWeb()
    {
        try
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "http://localhost:5071/proyectos",
                UseShellExecute = true
            });
        }
        catch
        {
        }
    }

    private void CerrarAplicacion()
    {
        permitirCerrar = true;
        notifyIcon.Visible = false;
        Close();
    }

    private void OnFormClosing(object? sender, FormClosingEventArgs e)
    {
        if (permitirCerrar)
        {
            return;
        }

        e.Cancel = true;
        Hide();
        ShowInTaskbar = false;
    }
}
