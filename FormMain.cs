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

        private bool _textareaLineEndingNormalizeToCrLf = true;

        private bool _duringSetMultilineTextBoxText = false;

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

            if (config.UserInterface_TextareaLineEnding.ToLower() == "normalizetocrlf")
            {
                _textareaLineEndingNormalizeToCrLf = true;
            }
            else
            {
                _textareaLineEndingNormalizeToCrLf = false;
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
            menuItemTools.Text = I18n._("&Tools");
            menuItemHelp.Text = I18n._("&Help");

            menuItemFileExit.Text = I18n._("E&xit");
            menuItemToolsOptions.Text = I18n._("&Options");
            menuItemHelpAbout.Text = I18n._("&About");

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
            buttonProcessedResult2Copy.Text = I18n._("Copy");
            buttonProcessedResult2SaveAsFile.Text = I18n._("Save as file...");
            checkBoxProcessedResult2AutoCopy.Text = I18n._("Auto copy to clipboard");
            checkBoxProcessedResult2AppendToEnd.Text = I18n._("Append new result");

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

            checkBoxClipboardTextAutoFetch.Checked = state.Control_AutoFetch;
            checkBoxClipboardTextAutoFetchOnlyWhenActivatingForm.Checked = state.Control_AutoFetchOnlyWhenActivatingForm;
            checkBoxClipboardTextAutoProcessAfterAutoFetch.Checked = state.Control_AutoProcessAfterAutoFetch;

            checkBoxProcessedResult1AutoCopy.Checked = state.Control_ProcessedResult1AutoCopy;
            checkBoxProcessedResult1AppendToEnd.Checked = state.Control_ProcessedResult1AppendToEnd;

            checkBoxProcessedResult2AutoCopy.Checked = state.Control_ProcessedResult2AutoCopy;
            checkBoxProcessedResult2AppendToEnd.Checked = state.Control_ProcessedResult2AppendToEnd;

            comboBoxScriptFileList1.ValueMember = nameof(ScriptFileItem.FileName);
            comboBoxScriptFileList1.DisplayMember = nameof(ScriptFileItem.DisplayTitle);
            comboBoxScriptFileList1.DataSource = _scriptFileList1;

            comboBoxScriptFileList2.ValueMember = nameof(ScriptFileItem.FileName);
            comboBoxScriptFileList2.DisplayMember = nameof(ScriptFileItem.DisplayTitle);
            comboBoxScriptFileList2.DataSource = _scriptFileList2;

            comboBoxHistoryOperationList.ValueMember = null;
            comboBoxHistoryOperationList.DisplayMember = nameof(HistoryOperationItem.DisplayText);
            comboBoxHistoryOperationList.DataSource = _historyOperationList;

            if (comboBoxScriptFileList1.Items.Count > 0)
            {
                if (!string.IsNullOrEmpty(state.Control_SelectedScriptFileName1))
                {
                    comboBoxScriptFileList1.SelectedValue = state.Control_SelectedScriptFileName1;
                }

                if (comboBoxScriptFileList1.SelectedValue == null)
                {
                    comboBoxScriptFileList1.SelectedIndex = 0;
                }
            }

            if (comboBoxScriptFileList2.Items.Count > 0)
            {
                if (!string.IsNullOrEmpty(state.Control_SelectedScriptFileName2))
                {
                    comboBoxScriptFileList2.SelectedValue = state.Control_SelectedScriptFileName2;
                }

                if (comboBoxScriptFileList2.SelectedValue == null)
                {
                    comboBoxScriptFileList2.SelectedIndex = 0;
                }
            }

            switch (state.Window_State.ToLower())
            {
                case "normal":
                case "minimized":
                    this.WindowState = FormWindowState.Normal;
                    break;

                case "maximized":
                    this.WindowState = FormWindowState.Maximized;
                    break;

                default:
                    break;
            }

            if ((state.Window_Left >= 0) && (state.Window_Top >= 0)
                    && (state.Window_Width > 0) && (state.Window_Height > 0))
            {
                this.SetBounds(state.Window_Left, state.Window_Top,
                        state.Window_Width, state.Window_Height);
            }

            if ((state.Layout_SplitterDistance1 > 0) && (state.Layout_SplitterDistance2 > 0))
            {
                this.splitContainerMain.SplitterDistance = state.Layout_SplitterDistance1;
                this.splitContainerSub.SplitterDistance = state.Layout_SplitterDistance2;
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            ApplicationState state = ApplicationService.State;

            switch (this.WindowState)
            {
                case FormWindowState.Normal:
                    state.Window_State = "normal";
                    break;

                case FormWindowState.Minimized:
                    state.Window_State = "minimized";
                    break;

                case FormWindowState.Maximized:
                    state.Window_State = "maximized";
                    break;

                default:
                    break;
            }

            Rectangle bounds = this.Bounds;
            state.Window_Left = bounds.Left;
            state.Window_Top = bounds.Top;
            state.Window_Width = bounds.Width;
            state.Window_Height = bounds.Height;

            state.Layout_SplitterDistance1 = this.splitContainerMain.SplitterDistance;
            state.Layout_SplitterDistance2 = this.splitContainerSub.SplitterDistance;

            state.Control_SelectedScriptFileName1 = (comboBoxScriptFileList1.SelectedValue as string) ?? string.Empty;
            state.Control_SelectedScriptFileName2 = (comboBoxScriptFileList2.SelectedValue as string) ?? string.Empty;

            state.Control_AutoFetch = checkBoxClipboardTextAutoFetch.Checked;
            state.Control_AutoFetchOnlyWhenActivatingForm = checkBoxClipboardTextAutoFetchOnlyWhenActivatingForm.Checked;
            state.Control_AutoProcessAfterAutoFetch = checkBoxClipboardTextAutoProcessAfterAutoFetch.Checked;

            state.Control_ProcessedResult1AutoCopy = checkBoxProcessedResult1AutoCopy.Checked;
            state.Control_ProcessedResult1AppendToEnd = checkBoxProcessedResult1AppendToEnd.Checked;

            state.Control_ProcessedResult2AutoCopy = checkBoxProcessedResult2AutoCopy.Checked;
            state.Control_ProcessedResult2AppendToEnd = checkBoxProcessedResult2AppendToEnd.Checked;

            state.Save();
        }

        private void FormMain_Activated(object sender, EventArgs e)
        {
            if (!checkBoxClipboardTextAutoFetch.Checked)
            {
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
            Clipboard.SetText(GetMultilineTextBoxText(textBoxProcessedResult1));

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

        private void MultilineTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!_textareaLineEndingNormalizeToCrLf)
            {
                return;
            }

            if (_duringSetMultilineTextBoxText)
            {
                return;
            }

            TextBox textBox = sender as TextBox;
            if (textBox == null)
            {
                return;
            }

            string text = GetMultilineTextBoxText(textBox);

            if (StringUtil.HasLfLineEnding(text))
            {
                int selectionStart = textBox.SelectionStart;
                string textBeforeCaret = text.Substring(0, selectionStart);

                string newText = StringUtil.NormalizeLineEndingToCrLf(text);
                string newTextBeforeCaret = StringUtil.NormalizeLineEndingToCrLf(textBeforeCaret);
                int newSelectionStart = selectionStart + (newTextBeforeCaret.Length - textBeforeCaret.Length);

                textBox.Text = newText;
                textBox.SelectionStart = newSelectionStart;
                textBox.ScrollToCaret();
            }
        }

        #endregion

        #region Menu items processing

        private void MenuItemFileExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MenuItemToolsOptions_Click(object sender, EventArgs e)
        {
            MessageBox.Show(I18n._("Please modify the application_config.ini file manually to set options."),
                I18n._("Graphical interface is not implemented yet"),
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MenuItemHelpAbout_Click(object sender, EventArgs e)
        {
            FormAbout formAbout = new FormAbout();

            formAbout.ShowDialog();
        }

        #endregion

        #region Text processing

        private void SetMultilineTextBoxText(TextBox textBox, string text)
        {
            _duringSetMultilineTextBoxText = true;

            if (_textareaLineEndingNormalizeToCrLf)
            {
                if (StringUtil.HasLfLineEnding(text))
                {
                    text = StringUtil.NormalizeLineEndingToCrLf(text);
                }
            }

            textBox.Text = text;

            _duringSetMultilineTextBoxText = false;
        }

        private string GetMultilineTextBoxText(TextBox textBox)
        {
            return textBox.Text;
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

            SetMultilineTextBoxText(textBoxClipboardText, clipboardText);

            return true;
        }

        private void ProcessClipboardText()
        {
            string clipboardText = GetMultilineTextBoxText(textBoxClipboardText);

            string processedResult1 = ProcessUsingScriptFile1(clipboardText);
            if (processedResult1 == null)
            {
                SetMultilineTextBoxText(textBoxProcessedResult1, string.Empty);
                SetMultilineTextBoxText(textBoxProcessedResult2, string.Empty);
                return;
            }

            string processedResult2 = ProcessUsingScriptFile2(processedResult1);

            AddHistoryItem(clipboardText);

            if (processedResult2 != null)
            {
                textBoxProcessedResult2.Focus();
            }
            else
            {
                textBoxProcessedResult1.Focus();
            }
        }

        private string ProcessUsingScriptFile1(string clipboardText)
        {
            return ProcessUsingScriptFile(clipboardText,
                    _scriptFileDirectoryFullPath1,
                    comboBoxScriptFileList1,
                    (checkBoxProcessedResult1AutoCopy.Checked && !checkBoxProcessedResult2AutoCopy.Checked),
                    checkBoxProcessedResult1AppendToEnd.Checked,
                    textBoxProcessedResult1);
        }

        private string ProcessUsingScriptFile2(string clipboardText)
        {
            return ProcessUsingScriptFile(clipboardText,
                    _scriptFileDirectoryFullPath2,
                    comboBoxScriptFileList2,
                    checkBoxProcessedResult2AutoCopy.Checked,
                    checkBoxProcessedResult2AppendToEnd.Checked,
                    textBoxProcessedResult2);
        }

        private string ProcessUsingScriptFile(string clipboardText, string scriptFileDirectoryFullPath, ComboBox comboBoxScriptFileList,
                bool processedResultAutoCopy, bool processedResultAppendToEnd, TextBox textBoxProcessedResult)
        {
            string scriptFileName = comboBoxScriptFileList.SelectedValue as string;
            if (scriptFileName == null)
            {
                SetMultilineTextBoxText(textBoxProcessedResult, string.Empty);
                return null;
            }

            string scriptFileFullPath = Path.Combine(scriptFileDirectoryFullPath, scriptFileName);
            if (!File.Exists(scriptFileFullPath))
            {
                SetMultilineTextBoxText(textBoxProcessedResult, string.Empty);
                return null;
            }

            string scriptFileExtension = Path.GetExtension(scriptFileFullPath).TrimStart('.').ToLower();
            ScriptInterpreterItem scriptInterpreter = ApplicationService.Config.GetScriptInterpreter(scriptFileExtension);

            string processedResult = ScriptUtil.CallScriptInterpreter(scriptInterpreter, scriptFileFullPath, clipboardText);

            if (processedResultAutoCopy)
            {
                Clipboard.SetText(processedResult);

                _currentClipboardText = Clipboard.GetText();
            }

            if (processedResultAppendToEnd)
            {
                string originalProcessedResult = GetMultilineTextBoxText(textBoxProcessedResult);

                if (originalProcessedResult == string.Empty)
                {
                    SetMultilineTextBoxText(textBoxProcessedResult, processedResult);
                }
                else
                {
                    SetMultilineTextBoxText(textBoxProcessedResult, originalProcessedResult
                            + (_textareaLineEndingNormalizeToCrLf ? "\r\n" : Environment.NewLine)
                            + processedResult);
                }
            }
            else
            {
                SetMultilineTextBoxText(textBoxProcessedResult, processedResult);
            }

            textBoxProcessedResult.Select(textBoxProcessedResult.Text.Length, 0);

            return processedResult;
        }

        private void AddHistoryItem(string clipboardText)
        {
            string summaryText = Regex.Replace(clipboardText, "/[\\t\\r\\n]/", " ").Trim();
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
        }

        #endregion
    }
}
