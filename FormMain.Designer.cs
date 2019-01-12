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
            this.textBoxProcessedResult1 = new System.Windows.Forms.TextBox();
            this.labelProcessedResult1 = new System.Windows.Forms.Label();
            this.comboBoxPrimaryScriptFileNames = new System.Windows.Forms.ComboBox();
            this.buttonFetchClipboardText = new System.Windows.Forms.Button();
            this.checkBoxAppendProcessedResult1ToEnd = new System.Windows.Forms.CheckBox();
            this.buttonCopyProcessedResult1 = new System.Windows.Forms.Button();
            this.buttonSaveProcessedResult1AsFile = new System.Windows.Forms.Button();
            this.comboBoxHistory = new System.Windows.Forms.ComboBox();
            this.buttonHistoryPrevious = new System.Windows.Forms.Button();
            this.buttonHistoryNext = new System.Windows.Forms.Button();
            this.comboBoxSecondaryScriptFileNames = new System.Windows.Forms.ComboBox();
            this.labelProcessedResult2 = new System.Windows.Forms.Label();
            this.textBoxProcessedResult2 = new System.Windows.Forms.TextBox();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.panelClipboardTextControls = new System.Windows.Forms.Panel();
            this.checkBoxOnlyWhenFormIsActivated = new System.Windows.Forms.CheckBox();
            this.buttonProcessClipboardText = new System.Windows.Forms.Button();
            this.checkBoxAutoProcessAfterCapturing = new System.Windows.Forms.CheckBox();
            this.checkBoxAutoFetch = new System.Windows.Forms.CheckBox();
            this.splitContainerSub = new System.Windows.Forms.SplitContainer();
            this.panelProcessedResult1Controls = new System.Windows.Forms.Panel();
            this.checkBoxAutoCopyProcessedResult1 = new System.Windows.Forms.CheckBox();
            this.panelProcessedResult2Controls = new System.Windows.Forms.Panel();
            this.mainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.menuItemFile = new System.Windows.Forms.MenuItem();
            this.menuItemOptions = new System.Windows.Forms.MenuItem();
            this.menuItemHelp = new System.Windows.Forms.MenuItem();
            this.labelHistory = new System.Windows.Forms.Label();
            this.panelHistory = new System.Windows.Forms.Panel();
            this.statusBar = new System.Windows.Forms.StatusBar();
            this.panelHistoryControls = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.panelClipboardTextControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerSub)).BeginInit();
            this.splitContainerSub.Panel1.SuspendLayout();
            this.splitContainerSub.Panel2.SuspendLayout();
            this.splitContainerSub.SuspendLayout();
            this.panelProcessedResult1Controls.SuspendLayout();
            this.panelHistory.SuspendLayout();
            this.panelHistoryControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxClipboardText
            // 
            this.textBoxClipboardText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxClipboardText.Location = new System.Drawing.Point(2, 25);
            this.textBoxClipboardText.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBoxClipboardText.Multiline = true;
            this.textBoxClipboardText.Name = "textBoxClipboardText";
            this.textBoxClipboardText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxClipboardText.Size = new System.Drawing.Size(477, 124);
            this.textBoxClipboardText.TabIndex = 0;
            this.textBoxClipboardText.WordWrap = false;
            this.textBoxClipboardText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxClipboardText_KeyDown);
            // 
            // labelClipboardText
            // 
            this.labelClipboardText.AutoSize = true;
            this.labelClipboardText.Location = new System.Drawing.Point(2, 4);
            this.labelClipboardText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelClipboardText.Name = "labelClipboardText";
            this.labelClipboardText.Size = new System.Drawing.Size(74, 13);
            this.labelClipboardText.TabIndex = 1;
            this.labelClipboardText.Text = "Clipboard text:";
            // 
            // textBoxProcessedResult1
            // 
            this.textBoxProcessedResult1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxProcessedResult1.Location = new System.Drawing.Point(2, 33);
            this.textBoxProcessedResult1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBoxProcessedResult1.Multiline = true;
            this.textBoxProcessedResult1.Name = "textBoxProcessedResult1";
            this.textBoxProcessedResult1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxProcessedResult1.Size = new System.Drawing.Size(477, 130);
            this.textBoxProcessedResult1.TabIndex = 2;
            this.textBoxProcessedResult1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxClipboardText_KeyDown);
            // 
            // labelProcessedResult1
            // 
            this.labelProcessedResult1.AutoSize = true;
            this.labelProcessedResult1.Location = new System.Drawing.Point(2, 8);
            this.labelProcessedResult1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelProcessedResult1.Name = "labelProcessedResult1";
            this.labelProcessedResult1.Size = new System.Drawing.Size(88, 13);
            this.labelProcessedResult1.TabIndex = 3;
            this.labelProcessedResult1.Text = "Processed result:";
            // 
            // comboBoxPrimaryScriptFileNames
            // 
            this.comboBoxPrimaryScriptFileNames.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxPrimaryScriptFileNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPrimaryScriptFileNames.FormattingEnabled = true;
            this.comboBoxPrimaryScriptFileNames.Location = new System.Drawing.Point(175, 6);
            this.comboBoxPrimaryScriptFileNames.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.comboBoxPrimaryScriptFileNames.Name = "comboBoxPrimaryScriptFileNames";
            this.comboBoxPrimaryScriptFileNames.Size = new System.Drawing.Size(304, 21);
            this.comboBoxPrimaryScriptFileNames.TabIndex = 6;
            // 
            // buttonFetchClipboardText
            // 
            this.buttonFetchClipboardText.Location = new System.Drawing.Point(3, 3);
            this.buttonFetchClipboardText.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonFetchClipboardText.Name = "buttonFetchClipboardText";
            this.buttonFetchClipboardText.Size = new System.Drawing.Size(82, 26);
            this.buttonFetchClipboardText.TabIndex = 1;
            this.buttonFetchClipboardText.Text = "Fetch";
            this.buttonFetchClipboardText.UseVisualStyleBackColor = true;
            this.buttonFetchClipboardText.Click += new System.EventHandler(this.buttonGetClipboardText_Click);
            // 
            // checkBoxAppendProcessedResult1ToEnd
            // 
            this.checkBoxAppendProcessedResult1ToEnd.AutoSize = true;
            this.checkBoxAppendProcessedResult1ToEnd.Location = new System.Drawing.Point(5, 95);
            this.checkBoxAppendProcessedResult1ToEnd.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.checkBoxAppendProcessedResult1ToEnd.Name = "checkBoxAppendProcessedResult1ToEnd";
            this.checkBoxAppendProcessedResult1ToEnd.Size = new System.Drawing.Size(147, 17);
            this.checkBoxAppendProcessedResult1ToEnd.TabIndex = 5;
            this.checkBoxAppendProcessedResult1ToEnd.Text = "Append new result to end";
            this.checkBoxAppendProcessedResult1ToEnd.UseVisualStyleBackColor = true;
            // 
            // buttonCopyProcessedResult1
            // 
            this.buttonCopyProcessedResult1.Location = new System.Drawing.Point(3, 3);
            this.buttonCopyProcessedResult1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonCopyProcessedResult1.Name = "buttonCopyProcessedResult1";
            this.buttonCopyProcessedResult1.Size = new System.Drawing.Size(194, 26);
            this.buttonCopyProcessedResult1.TabIndex = 3;
            this.buttonCopyProcessedResult1.Text = "Copy";
            this.buttonCopyProcessedResult1.UseVisualStyleBackColor = true;
            this.buttonCopyProcessedResult1.Click += new System.EventHandler(this.buttonCopyPrimaryProcessedResult_Click);
            // 
            // buttonSaveProcessedResult1AsFile
            // 
            this.buttonSaveProcessedResult1AsFile.Location = new System.Drawing.Point(3, 33);
            this.buttonSaveProcessedResult1AsFile.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonSaveProcessedResult1AsFile.Name = "buttonSaveProcessedResult1AsFile";
            this.buttonSaveProcessedResult1AsFile.Size = new System.Drawing.Size(194, 26);
            this.buttonSaveProcessedResult1AsFile.TabIndex = 4;
            this.buttonSaveProcessedResult1AsFile.Text = "Save as file...";
            this.buttonSaveProcessedResult1AsFile.UseVisualStyleBackColor = true;
            // 
            // comboBoxHistory
            // 
            this.comboBoxHistory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxHistory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxHistory.FormattingEnabled = true;
            this.comboBoxHistory.Location = new System.Drawing.Point(52, 4);
            this.comboBoxHistory.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.comboBoxHistory.Name = "comboBoxHistory";
            this.comboBoxHistory.Size = new System.Drawing.Size(427, 21);
            this.comboBoxHistory.TabIndex = 9;
            // 
            // buttonHistoryPrevious
            // 
            this.buttonHistoryPrevious.Location = new System.Drawing.Point(3, 3);
            this.buttonHistoryPrevious.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonHistoryPrevious.Name = "buttonHistoryPrevious";
            this.buttonHistoryPrevious.Size = new System.Drawing.Size(95, 24);
            this.buttonHistoryPrevious.TabIndex = 10;
            this.buttonHistoryPrevious.Text = "<";
            this.buttonHistoryPrevious.UseVisualStyleBackColor = true;
            // 
            // buttonHistoryNext
            // 
            this.buttonHistoryNext.Location = new System.Drawing.Point(102, 3);
            this.buttonHistoryNext.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonHistoryNext.Name = "buttonHistoryNext";
            this.buttonHistoryNext.Size = new System.Drawing.Size(95, 24);
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
            this.comboBoxSecondaryScriptFileNames.Location = new System.Drawing.Point(175, 6);
            this.comboBoxSecondaryScriptFileNames.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.comboBoxSecondaryScriptFileNames.Name = "comboBoxSecondaryScriptFileNames";
            this.comboBoxSecondaryScriptFileNames.Size = new System.Drawing.Size(304, 21);
            this.comboBoxSecondaryScriptFileNames.TabIndex = 7;
            // 
            // labelProcessedResult2
            // 
            this.labelProcessedResult2.AutoSize = true;
            this.labelProcessedResult2.Location = new System.Drawing.Point(2, 8);
            this.labelProcessedResult2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelProcessedResult2.Name = "labelProcessedResult2";
            this.labelProcessedResult2.Size = new System.Drawing.Size(141, 13);
            this.labelProcessedResult2.TabIndex = 13;
            this.labelProcessedResult2.Text = "Secondary processed result:";
            // 
            // textBoxProcessedResult2
            // 
            this.textBoxProcessedResult2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxProcessedResult2.Location = new System.Drawing.Point(2, 33);
            this.textBoxProcessedResult2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBoxProcessedResult2.Multiline = true;
            this.textBoxProcessedResult2.Name = "textBoxProcessedResult2";
            this.textBoxProcessedResult2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxProcessedResult2.Size = new System.Drawing.Size(477, 97);
            this.textBoxProcessedResult2.TabIndex = 5;
            this.textBoxProcessedResult2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxClipboardText_KeyDown);
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerMain.Location = new System.Drawing.Point(9, 5);
            this.splitContainerMain.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.splitContainerMain.Name = "splitContainerMain";
            this.splitContainerMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.panelClipboardTextControls);
            this.splitContainerMain.Panel1.Controls.Add(this.textBoxClipboardText);
            this.splitContainerMain.Panel1.Controls.Add(this.labelClipboardText);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.splitContainerSub);
            this.splitContainerMain.Size = new System.Drawing.Size(686, 456);
            this.splitContainerMain.SplitterDistance = 152;
            this.splitContainerMain.SplitterWidth = 3;
            this.splitContainerMain.TabIndex = 0;
            // 
            // panelClipboardTextControls
            // 
            this.panelClipboardTextControls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelClipboardTextControls.AutoScroll = true;
            this.panelClipboardTextControls.Controls.Add(this.buttonFetchClipboardText);
            this.panelClipboardTextControls.Controls.Add(this.checkBoxOnlyWhenFormIsActivated);
            this.panelClipboardTextControls.Controls.Add(this.buttonProcessClipboardText);
            this.panelClipboardTextControls.Controls.Add(this.checkBoxAutoProcessAfterCapturing);
            this.panelClipboardTextControls.Controls.Add(this.checkBoxAutoFetch);
            this.panelClipboardTextControls.Location = new System.Drawing.Point(483, 22);
            this.panelClipboardTextControls.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panelClipboardTextControls.Name = "panelClipboardTextControls";
            this.panelClipboardTextControls.Size = new System.Drawing.Size(200, 127);
            this.panelClipboardTextControls.TabIndex = 6;
            // 
            // checkBoxOnlyWhenFormIsActivated
            // 
            this.checkBoxOnlyWhenFormIsActivated.AutoSize = true;
            this.checkBoxOnlyWhenFormIsActivated.Checked = true;
            this.checkBoxOnlyWhenFormIsActivated.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxOnlyWhenFormIsActivated.Location = new System.Drawing.Point(22, 91);
            this.checkBoxOnlyWhenFormIsActivated.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.checkBoxOnlyWhenFormIsActivated.Name = "checkBoxOnlyWhenFormIsActivated";
            this.checkBoxOnlyWhenFormIsActivated.Size = new System.Drawing.Size(156, 17);
            this.checkBoxOnlyWhenFormIsActivated.TabIndex = 4;
            this.checkBoxOnlyWhenFormIsActivated.Text = "Only when form is activated";
            this.checkBoxOnlyWhenFormIsActivated.UseVisualStyleBackColor = true;
            // 
            // buttonProcessClipboardText
            // 
            this.buttonProcessClipboardText.Location = new System.Drawing.Point(89, 3);
            this.buttonProcessClipboardText.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonProcessClipboardText.Name = "buttonProcessClipboardText";
            this.buttonProcessClipboardText.Size = new System.Drawing.Size(109, 26);
            this.buttonProcessClipboardText.TabIndex = 5;
            this.buttonProcessClipboardText.Text = "Process";
            this.buttonProcessClipboardText.UseVisualStyleBackColor = true;
            this.buttonProcessClipboardText.Click += new System.EventHandler(this.buttonProcess_Click);
            // 
            // checkBoxAutoProcessAfterCapturing
            // 
            this.checkBoxAutoProcessAfterCapturing.AutoSize = true;
            this.checkBoxAutoProcessAfterCapturing.Checked = true;
            this.checkBoxAutoProcessAfterCapturing.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAutoProcessAfterCapturing.Location = new System.Drawing.Point(22, 68);
            this.checkBoxAutoProcessAfterCapturing.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.checkBoxAutoProcessAfterCapturing.Name = "checkBoxAutoProcessAfterCapturing";
            this.checkBoxAutoProcessAfterCapturing.Size = new System.Drawing.Size(153, 17);
            this.checkBoxAutoProcessAfterCapturing.TabIndex = 3;
            this.checkBoxAutoProcessAfterCapturing.Text = "Auto process after fetching";
            this.checkBoxAutoProcessAfterCapturing.UseVisualStyleBackColor = true;
            // 
            // checkBoxAutoFetch
            // 
            this.checkBoxAutoFetch.AutoSize = true;
            this.checkBoxAutoFetch.Checked = true;
            this.checkBoxAutoFetch.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAutoFetch.Location = new System.Drawing.Point(5, 45);
            this.checkBoxAutoFetch.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.checkBoxAutoFetch.Name = "checkBoxAutoFetch";
            this.checkBoxAutoFetch.Size = new System.Drawing.Size(75, 17);
            this.checkBoxAutoFetch.TabIndex = 2;
            this.checkBoxAutoFetch.Text = "Auto fetch";
            this.checkBoxAutoFetch.UseVisualStyleBackColor = true;
            // 
            // splitContainerSub
            // 
            this.splitContainerSub.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerSub.Location = new System.Drawing.Point(0, 0);
            this.splitContainerSub.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.splitContainerSub.Name = "splitContainerSub";
            this.splitContainerSub.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerSub.Panel1
            // 
            this.splitContainerSub.Panel1.Controls.Add(this.panelProcessedResult1Controls);
            this.splitContainerSub.Panel1.Controls.Add(this.textBoxProcessedResult1);
            this.splitContainerSub.Panel1.Controls.Add(this.labelProcessedResult1);
            this.splitContainerSub.Panel1.Controls.Add(this.comboBoxPrimaryScriptFileNames);
            // 
            // splitContainerSub.Panel2
            // 
            this.splitContainerSub.Panel2.Controls.Add(this.panelProcessedResult2Controls);
            this.splitContainerSub.Panel2.Controls.Add(this.comboBoxSecondaryScriptFileNames);
            this.splitContainerSub.Panel2.Controls.Add(this.textBoxProcessedResult2);
            this.splitContainerSub.Panel2.Controls.Add(this.labelProcessedResult2);
            this.splitContainerSub.Size = new System.Drawing.Size(686, 301);
            this.splitContainerSub.SplitterDistance = 166;
            this.splitContainerSub.SplitterWidth = 3;
            this.splitContainerSub.TabIndex = 0;
            // 
            // panelProcessedResult1Controls
            // 
            this.panelProcessedResult1Controls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelProcessedResult1Controls.AutoScroll = true;
            this.panelProcessedResult1Controls.Controls.Add(this.buttonCopyProcessedResult1);
            this.panelProcessedResult1Controls.Controls.Add(this.checkBoxAutoCopyProcessedResult1);
            this.panelProcessedResult1Controls.Controls.Add(this.buttonSaveProcessedResult1AsFile);
            this.panelProcessedResult1Controls.Controls.Add(this.checkBoxAppendProcessedResult1ToEnd);
            this.panelProcessedResult1Controls.Location = new System.Drawing.Point(483, 30);
            this.panelProcessedResult1Controls.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panelProcessedResult1Controls.Name = "panelProcessedResult1Controls";
            this.panelProcessedResult1Controls.Size = new System.Drawing.Size(200, 133);
            this.panelProcessedResult1Controls.TabIndex = 8;
            // 
            // checkBoxAutoCopyProcessedResult1
            // 
            this.checkBoxAutoCopyProcessedResult1.AutoSize = true;
            this.checkBoxAutoCopyProcessedResult1.Location = new System.Drawing.Point(5, 72);
            this.checkBoxAutoCopyProcessedResult1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.checkBoxAutoCopyProcessedResult1.Name = "checkBoxAutoCopyProcessedResult1";
            this.checkBoxAutoCopyProcessedResult1.Size = new System.Drawing.Size(132, 17);
            this.checkBoxAutoCopyProcessedResult1.TabIndex = 7;
            this.checkBoxAutoCopyProcessedResult1.Text = "Auto copy to clipboard";
            this.checkBoxAutoCopyProcessedResult1.UseVisualStyleBackColor = true;
            // 
            // panelProcessedResult2Controls
            // 
            this.panelProcessedResult2Controls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelProcessedResult2Controls.AutoScroll = true;
            this.panelProcessedResult2Controls.Location = new System.Drawing.Point(483, 30);
            this.panelProcessedResult2Controls.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panelProcessedResult2Controls.Name = "panelProcessedResult2Controls";
            this.panelProcessedResult2Controls.Size = new System.Drawing.Size(200, 100);
            this.panelProcessedResult2Controls.TabIndex = 14;
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
            this.labelHistory.AutoSize = true;
            this.labelHistory.Location = new System.Drawing.Point(2, 7);
            this.labelHistory.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelHistory.Name = "labelHistory";
            this.labelHistory.Size = new System.Drawing.Size(42, 13);
            this.labelHistory.TabIndex = 16;
            this.labelHistory.Text = "History:";
            // 
            // panelHistory
            // 
            this.panelHistory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelHistory.Controls.Add(this.buttonHistoryPrevious);
            this.panelHistory.Controls.Add(this.buttonHistoryNext);
            this.panelHistory.Location = new System.Drawing.Point(483, 0);
            this.panelHistory.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panelHistory.Name = "panelHistory";
            this.panelHistory.Size = new System.Drawing.Size(200, 30);
            this.panelHistory.TabIndex = 17;
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 503);
            this.statusBar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(704, 18);
            this.statusBar.TabIndex = 18;
            // 
            // panelHistoryControls
            // 
            this.panelHistoryControls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelHistoryControls.Controls.Add(this.labelHistory);
            this.panelHistoryControls.Controls.Add(this.comboBoxHistory);
            this.panelHistoryControls.Controls.Add(this.panelHistory);
            this.panelHistoryControls.Location = new System.Drawing.Point(9, 466);
            this.panelHistoryControls.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panelHistoryControls.Name = "panelHistoryControls";
            this.panelHistoryControls.Size = new System.Drawing.Size(686, 30);
            this.panelHistoryControls.TabIndex = 19;
            // 
            // FormMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(704, 521);
            this.Controls.Add(this.panelHistoryControls);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.splitContainerMain);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MinimumSize = new System.Drawing.Size(453, 480);
            this.Name = "FormMain";
            this.Text = "Clipboard Auto Processor";
            this.Activated += new System.EventHandler(this.FormMain_Activated);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel1.PerformLayout();
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.panelClipboardTextControls.ResumeLayout(false);
            this.panelClipboardTextControls.PerformLayout();
            this.splitContainerSub.Panel1.ResumeLayout(false);
            this.splitContainerSub.Panel1.PerformLayout();
            this.splitContainerSub.Panel2.ResumeLayout(false);
            this.splitContainerSub.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerSub)).EndInit();
            this.splitContainerSub.ResumeLayout(false);
            this.panelProcessedResult1Controls.ResumeLayout(false);
            this.panelProcessedResult1Controls.PerformLayout();
            this.panelHistory.ResumeLayout(false);
            this.panelHistoryControls.ResumeLayout(false);
            this.panelHistoryControls.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxClipboardText;
        private System.Windows.Forms.Label labelClipboardText;
        private System.Windows.Forms.TextBox textBoxProcessedResult1;
        private System.Windows.Forms.Label labelProcessedResult1;
        private System.Windows.Forms.ComboBox comboBoxPrimaryScriptFileNames;
        private System.Windows.Forms.Button buttonFetchClipboardText;
        private System.Windows.Forms.CheckBox checkBoxAppendProcessedResult1ToEnd;
        private System.Windows.Forms.Button buttonCopyProcessedResult1;
        private System.Windows.Forms.Button buttonSaveProcessedResult1AsFile;
        private System.Windows.Forms.ComboBox comboBoxHistory;
        private System.Windows.Forms.Button buttonHistoryPrevious;
        private System.Windows.Forms.Button buttonHistoryNext;
        private System.Windows.Forms.ComboBox comboBoxSecondaryScriptFileNames;
        private System.Windows.Forms.Label labelProcessedResult2;
        private System.Windows.Forms.TextBox textBoxProcessedResult2;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.SplitContainer splitContainerSub;
        private System.Windows.Forms.MainMenu mainMenu;
        private System.Windows.Forms.MenuItem menuItemFile;
        private System.Windows.Forms.MenuItem menuItemOptions;
        private System.Windows.Forms.MenuItem menuItemHelp;
        private System.Windows.Forms.Label labelHistory;
        private System.Windows.Forms.CheckBox checkBoxAutoProcessAfterCapturing;
        private System.Windows.Forms.CheckBox checkBoxAutoFetch;
        private System.Windows.Forms.CheckBox checkBoxOnlyWhenFormIsActivated;
        private System.Windows.Forms.CheckBox checkBoxAutoCopyProcessedResult1;
        private System.Windows.Forms.Button buttonProcessClipboardText;
        private System.Windows.Forms.Panel panelClipboardTextControls;
        private System.Windows.Forms.Panel panelProcessedResult1Controls;
        private System.Windows.Forms.Panel panelProcessedResult2Controls;
        private System.Windows.Forms.Panel panelHistory;
        private System.Windows.Forms.StatusBar statusBar;
        private System.Windows.Forms.Panel panelHistoryControls;
    }
}

