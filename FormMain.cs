﻿using System;
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
using WK.Libraries.SharpClipboardNS;

namespace ClipboardAutoProcessor
{
    public partial class FormMain : Form
    {
        #region Members

        private string _scriptFileDirectoryFullPath1;
        private string _scriptFileDirectoryFullPath2;

        private BindingList<ScriptFileItem> _scriptFileList1;
        private BindingList<ScriptFileItem> _scriptFileList2;

        private SharpClipboard _sharpClipboard = new SharpClipboard();

        private string _currentClipboardText = string.Empty;

        private BindingList<HistoryOperationItem> _historyOperationList = new BindingList<HistoryOperationItem>();

        #endregion

        #region Constructor

        public FormMain()
        {
            ApplicationService.Init();

            ApplicationConfig config = ApplicationService.Config;

            switch (config.UserInterface_DisplayLanguage.ToLower()) {
                case "auto":
                case "":
                    break;

                case "en-us":
                case "en":
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
                    break;

                case "zh-cn":
                case "cn":
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("zh-CN");
                    break;

                default:
                    break;
            }

            _scriptFileDirectoryFullPath1 = FileSystemUtil.GetFullPathBasedOnProgramFile(config.DirPath_ScriptDir1);
            _scriptFileDirectoryFullPath2 = FileSystemUtil.GetFullPathBasedOnProgramFile(config.DirPath_ScriptDir2);

            _scriptFileList1 = ScriptUtil.GetScriptFileList(_scriptFileDirectoryFullPath1);
            _scriptFileList2 = ScriptUtil.GetScriptFileList(_scriptFileDirectoryFullPath2);

//            this.Font = SystemFonts.MessageBoxFont;

            InitializeComponent();

            UpdateTexts();

            string newFontFamily = config.UserInterface_TextareaFontName;

            float newFontSize;
            if ((config.UserInterface_TextareaFontSize == string.Empty)
                    || !float.TryParse(config.UserInterface_TextareaFontSize, out newFontSize)) {
                newFontSize = -1;
            }

            if ((newFontFamily != string.Empty) || (newFontSize > 0))
            {
                Font oldFont = textBoxClipboardText.Font;

                if (newFontFamily == string.Empty) {
                    newFontFamily = oldFont.Name;
                }

                if (newFontSize <= 0)
                {
                    newFontSize = oldFont.Size;
                }

                Font newFont = new Font(newFontFamily, newFontSize);

                textBoxClipboardText.Font = newFont;
                textBoxProcessedResult1.Font = newFont;
                textBoxProcessedResult2.Font = newFont;
            }

            _sharpClipboard.ObservableFormats.All = false;
            _sharpClipboard.ObservableFormats.Texts = true;
            _sharpClipboard.ClipboardChanged += SharpClipboard_ClipboardChanged;
        }

        #endregion

        #region I18n

