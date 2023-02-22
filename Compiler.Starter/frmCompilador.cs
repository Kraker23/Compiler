using DevToolsNet.Shared.Configs;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevToolsNet.PowerShell;
using DevToolsNet.DB.Objects.Configs;
using DevToolsNet.DB.Runner.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Security;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using Microsoft.CodeAnalysis;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Management.Automation.Runspaces;

namespace Compiler.Starter;

public partial class frmCompilador : Form
{
    private class TabData
    {
        public string Name { get; set; }
        public IPowerShellRunner psr { get; set; }
        public System.Windows.Forms.TextBox TextBox { get; set; }
    }

    ServerTreeManager.TreeServersManger treeServesManager = new ServerTreeManager.TreeServersManger();
    ServersConfig<ServerConfig> servers;
    // List<Carpeta> carpetas;
    Dictionary<string, IPowerShellRunner> runners = new Dictionary<string, IPowerShellRunner>();
    SecureString passSecure = new SecureString();

    private frmCompilador()
    {
        InitializeComponent();

        treeServesManager.InitializeTree(treeCarpetas.Tree);

        tstUser.Text = Environment.UserName;
    }

    public frmCompilador(IOptions<ServersConfig<ServerConfig>> settings) : this()
    {
        /*servers = settings.Value;

        if(servers !=null) treeServesManager.LoadNodes(treeCarpetas.Tree, servers);*/
    }

    private async void treeServers_AfterNodeCheck(object sender, TreeViewEventArgs e)
    {
        if (e?.Node?.Tag is ServerConfig)
        {
            ServerConfig? sc = e?.Node?.Tag as ServerConfig;
            if (sc != null && e?.Node != null)
            {
                if (e.Node.Checked)
                {
                    if (!(await createRunner(sc, e.Node.Name)))
                    {
                        e.Node.Checked = false;
                    }
                }
                else
                {
                    if (runners.ContainsKey(e.Node.Name))
                    {
                        var r = runners[e.Node.Name];
                        runners.Remove(e.Node.Name);
                        r.Dispose();
                        tabResults.TabPages.RemoveByKey(e.Node.Name);
                    }
                }
            }
        }
        else if (e?.Node?.Tag is Elemento)
        {
            if (e.Node.Checked)
            {
                Elemento? elemento = e?.Node?.Tag as Elemento;
                // createPowerShell(elemento, e.Node.Name);
                if (elemento.tipoElemento == TipoElemento.Solucion)
                {
                    createPowerShell(elemento);
                }


            }
        }
    }

    private void AddResultTab(IPowerShellRunner psr, string tabText)
    {
        TabData tdata = new TabData();
        tdata.psr = psr;

        var tab = new TabPage(tabText);
        tab.Name = psr.Key;
        tab.Tag = tdata;

        tdata.TextBox = new System.Windows.Forms.TextBox()
        {
            Dock = DockStyle.Fill,
            Multiline = true,
            MaxLength = int.MaxValue,
            ScrollBars = ScrollBars.Both,
            Font = new Font("Consolas", 10),
            ForeColor = Color.White,
            BackColor = Color.FromArgb(1, 36, 86)
        };

        tab.Controls.Add(tdata.TextBox);

        tabResults.TabPages.Add(tab);
    }


    private void tsbClear_Click(object sender, EventArgs e)
    {
        foreach (TabPage tab in tabResults.TabPages)
        {
            ((TabData)tab.Tag).TextBox.Text = string.Empty;
        }

    }


    private async Task<bool> createRunner(ServerConfig sc, string key)
    {
        try
        {
            passSecure.Clear();
            foreach (Char c in tstPass.Text) passSecure.AppendChar(c);

            var r = await Task.Factory.StartNew<IPowerShellRunner>(() => new PowerShellRunner(sc, tstUser.Text, passSecure)).WaitAsync(CancellationToken.None);
            if (r != null)
            {
                r.Key = key;
                r.TextMessaje += runner_TextMessaje;
                r.ErrorMessaje += runner_TextMessaje;
                r.InfoMessaje += runner_TextMessaje;
                r.WarningMessaje += runner_TextMessaje;
                runners.Add(key, r);
                AddResultTab(r, sc.Name);
                return true;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"{sc.Name}: {ex.ToString()}");
        }

        return false;
    }

