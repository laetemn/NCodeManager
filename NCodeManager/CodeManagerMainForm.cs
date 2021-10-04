using System;
using System.IO;
using System.Windows.Forms;

namespace NCodeManager
{
    public partial class CodeManagerMainForm : Form
    {
        public CodeManagerMainForm()
        {
            InitializeComponent();
        }

        private void OnAboutClick(object sender, EventArgs e)
        {
            var aboutBox = new CodeManagerAboutBox();
            aboutBox.ShowDialog();
        }

        private void OnAddCodeClick(object sender, EventArgs e)
        {
            CodesList.Items.Add(new CheatCode(), true);
        }

        private void OnOpenClick(object sender, EventArgs e)
        {
            CodesList.Items.Clear();
            if (CodeManagerOpenFileDialog.ShowDialog() != DialogResult.OK)
                return;

            Stream stream = null;
            try
            {
                stream = File.OpenRead(CodeManagerOpenFileDialog.FileName);
                CodesList.Items.Add(new CheatCode("Imported GCT Code", stream), true);
            }
            catch (Exception exception)
            {
                MessageBox.Show(string.Format("ERROR: Could not read GCT: {0}", exception.Message));
            }

            if (stream != null)
                stream.Close();
        }

        private void OnCodesListItemSelected(object sender, EventArgs e)
        {
            var cheatCode = (CheatCode)CodesList.SelectedItem;
            if (cheatCode == null)
                return;

            CodeContentsTextBox.Text = cheatCode.InstructionsAsString();
            CodeNameTextBox.Text = cheatCode.Name;
        }

        private void OnSaveCodeClick(object sender, EventArgs e)
        {
            var cheatCode = (CheatCode)CodesList.SelectedItem;
            if (cheatCode == null)
                return;

            CodesList.BeginUpdate();

            try
            {
                cheatCode.Parse(CodeContentsTextBox.Text);
                cheatCode.Name = CodeNameTextBox.Text;
            }
            catch (Exception exception)
            {
                MessageBox.Show(string.Format("ERROR: Invalid code: {0}", exception.Message));
            }

            CodesList.EndUpdate();
        }

        private void OnSaveClick(object sender, EventArgs e)
        {
            if (CodeManagerSaveFileDialog.ShowDialog() != DialogResult.OK)
                return;

            Stream stream = null;
            try
            {
                stream = File.OpenWrite(CodeManagerSaveFileDialog.FileName);
                CheatCode.WriteGCT(stream, CodesList.CheckedItems);
            }
            catch (Exception exception)
            {
                MessageBox.Show(string.Format("ERROR: {0}", exception.Message));
            }

            if (stream != null)
                stream.Close();
        }

        private void OnRemoveCodeClick(object sender, EventArgs e)
        {
            CodesList.Items.Remove(CodesList.SelectedItem);
        }
    }
}
