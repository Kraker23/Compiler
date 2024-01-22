namespace Compiler.UI
{
    partial class frmConfiguracionArchivosExcluyentes
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
            treeAplicaciones = new TreeView();
            metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(components);
            ((System.ComponentModel.ISupportInitialize)metroStyleManager1).BeginInit();
            SuspendLayout();
            // 
            // treeAplicaciones
            // 
            treeAplicaciones.Location = new Point(4, 33);
            treeAplicaciones.Name = "treeAplicaciones";
            treeAplicaciones.Size = new Size(271, 413);
            treeAplicaciones.TabIndex = 0;
            // 
            // metroStyleManager1
            // 
            metroStyleManager1.Owner = this;
            metroStyleManager1.Style = MetroFramework.MetroColorStyle.Red;
            metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // frmConfiguracionArchivosExcluyentes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            ClientSize = new Size(800, 450);
            Controls.Add(treeAplicaciones);
            Name = "frmConfiguracionArchivosExcluyentes";
            Style = MetroFramework.MetroColorStyle.Red;
            Text = "Archivos Excluyentes";
            Load += frmConfiguracionArchivosExcluyentes_Load;
            ((System.ComponentModel.ISupportInitialize)metroStyleManager1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TreeView treeAplicaciones;
        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
    }
}
