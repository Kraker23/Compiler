namespace Compiler.UI
{
    partial class frmConfiguracionProyectos
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
            metroPanel1 = new MetroFramework.Controls.MetroPanel();
            treeProyectos = new TreeView();
            toolStrip1 = new ToolStrip();
            tsbAdd = new ToolStripButton();
            tsbBorrar = new ToolStripButton();
            pProyecto = new MetroFramework.Controls.MetroPanel();
            metroPanel1.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // metroPanel1
            // 
            metroPanel1.Controls.Add(treeProyectos);
            metroPanel1.Controls.Add(toolStrip1);
            metroPanel1.Dock = DockStyle.Left;
            metroPanel1.HorizontalScrollbarBarColor = true;
            metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            metroPanel1.HorizontalScrollbarSize = 10;
            metroPanel1.Location = new Point(1, 30);
            metroPanel1.Name = "metroPanel1";
            metroPanel1.Size = new Size(328, 419);
            metroPanel1.TabIndex = 4;
            metroPanel1.VerticalScrollbarBarColor = true;
            metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            metroPanel1.VerticalScrollbarSize = 10;
            // 
            // treeProyectos
            // 
            treeProyectos.Dock = DockStyle.Fill;
            treeProyectos.Location = new Point(0, 25);
            treeProyectos.Name = "treeProyectos";
            treeProyectos.Size = new Size(328, 394);
            treeProyectos.TabIndex = 3;
            treeProyectos.AfterSelect += treeProyectos_AfterSelect;
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { tsbAdd, tsbBorrar });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(328, 25);
            toolStrip1.TabIndex = 2;
            toolStrip1.Text = "toolStrip1";
            // 
            // tsbAdd
            // 
            tsbAdd.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbAdd.Image = Properties.Resources.folder_add;
            tsbAdd.ImageTransparentColor = Color.Magenta;
            tsbAdd.Name = "tsbAdd";
            tsbAdd.Size = new Size(23, 22);
            tsbAdd.Text = "Añadir";
            tsbAdd.Click += tsbAdd_Click;
            // 
            // tsbBorrar
            // 
            tsbBorrar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbBorrar.Image = Properties.Resources.folder_delete;
            tsbBorrar.ImageTransparentColor = Color.Magenta;
            tsbBorrar.Name = "tsbBorrar";
            tsbBorrar.Size = new Size(23, 22);
            tsbBorrar.Text = "toolStripButton2";
            tsbBorrar.Click += tsbBorrar_Click;
            // 
            // pProyecto
            // 
            pProyecto.Dock = DockStyle.Fill;
            pProyecto.HorizontalScrollbarBarColor = true;
            pProyecto.HorizontalScrollbarHighlightOnWheel = false;
            pProyecto.HorizontalScrollbarSize = 10;
            pProyecto.Location = new Point(329, 30);
            pProyecto.Name = "pProyecto";
            pProyecto.Size = new Size(470, 419);
            pProyecto.TabIndex = 5;
            pProyecto.VerticalScrollbarBarColor = true;
            pProyecto.VerticalScrollbarHighlightOnWheel = false;
            pProyecto.VerticalScrollbarSize = 10;
            // 
            // frmConfiguracionProyectos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pProyecto);
            Controls.Add(metroPanel1);
            Name = "frmConfiguracionProyectos";
            Style = MetroFramework.MetroColorStyle.Red;
            Text = "Proyectos";
            Load += frmConfiguracionProyectos_Load;
            metroPanel1.ResumeLayout(false);
            metroPanel1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private TreeView treeProyectos;
        private ToolStrip toolStrip1;
        private ToolStripButton tsbAdd;
        private ToolStripButton tsbBorrar;
        private MetroFramework.Controls.MetroPanel pProyecto;
    }
}
