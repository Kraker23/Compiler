namespace Compiler.UI.Controls
{
    partial class cProyecto
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            propId = new MetroFramework.ControlsPersonalizados.cPropierty();
            propNombre = new MetroFramework.ControlsPersonalizados.cPropierty();
            btSave = new Button();
            treeAplicaciones = new TreeView();
            lblAplicaciones = new MetroFramework.Controls.MetroLabel();
            SuspendLayout();
            // 
            // propId
            // 
            propId.label = "ID";
            propId.Location = new Point(3, 13);
            propId.MinimumSize = new Size(110, 47);
            propId.Name = "propId";
            propId.Size = new Size(361, 47);
            propId.TabIndex = 0;
            propId.text = "";
            propId.UseSelectable = true;
            // 
            // propNombre
            // 
            propNombre.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            propNombre.label = "Nombre";
            propNombre.Location = new Point(3, 66);
            propNombre.MinimumSize = new Size(110, 47);
            propNombre.Name = "propNombre";
            propNombre.Size = new Size(385, 47);
            propNombre.TabIndex = 1;
            propNombre.text = "";
            propNombre.UseSelectable = true;
            // 
            // btSave
            // 
            btSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btSave.Image = Properties.Resources.disk_blue;
            btSave.Location = new Point(371, 19);
            btSave.Name = "btSave";
            btSave.Size = new Size(40, 41);
            btSave.TabIndex = 6;
            btSave.UseVisualStyleBackColor = true;
            btSave.Click += btSave_Click;
            // 
            // treeAplicaciones
            // 
            treeAplicaciones.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            treeAplicaciones.CheckBoxes = true;
            treeAplicaciones.Location = new Point(18, 138);
            treeAplicaciones.Name = "treeAplicaciones";
            treeAplicaciones.Size = new Size(404, 69);
            treeAplicaciones.TabIndex = 11;
            treeAplicaciones.AfterCheck += treeAplicaciones_AfterCheck;
            // 
            // lblAplicaciones
            // 
            lblAplicaciones.AutoSize = true;
            lblAplicaciones.Location = new Point(3, 116);
            lblAplicaciones.Name = "lblAplicaciones";
            lblAplicaciones.Size = new Size(81, 19);
            lblAplicaciones.TabIndex = 12;
            lblAplicaciones.Text = "Aplicaciones";
            // 
            // cProyecto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblAplicaciones);
            Controls.Add(treeAplicaciones);
            Controls.Add(btSave);
            Controls.Add(propNombre);
            Controls.Add(propId);
            MinimumSize = new Size(438, 219);
            Name = "cProyecto";
            Size = new Size(438, 219);
            Load += cProyecto_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MetroFramework.ControlsPersonalizados.cPropierty propId;
        private MetroFramework.ControlsPersonalizados.cPropierty propNombre;
        private Button btSave;
        private TreeView treeAplicaciones;
        private MetroFramework.Controls.MetroLabel lblAplicaciones;
    }
}
