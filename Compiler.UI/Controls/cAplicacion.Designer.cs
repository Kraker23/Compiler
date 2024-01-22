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
            propNombre.label = "Nombre";
            propNombre.Location = new Point(3, 66);
            propNombre.MinimumSize = new Size(110, 47);
            propNombre.Name = "propNombre";
            propNombre.Size = new Size(598, 47);
            propNombre.TabIndex = 1;
            propNombre.text = "";
            propNombre.UseSelectable = true;
            // 
            // propUbicacionAplicacion
            // 
            propUbicacionAplicacion.label = "Ubicacion Aplicacion";
            propUbicacionAplicacion.Location = new Point(3, 119);
            propUbicacionAplicacion.MinimumSize = new Size(110, 47);
            propUbicacionAplicacion.Name = "propUbicacionAplicacion";
            propUbicacionAplicacion.Size = new Size(598, 47);
            propUbicacionAplicacion.TabIndex = 2;
            propUbicacionAplicacion.text = "";
            propUbicacionAplicacion.UseSelectable = true;
            // 
            // propCarpetaCompilado
            // 
            propCarpetaCompilado.label = "Carpeta Compilado";
            propCarpetaCompilado.Location = new Point(3, 172);
            propCarpetaCompilado.MinimumSize = new Size(110, 47);
            propCarpetaCompilado.Name = "propCarpetaCompilado";
            propCarpetaCompilado.Size = new Size(598, 47);
            propCarpetaCompilado.TabIndex = 3;
            propCarpetaCompilado.text = "";
            propCarpetaCompilado.UseSelectable = true;
            // 
            // propCarpetaPublicacion
            // 
            propCarpetaPublicacion.label = "Carpeta Publicacion";
            propCarpetaPublicacion.Location = new Point(3, 225);
            propCarpetaPublicacion.MinimumSize = new Size(110, 47);
            propCarpetaPublicacion.Name = "propCarpetaPublicacion";
            propCarpetaPublicacion.Size = new Size(598, 47);
            propCarpetaPublicacion.TabIndex = 4;
            propCarpetaPublicacion.text = "";
            propCarpetaPublicacion.UseSelectable = true;
            // 
            // propComandoCompilado
            // 
            propComandoCompilado.label = "ComandoCompilado";
            propComandoCompilado.Location = new Point(3, 278);
            propComandoCompilado.MinimumSize = new Size(110, 47);
            propComandoCompilado.Name = "propComandoCompilado";
            propComandoCompilado.Size = new Size(598, 47);
            propComandoCompilado.TabIndex = 5;
            propComandoCompilado.text = "";
            propComandoCompilado.UseSelectable = true;
            // 
            // btSave
            // 
            btSave.Image = Properties.Resources.disk_blue;
            btSave.Location = new Point(516, 19);
            btSave.Name = "btSave";
            btSave.Size = new Size(40, 41);
            btSave.TabIndex = 6;
            btSave.UseVisualStyleBackColor = true;
            btSave.Click += btSave_Click;
            // 
            // cAplicacion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btSave);
            Controls.Add(propComandoCompilado);
            Controls.Add(propCarpetaPublicacion);
            Controls.Add(propCarpetaCompilado);
            Controls.Add(propUbicacionAplicacion);
            Controls.Add(propNombre);
            Controls.Add(propId);
            Name = "cAplicacion";
            Size = new Size(651, 411);
            Load += cAplicacion_Load;
            ResumeLayout(false);
        }

        #endregion

        private MetroFramework.ControlsPersonalizados.cPropierty propUbicacionAplicacion;
        private MetroFramework.ControlsPersonalizados.cPropierty propId;
        private MetroFramework.ControlsPersonalizados.cPropierty propNombre;
        private MetroFramework.ControlsPersonalizados.cPropierty propCarpetaCompilado;
        private MetroFramework.ControlsPersonalizados.cPropierty propCarpetaPublicacion;
        private MetroFramework.ControlsPersonalizados.cPropierty propComandoCompilado;
        private Button btSave;
    }
}
