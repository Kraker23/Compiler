namespace Compiler.UI.Controls
{
    partial class cAplicacion
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
            propUbicacionAplicacion = new MetroFramework.ControlsPersonalizados.cPropierty();
            propCarpetaCompilado = new MetroFramework.ControlsPersonalizados.cPropierty();
            propCarpetaPublicacion = new MetroFramework.ControlsPersonalizados.cPropierty();
            propComandoCompilado = new MetroFramework.ControlsPersonalizados.cPropierty();
            btSave = new Button();
            btUbicacionAplicacion = new Button();
            btCarpetaCompilado = new Button();
            btCarpetaPublicacion = new Button();
            treeArchivos = new TreeView();
            lblArchivos = new MetroFramework.Controls.MetroLabel();
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
            // propUbicacionAplicacion
            // 
            propUbicacionAplicacion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            propUbicacionAplicacion.label = "Ubicacion Aplicacion";
            propUbicacionAplicacion.Location = new Point(3, 119);
            propUbicacionAplicacion.MinimumSize = new Size(110, 47);
            propUbicacionAplicacion.Name = "propUbicacionAplicacion";
            propUbicacionAplicacion.Size = new Size(385, 47);
            propUbicacionAplicacion.TabIndex = 2;
            propUbicacionAplicacion.text = "";
            propUbicacionAplicacion.UseSelectable = true;
            // 
            // propCarpetaCompilado
            // 
            propCarpetaCompilado.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            propCarpetaCompilado.label = "Carpeta Compilado";
            propCarpetaCompilado.Location = new Point(3, 172);
            propCarpetaCompilado.MinimumSize = new Size(110, 47);
            propCarpetaCompilado.Name = "propCarpetaCompilado";
            propCarpetaCompilado.Size = new Size(385, 47);
            propCarpetaCompilado.TabIndex = 3;
            propCarpetaCompilado.text = "";
            propCarpetaCompilado.UseSelectable = true;
            // 
            // propCarpetaPublicacion
            // 
            propCarpetaPublicacion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            propCarpetaPublicacion.label = "Carpeta Publicacion";
            propCarpetaPublicacion.Location = new Point(3, 225);
            propCarpetaPublicacion.MinimumSize = new Size(110, 47);
            propCarpetaPublicacion.Name = "propCarpetaPublicacion";
            propCarpetaPublicacion.Size = new Size(385, 47);
            propCarpetaPublicacion.TabIndex = 4;
            propCarpetaPublicacion.text = "";
            propCarpetaPublicacion.UseSelectable = true;
            // 
            // propComandoCompilado
            // 
            propComandoCompilado.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            propComandoCompilado.label = "Comando Compilado";
            propComandoCompilado.Location = new Point(3, 278);
            propComandoCompilado.MinimumSize = new Size(110, 47);
            propComandoCompilado.Name = "propComandoCompilado";
            propComandoCompilado.Size = new Size(385, 47);
            propComandoCompilado.TabIndex = 5;
            propComandoCompilado.text = "";
            propComandoCompilado.UseSelectable = true;
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
            // btUbicacionAplicacion
            // 
            btUbicacionAplicacion.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btUbicacionAplicacion.Image = Properties.Resources.folder_view;
            btUbicacionAplicacion.Location = new Point(393, 129);
            btUbicacionAplicacion.Name = "btUbicacionAplicacion";
            btUbicacionAplicacion.Size = new Size(41, 37);
            btUbicacionAplicacion.TabIndex = 8;
            btUbicacionAplicacion.UseVisualStyleBackColor = true;
            btUbicacionAplicacion.Click += btUbicacionAplicacion_Click;
            // 
            // btCarpetaCompilado
            // 
            btCarpetaCompilado.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btCarpetaCompilado.Image = Properties.Resources.folder_view;
            btCarpetaCompilado.Location = new Point(393, 182);
            btCarpetaCompilado.Name = "btCarpetaCompilado";
            btCarpetaCompilado.Size = new Size(41, 37);
            btCarpetaCompilado.TabIndex = 9;
            btCarpetaCompilado.UseVisualStyleBackColor = true;
            btCarpetaCompilado.Click += btCarpetaCompilado_Click;
            // 
            // btCarpetaPublicacion
            // 
            btCarpetaPublicacion.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btCarpetaPublicacion.Image = Properties.Resources.folder_view;
            btCarpetaPublicacion.Location = new Point(393, 235);
            btCarpetaPublicacion.Name = "btCarpetaPublicacion";
            btCarpetaPublicacion.Size = new Size(41, 37);
            btCarpetaPublicacion.TabIndex = 10;
            btCarpetaPublicacion.UseVisualStyleBackColor = true;
            btCarpetaPublicacion.Click += btCarpetaPublicacion_Click;
            // 
            // treeArchivos
            // 
            treeArchivos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            treeArchivos.CheckBoxes = true;
            treeArchivos.Location = new Point(18, 350);
            treeArchivos.Name = "treeArchivos";
            treeArchivos.Size = new Size(404, 87);
            treeArchivos.TabIndex = 11;
            treeArchivos.AfterCheck += treeArchivos_AfterCheck;
            // 
            // lblArchivos
            // 
            lblArchivos.AutoSize = true;
            lblArchivos.Location = new Point(3, 328);
            lblArchivos.Name = "lblArchivos";
            lblArchivos.Size = new Size(115, 19);
            lblArchivos.TabIndex = 12;
            lblArchivos.Text = "Archivos Excluidos";
            // 
            // cAplicacion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblArchivos);
            Controls.Add(treeArchivos);
            Controls.Add(btCarpetaPublicacion);
            Controls.Add(btCarpetaCompilado);
            Controls.Add(btUbicacionAplicacion);
            Controls.Add(btSave);
            Controls.Add(propComandoCompilado);
            Controls.Add(propCarpetaPublicacion);
            Controls.Add(propCarpetaCompilado);
            Controls.Add(propUbicacionAplicacion);
            Controls.Add(propNombre);
            Controls.Add(propId);
            MinimumSize = new Size(438, 450);
            Name = "cAplicacion";
            Size = new Size(438, 450);
            Load += cAplicacion_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MetroFramework.ControlsPersonalizados.cPropierty propUbicacionAplicacion;
        private MetroFramework.ControlsPersonalizados.cPropierty propId;
        private MetroFramework.ControlsPersonalizados.cPropierty propNombre;
        private MetroFramework.ControlsPersonalizados.cPropierty propCarpetaCompilado;
        private MetroFramework.ControlsPersonalizados.cPropierty propCarpetaPublicacion;
        private MetroFramework.ControlsPersonalizados.cPropierty propComandoCompilado;
        private Button btSave;
        private Button btUbicacionAplicacion;
        private Button btCarpetaCompilado;
        private Button btCarpetaPublicacion;
        private TreeView treeArchivos;
        private MetroFramework.Controls.MetroLabel lblArchivos;
    }
}
