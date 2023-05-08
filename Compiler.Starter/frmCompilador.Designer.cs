namespace Compiler.Starter
{
    partial class frmCompilador
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbBuscarCarpeta = new System.Windows.Forms.ToolStripButton();
            this.tstCarpeta = new DevToolsNet.WinFormsControlLibrary.ToolStripTextHosted();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tslUser = new System.Windows.Forms.ToolStripLabel();
            this.tstUser = new System.Windows.Forms.ToolStripTextBox();
            this.tslPass = new System.Windows.Forms.ToolStripLabel();
            this.tstPass = new DevToolsNet.WinFormsControlLibrary.ToolStripTextHosted();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbExecute = new System.Windows.Forms.ToolStripButton();
            this.tsbRefresh = new System.Windows.Forms.ToolStripButton();
            this.tsbClear = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeCarpetas = new DevToolsNet.WinFormsControlLibrary.TreeViewTools();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.txtCommand = new System.Windows.Forms.TextBox();
            this.tabResults = new System.Windows.Forms.TabControl();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbBuscarCarpeta,
            this.tstCarpeta,
            this.toolStripSeparator3,
            this.tslUser,
            this.tstUser,
            this.tslPass,
            this.tstPass,
            this.toolStripSeparator1,
            this.tsbExecute,
            this.tsbRefresh,
            this.tsbClear,
            this.toolStripSeparator2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1327, 26);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbBuscarCarpeta
            // 
            this.tsbBuscarCarpeta.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
          //  this.tsbBuscarCarpeta.Image = global::Compiler.Starter.Properties.Resources.folder_add;
            this.tsbBuscarCarpeta.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBuscarCarpeta.Name = "tsbBuscarCarpeta";
            this.tsbBuscarCarpeta.Size = new System.Drawing.Size(23, 23);
            this.tsbBuscarCarpeta.Text = "toolStripButton1";
            this.tsbBuscarCarpeta.Click += new System.EventHandler(this.tsbBuscarCarpeta_Click);
            // 
            // tstCarpeta
            // 
            this.tstCarpeta.AutoSize = false;
            this.tstCarpeta.Name = "tstCarpeta";
            this.tstCarpeta.Size = new System.Drawing.Size(300, 23);
            // 
            // tstCarpeta
            // 
            this.tstCarpeta.TextBox.AccessibleName = "tstCarpeta";
            this.tstCarpeta.TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tstCarpeta.TextBox.Location = new System.Drawing.Point(32, 4);
            this.tstCarpeta.TextBox.Name = "tstPass";
            this.tstCarpeta.TextBox.Size = new System.Drawing.Size(300, 16);
            this.tstCarpeta.TextBox.TabIndex = 1;
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 26);
            // 
            // tslUser
            // 
            this.tslUser.Name = "tslUser";
            this.tslUser.Size = new System.Drawing.Size(33, 23);
            this.tslUser.Text = "User:";
            // 
            // tstUser
            // 
            this.tstUser.AutoSize = false;
            this.tstUser.Name = "tstUser";
            this.tstUser.Size = new System.Drawing.Size(100, 26);
            this.tstUser.ToolTipText = "User";
            // 
            // tslPass
            // 
            this.tslPass.Name = "tslPass";
            this.tslPass.Size = new System.Drawing.Size(55, 23);
            this.tslPass.Text = "Pasword:";
            // 
            // tstPass
            // 
            this.tstPass.AutoSize = false;
            this.tstPass.Name = "tstPass";
            this.tstPass.Size = new System.Drawing.Size(100, 23);
            // 
            // tstPass
            // 
            this.tstPass.TextBox.AccessibleName = "tstPass";
            this.tstPass.TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tstPass.TextBox.Location = new System.Drawing.Point(528, 4);
            this.tstPass.TextBox.Name = "tstPass";
            this.tstPass.TextBox.PasswordChar = '·';
            this.tstPass.TextBox.TabIndex = 1;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 26);
            // 
            // tsbExecute
            // 
            this.tsbExecute.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
          //  this.tsbExecute.Image = global::Compiler.Starter.Properties.Resources.media_play;
            this.tsbExecute.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExecute.Name = "tsbExecute";
            this.tsbExecute.Size = new System.Drawing.Size(23, 23);
            this.tsbExecute.Text = "toolStripButton1";
            this.tsbExecute.Click += new System.EventHandler(this.tsbExecute_Click);
            // 
            // tsbRefresh
            // 
            this.tsbRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
          //  this.tsbRefresh.Image = global::Compiler.Starter.Properties.Resources.refresh;
            this.tsbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRefresh.Name = "tsbRefresh";
            this.tsbRefresh.Size = new System.Drawing.Size(23, 23);
            this.tsbRefresh.Text = "Refresh";
            this.tsbRefresh.ToolTipText = "Refrescar usuario";
            // 
            // tsbClear
            // 
            this.tsbClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
          //  this.tsbClear.Image = global::Compiler.Starter.Properties.Resources.document_new;
            this.tsbClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClear.Name = "tsbClear";
            this.tsbClear.Size = new System.Drawing.Size(23, 23);
            this.tsbClear.Text = "toolStripButton1";
            this.tsbClear.Click += new System.EventHandler(this.tsbClear_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 26);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 26);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeCarpetas);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1327, 657);
            this.splitContainer1.SplitterDistance = 441;
            this.splitContainer1.TabIndex = 1;
            // 
            // treeCarpetas
            // 
            this.treeCarpetas.CheckBoxes = true;
            this.treeCarpetas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeCarpetas.Location = new System.Drawing.Point(0, 0);
            this.treeCarpetas.Name = "treeCarpetas";
            this.treeCarpetas.ShowTools = true;
            this.treeCarpetas.Size = new System.Drawing.Size(441, 657);
            this.treeCarpetas.TabIndex = 0;
            this.treeCarpetas.AfterNodeCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeServers_AfterNodeCheck);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.txtCommand);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tabResults);
            this.splitContainer2.Size = new System.Drawing.Size(882, 657);
            this.splitContainer2.SplitterDistance = 326;
            this.splitContainer2.TabIndex = 1;
            // 
            // txtCommand
            // 
            this.txtCommand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCommand.Location = new System.Drawing.Point(0, 0);
            this.txtCommand.Multiline = true;
            this.txtCommand.Name = "txtCommand";
            this.txtCommand.Size = new System.Drawing.Size(882, 326);
            this.txtCommand.TabIndex = 0;
            // 
            // tabResults
            // 
            this.tabResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabResults.Location = new System.Drawing.Point(0, 0);
            this.tabResults.Name = "tabResults";
            this.tabResults.SelectedIndex = 0;
            this.tabResults.Size = new System.Drawing.Size(882, 327);
            this.tabResults.TabIndex = 1;
            // 
            // frmCompilador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1327, 683);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmCompilador";
            this.Text = "Compilador";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ToolStrip toolStrip1;
        private SplitContainer splitContainer1;
        private ToolStripButton tsbExecute;
        private SplitContainer splitContainer2;
        private TextBox txtCommand;
        private TabControl tabResults;
        private ToolStripLabel tslUser;
        private ToolStripTextBox tstUser;
        private ToolStripLabel tslPass;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton tsbRefresh;
        private DevToolsNet.WinFormsControlLibrary.ToolStripTextHosted tstPass;
        private DevToolsNet.WinFormsControlLibrary.TreeViewTools treeCarpetas;
        private ToolStripButton tsbClear;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton tsbBuscarCarpeta;
        private DevToolsNet.WinFormsControlLibrary.ToolStripTextHosted tstCarpeta;
        private ToolStripSeparator toolStripSeparator3;
    }
}