    private void createPowerShell(Elemento elemento)
    {
        try
        {
           /* InitialSessionState iss = InitialSessionState.Create();
            SessionStateCmdletEntry getCommand = new SessionStateCmdletEntry("Get-Command", typeof(Microsoft.PowerShell.Commands.GetCommandCommand), "");
            SessionStateCmdletEntry importModule = new SessionStateCmdletEntry("Import-Module", typeof(Microsoft.PowerShell.Commands.ImportModuleCommand), "");

            iss.Commands.Add(new SessionStateCmdletEntry("Import-Module", typeof(Microsoft.PowerShell.Commands.loc), ""));

            iss.Commands.Add(getCommand);
            iss.Commands.Add(importModule);

            //Creamos un espacio de ejecución para capturar el resultado del comando
            Runspace espacioEjecucion = RunspaceFactory.CreateRunspace(iss);
            //Lo iniciamos
             System.Environment.CurrentDirectory = "C:\\Program Files\\Microsoft Visual Studio\\2022\\Community\\MSBuild\\Current\\Bin\\";
            espacioEjecucion.Open();
            */
            // espacioEjecucion.SessionStateProxy.Path.SetLocation("C:\\Program Files\\Microsoft Visual Studio\\2022\\Community\\MSBuild\\Current\\Bin\\");
            //Creamos el objeto PowerShell
           
            //System.Management.Automation.PowerShell objPowerShell = System.Management.Automation.PowerShell.Create();
            //Al objeto PowerShell le asignamos el espacio de ejecución
            //  objPowerShell.Runspace = espacioEjecucion;
            //Agregamos el comando PowerShell a ejecutar
            //objPowerShell.AddScript(@"Get-NetAdapter | Select Name | Format-Table -HideTableHeaders | Out-String");
            // objPowerShell.AddScript("Set-Location \"C:\\Program Files\\Microsoft Visual Studio\\2022\\Community\\MSBuild\\Current\\Bin\\\"");
            //objPowerShell.AddCommand("Set-Location \"C:\\Program Files\\Microsoft Visual Studio\\2022\\Community\\MSBuild\\Current\\Bin\\\"");
            //  objPowerShell.AddCommand("cd \"C:\\Program Files\\Microsoft Visual Studio\\2022\\Community\\MSBuild\\Current\\Bin\\\"");

            // objPowerShell.AddCommand($" \"C:\\Program Files\\Microsoft Visual Studio\\2022\\Community\\MSBuild\\Current\\Bin\\MSBuild.exe\" \"{elemento.Ruta}\" /clp:ErrorsOnly");
            //  objPowerShell.AddCommand($".\\MSBuild.exe \"{elemento.Ruta}\" /clp:ErrorsOnly");
            // objPowerShell.AddCommand("get-Process");
            //objPowerShell.AddCommand("ls");

            // string commnd_text = "cd " + "\"C:\\VSS-DB\\Sicer-España\\DNOTA.Tools\"" + "\n";
            // string commnd_text = "cd " + elemento.Ruta + "\n";
            //  commnd_text += "ls";


            System.Management.Automation.PowerShell objPowerShell = System.Management.Automation.PowerShell.Create();
            string commnd_text = "Set-Location \"C:\\Program Files\\Microsoft Visual Studio\\2022\\Community\\MSBuild\\Current\\Bin\\\"" + "\n";
            commnd_text += $".\\MSBuild.exe \"{elemento.Ruta}\" /clp:ErrorsOnly";

            objPowerShell.AddScript(commnd_text);
            objPowerShell.AddCommand("Out-String");

            Collection<PSObject> resultadoEjecucion = objPowerShell.Invoke();

            StringBuilder stringBuilder = new StringBuilder();
            foreach (PSObject lineaResultado in resultadoEjecucion)
            {
                txtCommand.AppendText(lineaResultado.ToString() + Environment.NewLine);
            }
        }
        catch (Exception ex)
        {
            //MessageBox.Show($"{sc.Name}: {ex.ToString()}");
            txtCommand.AppendText($"{elemento.Nombre}: {ex.ToString()}");
        }


    }

