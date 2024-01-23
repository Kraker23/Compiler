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
            toolStrip1 = new ToolStrip();
            toolStripDropDownButton1 = new ToolStripDropDownButton();
            tsmiAplicaciones = new ToolStripMenuItem();
            tsmiProyectos = new ToolStripMenuItem();
            tsmiArchivosExcluyentes = new ToolStripMenuItem();
            cmBarraIconos = new MetroFramework.Controls.MetroContextMenu(components);
            notifyIcon = new NotifyIcon(components);
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripDropDownButton1 });
            toolStrip1.Location = new Point(1, 30);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1121, 25);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
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
            // cmBarraIconos
            // 
            cmBarraIconos.Name = "cmBarraIconos";
            cmBarraIconos.Size = new Size(181, 26);
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
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1123, 693);
            Controls.Add(toolStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmMain";
            Text = "Gestor Compiler";
            TransparencyKey = Color.Empty;
            FormClosing += frmMain_FormClosing;
            Load += frmMain_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
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
    }
}
