using System;
using System.IO;
using System.Windows.Forms;

namespace DtsTools
{
	public partial class AppForm : Form
	{
		public AppForm()
		{
			InitializeComponent();

			_ofd.InitialDirectory = @"d:\7\";

			_txtInitialFile.Text = @"d:\7\whyred-o-oss\sdm636-mtp_wayne.dts";
			_txtInitialFileA.Text = @"d:\7\whyred-o-oss\sdm636-mtp_wayne.dts";
			_txtInitialFileB.Text = @"d:\7\caf-whyred\sdm636-mtp.dts";

			_cbSource.SelectedIndex = 0;
		}

		private void On_btnBrowse_Click(object sender, EventArgs e)
		{
			if (_ofd.ShowDialog() == DialogResult.Cancel || string.IsNullOrEmpty(_ofd.SafeFileName)) return;
			_txtInitialFile.Text = _ofd.FileName;
		}

		private void On_btnBrowseA_Click(object sender, EventArgs e)
		{
			if (_ofd.ShowDialog() == DialogResult.Cancel || string.IsNullOrEmpty(_ofd.SafeFileName)) return;
			_txtInitialFileA.Text = _ofd.FileName;
		}

		private void On_btnBrowseB_Click(object sender, EventArgs e)
		{
			if (_ofd.ShowDialog() == DialogResult.Cancel || string.IsNullOrEmpty(_ofd.SafeFileName)) return;
			_txtInitialFileB.Text = _ofd.FileName;
		}

		private void On_btnDump_Click(object sender, EventArgs e)
		{
			var initialFile = _txtInitialFile.Text;
			var workingFolder = Path.GetDirectoryName(initialFile);
			var (rootNode, processedFiles) = DtsProcessor.Parse(workingFolder, initialFile);
			var contents = rootNode.Dump(_chkPrintNodesPaths.Checked);
			File.WriteAllText($"{initialFile}.lst", string.Join("\n", processedFiles));
			File.WriteAllText($"{initialFile}.dump", contents);

			MessageBox.Show($@"All done!");
		}
		
		private void On_cbSource_SelectedIndexChanged(object sender, EventArgs e)
		{
			_txtTarget.Text = _cbSource.SelectedIndex == 0 ? "B" : "A";
		}

		private void On_btnCreateOverlay_Click(object sender, EventArgs e)
		{
			var initialFileA = _txtInitialFileA.Text;
			var workingFolderA = Path.GetDirectoryName(initialFileA);

			var initialFileB = _txtInitialFileB.Text;
			var workingFolderB = Path.GetDirectoryName(initialFileB);

			var (rootNodeA, _) = DtsProcessor.Parse(workingFolderA, initialFileA);
			var (rootNodeB, _) = DtsProcessor.Parse(workingFolderB, initialFileB);

			var overlay = _cbSource.SelectedIndex == 0 ? rootNodeA.Overlay(rootNodeB) : rootNodeB.Overlay(rootNodeA);
			File.WriteAllText(Path.Combine($"{workingFolderA}", $"{Path.GetFileNameWithoutExtension(initialFileA)}-overlay.dtsi"), overlay);
			MessageBox.Show(@"All done!");
		}
	}
}
