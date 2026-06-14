namespace Compiler.UI.Controls
{
    partial class cArchivoExclusion
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
            propContenido = new MetroFramework.ControlsPersonalizados.cPropierty();
            btSave = new Button();
            btArchivoConcreto = new Button();
            cboTipoExclusion = new MetroFramework.Controls.MetroComboBox();
            lblTipoExclusion = new MetroFramework.Controls.MetroLabel();
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
            // propContenido
            // 
            propContenido.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            propContenido.label = "Contenido";
            propContenido.Location = new Point(3, 66);
            propContenido.MinimumSize = new Size(110, 47);
            propContenido.Name = "propContenido";
            propContenido.Size = new Size(360, 47);
            propContenido.TabIndex = 1;
            propContenido.text = "";
            propContenido.Theme = MetroFramework.MetroThemeStyle.Light;
            propContenido.UseSelectable = true;
            // 
            // btSave
            // 
            btSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btSave.Image = Properties.Resources.disk_blue;
            btSave.Location = new Point(369, 19);
            btSave.Name = "btSave";
            btSave.Size = new Size(40, 41);
            btSave.TabIndex = 6;
            btSave.UseVisualStyleBackColor = true;
            btSave.Click += btSave_Click;
            // 
            // btArchivoConcreto
            // 
            btArchivoConcreto.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btArchivoConcreto.Image = Properties.Resources.document_view;
            btArchivoConcreto.Location = new Point(369, 69);
            btArchivoConcreto.Name = "btArchivoConcreto";
            btArchivoConcreto.Size = new Size(41, 44);
            btArchivoConcreto.TabIndex = 8;
            btArchivoConcreto.UseVisualStyleBackColor = true;
            btArchivoConcreto.Click += btArchivoConcreto_Click;
            // 
            // cboTipoExclusion
            // 
            cboTipoExclusion.AccessibleRole = AccessibleRole.None;
            cboTipoExclusion.FormattingEnabled = true;
            cboTipoExclusion.ItemHeight = 23;
            cboTipoExclusion.Location = new Point(18, 138);
            cboTipoExclusion.Name = "cboTipoExclusion";
            cboTipoExclusion.Size = new Size(273, 29);
            cboTipoExclusion.TabIndex = 9;
            cboTipoExclusion.Theme = MetroFramework.MetroThemeStyle.Light;
            cboTipoExclusion.UseSelectable = true;
            // 
            // lblTipoExclusion
            // 
            lblTipoExclusion.AutoSize = true;
            lblTipoExclusion.Location = new Point(3, 116);
            lblTipoExclusion.Name = "lblTipoExclusion";
            lblTipoExclusion.Size = new Size(91, 19);
            lblTipoExclusion.TabIndex = 10;
            lblTipoExclusion.Text = "Tipo Exclusion";
            lblTipoExclusion.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // cArchivoExclusion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblTipoExclusion);
            Controls.Add(cboTipoExclusion);
            Controls.Add(btArchivoConcreto);
            Controls.Add(btSave);
            Controls.Add(propContenido);
            Controls.Add(propId);
            MinimumSize = new Size(434, 178);
            Name = "cArchivoExclusion";
            Size = new Size(434, 180);
            Load += cArchivoExclusion_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MetroFramework.ControlsPersonalizados.cPropierty propId;
        private MetroFramework.ControlsPersonalizados.cPropierty propContenido;
        private Button btSave;
        private Button btArchivoConcreto;
        private MetroFramework.Controls.MetroComboBox cboTipoExclusion;
        private MetroFramework.Controls.MetroLabel lblTipoExclusion;
    }
}
