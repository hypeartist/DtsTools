using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DtsTools
{
	public partial class AppForm : Form
	{
		private string _workingDir;
		private string _workingDirA;
		private string _workingDirB;
		private readonly List<string> _filesToProcess = new List<string>();
		private readonly List<string> _filesToProcessA = new List<string>();
		private readonly List<string> _filesToProcessB = new List<string>();

		public AppForm()
		{
			InitializeComponent();

			_workingDir = _txtWorkingDir.Text = @"d:\7\xiaomi-jasmine\";
			_workingDirA = _txtWorkingDirA.Text = @"d:\7\xiaomi-jasmine\";
			_workingDirB = _txtWorkingDirB.Text = @"d:\7\caf\";
			_txtFilesToProcess.Text = @"sdm660-mtp.dts";
			_txtFilesToProcessA.Text = @"sdm660-mtp.dts";
			_txtFilesToProcessB.Text = @"sdm660-mtp.dts";
			_cbSource.SelectedIndex = 0;
		}

		private void On_btnBrowse_Click(object sender, EventArgs e)
		{
			if (_fbd.ShowDialog() == DialogResult.Cancel) return;
			var path = _fbd.SelectedPath;
			if (string.IsNullOrEmpty(path)) return;

			_workingDir = _txtWorkingDir.Text = _fbd.SelectedPath;
			_txtFilesToProcess.Clear();
			_txtDumpFile.Clear();
		}

				
		private void On_btnBrowseA_Click(object sender, EventArgs e)
		{
			if (_fbd.ShowDialog() == DialogResult.Cancel) return;
			var path = _fbd.SelectedPath;
			if (string.IsNullOrEmpty(path)) return;

			_workingDirA = _txtWorkingDirA.Text = _fbd.SelectedPath;
			_txtFilesToProcessA.Clear();
		}

		private void On_btnBrowseB_Click(object sender, EventArgs e)
		{
			if (_fbd.ShowDialog() == DialogResult.Cancel) return;
			var path = _fbd.SelectedPath;
			if (string.IsNullOrEmpty(path)) return;

			_workingDirB = _txtWorkingDirB.Text = _fbd.SelectedPath;
			_txtFilesToProcessB.Clear();
		}

		private void On_btnDump_Click(object sender, EventArgs e)
		{
			var processedFiles = new List<string>();

			var dump = DtsProcessor.Dump(_workingDir, _filesToProcess.ToArray(), processedFiles);
			if (string.IsNullOrEmpty(dump))
			{
				MessageBox.Show($@"Dumping failed!");
				return;
			}
			File.WriteAllText(Path.Combine(_workingDir, $"{_txtDumpFile.Text}.lst"), string.Join("\n", processedFiles));
			File.WriteAllText(Path.Combine(_workingDir, _txtDumpFile.Text), dump);
			MessageBox.Show($@"All done!");
		}

		private void On_txtFilesToProcess_TextChanged(object sender, EventArgs e)
		{
			_filesToProcess.Clear();
			var files = _txtFilesToProcess.Text.Split(new[] {Environment.NewLine}, StringSplitOptions.None);
			if(files.Length == 0) return;
			for (var i = 0; i < files.Length; i++)
			{
				var file = files[i];
				if (file.EndsWith(".dtb"))
				{
					file = file.Replace(".dtb", ".dts");
				}

				_filesToProcess.Add(file);
			}

			_txtDumpFile.Text = $@"{_filesToProcess[0]}.dmp";
			_btnDump.Enabled = true;
		}
		
		private void On_txtFilesToProcessA_TextChanged(object sender, EventArgs e)
		{
			_filesToProcessA.Clear();
			var files = _txtFilesToProcessA.Text.Split(new[] {Environment.NewLine}, StringSplitOptions.None);
			if(files.Length == 0) return;
			for (var i = 0; i < files.Length; i++)
			{
				var file = files[i];
				if (file.EndsWith(".dtb"))
				{
					file = file.Replace(".dtb", ".dts");
				}

				_filesToProcessA.Add(file);
			}
		}

		private void On_txtFilesToProcessB_TextChanged(object sender, EventArgs e)
		{
			_filesToProcessB.Clear();
			var files = _txtFilesToProcessB.Text.Split(new[] {Environment.NewLine}, StringSplitOptions.None);
			if(files.Length == 0) return;
			for (var i = 0; i < files.Length; i++)
			{
				var file = files[i];
				if (file.EndsWith(".dtb"))
				{
					file = file.Replace(".dtb", ".dts");
				}

				_filesToProcessB.Add(file);
			}
		}

		private void On_txtDumpFile_TextChanged(object sender, EventArgs e)
		{
			_btnDump.Enabled = !string.IsNullOrEmpty(_txtDumpFile.Text);
		}

		private void On_btnFormat_Click(object sender, EventArgs e)
		{
			var path = _txtNodePath.Text;
			if(string.IsNullOrEmpty(path)) return;
			path = Regex.Replace(path, @"/+", "/");
			var crumbs = path.Split('|');
			crumbs[0] = "/";
			var output = "";
			for (var i = 0; i < crumbs.Length; i++)
			{
				var indent = "";
				for (var j = 0; j < i; j++)
				{
					indent += '\t';
				}

				output += $"{indent}{crumbs[i]} {{\n";
			}

			output += '\n';

			for (var i = crumbs.Length - 1; i >= 0 ; i--)
			{
				var indent = "";
				for (var j = 0; j < i; j++)
				{
					indent += '\t';
				}

				output += $"{indent}}};\n";
			}

			_rtbOutput.Text = output;
		}

		private void On_cbSource_SelectedIndexChanged(object sender, EventArgs e)
		{
			_txtTarget.Text = _cbSource.SelectedIndex == 0 ? "B" : "A";
		}

		private void On_btnCreateOverlay_Click(object sender, EventArgs e)
		{
			if(string.IsNullOrEmpty(_txtSaveOverlayTo.Text)) return;

			var dumpA = DtsProcessor.Dump(_workingDirA, _filesToProcessA.ToArray());
			var dumpB = DtsProcessor.Dump(_workingDirB, _filesToProcessB.ToArray());

			var overlay = _cbSource.SelectedIndex == 0 ? dumpA.Overlay(dumpB) : dumpB.Overlay(dumpA);
			File.WriteAllText(_txtSaveOverlayTo.Text, overlay);
			MessageBox.Show(@"All done!");
		}

		private void On_btnBrowseOverlay_Click(object sender, EventArgs e)
		{
			_sfd.InitialDirectory = _cbSource.SelectedIndex == 0 ? _workingDirA : _workingDirB;
			_sfd.FileName = _cbSource.SelectedIndex == 0 ? "dts_overlay_a.dtsi" : "dts_overlay_b.dtsi";
			if(_sfd.ShowDialog() != DialogResult.OK) return;
			var path = _sfd.FileName;
			_txtSaveOverlayTo.Text = path;
		}
	}
}
