using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using ClipboardAutoProcessor.DataStructure;
using ClipboardAutoProcessor.Util;

namespace ClipboardAutoProcessor
{
    public partial class FormMain : Form
    {
        #region Members

        private string _currentDirectoryPath;

        private string _scriptFileDirectoryPath1;
        private string _scriptFileDirectoryPath2;

        private BindingList<ScriptFileItem> _scriptFileList1;
        private BindingList<ScriptFileItem> _scriptFileList2;

        private string _currentClipboardText = string.Empty;

        private BindingList<HistoryOperationItem> _historyOperationList = new BindingList<HistoryOperationItem>();

        #endregion

        #region Constructor

        public FormMain()
        {
//            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
//            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("zh-CN");

            _currentDirectoryPath = Path.GetFullPath(".");

            _scriptFileDirectoryPath1 = _currentDirectoryPath + "\\processors";
            _scriptFileDirectoryPath2 = _currentDirectoryPath + "\\processors2";

            _scriptFileList1 = ScriptUtil.GetScriptFileList(_scriptFileDirectoryPath1);
            _scriptFileList2 = ScriptUtil.GetScriptFileList(_scriptFileDirectoryPath2);

//            this.Font = SystemFonts.MessageBoxFont;

            InitializeComponent();

            UpdateTexts();
        }

        #endregion

        #region I18n

        private void UpdateTexts()
        {
            menuItemFile.Text = I18n._("&File");
            menuItemOptions.Text = I18n._("&Options");
            menuItemHelp.Text = I18n._("&Help");

            labelClipboardText.Text = I18n._("Clipboard text:");
            buttonFetchClipboardText.Text = I18n._("Fetch");
            buttonProcessClipboardText.Text = I18n._("Process");
            checkBoxAutoFetch.Text = I18n._("Auto fetch");
            checkBoxAutoProcessAfterCapturing.Text = I18n._("Auto process after fetching");
            checkBoxOnlyWhenFormIsActivated.Text = I18n._("Only when form is activated");

            labelProcessedResult1.Text = I18n._("Processed result:");
            buttonCopyProcessedResult1.Text = I18n._("Copy");
            buttonSaveProcessedResult1AsFile.Text = I18n._("Save as file...");
            checkBoxAutoCopyProcessedResult1.Text = I18n._("Auto copy to clipboard");
            checkBoxAppendProcessedResult1ToEnd.Text = I18n._("Append new result");

            labelProcessedResult2.Text = I18n._("Secondary processed result:");

            labelHistory.Text = I18n._("History:");
            buttonHistoryPrevious.Text = I18n._("<");
            buttonHistoryNext.Text = I18n._(">");

            this.Text = I18n._("Clipboard Auto Processor");
        }

        #endregion

        #region Control events processing

        private void FormMain_Load(object sender, EventArgs e)
        {
            // To avoid the bug of MainMenu control handling in Visual Studio designer
            this.Menu = mainMenu;

            comboBoxPrimaryScriptFileNames.ValueMember = null;
            comboBoxPrimaryScriptFileNames.DisplayMember = nameof(ScriptFileItem.DisplayTitle);
            comboBoxPrimaryScriptFileNames.DataSource = _scriptFileList1;

            comboBoxHistory.ValueMember = null;
            comboBoxHistory.DisplayMember = nameof(HistoryOperationItem.DisplayText);
            comboBoxHistory.DataSource = _historyOperationList;

            if (comboBoxPrimaryScriptFileNames.Items.Count > 0)
            {
                comboBoxPrimaryScriptFileNames.SelectedIndex = 0;
            }
        }

        private void FormMain_Activated(object sender, EventArgs e)
        {
            if (!checkBoxOnlyWhenFormIsActivated.Enabled
                    || !checkBoxOnlyWhenFormIsActivated.Checked)
            {
                return;
            }

            string clipboardText = Clipboard.GetText();

            if (clipboardText != _currentClipboardText)
            {
                SetClipboardText(clipboardText);

                if (checkBoxAutoProcessAfterCapturing.Enabled
                        && checkBoxAutoProcessAfterCapturing.Checked)
                {
                    ProcessClipboardText();
                }
            }
        }

        private void ButtonGetClipboardText_Click(object sender, EventArgs e)
        {
            string clipboard_text = Clipboard.GetText();

            SetClipboardText(clipboard_text);
        }

        private void ButtonProcess_Click(object sender, EventArgs e)
        {
            ProcessClipboardText();
        }

        private void ButtonCopyPrimaryProcessedResult_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBoxProcessedResult1.Text);

            _currentClipboardText = Clipboard.GetText();
        }

        private void MultilineTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control & e.KeyCode == Keys.A)
            {
                ((TextBox)sender).SelectAll();
            }
        }

        #endregion

        #region Clipboard processing

        private void SetClipboardText(string clipboard_text)
        {
            if (clipboard_text.Length > (1024 * 1024))
            {
                return;
            }

            _currentClipboardText = clipboard_text;

            textBoxClipboardText.Text = clipboard_text;
        }

        private void ProcessClipboardText()
        {
            string text = textBoxClipboardText.Text;

            string scriptFileName = comboBoxPrimaryScriptFileNames.Text;
            string scriptFileFullpath = Path.GetFullPath(_currentDirectoryPath + "\\processors\\" + scriptFileName);

            if (!File.Exists(scriptFileFullpath))
            {
                return;
            }

            string scriptFileExtension = Path.GetExtension(scriptFileFullpath).TrimStart('.').ToLower();
            ScriptInterpreterItem scriptInterpreter = ApplicationService.ApplicationConfig.GetScriptInterpreter(scriptFileExtension);

            string text2 = ScriptUtil.CallScriptInterpreter(scriptInterpreter, scriptFileFullpath, text);

            if (checkBoxAppendProcessedResult1ToEnd.Checked)
            {
                if (textBoxProcessedResult1.Text == "")
                {
                    textBoxProcessedResult1.Text = text2;
                }
                else
                {
                    textBoxProcessedResult1.Text += "\r\n" + text2;
                }
            }
            else
            {
                textBoxProcessedResult1.Text = text2;
            }

            string summaryText = Regex.Replace(text, "/[\\t\\r\\n]/", " ").Trim();
            if (summaryText.Length > 50)
            {
                summaryText = summaryText.Substring(0, 47) + "...";
            }

            HistoryOperationItem historyOperation = new HistoryOperationItem()
            {
                Type = I18n._("Auto"),
                Time = DateTime.Now,
                SummaryText = summaryText
            };

            historyOperation.DisplayText = String.Format("[{0}] ({1:H:mm:ss}) {2}",
                    historyOperation.Type, historyOperation.Time, historyOperation.SummaryText);

            _historyOperationList.Add(historyOperation);

            if (comboBoxHistory.Items.Count > 0)
            {
                comboBoxHistory.SelectedIndex = comboBoxHistory.Items.Count - 1;
            }

            if (checkBoxAutoCopyProcessedResult1.Checked)
            {
                Clipboard.SetText(textBoxProcessedResult1.Text);

                _currentClipboardText = Clipboard.GetText();
            }

            textBoxProcessedResult1.Select(textBoxProcessedResult1.Text.Length, 0);
            textBoxProcessedResult1.Focus();
        }

        #endregion
    }
}
