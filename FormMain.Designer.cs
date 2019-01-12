namespace ClipboardAutoProcessor
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBoxClipboardText = new System.Windows.Forms.TextBox();
            this.labelClipboardText = new System.Windows.Forms.Label();
            this.textBoxPrimaryProcessedResult = new System.Windows.Forms.TextBox();
            this.labelPrimaryProcessedResult = new System.Windows.Forms.Label();
            this.comboBoxPrimaryScriptFileNames = new System.Windows.Forms.ComboBox();
            this.buttonGetClipboardText = new System.Windows.Forms.Button();
            this.checkBoxAppendPrimaryProcessedResultToEnd = new System.Windows.Forms.CheckBox();
            this.buttonCopyPrimaryProcessedResult = new System.Windows.Forms.Button();
            this.buttonSavePrimaryProcessedResultAsFile = new System.Windows.Forms.Button();
            this.comboBoxHistory = new System.Windows.Forms.ComboBox();
            this.buttonHistoryPrevious = new System.Windows.Forms.Button();
            this.buttonHistoryNext = new System.Windows.Forms.Button();
            this.comboBoxSecondaryScriptFileNames = new System.Windows.Forms.ComboBox();
            this.labelSecondaryProcessedResult = new System.Windows.Forms.Label();
            this.textBoxSecondaryProcessedResult = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.buttonProcess = new System.Windows.Forms.Button();
            this.checkBoxOnlyWhenFormIsActivated = new System.Windows.Forms.CheckBox();
            this.checkBoxAutoProcessAfterCapturing = new System.Windows.Forms.CheckBox();
            this.checkBoxAutoFetch = new System.Windows.Forms.CheckBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.checkBoxAutoCopyPrimaryProcessedResult = new System.Windows.Forms.CheckBox();
            this.mainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.menuItemFile = new System.Windows.Forms.MenuItem();
            this.menuItemOptions = new System.Windows.Forms.MenuItem();
            this.menuItemHelp = new System.Windows.Forms.MenuItem();
            this.labelHistory = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxClipboardText
            // 
            this.textBoxClipboardText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxClipboardText.Location = new System.Drawing.Point(3, 30);
            this.textBoxClipboardText.Multiline = true;
            this.textBoxClipboardText.Name = "textBoxClipboardText";
            this.textBoxClipboardText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxClipboardText.Size = new System.Drawing.Size(560, 125);
            this.textBoxClipboardText.TabIndex = 0;
            this.textBoxClipboardText.WordWrap = false;
            this.textBoxClipboardText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxClipboardText_KeyDown);
            // 
            // labelClipboardText
            // 
            this.labelClipboardText.AutoSize = true;
            this.labelClipboardText.Location = new System.Drawing.Point(3, 5);
            this.labelClipboardText.Name = "labelClipboardText";
            this.labelClipboardText.Size = new System.Drawing.Size(98, 17);
            this.labelClipboardText.TabIndex = 1;
            this.labelClipboardText.Text = "Clipboard text:";
            // 
            // textBoxPrimaryProcessedResult
            // 
            this.textBoxPrimaryProcessedResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPrimaryProcessedResult.Location = new System.Drawing.Point(3, 35);
            this.textBoxPrimaryProcessedResult.Multiline = true;
            this.textBoxPrimaryProcessedResult.Name = "textBoxPrimaryProcessedResult";
            this.textBoxPrimaryProcessedResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxPrimaryProcessedResult.Size = new System.Drawing.Size(560, 135);
            this.textBoxPrimaryProcessedResult.TabIndex = 2;
            this.textBoxPrimaryProcessedResult.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxClipboardText_KeyDown);
            // 
            // labelPrimaryProcessedResult
            // 
            this.labelPrimaryProcessedResult.AutoSize = true;
            this.labelPrimaryProcessedResult.Location = new System.Drawing.Point(3, 10);
            this.labelPrimaryProcessedResult.Name = "labelPrimaryProcessedResult";
            this.labelPrimaryProcessedResult.Size = new System.Drawing.Size(118, 17);
            this.labelPrimaryProcessedResult.TabIndex = 3;
            this.labelPrimaryProcessedResult.Text = "Processed result:";
            // 
            // comboBoxPrimaryScriptFileNames
            // 
            this.comboBoxPrimaryScriptFileNames.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxPrimaryScriptFileNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPrimaryScriptFileNames.FormattingEnabled = true;
            this.comboBoxPrimaryScriptFileNames.Location = new System.Drawing.Point(233, 7);
            this.comboBoxPrimaryScriptFileNames.Name = "comboBoxPrimaryScriptFileNames";
            this.comboBoxPrimaryScriptFileNames.Size = new System.Drawing.Size(330, 24);
            this.comboBoxPrimaryScriptFileNames.TabIndex = 6;
            // 
            // buttonGetClipboardText
            // 
            this.buttonGetClipboardText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGetClipboardText.Location = new System.Drawing.Point(569, 30);
            this.buttonGetClipboardText.Name = "buttonGetClipboardText";
            this.buttonGetClipboardText.Size = new System.Drawing.Size(80, 28);
            this.buttonGetClipboardText.TabIndex = 1;
            this.buttonGetClipboardText.Text = "Fetch";
            this.buttonGetClipboardText.UseVisualStyleBackColor = true;
            this.buttonGetClipboardText.Click += new System.EventHandler(this.buttonGetClipboardText_Click);
            // 
            // checkBoxAppendPrimaryProcessedResultToEnd
            // 
            this.checkBoxAppendPrimaryProcessedResultToEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxAppendPrimaryProcessedResultToEnd.Location = new System.Drawing.Point(570, 149);
            this.checkBoxAppendPrimaryProcessedResultToEnd.Name = "checkBoxAppendPrimaryProcessedResultToEnd";
            this.checkBoxAppendPrimaryProcessedResultToEnd.Size = new System.Drawing.Size(160, 21);
            this.checkBoxAppendPrimaryProcessedResultToEnd.TabIndex = 5;
            this.checkBoxAppendPrimaryProcessedResultToEnd.Text = "Append new result";
            this.checkBoxAppendPrimaryProcessedResultToEnd.UseVisualStyleBackColor = true;
            // 
            // buttonCopyPrimaryProcessedResult
            // 
            this.buttonCopyPrimaryProcessedResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCopyPrimaryProcessedResult.Location = new System.Drawing.Point(569, 35);
            this.buttonCopyPrimaryProcessedResult.Name = "buttonCopyPrimaryProcessedResult";
            this.buttonCopyPrimaryProcessedResult.Size = new System.Drawing.Size(186, 28);
            this.buttonCopyPrimaryProcessedResult.TabIndex = 3;
            this.buttonCopyPrimaryProcessedResult.Text = "Copy";
            this.buttonCopyPrimaryProcessedResult.UseVisualStyleBackColor = true;
            this.buttonCopyPrimaryProcessedResult.Click += new System.EventHandler(this.buttonCopyPrimaryProcessedResult_Click);
            // 
            // buttonSavePrimaryProcessedResultAsFile
            // 
            this.buttonSavePrimaryProcessedResultAsFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSavePrimaryProcessedResultAsFile.Location = new System.Drawing.Point(569, 69);
            this.buttonSavePrimaryProcessedResultAsFile.Name = "buttonSavePrimaryProcessedResultAsFile";
            this.buttonSavePrimaryProcessedResultAsFile.Size = new System.Drawing.Size(186, 28);
            this.buttonSavePrimaryProcessedResultAsFile.TabIndex = 4;
            this.buttonSavePrimaryProcessedResultAsFile.Text = "Save as file...";
            this.buttonSavePrimaryProcessedResultAsFile.UseVisualStyleBackColor = true;
            // 
            // comboBoxHistory
            // 
            this.comboBoxHistory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxHistory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxHistory.FormattingEnabled = true;
            this.comboBoxHistory.Location = new System.Drawing.Point(77, 539);
            this.comboBoxHistory.Name = "comboBoxHistory";
            this.comboBoxHistory.Size = new System.Drawing.Size(498, 24);
            this.comboBoxHistory.TabIndex = 9;
            // 
            // buttonHistoryPrevious
            // 
            this.buttonHistoryPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonHistoryPrevious.Location = new System.Drawing.Point(581, 538);
            this.buttonHistoryPrevious.Name = "buttonHistoryPrevious";
            this.buttonHistoryPrevious.Size = new System.Drawing.Size(90, 26);
            this.buttonHistoryPrevious.TabIndex = 10;
            this.buttonHistoryPrevious.Text = "<";
            this.buttonHistoryPrevious.UseVisualStyleBackColor = true;
            // 
            // buttonHistoryNext
            // 
            this.buttonHistoryNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonHistoryNext.Location = new System.Drawing.Point(677, 538);
            this.buttonHistoryNext.Name = "buttonHistoryNext";
            this.buttonHistoryNext.Size = new System.Drawing.Size(90, 26);
            this.buttonHistoryNext.TabIndex = 11;
            this.buttonHistoryNext.Text = ">";
            this.buttonHistoryNext.UseVisualStyleBackColor = true;
            // 
            // comboBoxSecondaryScriptFileNames
            // 
            this.comboBoxSecondaryScriptFileNames.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxSecondaryScriptFileNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSecondaryScriptFileNames.FormattingEnabled = true;
            this.comboBoxSecondaryScriptFileNames.Location = new System.Drawing.Point(233, 7);
            this.comboBoxSecondaryScriptFileNames.Name = "comboBoxSecondaryScriptFileNames";
            this.comboBoxSecondaryScriptFileNames.Size = new System.Drawing.Size(330, 24);
            this.comboBoxSecondaryScriptFileNames.TabIndex = 7;
            // 
            // labelSecondaryProcessedResult
            // 
            this.labelSecondaryProcessedResult.AutoSize = true;
            this.labelSecondaryProcessedResult.Location = new System.Drawing.Point(3, 10);
            this.labelSecondaryProcessedResult.Name = "labelSecondaryProcessedResult";
            this.labelSecondaryProcessedResult.Size = new System.Drawing.Size(189, 17);
            this.labelSecondaryProcessedResult.TabIndex = 13;
            this.labelSecondaryProcessedResult.Text = "Secondary processed result:";
            // 
            // textBoxSecondaryProcessedResult
            // 
            this.textBoxSecondaryProcessedResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSecondaryProcessedResult.Location = new System.Drawing.Point(3, 35);
            this.textBoxSecondaryProcessedResult.Multiline = true;
            this.textBoxSecondaryProcessedResult.Name = "textBoxSecondaryProcessedResult";
            this.textBoxSecondaryProcessedResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxSecondaryProcessedResult.Size = new System.Drawing.Size(560, 135);
            this.textBoxSecondaryProcessedResult.TabIndex = 5;
            this.textBoxSecondaryProcessedResult.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxClipboardText_KeyDown);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 6);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.buttonProcess);
            this.splitContainer1.Panel1.Controls.Add(this.checkBoxOnlyWhenFormIsActivated);
            this.splitContainer1.Panel1.Controls.Add(this.checkBoxAutoProcessAfterCapturing);
            this.splitContainer1.Panel1.Controls.Add(this.checkBoxAutoFetch);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxClipboardText);
            this.splitContainer1.Panel1.Controls.Add(this.labelClipboardText);
            this.splitContainer1.Panel1.Controls.Add(this.buttonGetClipboardText);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(758, 520);
            this.splitContainer1.SplitterDistance = 160;
            this.splitContainer1.TabIndex = 0;
            // 
            // buttonProcess
            // 
            this.buttonProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonProcess.Location = new System.Drawing.Point(655, 30);
            this.buttonProcess.Name = "buttonProcess";
            this.buttonProcess.Size = new System.Drawing.Size(100, 28);
            this.buttonProcess.TabIndex = 5;
            this.buttonProcess.Text = "Process";
            this.buttonProcess.UseVisualStyleBackColor = true;
            this.buttonProcess.Click += new System.EventHandler(this.buttonProcess_Click);
            // 
            // checkBoxOnlyWhenFormIsActivated
            // 
            this.checkBoxOnlyWhenFormIsActivated.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxOnlyWhenFormIsActivated.Checked = true;
            this.checkBoxOnlyWhenFormIsActivated.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxOnlyWhenFormIsActivated.Location = new System.Drawing.Point(593, 134);
            this.checkBoxOnlyWhenFormIsActivated.Name = "checkBoxOnlyWhenFormIsActivated";
            this.checkBoxOnlyWhenFormIsActivated.Size = new System.Drawing.Size(145, 21);
            this.checkBoxOnlyWhenFormIsActivated.TabIndex = 4;
            this.checkBoxOnlyWhenFormIsActivated.Text = "Only when activated";
            this.checkBoxOnlyWhenFormIsActivated.UseVisualStyleBackColor = true;
            // 
            // checkBoxAutoProcessAfterCapturing
            // 
            this.checkBoxAutoProcessAfterCapturing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxAutoProcessAfterCapturing.Checked = true;
            this.checkBoxAutoProcessAfterCapturing.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAutoProcessAfterCapturing.Location = new System.Drawing.Point(593, 109);
            this.checkBoxAutoProcessAfterCapturing.Name = "checkBoxAutoProcessAfterCapturing";
            this.checkBoxAutoProcessAfterCapturing.Size = new System.Drawing.Size(145, 21);
            this.checkBoxAutoProcessAfterCapturing.TabIndex = 3;
            this.checkBoxAutoProcessAfterCapturing.Text = "Auto process";
            this.checkBoxAutoProcessAfterCapturing.UseVisualStyleBackColor = true;
            // 
            // checkBoxAutoFetch
            // 
            this.checkBoxAutoFetch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxAutoFetch.Checked = true;
            this.checkBoxAutoFetch.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAutoFetch.Location = new System.Drawing.Point(570, 84);
            this.checkBoxAutoFetch.Name = "checkBoxAutoFetch";
            this.checkBoxAutoFetch.Size = new System.Drawing.Size(110, 21);
            this.checkBoxAutoFetch.TabIndex = 2;
            this.checkBoxAutoFetch.Text = "Auto fetch";
            this.checkBoxAutoFetch.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.checkBoxAutoCopyPrimaryProcessedResult);
            this.splitContainer2.Panel1.Controls.Add(this.textBoxPrimaryProcessedResult);
            this.splitContainer2.Panel1.Controls.Add(this.labelPrimaryProcessedResult);
            this.splitContainer2.Panel1.Controls.Add(this.comboBoxPrimaryScriptFileNames);
            this.splitContainer2.Panel1.Controls.Add(this.buttonCopyPrimaryProcessedResult);
            this.splitContainer2.Panel1.Controls.Add(this.checkBoxAppendPrimaryProcessedResultToEnd);
            this.splitContainer2.Panel1.Controls.Add(this.buttonSavePrimaryProcessedResultAsFile);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.comboBoxSecondaryScriptFileNames);
            this.splitContainer2.Panel2.Controls.Add(this.textBoxSecondaryProcessedResult);
            this.splitContainer2.Panel2.Controls.Add(this.labelSecondaryProcessedResult);
            this.splitContainer2.Size = new System.Drawing.Size(758, 356);
            this.splitContainer2.SplitterDistance = 175;
            this.splitContainer2.TabIndex = 0;
            // 
            // checkBoxAutoCopyPrimaryProcessedResult
            // 
            this.checkBoxAutoCopyPrimaryProcessedResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxAutoCopyPrimaryProcessedResult.Location = new System.Drawing.Point(570, 108);
            this.checkBoxAutoCopyPrimaryProcessedResult.Name = "checkBoxAutoCopyPrimaryProcessedResult";
            this.checkBoxAutoCopyPrimaryProcessedResult.Size = new System.Drawing.Size(180, 21);
            this.checkBoxAutoCopyPrimaryProcessedResult.TabIndex = 7;
            this.checkBoxAutoCopyPrimaryProcessedResult.Text = "Auto copy to clipboard";
            this.checkBoxAutoCopyPrimaryProcessedResult.UseVisualStyleBackColor = true;
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemFile,
            this.menuItemOptions,
            this.menuItemHelp});
            // 
            // menuItemFile
            // 
            this.menuItemFile.Index = 0;
            this.menuItemFile.Text = "&File";
            // 
            // menuItemOptions
            // 
            this.menuItemOptions.Index = 1;
            this.menuItemOptions.Text = "&Options";
            // 
            // menuItemHelp
            // 
            this.menuItemHelp.Index = 2;
            this.menuItemHelp.Text = "&Help";
            // 
            // labelHistory
            // 
            this.labelHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelHistory.AutoSize = true;
            this.labelHistory.Location = new System.Drawing.Point(15, 543);
            this.labelHistory.Name = "labelHistory";
            this.labelHistory.Size = new System.Drawing.Size(56, 17);
            this.labelHistory.TabIndex = 16;
            this.labelHistory.Text = "History:";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(782, 577);
            this.Controls.Add(this.labelHistory);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.buttonHistoryNext);
            this.Controls.Add(this.buttonHistoryPrevious);
            this.Controls.Add(this.comboBoxHistory);
            this.MinimumSize = new System.Drawing.Size(600, 600);
            this.Name = "FormMain";
            this.Text = "Clipboard Auto Processor";
            this.Activated += new System.EventHandler(this.FormMain_Activated);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxClipboardText;
        private System.Windows.Forms.Label labelClipboardText;
        private System.Windows.Forms.TextBox textBoxPrimaryProcessedResult;
        private System.Windows.Forms.Label labelPrimaryProcessedResult;
        private System.Windows.Forms.ComboBox comboBoxPrimaryScriptFileNames;
        private System.Windows.Forms.Button buttonGetClipboardText;
        private System.Windows.Forms.CheckBox checkBoxAppendPrimaryProcessedResultToEnd;
        private System.Windows.Forms.Button buttonCopyPrimaryProcessedResult;
        private System.Windows.Forms.Button buttonSavePrimaryProcessedResultAsFile;
        private System.Windows.Forms.ComboBox comboBoxHistory;
        private System.Windows.Forms.Button buttonHistoryPrevious;
        private System.Windows.Forms.Button buttonHistoryNext;
        private System.Windows.Forms.ComboBox comboBoxSecondaryScriptFileNames;
        private System.Windows.Forms.Label labelSecondaryProcessedResult;
        private System.Windows.Forms.TextBox textBoxSecondaryProcessedResult;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.MainMenu mainMenu;
        private System.Windows.Forms.MenuItem menuItemFile;
        private System.Windows.Forms.MenuItem menuItemOptions;
        private System.Windows.Forms.MenuItem menuItemHelp;
        private System.Windows.Forms.Label labelHistory;
        private System.Windows.Forms.CheckBox checkBoxAutoProcessAfterCapturing;
        private System.Windows.Forms.CheckBox checkBoxAutoFetch;
        private System.Windows.Forms.CheckBox checkBoxOnlyWhenFormIsActivated;
        private System.Windows.Forms.CheckBox checkBoxAutoCopyPrimaryProcessedResult;
        private System.Windows.Forms.Button buttonProcess;
    }
}

