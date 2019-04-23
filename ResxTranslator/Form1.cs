using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Net;

namespace ResxTranslator
{
    /// <summary>
    /// Form1
    /// </summary>
    public partial class Form1 : Form
    {
        #region Fields
        private string[] mySelectedFiles;
        BackgroundWorker myBackgroundWorker;
        #endregion

        #region Events

        #endregion

        #region Constructor
        public Form1()
        {
            InitializeComponent();
            InitializeBackgroundWorker();
            myLanguageCheckedBox.ItemCheck += new ItemCheckEventHandler(myLanguageCheckedBox_ItemCheck);
        }
        #endregion

        #region Methods
        #region Private Methods
        /// <summary>
        /// Set up the BackgroundWorker object by attaching event handlers. 
        /// </summary>
        private void InitializeBackgroundWorker()
        {
            myBackgroundWorker = new BackgroundWorker();
            this.myBackgroundWorker.WorkerReportsProgress = true;
            this.myBackgroundWorker.WorkerSupportsCancellation = true;
            myBackgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            myBackgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
            myBackgroundWorker.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
        }

        /// <summary>
        /// Gets the selected language from config page.
        /// </summary>
        /// <returns>selected languages.</returns>
        private Language[] GetCheckedLanguages()
        {
            Language[] languages = new Language[myLanguageCheckedBox.CheckedItems.Count];
            int i = 0;
            foreach (object obj in myLanguageCheckedBox.CheckedItems)
            {
                foreach (Language l in Language.TranslatableCollection)
                {
                    if (string.Compare(l.Name, obj.ToString(), true) == 0)
                    {
                        languages[i++] = l;
                    }
                }
            }
            return languages;
        }

        /// <summary>
        /// Reset the states of UI controls.
        /// </summary>
        private void ResetControlsState()
        {
            myPathTextBox.Text = string.Empty;
            myResxFilesCheckedBox.Items.Clear();
            myStartButton.Enabled = false;
            myCancelButton.Enabled = false;
            myToolStripStatusLabel.Text = string.Empty;
            mySelectAllResxFileCheckBox.Enabled = false;
            myTotalProgressBar.Value = 0;
        }

        /// <summary>
        /// Get the selected resx files list to translate.
        /// </summary>
        private void GetTotalResxFiles()
        {
            if (string.IsNullOrEmpty(myPathTextBox.Text))
            {
                return;
            }
            myResxFilesCheckedBox.Items.Clear();
            SearchOption option = SearchOption.TopDirectoryOnly;
            if (!mySearchPatternCheckBox.Checked)
            {
                option = SearchOption.AllDirectories;
            }
            string[] fileNames = Directory.GetFiles(myPathTextBox.Text, "*.resx", option);
            myResxFilesCheckedBox.Items.AddRange(fileNames);
            mySelectedFiles = fileNames;
            if (mySelectedFiles.Length > 0)
            {
                myStartButton.Enabled = true;
                mySelectAllResxFileCheckBox.Enabled = true;
            }
            else
            {
                mySelectAllResxFileCheckBox.Enabled = false;
                myToolStripStatusLabel.Text = "There is no .resx file in the given folder...";
            }
        }

        /// <summary>
        /// Perform translation for each selected language for all selected resx files.
        /// </summary>
        /// <param name="languages">selected languages.</param>
        /// <param name="worker">BackgroundWorker instance.</param>
        /// <param name="e">DoWorkEventArgs</param>
        private void PerformTranslation(Language[] languages, BackgroundWorker worker, DoWorkEventArgs e, bool onlyTextStrings)
        {
            int totalProgress = 0;
            foreach (string file in mySelectedFiles)
            {
                foreach (Language targetLanguage in languages)
                {
                    if (worker.CancellationPending)
                    {
                        e.Cancel = true;
                    }
                    else
                    {
                        ResxWriter.Write(targetLanguage, file, onlyTextStrings);
                        totalProgress++;
                        worker.ReportProgress(totalProgress);
                    }
                }
            }
        }
        #endregion

        #region Event Handlers
        void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            myTotalProgressBar.Value = e.ProgressPercentage;
        }