    private void test()
    {
        //Creamos un espacio de ejecución para capturar el resultado del comando
        Runspace espacioEjecucion = RunspaceFactory.CreateRunspace();
        //Lo iniciamos
        espacioEjecucion.Open();
        //Creamos el objeto PowerShell
        System.Management.Automation.PowerShell objPowerShell = System.Management.Automation.PowerShell.Create();
        //Al objeto PowerShell le asignamos el espacio de ejecución
        objPowerShell.Runspace = espacioEjecucion;
        //Agregamos el comando PowerShell a ejecutar
        //objPowerShell.AddScript(@"Get-NetAdapter | Select Name | Format-Table -HideTableHeaders | Out-String");
        objPowerShell.AddCommand("Get-Process");
        //Ejecutamos el comando PowerShell y guardamos su resultado
        Collection<PSObject> resultadoEjecucion = objPowerShell.Invoke();
        //Cerramos el espacio de ejecución
        espacioEjecucion.Close();
        //Recorremos cada línea del resultado para mostrarla por consola
        StringBuilder stringBuilder = new StringBuilder();
        foreach (PSObject lineaResultado in resultadoEjecucion)
        {
            txtCommand.AppendText(lineaResultado.ToString() + Environment.NewLine);
        }


        //// Runspace rs = RunspaceFactory.CreateRunspace(iss);
        //// rs.Open();
        //System.Management.Automation.PowerShell ps = System.Management.Automation.PowerShell.Create();
        ////ps.Runspace = rs;
        //ps.AddCommand("Get-Process");
        //Collection<CommandInfo> result = ps.Invoke<CommandInfo>();
        //foreach (var entry in result)
        //{
        //    txtCommand.AppendText (entry.Name + Environment.NewLine );
        //}
    }

    private void tsbExecute_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (var run in runners)
            {
                Task.Factory.StartNew(() => run.Value.RunCommand(txtCommand.Text));
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
    }

    private void runner_TextMessaje(IPowerShellRunner runner, string msg)
    {
        try
        {
            var td = tabResults.TabPages[runner.Key].Tag as TabData;
            if (td != null)
            {
                if (td.TextBox.InvokeRequired)
                {
                    td.TextBox.Invoke(() =>
                    {
                        td.TextBox.Text += msg;
                        td.TextBox.SelectionStart = td.TextBox.Text.Length;
                        td.TextBox.ScrollToCaret();
                    });
                }
            }
            else
            {
                td.TextBox.Text += msg;
                td.TextBox.SelectionStart = td.TextBox.Text.Length;
                td.TextBox.ScrollToCaret();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }

    }

    private void tsbBuscarCarpeta_Click(object sender, EventArgs e)
    {
        using (var fd = new FolderBrowserDialog())
        {
            if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(fd.SelectedPath))
            {
                tstCarpeta.Text = fd.SelectedPath;
            }
        }
        CargarCarpetas();

    }

