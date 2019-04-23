namespace ResxTranslator
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.mySearchPatternCheckBox = new System.Windows.Forms.CheckBox();
            this.myCancelButton = new System.Windows.Forms.Button();
            this.mySelectAllResxFileCheckBox = new System.Windows.Forms.CheckBox();
            this.myTotalProgressLabel = new System.Windows.Forms.Label();
            this.myTotalProgressBar = new System.Windows.Forms.ProgressBar();
            this.myStartButton = new System.Windows.Forms.Button();
            this.myResxFilesCheckedBox = new System.Windows.Forms.CheckedListBox();
            this.myBrowseButton = new System.Windows.Forms.Button();
            this.myResxPathRadioButton = new System.Windows.Forms.RadioButton();
            this.myResxOnlyRadioButton = new System.Windows.Forms.RadioButton();
            this.myPathTextBox = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.myTargetLanguageLabel = new System.Windows.Forms.Label();
            this.mySelectAllCheckBox = new System.Windows.Forms.CheckBox();
            this.myLanguageCheckedBox = new System.Windows.Forms.CheckedListBox();
            this.myStatusStrip = new System.Windows.Forms.StatusStrip();
            this.myToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.myStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.mySearchPatternCheckBox);
            this.tabPage1.Controls.Add(this.myCancelButton);
            this.tabPage1.Controls.Add(this.mySelectAllResxFileCheckBox);
            this.tabPage1.Controls.Add(this.myTotalProgressLabel);
            this.tabPage1.Controls.Add(this.myTotalProgressBar);
            this.tabPage1.Controls.Add(this.myStartButton);
            this.tabPage1.Controls.Add(this.myResxFilesCheckedBox);
            this.tabPage1.Controls.Add(this.myBrowseButton);
            this.tabPage1.Controls.Add(this.myResxPathRadioButton);
            this.tabPage1.Controls.Add(this.myResxOnlyRadioButton);
            this.tabPage1.Controls.Add(this.myPathTextBox);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // mySearchPatternCheckBox
            // 
            resources.ApplyResources(this.mySearchPatternCheckBox, "mySearchPatternCheckBox");
            this.mySearchPatternCheckBox.Name = "mySearchPatternCheckBox";
            this.mySearchPatternCheckBox.UseVisualStyleBackColor = true;
            this.mySearchPatternCheckBox.CheckedChanged += new System.EventHandler(this.mySearchPatternCheckBox_CheckedChanged);
            // 
            // myCancelButton
            // 
            resources.ApplyResources(this.myCancelButton, "myCancelButton");
            this.myCancelButton.Name = "myCancelButton";
            this.myCancelButton.UseVisualStyleBackColor = true;
            this.myCancelButton.Click += new System.EventHandler(this.myCancelButton_Click);
            // 
            // mySelectAllResxFileCheckBox
            // 
            resources.ApplyResources(this.mySelectAllResxFileCheckBox, "mySelectAllResxFileCheckBox");
            this.mySelectAllResxFileCheckBox.Name = "mySelectAllResxFileCheckBox";
            this.mySelectAllResxFileCheckBox.UseVisualStyleBackColor = true;
            this.mySelectAllResxFileCheckBox.CheckedChanged += new System.EventHandler(this.mySelectAllResxFileCheckBox_CheckedChanged);
            // 
            // myTotalProgressLabel
            // 
            resources.ApplyResources(this.myTotalProgressLabel, "myTotalProgressLabel");
            this.myTotalProgressLabel.Name = "myTotalProgressLabel";
            // 
            // myTotalProgressBar
            // 
            resources.ApplyResources(this.myTotalProgressBar, "myTotalProgressBar");
            this.myTotalProgressBar.Name = "myTotalProgressBar";
            // 
            // myStartButton
            // 
            resources.ApplyResources(this.myStartButton, "myStartButton");
            this.myStartButton.Name = "myStartButton";
            this.myStartButton.UseVisualStyleBackColor = true;
            this.myStartButton.Click += new System.EventHandler(this.myStartButton_Click);
            // 
            // myResxFilesCheckedBox
            // 
            this.myResxFilesCheckedBox.CheckOnClick = true;
            this.myResxFilesCheckedBox.FormattingEnabled = true;
            resources.ApplyResources(this.myResxFilesCheckedBox, "myResxFilesCheckedBox");
            this.myResxFilesCheckedBox.Name = "myResxFilesCheckedBox";
            this.myResxFilesCheckedBox.Sorted = true;
            // 
            // myBrowseButton
            // 
            resources.ApplyResources(this.myBrowseButton, "myBrowseButton");
            this.myBrowseButton.Name = "myBrowseButton";
            this.myBrowseButton.UseVisualStyleBackColor = true;
            this.myBrowseButton.Click += new System.EventHandler(this.myBrowseButton_Click);
            // 
            // myResxPathRadioButton
            // 
            resources.ApplyResources(this.myResxPathRadioButton, "myResxPathRadioButton");
            this.myResxPathRadioButton.Name = "myResxPathRadioButton";
            this.myResxPathRadioButton.UseVisualStyleBackColor = true;
            this.myResxPathRadioButton.CheckedChanged += new System.EventHandler(this.myResxPathRadioButton_CheckedChanged);
            // 
            // myResxOnlyRadioButton
            // 
            resources.ApplyResources(this.myResxOnlyRadioButton, "myResxOnlyRadioButton");
            this.myResxOnlyRadioButton.Checked = true;
            this.myResxOnlyRadioButton.Name = "myResxOnlyRadioButton";
            this.myResxOnlyRadioButton.TabStop = true;
            this.myResxOnlyRadioButton.UseVisualStyleBackColor = true;
            this.myResxOnlyRadioButton.CheckedChanged += new System.EventHandler(this.myResxOnlyRadioButton_CheckedChanged);
            // 
            // myPathTextBox
            // 
            resources.ApplyResources(this.myPathTextBox, "myPathTextBox");
            this.myPathTextBox.Name = "myPathTextBox";
            this.myPathTextBox.ReadOnly = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.myTargetLanguageLabel);
            this.tabPage2.Controls.Add(this.mySelectAllCheckBox);
            this.tabPage2.Controls.Add(this.myLanguageCheckedBox);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // myTargetLanguageLabel
            // 
            resources.ApplyResources(this.myTargetLanguageLabel, "myTargetLanguageLabel");
            this.myTargetLanguageLabel.Name = "myTargetLanguageLabel";
            // 
            // mySelectAllCheckBox
            // 
            resources.ApplyResources(this.mySelectAllCheckBox, "mySelectAllCheckBox");
            this.mySelectAllCheckBox.Name = "mySelectAllCheckBox";
            this.mySelectAllCheckBox.UseVisualStyleBackColor = true;
            this.mySelectAllCheckBox.CheckedChanged += new System.EventHandler(this.mySelectAllCheckBox_CheckedChanged);
            // 
            // myLanguageCheckedBox
            // 
            this.myLanguageCheckedBox.CheckOnClick = true;
            this.myLanguageCheckedBox.FormattingEnabled = true;
            resources.ApplyResources(this.myLanguageCheckedBox, "myLanguageCheckedBox");
            this.myLanguageCheckedBox.MultiColumn = true;
            this.myLanguageCheckedBox.Name = "myLanguageCheckedBox";
            this.myLanguageCheckedBox.Sorted = true;
            // 
            // myStatusStrip
            // 
            this.myStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.myToolStripStatusLabel});
            resources.ApplyResources(this.myStatusStrip, "myStatusStrip");
            this.myStatusStrip.Name = "myStatusStrip";
            this.myStatusStrip.SizingGrip = false;
            // 
            // myToolStripStatusLabel
            // 
            this.myToolStripStatusLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.myToolStripStatusLabel.Name = "myToolStripStatusLabel";
            resources.ApplyResources(this.myToolStripStatusLabel, "myToolStripStatusLabel");
            this.myToolStripStatusLabel.Spring = true;
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.myStatusStrip);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.myStatusStrip.ResumeLayout(false);
            this.myStatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckedListBox myLanguageCheckedBox;
        private System.Windows.Forms.CheckBox mySelectAllCheckBox;
        private System.Windows.Forms.Button myBrowseButton;
        private System.Windows.Forms.RadioButton myResxPathRadioButton;
        private System.Windows.Forms.RadioButton myResxOnlyRadioButton;
        private System.Windows.Forms.TextBox myPathTextBox;
        private System.Windows.Forms.CheckedListBox myResxFilesCheckedBox;
        private System.Windows.Forms.Button myStartButton;
        private System.Windows.Forms.Label myTargetLanguageLabel;
        private System.Windows.Forms.StatusStrip myStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel myToolStripStatusLabel;
        private System.Windows.Forms.CheckBox mySelectAllResxFileCheckBox;
        private System.Windows.Forms.Label myTotalProgressLabel;
        private System.Windows.Forms.ProgressBar myTotalProgressBar;
        private System.Windows.Forms.Button myCancelButton;
        private System.Windows.Forms.CheckBox mySearchPatternCheckBox;

    }
}

