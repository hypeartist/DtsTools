namespace DtsTools
{
	partial class AppForm
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
			this._btnDump = new System.Windows.Forms.Button();
			this._fbd = new System.Windows.Forms.FolderBrowserDialog();
			this.label2 = new System.Windows.Forms.Label();
			this._txtInitialFile = new System.Windows.Forms.TextBox();
			this._btnBrowse = new System.Windows.Forms.Button();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this._chkPrintNodesPaths = new System.Windows.Forms.CheckBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.label1 = new System.Windows.Forms.Label();
			this._txtTarget = new System.Windows.Forms.TextBox();
			this._btnCreateOverlay = new System.Windows.Forms.Button();
			this.label9 = new System.Windows.Forms.Label();
			this._cbSource = new System.Windows.Forms.ComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this._txtInitialFileB = new System.Windows.Forms.TextBox();
			this._btnBrowseB = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this._txtInitialFileA = new System.Windows.Forms.TextBox();
			this._btnBrowseA = new System.Windows.Forms.Button();
			this._sfd = new System.Windows.Forms.SaveFileDialog();
			this._ofd = new System.Windows.Forms.OpenFileDialog();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.SuspendLayout();
			// 
			// _btnDump
			// 
			this._btnDump.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._btnDump.Location = new System.Drawing.Point(775, 33);
			this._btnDump.Name = "_btnDump";
			this._btnDump.Size = new System.Drawing.Size(75, 23);
			this._btnDump.TabIndex = 0;
			this._btnDump.Text = "Render";
			this._btnDump.UseVisualStyleBackColor = true;
			this._btnDump.Click += new System.EventHandler(this.On_btnDump_Click);
			// 
			// _fbd
			// 
			this._fbd.RootFolder = System.Environment.SpecialFolder.MyComputer;
			this._fbd.ShowNewFolderButton = false;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 12);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(75, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Initial DTS file:";
			// 
			// _txtInitialFile
			// 
			this._txtInitialFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._txtInitialFile.Location = new System.Drawing.Point(87, 9);
			this._txtInitialFile.Name = "_txtInitialFile";
			this._txtInitialFile.Size = new System.Drawing.Size(682, 20);
			this._txtInitialFile.TabIndex = 3;
			// 
			// _btnBrowse
			// 
			this._btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._btnBrowse.Location = new System.Drawing.Point(775, 7);
			this._btnBrowse.Name = "_btnBrowse";
			this._btnBrowse.Size = new System.Drawing.Size(75, 23);
			this._btnBrowse.TabIndex = 5;
			this._btnBrowse.Text = "Browse";
			this._btnBrowse.UseVisualStyleBackColor = true;
			this._btnBrowse.Click += new System.EventHandler(this.On_btnBrowse_Click);
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(864, 644);
			this.tabControl1.TabIndex = 10;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this._chkPrintNodesPaths);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this._btnDump);
			this.tabPage1.Controls.Add(this._txtInitialFile);
			this.tabPage1.Controls.Add(this._btnBrowse);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(856, 618);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Render DTS";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// _chkPrintNodesPaths
			// 
			this._chkPrintNodesPaths.AutoSize = true;
			this._chkPrintNodesPaths.Checked = true;
			this._chkPrintNodesPaths.CheckState = System.Windows.Forms.CheckState.Checked;
			this._chkPrintNodesPaths.Location = new System.Drawing.Point(87, 37);
			this._chkPrintNodesPaths.Name = "_chkPrintNodesPaths";
			this._chkPrintNodesPaths.Size = new System.Drawing.Size(110, 17);
			this._chkPrintNodesPaths.TabIndex = 6;
			this._chkPrintNodesPaths.Text = "Print nodes\' paths";
			this._chkPrintNodesPaths.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.label1);
			this.tabPage2.Controls.Add(this._txtTarget);
			this.tabPage2.Controls.Add(this._btnCreateOverlay);
			this.tabPage2.Controls.Add(this.label9);
			this.tabPage2.Controls.Add(this._cbSource);
			this.tabPage2.Controls.Add(this.label7);
			this.tabPage2.Controls.Add(this._txtInitialFileB);
			this.tabPage2.Controls.Add(this._btnBrowseB);
			this.tabPage2.Controls.Add(this.label5);
			this.tabPage2.Controls.Add(this._txtInitialFileA);
			this.tabPage2.Controls.Add(this._btnBrowseA);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(856, 618);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Overlay DTS";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 64);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(52, 13);
			this.label1.TabIndex = 23;
			this.label1.Text = "Direction:";
			// 
			// _txtTarget
			// 
			this._txtTarget.Enabled = false;
			this._txtTarget.Location = new System.Drawing.Point(181, 61);
			this._txtTarget.Name = "_txtTarget";
			this._txtTarget.Size = new System.Drawing.Size(55, 20);
			this._txtTarget.TabIndex = 22;
			// 
			// _btnCreateOverlay
			// 
			this._btnCreateOverlay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._btnCreateOverlay.Location = new System.Drawing.Point(775, 59);
			this._btnCreateOverlay.Name = "_btnCreateOverlay";
			this._btnCreateOverlay.Size = new System.Drawing.Size(75, 23);
			this._btnCreateOverlay.TabIndex = 21;
			this._btnCreateOverlay.Text = "Overlay";
			this._btnCreateOverlay.UseVisualStyleBackColor = true;
			this._btnCreateOverlay.Click += new System.EventHandler(this.On_btnCreateOverlay_Click);
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(157, 64);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(19, 13);
			this.label9.TabIndex = 20;
			this.label9.Text = "=>";
			// 
			// _cbSource
			// 
			this._cbSource.FormattingEnabled = true;
			this._cbSource.Items.AddRange(new object[] {
            "A",
            "B"});
			this._cbSource.Location = new System.Drawing.Point(95, 61);
			this._cbSource.Name = "_cbSource";
			this._cbSource.Size = new System.Drawing.Size(55, 21);
			this._cbSource.TabIndex = 19;
			this._cbSource.SelectedIndexChanged += new System.EventHandler(this.On_cbSource_SelectedIndexChanged);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(6, 38);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(85, 13);
			this.label7.TabIndex = 15;
			this.label7.Text = "Initial DTS file B:";
			// 
			// _txtInitialFileB
			// 
			this._txtInitialFileB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._txtInitialFileB.Location = new System.Drawing.Point(95, 35);
			this._txtInitialFileB.Name = "_txtInitialFileB";
			this._txtInitialFileB.Size = new System.Drawing.Size(674, 20);
			this._txtInitialFileB.TabIndex = 14;
			// 
			// _btnBrowseB
			// 
			this._btnBrowseB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._btnBrowseB.Location = new System.Drawing.Point(775, 33);
			this._btnBrowseB.Name = "_btnBrowseB";
			this._btnBrowseB.Size = new System.Drawing.Size(75, 23);
			this._btnBrowseB.TabIndex = 16;
			this._btnBrowseB.Text = "Browse";
			this._btnBrowseB.UseVisualStyleBackColor = true;
			this._btnBrowseB.Click += new System.EventHandler(this.On_btnBrowseB_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(6, 12);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(85, 13);
			this.label5.TabIndex = 10;
			this.label5.Text = "Initial DTS file A:";
			// 
			// _txtInitialFileA
			// 
			this._txtInitialFileA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._txtInitialFileA.Location = new System.Drawing.Point(95, 9);
			this._txtInitialFileA.Name = "_txtInitialFileA";
			this._txtInitialFileA.Size = new System.Drawing.Size(674, 20);
			this._txtInitialFileA.TabIndex = 9;
			// 
			// _btnBrowseA
			// 
			this._btnBrowseA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._btnBrowseA.Location = new System.Drawing.Point(775, 7);
			this._btnBrowseA.Name = "_btnBrowseA";
			this._btnBrowseA.Size = new System.Drawing.Size(75, 23);
			this._btnBrowseA.TabIndex = 11;
			this._btnBrowseA.Text = "Browse";
			this._btnBrowseA.UseVisualStyleBackColor = true;
			this._btnBrowseA.Click += new System.EventHandler(this.On_btnBrowseA_Click);
			// 
			// _ofd
			// 
			this._ofd.DefaultExt = "dts";
			// 
			// AppForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(864, 644);
			this.Controls.Add(this.tabControl1);
			this.Name = "AppForm";
			this.ShowIcon = false;
			this.Text = "DTS Tool";
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Button _btnDump;
		private System.Windows.Forms.FolderBrowserDialog _fbd;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox _txtInitialFile;
		private System.Windows.Forms.Button _btnBrowse;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox _txtInitialFileB;
		private System.Windows.Forms.Button _btnBrowseB;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox _txtInitialFileA;
		private System.Windows.Forms.Button _btnBrowseA;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.ComboBox _cbSource;
		private System.Windows.Forms.Button _btnCreateOverlay;
		private System.Windows.Forms.TextBox _txtTarget;
		private System.Windows.Forms.SaveFileDialog _sfd;
		private System.Windows.Forms.OpenFileDialog _ofd;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox _chkPrintNodesPaths;
	}
}

