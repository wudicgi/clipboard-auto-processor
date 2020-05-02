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

namespace ClipboardAutoProcessor
{
    public partial class FormMain : Form
    {
        private ApplicationConfig _applicationConfig = new ApplicationConfig();

        private string _pathCurrentDirectory;

        private string _pathProcessors1;
        private string _pathProcessors2;

        private BindingList<ProcessorScript> _processorScripts1;
        private BindingList<ProcessorScript> _processorScripts2;

        private string _currentClipboardText = "";

        private BindingList<HistoryState> _historyStates;

        public FormMain()
        {
//            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
//            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("zh-CN");

            _pathCurrentDirectory = Path.GetFullPath(".");

            _pathProcessors1 = _pathCurrentDirectory + "\\processors";
            _pathProcessors2 = _pathCurrentDirectory + "\\processors2";

            _processorScripts1 = GetProcessorScripts(_pathProcessors1);
            _processorScripts2 = GetProcessorScripts(_pathProcessors2);

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

        private BindingList<ProcessorScript> GetProcessorScripts(string path)
        {
            BindingList<ProcessorScript> processorScripts = new BindingList<ProcessorScript>();

            if (!Directory.Exists(path))
            {
                return processorScripts;
            }

            string[] files = Directory.GetFiles(path);

            foreach (string file in files)
            {
                string extension = Path.GetExtension(file).TrimStart('.').ToLower();

                if (!_applicationConfig.IsSupportedFileExtension(extension))
                {
                    continue;
                }

                ProcessorScript item = new ProcessorScript()
                {
                    FullPath = Path.GetFullPath(file),
                    FileName = Path.GetFileName(file),
                    ShowTitle = Path.GetFileName(file),
                };

                processorScripts.Add(item);
            }

            return processorScripts;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            // To avoid the bug of MainMenu control handling in Visual Studio designer
            this.Menu = mainMenu;

            comboBoxPrimaryScriptFileNames.ValueMember = null;
            comboBoxPrimaryScriptFileNames.DisplayMember = "ShowTitle";
            comboBoxPrimaryScriptFileNames.DataSource = _processorScripts1;
            
            if (comboBoxPrimaryScriptFileNames.Items.Count > 0)
            {
                comboBoxPrimaryScriptFileNames.SelectedIndex = 0;
            }

            _historyStates = new BindingList<HistoryState>();

            comboBoxHistory.ValueMember = null;
            comboBoxHistory.DisplayMember = "Text";
            comboBoxHistory.DataSource = _historyStates;
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

        private void buttonGetClipboardText_Click(object sender, EventArgs e)
        {
            string clipboard_text = Clipboard.GetText();

            SetClipboardText(clipboard_text);
        }

        private void buttonProcess_Click(object sender, EventArgs e)
        {
            CallProcessor();
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

        private void CallProcessor()
        {
            string text = textBoxClipboardText.Text;

            string scriptFileName = comboBoxPrimaryScriptFileNames.Text;
            string scriptFileFullpath = Path.GetFullPath(_pathCurrentDirectory + "\\processors\\" + scriptFileName);

            if (!File.Exists(scriptFileFullpath))
            {
                return;
            }

            string scriptFileExtension = Path.GetExtension(scriptFileFullpath).TrimStart('.').ToLower();
            ScriptInterpreterConfig scriptInterpreterConfig = _applicationConfig.GetScriptInterpreter(scriptFileExtension);

            Process process = new Process();
            process.StartInfo.FileName = scriptInterpreterConfig.ExecutableProgram.Replace("<filename>", scriptFileFullpath);
            process.StartInfo.Arguments = scriptInterpreterConfig.CommandLineArguments.Replace("<filename>", scriptFileFullpath);
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

            HistoryState historyState = new HistoryState()
            {
                Type = I18n._("Auto"),
                Time = DateTime.Now,
                SummaryText = summaryText
            };

            historyState.Text = String.Format("[{0}] ({1:H:mm:ss}) {2}",
                historyState.Type, historyState.Time, historyState.SummaryText);

            _historyStates.Add(historyState);

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
                    CallProcessor();
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

        private void buttonCopyPrimaryProcessedResult_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBoxProcessedResult1.Text);

            _currentClipboardText = Clipboard.GetText();
        }
    }

    public class ProcessorScript
    {
        public string FullPath { get; set; }
        public string FileName { get; set; }
        public string ShowTitle { get; set; }
    }

    public class HistoryState
    {
        public string Text { get; set; }

        public string Type { get; set; }
        public DateTime Time { get; set; }
        public string SummaryText { get; set; }

        public string ClipboardText { get; set; }
        public string ProcessResult1 { get; set; }
        public string ProcessResult2 { get; set; }
        public string Script1 { get; set; }
        public string Script2 { get; set; }
    }
}