        void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                myToolStripStatusLabel.Text = "Translation Cancelled...";
                myTotalProgressBar.Value = myTotalProgressBar.Maximum;
            }
            else if (e.Error != null)
            {
                myToolStripStatusLabel.Text = "Error...";
                MessageBox.Show("Error while Translating..!" + e.Result.ToString(), "Resx Translator");
            }
            else
            {
                MessageBox.Show("Translation finished. Please check the corresponding resx files.", "Resx Translator");
            }
            myStartButton.Enabled = true;
            myCancelButton.Enabled = false;
        }

        void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                BackgroundWorker worker = sender as BackgroundWorker;
                Language[] languages = e.Argument as Language[];
                PerformTranslation(languages, worker, e, true);
            }
            catch (WebException ex)
            {
                e.Cancel = true;
                myToolStripStatusLabel.Text = "Error...";
                MessageBox.Show(ex.Message);
            }
        }

        void myLanguageCheckedBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // TODO: if unchecked, remove check from select all.
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            myStartButton.Enabled = false;
            myCancelButton.Enabled = false;
            mySearchPatternCheckBox.Enabled = false;
            mySearchPatternCheckBox.Checked = true;
            mySelectAllResxFileCheckBox.Enabled = false;
            ICollection<Language> allLanguages = Language.TranslatableCollection;
            myLanguageCheckedBox.Items.AddRange(allLanguages.OrderBy(l=> l.Name).ToArray<Language>());
            //myLanguageCheckedBox.Items.RemoveAt(10);
        }

        private void mySelectAllCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < this.myLanguageCheckedBox.Items.Count; i++)
            {
                this.myLanguageCheckedBox.SetItemChecked(i, mySelectAllCheckBox.Checked);
            }
        }

        private void myBrowseButton_Click(object sender, EventArgs e)
        {
            if (myResxPathRadioButton.Checked)
            {
                FolderBrowserDialog browserDialog = new FolderBrowserDialog();
                browserDialog.RootFolder = Environment.SpecialFolder.Desktop;

                DialogResult result = browserDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    ResetControlsState();
                    myPathTextBox.Text = browserDialog.SelectedPath;
                    GetTotalResxFiles();
                }
            }
            else
            {
                OpenFileDialog fileDialog = new OpenFileDialog();
                fileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                fileDialog.DefaultExt = "*.resx";
                fileDialog.Filter = "resx files (*.resx)|*.resx|All files (*.*)|*.*";
                string[] fileNames = new string[1];
                DialogResult result = fileDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    ResetControlsState();
                    myPathTextBox.Text = fileDialog.FileName;
                    fileNames[0] = myPathTextBox.Text;
                    mySelectedFiles = fileNames;
                    if (string.Compare(Path.GetExtension(myPathTextBox.Text), ".resx") == 0)
                    {
                        myStartButton.Enabled = true;
                    }
                    else
                    {
                        myToolStripStatusLabel.Text = "Not a valid resx file...";
                    }
                }
            }
        }

        private void myStartButton_Click(object sender, EventArgs e)
        {
            myToolStripStatusLabel.Text = string.Empty;
            if (myResxPathRadioButton.Checked)
            {
                string[] files = new string[myResxFilesCheckedBox.CheckedItems.Count];
                int i = 0;
                // Next show the object title and check state for each item selected.
                foreach (object itemChecked in myResxFilesCheckedBox.CheckedItems)
                {
                    files[i++] = itemChecked.ToString();
                }
                mySelectedFiles = files;
            }

            if (mySelectedFiles.Length > 0)
            {
                Language[] languages = GetCheckedLanguages();
                if (languages.Length > 0)
                {
                    myStartButton.Enabled = false;
                    myCancelButton.Enabled = true;

                    myTotalProgressBar.Value = 0;
                    myTotalProgressBar.Minimum = 0;

                    int max = mySelectedFiles.Length * languages.Length;
                    myTotalProgressBar.Maximum = max;

                    myToolStripStatusLabel.Text = "Running...";
                    myBackgroundWorker.RunWorkerAsync(languages);
                }
                else
                {
                    myToolStripStatusLabel.Text = "Please select atleast one language to translate.";
                }
            }
            else
            {
                myToolStripStatusLabel.Text = "Please select atleast one resx file to translate.";
            }
        }

        private void myResxOnlyRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            ResetControlsState();
        }

        private void myResxPathRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            ResetControlsState();
            mySearchPatternCheckBox.Enabled = myResxPathRadioButton.Checked;
        }

        private void mySelectAllResxFileCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < this.myResxFilesCheckedBox.Items.Count; i++)
            {
                this.myResxFilesCheckedBox.SetItemChecked(i, mySelectAllResxFileCheckBox.Checked);
            }
        }
        

        private void mySearchPatternCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            mySelectAllResxFileCheckBox.Checked = false;
            GetTotalResxFiles();
        }

        private void myCancelButton_Click(object sender, EventArgs e)
        {
            myCancelButton.Enabled = false;
            myBackgroundWorker.CancelAsync();
        }
        #endregion
        #endregion
    }
}
