namespace Compiler.UI
{
    partial class frmCrearNombre
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btOk = new MetroFramework.Controls.MetroButton();
            btCancel = new MetroFramework.Controls.MetroButton();
            propNombre = new MetroFramework.ControlsPersonalizados.cPropierty();
            SuspendLayout();
            // 
            // btOk
            // 
            btOk.Location = new Point(28, 86);
            btOk.Name = "btOk";
            btOk.Size = new Size(157, 35);
            btOk.TabIndex = 2;
            btOk.Text = "Aceptar";
            btOk.UseSelectable = true;
            btOk.Click += btOk_Click;
            // 
            // btCancel
            // 
            btCancel.Location = new Point(236, 86);
            btCancel.Name = "btCancel";
            btCancel.Size = new Size(157, 35);
            btCancel.TabIndex = 3;
            btCancel.Text = "Cancelar";
            btCancel.UseSelectable = true;
            btCancel.Click += btCancel_Click;
            // 
            // propNombre
            // 
            propNombre.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            propNombre.label = "Nombre Carpeta";
            propNombre.Location = new Point(4, 33);
            propNombre.MinimumSize = new Size(110, 47);
            propNombre.Name = "propNombre";
            propNombre.Size = new Size(417, 47);
            propNombre.TabIndex = 4;
            propNombre.text = "";
            propNombre.UseSelectable = true;
            // 
            // frmCrearNombre
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(425, 135);
            Controls.Add(propNombre);
            Controls.Add(btCancel);
            Controls.Add(btOk);
            MaximumSize = new Size(425, 135);
            MinimumSize = new Size(425, 135);
            Name = "frmCrearNombre";
            Style = MetroFramework.MetroColorStyle.Green;
            Text = "Nombre";
            ResumeLayout(false);
        }

        #endregion
        private MetroFramework.Controls.MetroButton btOk;
        private MetroFramework.Controls.MetroButton btCancel;
        private MetroFramework.ControlsPersonalizados.cPropierty propNombre;
    }
}