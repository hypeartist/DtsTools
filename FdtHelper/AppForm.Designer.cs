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
			this.label1 = new System.Windows.Forms.Label();
			this._fbd = new System.Windows.Forms.FolderBrowserDialog();
			this.label2 = new System.Windows.Forms.Label();
			this._txtWorkingDir = new System.Windows.Forms.TextBox();
			this._btnBrowse = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this._txtNodePath = new System.Windows.Forms.TextBox();
			this._btnFormat = new System.Windows.Forms.Button();
			this._rtbOutput = new System.Windows.Forms.RichTextBox();
			this._txtFilesToProcess = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this._txtDumpFile = new System.Windows.Forms.TextBox();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this._txtTarget = new System.Windows.Forms.TextBox();
			this._btnCreateOverlay = new System.Windows.Forms.Button();
			this.label9 = new System.Windows.Forms.Label();
			this._cbSource = new System.Windows.Forms.ComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this._txtWorkingDirB = new System.Windows.Forms.TextBox();
			this._btnBrowseB = new System.Windows.Forms.Button();
			this._txtFilesToProcessB = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this._txtWorkingDirA = new System.Windows.Forms.TextBox();
			this._btnBrowseA = new System.Windows.Forms.Button();
			this._txtFilesToProcessA = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.label10 = new System.Windows.Forms.Label();
			this._txtSaveOverlayTo = new System.Windows.Forms.TextBox();
			this._sfd = new System.Windows.Forms.SaveFileDialog();
			this._btnBrowseOverlay = new System.Windows.Forms.Button();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.SuspendLayout();
			// 
			// _btnDump
			// 
			this._btnDump.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._btnDump.Enabled = false;
			this._btnDump.Location = new System.Drawing.Point(775, 136);
			this._btnDump.Name = "_btnDump";
			this._btnDump.Size = new System.Drawing.Size(75, 23);
			this._btnDump.TabIndex = 0;
			this._btnDump.Text = "Dump";
			this._btnDump.UseVisualStyleBackColor = true;
			this._btnDump.Click += new System.EventHandler(this.On_btnDump_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 39);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(83, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Files to process:";
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
			this.label2.Size = new System.Drawing.Size(61, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "DTS folder:";
			// 
			// _txtWorkingDir
			// 
			this._txtWorkingDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._txtWorkingDir.Location = new System.Drawing.Point(95, 9);
			this._txtWorkingDir.Name = "_txtWorkingDir";
			this._txtWorkingDir.Size = new System.Drawing.Size(674, 20);
			this._txtWorkingDir.TabIndex = 3;
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
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 9);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(60, 13);
			this.label3.TabIndex = 13;
			this.label3.Text = "Node path:";
			// 
			// _txtNodePath
			// 
			this._txtNodePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._txtNodePath.Location = new System.Drawing.Point(72, 6);
			this._txtNodePath.Name = "_txtNodePath";
			this._txtNodePath.Size = new System.Drawing.Size(697, 20);
			this._txtNodePath.TabIndex = 12;
			// 
			// _btnFormat
			// 
			this._btnFormat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._btnFormat.Location = new System.Drawing.Point(775, 4);
			this._btnFormat.Name = "_btnFormat";
			this._btnFormat.Size = new System.Drawing.Size(75, 23);
			this._btnFormat.TabIndex = 11;
			this._btnFormat.Text = "Format";
			this._btnFormat.UseVisualStyleBackColor = true;
			this._btnFormat.Click += new System.EventHandler(this.On_btnFormat_Click);
			// 
			// _rtbOutput
			// 
			this._rtbOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._rtbOutput.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._rtbOutput.Location = new System.Drawing.Point(9, 32);
			this._rtbOutput.Name = "_rtbOutput";
			this._rtbOutput.Size = new System.Drawing.Size(841, 580);
			this._rtbOutput.TabIndex = 10;
			this._rtbOutput.Text = "";
			// 
			// _txtFilesToProcess
			// 
			this._txtFilesToProcess.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._txtFilesToProcess.Location = new System.Drawing.Point(95, 36);
			this._txtFilesToProcess.Multiline = true;
			this._txtFilesToProcess.Name = "_txtFilesToProcess";
			this._txtFilesToProcess.Size = new System.Drawing.Size(674, 96);
			this._txtFilesToProcess.TabIndex = 7;
			this._txtFilesToProcess.TextChanged += new System.EventHandler(this.On_txtFilesToProcess_TextChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 141);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(54, 13);
			this.label4.TabIndex = 9;
			this.label4.Text = "Dump file:";
			// 
			// _txtDumpFile
			// 
			this._txtDumpFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._txtDumpFile.Location = new System.Drawing.Point(95, 138);
			this._txtDumpFile.Name = "_txtDumpFile";
			this._txtDumpFile.Size = new System.Drawing.Size(674, 20);
			this._txtDumpFile.TabIndex = 8;
			this._txtDumpFile.TextChanged += new System.EventHandler(this.On_txtDumpFile_TextChanged);
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(864, 644);
			this.tabControl1.TabIndex = 10;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.label4);
			this.tabPage1.Controls.Add(this._btnDump);
			this.tabPage1.Controls.Add(this._txtWorkingDir);
			this.tabPage1.Controls.Add(this._txtDumpFile);
			this.tabPage1.Controls.Add(this._btnBrowse);
			this.tabPage1.Controls.Add(this._txtFilesToProcess);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(856, 618);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "tabPage1";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this._btnBrowseOverlay);
			this.tabPage2.Controls.Add(this.label10);
			this.tabPage2.Controls.Add(this._txtSaveOverlayTo);
			this.tabPage2.Controls.Add(this._txtTarget);
			this.tabPage2.Controls.Add(this._btnCreateOverlay);
			this.tabPage2.Controls.Add(this.label9);
			this.tabPage2.Controls.Add(this._cbSource);
			this.tabPage2.Controls.Add(this.label7);
			this.tabPage2.Controls.Add(this._txtWorkingDirB);
			this.tabPage2.Controls.Add(this._btnBrowseB);
			this.tabPage2.Controls.Add(this._txtFilesToProcessB);
			this.tabPage2.Controls.Add(this.label8);
			this.tabPage2.Controls.Add(this.label5);
			this.tabPage2.Controls.Add(this._txtWorkingDirA);
			this.tabPage2.Controls.Add(this._btnBrowseA);
			this.tabPage2.Controls.Add(this._txtFilesToProcessA);
			this.tabPage2.Controls.Add(this.label6);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(856, 618);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "tabPage2";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// _txtTarget
			// 
			this._txtTarget.Enabled = false;
			this._txtTarget.Location = new System.Drawing.Point(180, 295);
			this._txtTarget.Name = "_txtTarget";
			this._txtTarget.Size = new System.Drawing.Size(55, 20);
			this._txtTarget.TabIndex = 22;
			// 
			// _btnCreateOverlay
			// 
			this._btnCreateOverlay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._btnCreateOverlay.Location = new System.Drawing.Point(241, 294);
			this._btnCreateOverlay.Name = "_btnCreateOverlay";
			this._btnCreateOverlay.Size = new System.Drawing.Size(96, 23);
			this._btnCreateOverlay.TabIndex = 21;
			this._btnCreateOverlay.Text = "Create overlay";
			this._btnCreateOverlay.UseVisualStyleBackColor = true;
			this._btnCreateOverlay.Click += new System.EventHandler(this.On_btnCreateOverlay_Click);
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(156, 299);
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
			this._cbSource.Location = new System.Drawing.Point(95, 295);
			this._cbSource.Name = "_cbSource";
			this._cbSource.Size = new System.Drawing.Size(55, 21);
			this._cbSource.TabIndex = 19;
			this._cbSource.SelectedIndexChanged += new System.EventHandler(this.On_cbSource_SelectedIndexChanged);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(6, 143);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(71, 13);
			this.label7.TabIndex = 15;
			this.label7.Text = "DTS folder B:";
			// 
			// _txtWorkingDirB
			// 
			this._txtWorkingDirB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._txtWorkingDirB.Location = new System.Drawing.Point(95, 140);
			this._txtWorkingDirB.Name = "_txtWorkingDirB";
			this._txtWorkingDirB.Size = new System.Drawing.Size(674, 20);
			this._txtWorkingDirB.TabIndex = 14;
			// 
			// _btnBrowseB
			// 
			this._btnBrowseB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._btnBrowseB.Location = new System.Drawing.Point(775, 138);
			this._btnBrowseB.Name = "_btnBrowseB";
			this._btnBrowseB.Size = new System.Drawing.Size(75, 23);
			this._btnBrowseB.TabIndex = 16;
			this._btnBrowseB.Text = "Browse";
			this._btnBrowseB.UseVisualStyleBackColor = true;
			this._btnBrowseB.Click += new System.EventHandler(this.On_btnBrowseB_Click);
			// 
			// _txtFilesToProcessB
			// 
			this._txtFilesToProcessB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._txtFilesToProcessB.Location = new System.Drawing.Point(95, 167);
			this._txtFilesToProcessB.Multiline = true;
			this._txtFilesToProcessB.Name = "_txtFilesToProcessB";
			this._txtFilesToProcessB.Size = new System.Drawing.Size(674, 96);
			this._txtFilesToProcessB.TabIndex = 17;
			this._txtFilesToProcessB.TextChanged += new System.EventHandler(this.On_txtFilesToProcessB_TextChanged);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(6, 170);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(83, 13);
			this.label8.TabIndex = 13;
			this.label8.Text = "Files to process:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(6, 12);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(71, 13);
			this.label5.TabIndex = 10;
			this.label5.Text = "DTS folder A:";
			// 
			// _txtWorkingDirA
			// 
			this._txtWorkingDirA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._txtWorkingDirA.Location = new System.Drawing.Point(95, 9);
			this._txtWorkingDirA.Name = "_txtWorkingDirA";
			this._txtWorkingDirA.Size = new System.Drawing.Size(674, 20);
			this._txtWorkingDirA.TabIndex = 9;
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
			// _txtFilesToProcessA
			// 
			this._txtFilesToProcessA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._txtFilesToProcessA.Location = new System.Drawing.Point(95, 36);
			this._txtFilesToProcessA.Multiline = true;
			this._txtFilesToProcessA.Name = "_txtFilesToProcessA";
			this._txtFilesToProcessA.Size = new System.Drawing.Size(674, 96);
			this._txtFilesToProcessA.TabIndex = 12;
			this._txtFilesToProcessA.TextChanged += new System.EventHandler(this.On_txtFilesToProcessA_TextChanged);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(6, 39);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(83, 13);
			this.label6.TabIndex = 8;
			this.label6.Text = "Files to process:";
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this._rtbOutput);
			this.tabPage3.Controls.Add(this._btnFormat);
			this.tabPage3.Controls.Add(this._txtNodePath);
			this.tabPage3.Controls.Add(this.label3);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(856, 618);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "tabPage3";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(6, 272);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(84, 13);
			this.label10.TabIndex = 24;
			this.label10.Text = "Save overlay to:";
			// 
			// _txtSaveOverlayTo
			// 
			this._txtSaveOverlayTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._txtSaveOverlayTo.Enabled = false;
			this._txtSaveOverlayTo.Location = new System.Drawing.Point(95, 269);
			this._txtSaveOverlayTo.Name = "_txtSaveOverlayTo";
			this._txtSaveOverlayTo.Size = new System.Drawing.Size(674, 20);
			this._txtSaveOverlayTo.TabIndex = 23;
			// 
			// _btnBrowseOverlay
			// 
			this._btnBrowseOverlay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._btnBrowseOverlay.Location = new System.Drawing.Point(775, 267);
			this._btnBrowseOverlay.Name = "_btnBrowseOverlay";
			this._btnBrowseOverlay.Size = new System.Drawing.Size(75, 23);
			this._btnBrowseOverlay.TabIndex = 25;
			this._btnBrowseOverlay.Text = "Browse";
			this._btnBrowseOverlay.UseVisualStyleBackColor = true;
			this._btnBrowseOverlay.Click += new System.EventHandler(this.On_btnBrowseOverlay_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(864, 644);
			this.Controls.Add(this.tabControl1);
			this.Name = "Form1";
			this.ShowIcon = false;
			this.Text = "DTS Tool";
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.tabPage3.ResumeLayout(false);
			this.tabPage3.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Button _btnDump;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.FolderBrowserDialog _fbd;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox _txtWorkingDir;
		private System.Windows.Forms.Button _btnBrowse;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox _txtNodePath;
		private System.Windows.Forms.Button _btnFormat;
		private System.Windows.Forms.RichTextBox _rtbOutput;
		private System.Windows.Forms.TextBox _txtFilesToProcess;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox _txtDumpFile;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox _txtWorkingDirB;
		private System.Windows.Forms.Button _btnBrowseB;
		private System.Windows.Forms.TextBox _txtFilesToProcessB;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox _txtWorkingDirA;
		private System.Windows.Forms.Button _btnBrowseA;
		private System.Windows.Forms.TextBox _txtFilesToProcessA;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.ComboBox _cbSource;
		private System.Windows.Forms.Button _btnCreateOverlay;
		private System.Windows.Forms.TextBox _txtTarget;
		private System.Windows.Forms.Button _btnBrowseOverlay;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox _txtSaveOverlayTo;
		private System.Windows.Forms.SaveFileDialog _sfd;
	}
}