        private void UpdateTexts()
        {
            menuItemFile.Text = I18n._("&File");
            menuItemOptions.Text = I18n._("&Options");
            menuItemHelp.Text = I18n._("&Help");

            labelClipboardText.Text = I18n._("Clipboard text:");
            buttonClipboardTextFetch.Text = I18n._("Fetch");
            buttonClipboardTextProcess.Text = I18n._("Process");
            checkBoxClipboardTextAutoFetch.Text = I18n._("Auto fetch");
            checkBoxClipboardTextAutoFetchOnlyWhenActivatingForm.Text = I18n._("Only when switched to this window");
            checkBoxClipboardTextAutoProcessAfterAutoFetch.Text = I18n._("Auto process after fetching");

            labelProcessedResult1.Text = I18n._("Processed result:");
            buttonProcessedResult1Copy.Text = I18n._("Copy");
            buttonProcessedResult1SaveAsFile.Text = I18n._("Save as file...");
            checkBoxProcessedResult1AutoCopy.Text = I18n._("Auto copy to clipboard");
            checkBoxProcessedResult1AppendToEnd.Text = I18n._("Append new result");

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

            ApplicationState state = ApplicationService.State;

            if ((state.Window_Left >= 0) && (state.Window_Top >= 0)
                    && (state.Window_Width > 0) && (state.Window_Height > 0))
            {
                this.SetBounds(state.Window_Left, state.Window_Top,
                        state.Window_Width, state.Window_Height);
            }

            if ((state.Layout_SplitterDistance1 > 0) && (state.Layout_SplitterDistance2 > 0))
            {
                this.splitContainerSub.SplitterDistance = state.Layout_SplitterDistance2;
                this.splitContainerMain.SplitterDistance = state.Layout_SplitterDistance1;
            }

            checkBoxClipboardTextAutoFetch.Checked = state.Control_AutoFetch;
            checkBoxClipboardTextAutoFetchOnlyWhenActivatingForm.Checked = state.Control_AutoFetchOnlyWhenActivatingForm;
            checkBoxClipboardTextAutoProcessAfterAutoFetch.Checked = state.Control_AutoProcessAfterAutoFetch;

            checkBoxProcessedResult1AutoCopy.Checked = state.Control_ProcessedResult1AutoCopy;
            checkBoxProcessedResult1AppendToEnd.Checked = state.Control_ProcessedResult1AppendToEnd;

            comboBoxScriptFileList1.ValueMember = null;
            comboBoxScriptFileList1.DisplayMember = nameof(ScriptFileItem.DisplayTitle);
            comboBoxScriptFileList1.DataSource = _scriptFileList1;

            comboBoxHistoryOperationList.ValueMember = null;
            comboBoxHistoryOperationList.DisplayMember = nameof(HistoryOperationItem.DisplayText);
            comboBoxHistoryOperationList.DataSource = _historyOperationList;

            if (comboBoxScriptFileList1.Items.Count > 0)
            {
                comboBoxScriptFileList1.SelectedIndex = 0;
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            ApplicationState state = ApplicationService.State;

            Rectangle bounds = this.Bounds;
            state.Window_Left = bounds.Left;
            state.Window_Top = bounds.Top;
            state.Window_Width = bounds.Width;
            state.Window_Height = bounds.Height;

            state.Layout_SplitterDistance1 = this.splitContainerMain.SplitterDistance;
            state.Layout_SplitterDistance2 = this.splitContainerSub.SplitterDistance;

            state.Control_AutoFetch = checkBoxClipboardTextAutoFetch.Checked;
            state.Control_AutoFetchOnlyWhenActivatingForm = checkBoxClipboardTextAutoFetchOnlyWhenActivatingForm.Checked;
            state.Control_AutoProcessAfterAutoFetch = checkBoxClipboardTextAutoProcessAfterAutoFetch.Checked;

            state.Control_ProcessedResult1AutoCopy = checkBoxProcessedResult1AutoCopy.Checked;
            state.Control_ProcessedResult1AppendToEnd = checkBoxProcessedResult1AppendToEnd.Checked;

            state.Save();
        }

        private void FormMain_Activated(object sender, EventArgs e)
        {
            if (!checkBoxClipboardTextAutoFetch.Checked) {
                return;
            }

            if (!checkBoxClipboardTextAutoFetchOnlyWhenActivatingForm.Checked)
            {
                return;
            }

            string clipboardText = Clipboard.GetText();

            OnNewClipboardTextDetected(clipboardText);
        }

        private void SharpClipboard_ClipboardChanged(object sender, SharpClipboard.ClipboardChangedEventArgs e)
        {
            if (!checkBoxClipboardTextAutoFetch.Checked)
            {
                return;
            }

            if (checkBoxClipboardTextAutoFetchOnlyWhenActivatingForm.Checked)
            {
                return;
            }

            if (e.ContentType != SharpClipboard.ContentTypes.Text)
            {
                return;
            }

            string clipboardText = _sharpClipboard.ClipboardText;

            OnNewClipboardTextDetected(clipboardText);
        }

        private void ButtonClipboardTextFetch_Click(object sender, EventArgs e)
        {
            string clipboardText = Clipboard.GetText();

            SetClipboardText(clipboardText);
        }

        private void ButtonClipboardTextProcess_Click(object sender, EventArgs e)
        {
            ProcessClipboardText();
        }

        private void ButtonProcessedResult1Copy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBoxProcessedResult1.Text);

            _currentClipboardText = Clipboard.GetText();
        }

        private void CheckBoxClipboardTextAutoFetch_CheckedChanged(object sender, EventArgs e)
        {
            bool autoFetchChecked = checkBoxClipboardTextAutoFetch.Checked;

            checkBoxClipboardTextAutoProcessAfterAutoFetch.Enabled = autoFetchChecked;
            checkBoxClipboardTextAutoFetchOnlyWhenActivatingForm.Enabled = autoFetchChecked;
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

        private void OnNewClipboardTextDetected(string newClipboardText)
        {
            if (newClipboardText == _currentClipboardText)
            {
                return;
            }

            bool succeeded = SetClipboardText(newClipboardText);
            if (!succeeded)
            {
                return;
            }

            if (!checkBoxClipboardTextAutoFetch.Checked
                    || !checkBoxClipboardTextAutoProcessAfterAutoFetch.Checked)
            {
                return;
            }

            ProcessClipboardText();
        }

        private bool SetClipboardText(string clipboardText)
        {
            if (clipboardText.Length > ApplicationService.CLIPBOARD_TEXT_MAX_SUPPORTED_LENGTH)
            {
                return false;
            }

            _currentClipboardText = clipboardText;

            textBoxClipboardText.Text = clipboardText;

            return true;
        }

        private void ProcessClipboardText()
        {
            string text = textBoxClipboardText.Text;

            string scriptFileName = comboBoxScriptFileList1.Text;
            string scriptFileFullPath = Path.Combine(_scriptFileDirectoryFullPath1, scriptFileName);

            if (!File.Exists(scriptFileFullPath))
            {
                return;
            }

            string scriptFileExtension = Path.GetExtension(scriptFileFullPath).TrimStart('.').ToLower();
            ScriptInterpreterItem scriptInterpreter = ApplicationService.Config.GetScriptInterpreter(scriptFileExtension);

            string text2 = ScriptUtil.CallScriptInterpreter(scriptInterpreter, scriptFileFullPath, text);

            if (checkBoxProcessedResult1AppendToEnd.Checked)
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

            if (comboBoxHistoryOperationList.Items.Count > 0)
            {
                comboBoxHistoryOperationList.SelectedIndex = comboBoxHistoryOperationList.Items.Count - 1;
            }

            if (checkBoxProcessedResult1AutoCopy.Checked)
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
