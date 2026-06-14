namespace Compiler.UI
{
    partial class frmProgress
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
            progressSpinner = new MetroFramework.Controls.MetroProgressSpinner();
            lblProgress = new Label();
            SuspendLayout();
            // 
            // progressSpinner
            // 
            progressSpinner.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            progressSpinner.Location = new Point(0, 0);
            progressSpinner.Maximum = 100;
            progressSpinner.Name = "progressSpinner";
            progressSpinner.Size = new Size(100, 100);
            progressSpinner.Spinning = false;
            progressSpinner.TabIndex = 4;
            progressSpinner.Text = "metroProgressSpinner1";
            progressSpinner.UseSelectable = true;
            progressSpinner.Value = -1;
            progressSpinner.Visible = false;
            // 
            // lblProgress
            // 
            lblProgress.AutoSize = true;
            lblProgress.Location = new Point(20, 41);
            lblProgress.Name = "lblProgress";
            lblProgress.Size = new Size(60, 15);
            lblProgress.TabIndex = 5;
            lblProgress.Text = "5000/5000";
            // 
            // frmProgress
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(100, 100);
            Controls.Add(lblProgress);
            Controls.Add(progressSpinner);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmProgress";
            Text = "frmProgress";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MetroFramework.Controls.MetroProgressSpinner progressSpinner;
        private Label lblProgress;
    }
}