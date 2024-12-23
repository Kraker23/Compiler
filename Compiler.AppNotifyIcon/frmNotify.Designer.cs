namespace Compiler.AppNotifyIcon
{
    partial class frmNotify
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNotify));
            notifyIcon = new NotifyIcon(components);
            cmBarraIconos = new ContextMenuStrip(components);
            txtPS = new TextBox();
            progresBar = new ProgressBar();
            button1 = new Button();
            SuspendLayout();
            // 
            // notifyIcon
            // 
            notifyIcon.ContextMenuStrip = cmBarraIconos;
            notifyIcon.Icon = (Icon)resources.GetObject("notifyIcon.Icon");
            notifyIcon.Text = "Compiler";
            notifyIcon.Visible = true;
            notifyIcon.MouseDoubleClick += notifyIcon_MouseDoubleClick;
            // 
            // cmBarraIconos
            // 
            cmBarraIconos.Name = "cmBarraIconos";
            cmBarraIconos.Size = new Size(61, 4);
            // 
            // txtPS
            // 
            txtPS.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtPS.Location = new Point(12, 54);
            txtPS.Multiline = true;
            txtPS.Name = "txtPS";
            txtPS.Size = new Size(776, 384);
            txtPS.TabIndex = 1;
            // 
            // progresBar
            // 
            progresBar.Location = new Point(634, 12);
            progresBar.Name = "progresBar";
            progresBar.Size = new Size(154, 23);
            progresBar.TabIndex = 2;
            progresBar.Visible = false;
            // 
            // button1
            // 
            button1.Location = new Point(23, 12);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 3;
            button1.Text = "testCopiar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // frmNotify
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(progresBar);
            Controls.Add(txtPS);
            Name = "frmNotify";
            Text = "CompilerNotify";
            FormClosing += frmMain_FormClosing;
            Load += frmNotify_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NotifyIcon notifyIcon;
        private ContextMenuStrip cmBarraIconos;
        private TextBox txtPS;
        private ProgressBar progresBar;
        private Button button1;
    }
}
