using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace ClipboardAutoProcessor
{
    public partial class FormMain : Form
    {
        private Preferences m_preferences = new Preferences();

        private string m_path_current_directory;

        private string m_path_processors_1;
        private string m_path_processors_2;

        private BindingList<ProcessorScript> m_processor_scripts_1;
        private BindingList<ProcessorScript> m_processor_scripts_2;

        private string m_current_clipboard_text = "";

        private BindingList<HistoryState> m_history_states;

        public FormMain()
        {
            m_path_current_directory = Path.GetFullPath(".");

            m_path_processors_1 = m_path_current_directory + "\\processors";
            m_path_processors_2 = m_path_current_directory + "\\processors2";

            m_processor_scripts_1 = GetProcessorScripts(m_path_processors_1);
            m_processor_scripts_2 = GetProcessorScripts(m_path_processors_2);

            this.Font = SystemFonts.MessageBoxFont;

            InitializeComponent();
        }

        private BindingList<ProcessorScript> GetProcessorScripts(string path)
        {
            BindingList<ProcessorScript> processor_scripts = new BindingList<ProcessorScript>();

            string[] files = Directory.GetFiles(path);

            foreach (string file in files)
            {
                string extension = Path.GetExtension(file).TrimStart('.').ToLower();

                if (!m_preferences.IsSupportedFileExtension(extension))
                {
                    continue;
                }

                ProcessorScript item = new ProcessorScript()
                {
                    FullPath = Path.GetFullPath(file),
                    FileName = Path.GetFileName(file),
                    ShowTitle = Path.GetFileName(file),
                };

                processor_scripts.Add(item);
            }

            return processor_scripts;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            // To avoid the bug of MainMenu control handling in Visual Studio designer
            this.Menu = mainMenu1;

            comboBoxScriptFileNames.ValueMember = null;
            comboBoxScriptFileNames.DisplayMember = "ShowTitle";
            comboBoxScriptFileNames.DataSource = m_processor_scripts_1;
            
            if (comboBoxScriptFileNames.Items.Count > 0)
            {
                comboBoxScriptFileNames.SelectedIndex = 0;
            }

            m_history_states = new BindingList<HistoryState>();

            comboBoxHistory.ValueMember = null;
            comboBoxHistory.DisplayMember = "Text";
            comboBoxHistory.DataSource = m_history_states;
        }

        private void SetClipboardText(string clipboard_text)
        {
            if (clipboard_text.Length > (1024 * 1024))
            {
                return;
            }

            m_current_clipboard_text = clipboard_text;

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

            string script_file_name = comboBoxScriptFileNames.Text;
            string script_file_fullpath = Path.GetFullPath(m_path_current_directory + "\\processors\\" + script_file_name);

            if (!File.Exists(script_file_fullpath))
            {
                return;
            }

            string script_file_extension = Path.GetExtension(script_file_fullpath).TrimStart('.').ToLower();
            ScriptExecuteCommandLine script_cmd = m_preferences.GetScriptExecuteCommandLine(script_file_extension);

            Process process = new Process();
            process.StartInfo.FileName = script_cmd.ExecutableProgram.Replace("<filename>", script_file_fullpath);
            process.StartInfo.Arguments = script_cmd.CommandLineArguments.Replace("<filename>", script_file_fullpath);
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

            if (checkBoxAppendMode.Checked)
            {
                if (textBoxResult1.Text == "")
                {
                    textBoxResult1.Text = text2;
                }
                else
                {
                    textBoxResult1.Text += "\r\n" + text2;
                }
            }
            else
            {
                textBoxResult1.Text = text2;
            }

            if (!process.HasExited)
            {
                process.Kill();
            }

            string summary_text = Regex.Replace(text, "/[\\t\\r\\n]/", " ").Trim();
            if (summary_text.Length > 50)
            {
                summary_text = summary_text.Substring(0, 47) + "...";
            }

            HistoryState history_state = new HistoryState()
            {
                Type = "Auto",
                Time = DateTime.Now,
                SummaryText = summary_text
            };

            history_state.Text = String.Format("[{0}] ({1:H:mm:ss}) {2}",
                history_state.Type, history_state.Time, history_state.SummaryText);

            m_history_states.Add(history_state);

            if (comboBoxHistory.Items.Count > 0)
            {
                comboBoxHistory.SelectedIndex = comboBoxHistory.Items.Count - 1;
            }

            if (checkBoxAutoCopyResult1.Checked)
            {
                Clipboard.SetText(textBoxResult1.Text);

                m_current_clipboard_text = Clipboard.GetText();
            }

            textBoxResult1.Select(textBoxResult1.Text.Length, 0);
            textBoxResult1.Focus();
        }

        private void FormMain_Activated(object sender, EventArgs e)
        {
            if (!checkBoxOnlyWhenFormIsActivated.Enabled
                || !checkBoxOnlyWhenFormIsActivated.Checked)
            {
                return;
            }

            string clipboard_text = Clipboard.GetText();

            if (clipboard_text != m_current_clipboard_text)
            {
                SetClipboardText(clipboard_text);

                if (checkBoxAutoProcessAfterCapturing.Enabled
                    && checkBoxAutoProcessAfterCapturing.Checked)
                {
                    CallProcessor();
                }
            }
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control & e.KeyCode == Keys.A)
            {
                ((TextBox)sender).SelectAll();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBoxResult1.Text);

            m_current_clipboard_text = Clipboard.GetText();
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
