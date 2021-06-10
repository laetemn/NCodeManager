using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            try
            {
                var data = File.OpenRead(CodeManagerOpenFileDialog.FileName);
                CodesList.Items.Add(new CheatCode("Imported GCT Code", data), true);
                data.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(string.Format("ERROR: {0}", exception.Message));
            }
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
                MessageBox.Show(string.Format("ERROR: {0}", exception.Message));
            }

            CodesList.EndUpdate();
        }

        private void OnSaveClick(object sender, EventArgs e)
        {
            if (CodeManagerSaveFileDialog.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                var stream = File.OpenWrite(CodeManagerSaveFileDialog.FileName);
                CheatCode.WriteGCT(stream, CodesList.CheckedItems);
                stream.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(string.Format("ERROR: {0}", exception.Message));
            }
        }

        private void OnRemoveCodeClick(object sender, EventArgs e)
        {
            CodesList.Items.Remove(CodesList.SelectedItem);
        }
    }
}
