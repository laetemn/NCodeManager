
namespace NCodeManager
{
    partial class CodeManagerMainForm
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
            this.CodeManagerMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeSelectedCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSelectedCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CodesList = new System.Windows.Forms.CheckedListBox();
            this.CodesLabel = new System.Windows.Forms.Label();
            this.CodeContentsLabel = new System.Windows.Forms.Label();
            this.CodeContentsTextBox = new System.Windows.Forms.TextBox();
            this.CodeNameLabel = new System.Windows.Forms.Label();
            this.CodeNameTextBox = new System.Windows.Forms.TextBox();
            this.CodeManagerOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.CodeManagerSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.CodeManagerMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // CodeManagerMenu
            // 
            this.CodeManagerMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.CodeManagerMenu.Location = new System.Drawing.Point(0, 0);
            this.CodeManagerMenu.Name = "CodeManagerMenu";
            this.CodeManagerMenu.Size = new System.Drawing.Size(624, 24);
            this.CodeManagerMenu.TabIndex = 0;
            this.CodeManagerMenu.Text = "CodeManagerMenu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OnOpenClick);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.OnSaveClick);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewCodeToolStripMenuItem,
            this.removeSelectedCodeToolStripMenuItem,
            this.saveSelectedCodeToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // addNewCodeToolStripMenuItem
            // 
            this.addNewCodeToolStripMenuItem.Name = "addNewCodeToolStripMenuItem";
            this.addNewCodeToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.addNewCodeToolStripMenuItem.Text = "Add New Code";
            this.addNewCodeToolStripMenuItem.Click += new System.EventHandler(this.OnAddCodeClick);
            // 
            // removeSelectedCodeToolStripMenuItem
            // 
            this.removeSelectedCodeToolStripMenuItem.Name = "removeSelectedCodeToolStripMenuItem";
            this.removeSelectedCodeToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.removeSelectedCodeToolStripMenuItem.Text = "Remove Selected Code";
            this.removeSelectedCodeToolStripMenuItem.Click += new System.EventHandler(this.OnRemoveCodeClick);
            // 
            // saveSelectedCodeToolStripMenuItem
            // 
            this.saveSelectedCodeToolStripMenuItem.Name = "saveSelectedCodeToolStripMenuItem";
            this.saveSelectedCodeToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.saveSelectedCodeToolStripMenuItem.Text = "Save Selected Code";
            this.saveSelectedCodeToolStripMenuItem.Click += new System.EventHandler(this.OnSaveCodeClick);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.OnAboutClick);
            // 
            // CodesList
            // 
            this.CodesList.FormattingEnabled = true;
            this.CodesList.Location = new System.Drawing.Point(12, 40);
            this.CodesList.Name = "CodesList";
            this.CodesList.Size = new System.Drawing.Size(210, 394);
            this.CodesList.TabIndex = 1;
            this.CodesList.SelectedIndexChanged += new System.EventHandler(this.OnCodesListItemSelected);
            // 
            // CodesLabel
            // 
            this.CodesLabel.AutoSize = true;
            this.CodesLabel.Location = new System.Drawing.Point(12, 24);
            this.CodesLabel.Name = "CodesLabel";
            this.CodesLabel.Size = new System.Drawing.Size(37, 13);
            this.CodesLabel.TabIndex = 2;
            this.CodesLabel.Text = "Codes";
            // 
            // CodeContentsLabel
            // 
            this.CodeContentsLabel.AutoSize = true;
            this.CodeContentsLabel.Location = new System.Drawing.Point(228, 63);
            this.CodeContentsLabel.Name = "CodeContentsLabel";
            this.CodeContentsLabel.Size = new System.Drawing.Size(77, 13);
            this.CodeContentsLabel.TabIndex = 3;
            this.CodeContentsLabel.Text = "Code Contents";
            // 
            // CodeContentsTextBox
            // 
            this.CodeContentsTextBox.Location = new System.Drawing.Point(228, 79);
            this.CodeContentsTextBox.Multiline = true;
            this.CodeContentsTextBox.Name = "CodeContentsTextBox";
            this.CodeContentsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.CodeContentsTextBox.Size = new System.Drawing.Size(384, 355);
            this.CodeContentsTextBox.TabIndex = 4;
            // 
            // CodeNameLabel
            // 
            this.CodeNameLabel.AutoSize = true;
            this.CodeNameLabel.Location = new System.Drawing.Point(228, 24);
            this.CodeNameLabel.Name = "CodeNameLabel";
            this.CodeNameLabel.Size = new System.Drawing.Size(63, 13);
            this.CodeNameLabel.TabIndex = 5;
            this.CodeNameLabel.Text = "Code Name";
            // 
            // CodeNameTextBox
            // 
            this.CodeNameTextBox.Location = new System.Drawing.Point(228, 40);
            this.CodeNameTextBox.Name = "CodeNameTextBox";
            this.CodeNameTextBox.Size = new System.Drawing.Size(384, 20);
            this.CodeNameTextBox.TabIndex = 6;
            // 
            // CodeManagerOpenFileDialog
            // 
            this.CodeManagerOpenFileDialog.Filter = "GCT File | *.gct";
            // 
            // CodeManagerSaveFileDialog
            // 
            this.CodeManagerSaveFileDialog.Filter = "GCT File | *.gct";
            // 
            // CodeManagerMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.CodeNameTextBox);
            this.Controls.Add(this.CodeNameLabel);
            this.Controls.Add(this.CodeContentsTextBox);
            this.Controls.Add(this.CodeContentsLabel);
            this.Controls.Add(this.CodesLabel);
            this.Controls.Add(this.CodesList);
            this.Controls.Add(this.CodeManagerMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.CodeManagerMenu;
            this.MaximizeBox = false;
            this.Name = "CodeManagerMainForm";
            this.ShowIcon = false;
            this.Text = "NCodeManager";
            this.CodeManagerMenu.ResumeLayout(false);
            this.CodeManagerMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip CodeManagerMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.CheckedListBox CodesList;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewCodeToolStripMenuItem;
        private System.Windows.Forms.Label CodesLabel;
        private System.Windows.Forms.Label CodeContentsLabel;
        private System.Windows.Forms.TextBox CodeContentsTextBox;
        private System.Windows.Forms.Label CodeNameLabel;
        private System.Windows.Forms.TextBox CodeNameTextBox;
        private System.Windows.Forms.ToolStripMenuItem removeSelectedCodeToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog CodeManagerOpenFileDialog;
        private System.Windows.Forms.SaveFileDialog CodeManagerSaveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem saveSelectedCodeToolStripMenuItem;
    }
}

