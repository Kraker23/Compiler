namespace Compiler.UI
{
    partial class frmConfiguracionAplicaciones
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
            splitter1 = new Splitter();
            metroPanel1 = new MetroFramework.Controls.MetroPanel();
            treeAplicaciones = new TreeView();
            toolStrip1 = new ToolStrip();
            tsbAdd = new ToolStripButton();
            tsbDuplicar = new ToolStripButton();
            tsbBorrar = new ToolStripButton();
            pAplicacion = new MetroFramework.Controls.MetroPanel();
            metroPanel1.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // splitter1
            // 
            splitter1.Location = new Point(1, 30);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(3, 536);
            splitter1.TabIndex = 1;
            splitter1.TabStop = false;
            // 
            // metroPanel1
            // 
            metroPanel1.Controls.Add(treeAplicaciones);
            metroPanel1.Controls.Add(toolStrip1);
            metroPanel1.Dock = DockStyle.Left;
            metroPanel1.HorizontalScrollbarBarColor = true;
            metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            metroPanel1.HorizontalScrollbarSize = 10;
            metroPanel1.Location = new Point(4, 30);
            metroPanel1.Name = "metroPanel1";
            metroPanel1.Size = new Size(328, 536);
            metroPanel1.TabIndex = 3;
            metroPanel1.VerticalScrollbarBarColor = true;
            metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            metroPanel1.VerticalScrollbarSize = 10;
            // 
            // treeAplicaciones
            // 
            treeAplicaciones.Dock = DockStyle.Fill;
            treeAplicaciones.Location = new Point(0, 25);
            treeAplicaciones.Name = "treeAplicaciones";
            treeAplicaciones.Size = new Size(328, 511);
            treeAplicaciones.TabIndex = 3;
            treeAplicaciones.AfterSelect += treeAplicaciones_AfterSelect;
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { tsbAdd, tsbDuplicar, tsbBorrar });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(328, 25);
            toolStrip1.TabIndex = 2;
            toolStrip1.Text = "toolStrip1";
            // 
            // tsbAdd
            // 
            tsbAdd.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbAdd.Image = Properties.Resources.window_add;
            tsbAdd.ImageTransparentColor = Color.Magenta;
            tsbAdd.Name = "tsbAdd";
            tsbAdd.Size = new Size(23, 22);
            tsbAdd.Text = "Añadir";
            tsbAdd.Click += tsbAdd_Click;
            // 
            // tsbDuplicar
            // 
            tsbDuplicar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbDuplicar.Image = Properties.Resources.windows;
            tsbDuplicar.ImageTransparentColor = Color.Magenta;
            tsbDuplicar.Name = "tsbDuplicar";
            tsbDuplicar.Size = new Size(23, 22);
            tsbDuplicar.Text = "Duplicar";
            tsbDuplicar.Click += tsbDuplicar_Click;
            // 
            // tsbBorrar
            // 
            tsbBorrar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbBorrar.Image = Properties.Resources.window_delete;
            tsbBorrar.ImageTransparentColor = Color.Magenta;
            tsbBorrar.Name = "tsbBorrar";
            tsbBorrar.Size = new Size(23, 22);
            tsbBorrar.Text = "toolStripButton2";
            tsbBorrar.Click += tsbBorrar_Click;
            // 
            // pAplicacion
            // 
            pAplicacion.Dock = DockStyle.Fill;
            pAplicacion.HorizontalScrollbarBarColor = true;
            pAplicacion.HorizontalScrollbarHighlightOnWheel = false;
            pAplicacion.HorizontalScrollbarSize = 10;
            pAplicacion.Location = new Point(332, 30);
            pAplicacion.Name = "pAplicacion";
            pAplicacion.Size = new Size(698, 536);
            pAplicacion.TabIndex = 4;
            pAplicacion.VerticalScrollbarBarColor = true;
            pAplicacion.VerticalScrollbarHighlightOnWheel = false;
            pAplicacion.VerticalScrollbarSize = 10;
            // 
            // frmConfiguracionAplicaciones
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1031, 567);
            Controls.Add(pAplicacion);
            Controls.Add(metroPanel1);
            Controls.Add(splitter1);
            Name = "frmConfiguracionAplicaciones";
            Style = MetroFramework.MetroColorStyle.Red;
            Text = "Aplicaciones";
            Theme = MetroFramework.MetroThemeStyle.Dark;
            Load += frmConfiguracionAplicaciones_Load;
            metroPanel1.ResumeLayout(false);
            metroPanel1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private TreeView treeAplicaciones;
        private ToolStrip toolStrip1;
        private Splitter splitter1;
        private ToolStripButton tsbAdd;
        private ToolStripButton tsbBorrar;
        private ToolStripButton tsbDuplicar;
        private MetroFramework.Controls.MetroPanel pAplicacion;
    }
}
