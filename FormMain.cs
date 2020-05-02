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

namespace ClipboardAutoProcessor
{
    public partial class FormMain : Form
    {
        private ApplicationConfig _applicationConfig = new ApplicationConfig();

        private string _currentDirectoryPath;

        private string _scriptFileDirectoryPath1;
        private string _scriptFileDirectoryPath2;

        private BindingList<ScriptFileItem> _scriptFileList1;
        private BindingList<ScriptFileItem> _scriptFileList2;

        private string _currentClipboardText = string.Empty;

        private BindingList<HistoryOperationItem> _historyOperationList = new BindingList<HistoryOperationItem>();

        public FormMain()
        {
//            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
//            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("zh-CN");

            _currentDirectoryPath = Path.GetFullPath(".");

            _scriptFileDirectoryPath1 = _currentDirectoryPath + "\\processors";
            _scriptFileDirectoryPath2 = _currentDirectoryPath + "\\processors2";

            _scriptFileList1 = GetScriptFileList(_scriptFileDirectoryPath1);
            _scriptFileList2 = GetScriptFileList(_scriptFileDirectoryPath2);

//            this.Font = SystemFonts.MessageBoxFont;

            InitializeComponent();

            UpdateTexts();
        }

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

        private BindingList<ScriptFileItem> GetScriptFileList(string path)
        {
            BindingList<ScriptFileItem> scriptFileList = new BindingList<ScriptFileItem>();

            if (!Directory.Exists(path))
            {
                return scriptFileList;
            }

            string[] files = Directory.GetFiles(path);

            foreach (string file in files)
            {
                string extension = Path.GetExtension(file).TrimStart('.').ToLower();

                if (!_applicationConfig.IsSupportedFileExtension(extension))
                {
                    continue;
                }

                ScriptFileItem item = new ScriptFileItem()
                {
                    FullPath = Path.GetFullPath(file),
                    FileName = Path.GetFileName(file),
                    DisplayTitle = Path.GetFileName(file),
                };

                scriptFileList.Add(item);
            }

            return scriptFileList;
        }

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

        private void SetClipboardText(string clipboard_text)
        {
            if (clipboard_text.Length > (1024 * 1024))
            {
                return;
            }

            _currentClipboardText = clipboard_text;

            textBoxClipboardText.Text = clipboard_text;
        }

        private void ButtonGetClipboardText_Click(object sender, EventArgs e)
        {
            string clipboard_text = Clipboard.GetText();

            SetClipboardText(clipboard_text);
        }

        private void ButtonProcess_Click(object sender, EventArgs e)
        {
            CallScriptInterpreter();
        }

        public static string Base64Encode(string text)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(text);

            return Convert.ToBase64String(bytes);
        }

        public static string Base64Decode(string text)
        {
            try
            {
                byte[] bytes = Convert.FromBase64String(text);

                return Encoding.UTF8.GetString(bytes);
            }
            catch (Exception)
            {
                return text;
            }
        }

        private void CallScriptInterpreter()
        {
            string text = textBoxClipboardText.Text;

            string scriptFileName = comboBoxPrimaryScriptFileNames.Text;
            string scriptFileFullpath = Path.GetFullPath(_currentDirectoryPath + "\\processors\\" + scriptFileName);

            if (!File.Exists(scriptFileFullpath))
            {
                return;
            }

            string scriptFileExtension = Path.GetExtension(scriptFileFullpath).TrimStart('.').ToLower();
            ScriptInterpreterItem scriptInterpreter = _applicationConfig.GetScriptInterpreter(scriptFileExtension);

            Process process = new Process();
            process.StartInfo.FileName = scriptInterpreter.ExecutableProgram.Replace("<filename>", scriptFileFullpath);
            process.StartInfo.Arguments = scriptInterpreter.CommandLineArguments.Replace("<filename>", scriptFileFullpath);
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;

            int timeout = 3000;

            StringBuilder stdout = new StringBuilder();
            StringBuilder stderr = new StringBuilder();

            AutoResetEvent outputWaitHandle = new AutoResetEvent(false);
            AutoResetEvent errorWaitHandle = new AutoResetEvent(false);

            process.OutputDataReceived += (sender, e) =>
            {
                if (e.Data == null)
                {
                    outputWaitHandle.Set();
                }
                else
                {
                    stdout.AppendLine(e.Data);
                }
            };
            process.ErrorDataReceived += (sender, e) =>
            {
                if (e.Data == null)
                {
                    errorWaitHandle.Set();
                }
                else
                {
                    stderr.AppendLine(e.Data);
                }
            };

            process.Start();

            process.StandardInput.WriteLine(Base64Encode(text));
            process.StandardInput.Close();

            process.BeginOutputReadLine();
            process.BeginErrorReadLine();

            if (process.WaitForExit(timeout) &&
                    outputWaitHandle.WaitOne(timeout) &&
                    errorWaitHandle.WaitOne(timeout))
            {
                // Process completed. Check process.ExitCode here.
            }
            else
            {
                // Timed out.
            }

            string text2 = Base64Decode(stdout.ToString());

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

            if (!process.HasExited)
            {
                process.Kill();
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
                    CallScriptInterpreter();
                }
            }
        }

        private void MultilineTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control & e.KeyCode == Keys.A)
            {
                ((TextBox)sender).SelectAll();
            }
        }

        private void ButtonCopyPrimaryProcessedResult_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBoxProcessedResult1.Text);

            _currentClipboardText = Clipboard.GetText();
        }
    }
}
