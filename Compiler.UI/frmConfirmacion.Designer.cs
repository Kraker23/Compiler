namespace Compiler.UI
{
    partial class frmConfirmacion
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
            lblInformacion = new MetroFramework.Controls.MetroLabel();
            btOk = new MetroFramework.Controls.MetroButton();
            btCancel = new MetroFramework.Controls.MetroButton();
            SuspendLayout();
            // 
            // lblInformacion
            // 
            lblInformacion.AutoSize = true;
            lblInformacion.Location = new Point(16, 41);
            lblInformacion.Name = "lblInformacion";
            lblInformacion.Size = new Size(79, 19);
            lblInformacion.TabIndex = 1;
            lblInformacion.Text = "Informacion";
            // 
            // btOk
            // 
            btOk.Location = new Point(16, 126);
            btOk.Name = "btOk";
            btOk.Size = new Size(157, 35);
            btOk.TabIndex = 2;
            btOk.Text = "Aceptar";
            btOk.UseSelectable = true;
            btOk.Click += btOk_Click;
            // 
            // btCancel
            // 
            btCancel.Location = new Point(229, 126);
            btCancel.Name = "btCancel";
            btCancel.Size = new Size(157, 35);
            btCancel.TabIndex = 3;
            btCancel.Text = "Cancelar";
            btCancel.UseSelectable = true;
            btCancel.Click += btCancel_Click;
            // 
            // frmConfirmacion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(425, 165);
            Controls.Add(btCancel);
            Controls.Add(btOk);
            Controls.Add(lblInformacion);
            MaximumSize = new Size(425, 165);
            MinimumSize = new Size(425, 165);
            Name = "frmConfirmacion";
            Style = MetroFramework.MetroColorStyle.Green;
            Text = "Confirmacion";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MetroFramework.Controls.MetroLabel lblInformacion;
        private MetroFramework.Controls.MetroButton btOk;
        private MetroFramework.Controls.MetroButton btCancel;
    }
}