    private void CargarCarpetas()
    {
        Elemento elemento = new Elemento();
        //carpetas = new List<Carpeta>();
        if (!string.IsNullOrEmpty(tstCarpeta.Text))
        {
            elemento = new Elemento(tstCarpeta.Text, TipoElemento.Carpeta);
            //Carpeta carpetaAux = new Carpeta();


            string[] directorios = Directory.GetDirectories(tstCarpeta.Text);
            string[] soluciones = Directory.GetFiles(tstCarpeta.Text, "*.sln");
            string[] projectos = Directory.GetFiles(tstCarpeta.Text, "*.csproj");

            directorios.ToList().ForEach(d => { elemento.elementos.Add(new Elemento(d, TipoElemento.Carpeta)); });
            soluciones.ToList().ForEach(d => { elemento.elementos.Add(new Elemento(d, TipoElemento.Solucion)); });
            projectos.ToList().ForEach(d => { elemento.elementos.Add(new Elemento(d, TipoElemento.Projecto)); });

            foreach (Elemento elemntoAux in elemento.elementos)
            {
                if (elemntoAux.tipoElemento == TipoElemento.Carpeta)
                {
                    Elemento aux = new Elemento();
                    Directory.GetFiles(elemntoAux.Ruta, "*.sln", SearchOption.AllDirectories).ToList().ForEach(x => { elemntoAux.elementos.Add(new Elemento(x, TipoElemento.Solucion)); });
                    Directory.GetFiles(elemntoAux.Ruta, "*.csproj", SearchOption.AllDirectories).ToList().ForEach(x => { elemntoAux.elementos.Add(new Elemento(x, TipoElemento.Projecto)); });
                    //if (Directory.Exists(directorio))
                    //{
                    //    carpetaAux.Nombre = Path.GetFileName(directorio);
                    //    carpetaAux.Ruta = directorio;
                    //}

                    //carpetas.Add(carpetaAux);                    
                }
            }


            //foreach (var directorio in directorios)
            //{
            //    //carpetaAux = new Carpeta(); 
            //    Elemento aux = new Elemento();
            //    Directory.GetFiles(directorio, "*.sln").ToList().ForEach(x => { carpetaAux.soluciones.Add(new Solucion(x)); });
            //    Directory.GetFiles(directorio, "*.csproj", SearchOption.AllDirectories).ToList().ForEach(x => { carpetaAux.projectos.Add(new Projecto(x)); });
            //    if (Directory.Exists(directorio))
            //    {
            //        carpetaAux.Nombre = Path.GetFileName(directorio);
            //        carpetaAux.Ruta = directorio;
            //    }

            //    //carpetas.Add(carpetaAux);
            //    elemento.elementos.Add();
            //}

            //if (carpetas != null) { treeServesManager.LoadNodes(treeCarpetas.Tree, carpetas); }
            // treeCarpetas.Nodes.AddRange(carpetas);

            // CargarTree(treeCarpetas.Nodes, carpetas);
            treeCarpetas.Nodes.Clear();
            CargarTree(treeCarpetas.Nodes, elemento.elementos);
        }
    }
    public void CargarTree(TreeNodeCollection Nodes, List<Elemento> elementos)
    {
        //foreach (Carpeta carpeta in carpetas)
        foreach (Elemento elementoAux in elementos)
        {
            TreeNode node = new TreeNode(elementoAux.Nombre);
            node.Tag = elementoAux;
            switch (elementoAux.tipoElemento)
            {
                case TipoElemento.Carpeta:
                    node.ImageKey = "carpeta";
                    break;
                case TipoElemento.Solucion:
                    node.ImageKey = "solucion";
                    break;
                case TipoElemento.Projecto:
                    node.ImageKey = "projecto";
                    break;
                default:
                    node.ImageKey = "grupo";
                    break;
            }
            if (elementoAux.elementos.Any())
            {
                CargarTree(node.Nodes, elementoAux.elementos);
            }
            /* carpeta.soluciones.ForEach(s => { node.Nodes.Add(s.Nombre); });
             carpeta.projectos.ForEach(p => { node.Nodes.Add(p.Nombre); });
            */
            Nodes.Add(node);
        }
    }
    //public void CargarTree(TreeNodeCollection Nodes, List<Carpeta> carpetas)
    //{
    //    foreach (Carpeta carpeta in carpetas)
    //    {
    //        TreeNode node = new TreeNode(carpeta.Nombre);
    //        node.ImageKey = "grupo";
    //        carpeta.soluciones.ForEach(s => { node.Nodes.Add(s.Nombre); });
    //        carpeta.projectos.ForEach(p => { node.Nodes.Add(p.Nombre); });

    //        Nodes.Add(node);
    //    }
    //}

}
/*
public class Carpeta
{
    public string Nombre { get; set; }
    public string Ruta { get; set; }
    public List<Carpeta> subCarpetas { get; set; }
    public List<Solucion> soluciones { get; set; }
    public List<Projecto> projectos { get; set; }
    public Carpeta()
    {
        subCarpetas = new List<Carpeta>();
        soluciones = new List<Solucion>();
        projectos = new List<Projecto>();
    }

}


public class Solucion
{
    public Solucion(string Ruta)
    {
        this.Ruta = Ruta;
        this.Nombre = Path.GetFileName(Ruta);
    }
    public string Nombre { get; set; }
    public string Ruta { get; set; }
}

public class Projecto
{
    public Projecto(string Ruta)
    {
        this.Ruta = Ruta;
        this.Nombre = Path.GetFileName(Ruta);
    }
    public string Nombre { get; set; }
    public string Ruta { get; set; }
}
*/

public class Elemento
{
    public Elemento()
    {
        elementos = new List<Elemento>();
    }
    public Elemento(string Ruta) : this()
    {
        this.Ruta = Ruta;
        this.Nombre = Path.GetFileName(Ruta);
    }
    public Elemento(string Ruta, TipoElemento tipo) : this(Ruta)
    {
        this.tipoElemento = tipo;
    }
    public TipoElemento tipoElemento { get; set; }
    public string Nombre { get; set; }
    public string Ruta { get; set; }
    public List<Elemento> elementos { get; set; }
}

public enum TipoElemento
{
    Carpeta,
    Projecto,
    Solucion
}