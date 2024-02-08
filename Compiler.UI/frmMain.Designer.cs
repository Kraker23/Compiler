namespace Compiler.UI
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            tsMain = new ToolStrip();
            tsbRecargar = new ToolStripButton();
            toolStripDropDownButton1 = new ToolStripDropDownButton();
            tsmiAplicaciones = new ToolStripMenuItem();
            tsmiProyectos = new ToolStripMenuItem();
            tsmiArchivosExcluyentes = new ToolStripMenuItem();
            toolStripButton1 = new ToolStripButton();
            cmBarraIconos = new MetroFramework.Controls.MetroContextMenu(components);
            notifyIcon = new NotifyIcon(components);
            pTree = new MetroFramework.Controls.MetroPanel();
            treeProyectos = new TreeView();
            cmTree = new MetroFramework.Controls.MetroContextMenu(components);
            tsmCopiar = new ToolStripMenuItem();
            tsmCompilar = new ToolStripMenuItem();
            tsmCompilarCopiar = new ToolStripMenuItem();
            iListTree = new ImageList(components);
            tsTree = new ToolStrip();
            tsbAdd = new ToolStripButton();
            tsbBorrar = new ToolStripButton();
            txtPS = new MetroFramework.Controls.MetroTextBox();
            txtError = new MetroFramework.Controls.MetroTextBox();
            spSalida = new SplitContainer();
            pProgress = new MetroFramework.Controls.MetroPanel();
            progresBar = new MetroFramework.Controls.MetroProgressBar();
            progressSpinner = new MetroFramework.Controls.MetroProgressSpinner();
            tsMain.SuspendLayout();
            pTree.SuspendLayout();
            cmTree.SuspendLayout();
            tsTree.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)spSalida).BeginInit();
            spSalida.Panel1.SuspendLayout();
            spSalida.Panel2.SuspendLayout();
            spSalida.SuspendLayout();
            pProgress.SuspendLayout();
            SuspendLayout();
            // 
            // tsMain
            // 
            tsMain.Items.AddRange(new ToolStripItem[] { tsbRecargar, toolStripDropDownButton1, toolStripButton1 });
            tsMain.Location = new Point(1, 30);
            tsMain.Name = "tsMain";
            tsMain.Size = new Size(1121, 25);
            tsMain.TabIndex = 0;
            tsMain.Text = "toolStrip1";
            // 
            // tsbRecargar
            // 
            tsbRecargar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbRecargar.Image = Properties.Resources.refresh;
            tsbRecargar.ImageTransparentColor = Color.Magenta;
            tsbRecargar.Name = "tsbRecargar";
            tsbRecargar.Size = new Size(23, 22);
            tsbRecargar.Text = "toolStripButton1";
            tsbRecargar.Click += tsbRecargar_Click;
            // 
            // toolStripDropDownButton1
            // 
            toolStripDropDownButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripDropDownButton1.DropDownItems.AddRange(new ToolStripItem[] { tsmiAplicaciones, tsmiProyectos, tsmiArchivosExcluyentes });
            toolStripDropDownButton1.Image = Properties.Resources.gear;
            toolStripDropDownButton1.ImageTransparentColor = Color.Magenta;
            toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            toolStripDropDownButton1.Size = new Size(29, 22);
            toolStripDropDownButton1.Text = "Configuraciones";
            // 
            // tsmiAplicaciones
            // 
            tsmiAplicaciones.Image = Properties.Resources.window_gear;
            tsmiAplicaciones.Name = "tsmiAplicaciones";
            tsmiAplicaciones.Size = new Size(185, 22);
            tsmiAplicaciones.Text = "Aplicaciones";
            tsmiAplicaciones.Click += tsmiAplicaciones_Click;
            // 
            // tsmiProyectos
            // 
            tsmiProyectos.Image = Properties.Resources.folder_gear;
            tsmiProyectos.Name = "tsmiProyectos";
            tsmiProyectos.Size = new Size(185, 22);
            tsmiProyectos.Text = "Proyectos";
            tsmiProyectos.Click += tsmiProyectos_Click;
            // 
            // tsmiArchivosExcluyentes
            // 
            tsmiArchivosExcluyentes.Image = Properties.Resources.document_gear;
            tsmiArchivosExcluyentes.Name = "tsmiArchivosExcluyentes";
            tsmiArchivosExcluyentes.Size = new Size(185, 22);
            tsmiArchivosExcluyentes.Text = "Archivos Excluyentes";
            tsmiArchivosExcluyentes.Click += tsmiArchivosExcluyentes_Click;
            // 
            // toolStripButton1
            // 
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton1.Image = Properties.Resources.scroll_run;
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(23, 22);
            toolStripButton1.Text = "toolStripButton1";
            toolStripButton1.Click += toolStripButton1_Click;
            // 
            // cmBarraIconos
            // 
            cmBarraIconos.Name = "cmBarraIconos";
            cmBarraIconos.Size = new Size(61, 4);
            cmBarraIconos.Style = MetroFramework.MetroColorStyle.Orange;
            cmBarraIconos.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // notifyIcon
            // 
            notifyIcon.ContextMenuStrip = cmBarraIconos;
            notifyIcon.Icon = (Icon)resources.GetObject("notifyIcon.Icon");
            notifyIcon.Text = "Compiler";
            notifyIcon.Visible = true;
            notifyIcon.DoubleClick += notifyIcon_DoubleClick;
            // 
            // pTree
            // 
            pTree.Controls.Add(treeProyectos);
            pTree.Controls.Add(tsTree);
            pTree.Dock = DockStyle.Left;
            pTree.HorizontalScrollbarBarColor = true;
            pTree.HorizontalScrollbarHighlightOnWheel = false;
            pTree.HorizontalScrollbarSize = 10;
            pTree.Location = new Point(1, 55);
            pTree.Name = "pTree";
            pTree.Size = new Size(328, 637);
            pTree.TabIndex = 5;
            pTree.VerticalScrollbarBarColor = true;
            pTree.VerticalScrollbarHighlightOnWheel = false;
            pTree.VerticalScrollbarSize = 10;
            // 
            // treeProyectos
            // 
            treeProyectos.CheckBoxes = true;
            treeProyectos.ContextMenuStrip = cmTree;
            treeProyectos.Dock = DockStyle.Fill;
            treeProyectos.ImageIndex = 0;
            treeProyectos.ImageList = iListTree;
            treeProyectos.Location = new Point(0, 25);
            treeProyectos.Name = "treeProyectos";
            treeProyectos.SelectedImageIndex = 0;
            treeProyectos.Size = new Size(328, 612);
            treeProyectos.TabIndex = 3;
            treeProyectos.BeforeCheck += treeProyectos_BeforeCheck;
            treeProyectos.BeforeSelect += treeProyectos_BeforeSelect;
            // 
            // cmTree
            // 
            cmTree.Items.AddRange(new ToolStripItem[] { tsmCopiar, tsmCompilar, tsmCompilarCopiar });
            cmTree.Name = "cmTree";
            cmTree.Size = new Size(171, 70);
            cmTree.Opening += cmTree_Opening;
            // 
            // tsmCopiar
            // 
            tsmCopiar.Image = Properties.Resources.copy;
            tsmCopiar.Name = "tsmCopiar";
            tsmCopiar.Size = new Size(170, 22);
            tsmCopiar.Text = "Copiar";
            tsmCopiar.Click += tsmCopiar_Click;
            // 
            // tsmCompilar
            // 
            tsmCompilar.Enabled = false;
            tsmCompilar.Image = Properties.Resources.compilador;
            tsmCompilar.Name = "tsmCompilar";
            tsmCompilar.Size = new Size(170, 22);
            tsmCompilar.Text = "Compilar";
            tsmCompilar.Click += tsmCompilar_Click;
            // 
            // tsmCompilarCopiar
            // 
            tsmCompilarCopiar.Enabled = false;
            tsmCompilarCopiar.Image = Properties.Resources.compilador__1_;
            tsmCompilarCopiar.Name = "tsmCompilarCopiar";
            tsmCompilarCopiar.Size = new Size(170, 22);
            tsmCompilarCopiar.Text = "Compilar y Copiar";
            tsmCompilarCopiar.Click += tsmCompilarCopiar_Click;
            // 
            // iListTree
            // 
            iListTree.ColorDepth = ColorDepth.Depth8Bit;
            iListTree.ImageStream = (ImageListStreamer)resources.GetObject("iListTree.ImageStream");
            iListTree.TransparentColor = Color.Transparent;
            iListTree.Images.SetKeyName(0, "folder_gear.png");
            iListTree.Images.SetKeyName(1, "window.png");
            iListTree.Images.SetKeyName(2, "scroll_run.png");
            // 
            // tsTree
            // 
            tsTree.Items.AddRange(new ToolStripItem[] { tsbAdd, tsbBorrar });
            tsTree.Location = new Point(0, 0);
            tsTree.Name = "tsTree";
            tsTree.Size = new Size(328, 25);
            tsTree.TabIndex = 2;
            tsTree.Text = "toolStrip2";
            // 
            // tsbAdd
            // 
            tsbAdd.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbAdd.Image = Properties.Resources.folder_add;
            tsbAdd.ImageTransparentColor = Color.Magenta;
            tsbAdd.Name = "tsbAdd";
            tsbAdd.Size = new Size(23, 22);
            tsbAdd.Text = "Añadir";
            // 
            // tsbBorrar
            // 
            tsbBorrar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbBorrar.Image = Properties.Resources.folder_delete;
            tsbBorrar.ImageTransparentColor = Color.Magenta;
            tsbBorrar.Name = "tsbBorrar";
            tsbBorrar.Size = new Size(23, 22);
            tsbBorrar.Text = "toolStripButton2";
            // 
            // txtPS
            // 
            txtPS.Dock = DockStyle.Fill;
            txtPS.Location = new Point(0, 100);
            txtPS.MaxLength = 32767;
            txtPS.Multiline = true;
            txtPS.Name = "txtPS";
            txtPS.PasswordChar = '\0';
            txtPS.ScrollBars = ScrollBars.Both;
            txtPS.SelectedText = "";
            txtPS.Size = new Size(793, 400);
            txtPS.TabIndex = 6;
            txtPS.UseSelectable = true;
            // 
            // txtError
            // 
            txtError.Dock = DockStyle.Fill;
            txtError.ForeColor = Color.Red;
            txtError.Location = new Point(0, 0);
            txtError.MaxLength = 32767;
            txtError.Multiline = true;
            txtError.Name = "txtError";
            txtError.PasswordChar = '\0';
            txtError.ScrollBars = ScrollBars.Both;
            txtError.SelectedText = "";
            txtError.Size = new Size(793, 133);
            txtError.TabIndex = 7;
            txtError.UseSelectable = true;
            // 
            // spSalida
            // 
            spSalida.Dock = DockStyle.Fill;
            spSalida.Location = new Point(329, 55);
            spSalida.Name = "spSalida";
            spSalida.Orientation = Orientation.Horizontal;
            // 
            // spSalida.Panel1
            // 
            spSalida.Panel1.Controls.Add(txtPS);
            spSalida.Panel1.Controls.Add(pProgress);
            // 
            // spSalida.Panel2
            // 
            spSalida.Panel2.Controls.Add(txtError);
            spSalida.Size = new Size(793, 637);
            spSalida.SplitterDistance = 500;
            spSalida.TabIndex = 8;
            // 
            // pProgress
            // 
            pProgress.Controls.Add(progresBar);
            pProgress.Controls.Add(progressSpinner);
            pProgress.Dock = DockStyle.Top;
            pProgress.HorizontalScrollbarBarColor = true;
            pProgress.HorizontalScrollbarHighlightOnWheel = false;
            pProgress.HorizontalScrollbarSize = 10;
            pProgress.Location = new Point(0, 0);
            pProgress.Name = "pProgress";
            pProgress.Size = new Size(793, 100);
            pProgress.TabIndex = 7;
            pProgress.VerticalScrollbarBarColor = true;
            pProgress.VerticalScrollbarHighlightOnWheel = false;
            pProgress.VerticalScrollbarSize = 10;
            // 
            // progresBar
            // 
            progresBar.Dock = DockStyle.Fill;
            progresBar.Location = new Point(0, 0);
            progresBar.Name = "progresBar";
            progresBar.Size = new Size(693, 100);
            progresBar.TabIndex = 2;
            progresBar.Visible = false;
            // 
            // progressSpinner
            // 
            progressSpinner.Dock = DockStyle.Right;
            progressSpinner.Location = new Point(693, 0);
            progressSpinner.Maximum = 100;
            progressSpinner.Name = "progressSpinner";
            progressSpinner.Size = new Size(100, 100);
            progressSpinner.Spinning = false;
            progressSpinner.TabIndex = 3;
            progressSpinner.Text = "metroProgressSpinner1";
            progressSpinner.UseSelectable = true;
            progressSpinner.Value = -1;
            progressSpinner.Visible = false;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1123, 693);
            Controls.Add(spSalida);
            Controls.Add(pTree);
            Controls.Add(tsMain);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmMain";
            Text = "Gestor Compiler";
            TransparencyKey = Color.Empty;
            FormClosing += frmMain_FormClosing;
            Load += frmMain_Load;
            tsMain.ResumeLayout(false);
            tsMain.PerformLayout();
            pTree.ResumeLayout(false);
            pTree.PerformLayout();
            cmTree.ResumeLayout(false);
            tsTree.ResumeLayout(false);
            tsTree.PerformLayout();
            spSalida.Panel1.ResumeLayout(false);
            spSalida.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)spSalida).EndInit();
            spSalida.ResumeLayout(false);
            pProgress.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripDropDownButton toolStripDropDownButton1;
        private ToolStripMenuItem tsmiAplicaciones;
        private ToolStripMenuItem tsmiProyectos;
        private ToolStripMenuItem tsmiArchivosExcluyentes;
        private MetroFramework.Controls.MetroContextMenu cmBarraIconos;
        private NotifyIcon notifyIcon;
        private MetroFramework.Controls.MetroPanel pTree;
        private TreeView treeProyectos;
        private ToolStrip toolStrip2;
        private ToolStripButton tsbAdd;
        private ToolStripButton tsbBorrar;
        private ToolStrip tsMain;
        private ToolStrip tsTree;
        private MetroFramework.Controls.MetroContextMenu cmTree;
        private ToolStripMenuItem tsmCopiar;
        private ToolStripMenuItem tsmCompilar;
        private ToolStripMenuItem tsmCompilarCopiar;
        private ToolStripButton tsbRecargar;
        private MetroFramework.Controls.MetroTextBox txtPS;
        private MetroFramework.Controls.MetroTextBox txtError;
        private SplitContainer spSalida;
        private ToolStripButton toolStripButton1;
        private MetroFramework.Controls.MetroPanel pProgress;
        private MetroFramework.Controls.MetroProgressBar progresBar;
        private MetroFramework.Controls.MetroProgressSpinner progressSpinner;
        private ImageList iListTree;
    }
}
