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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.textBoxClipboardText = new System.Windows.Forms.TextBox();
            this.labelClipboardText = new System.Windows.Forms.Label();
            this.textBoxProcessedResult1 = new System.Windows.Forms.TextBox();
            this.labelProcessedResult1 = new System.Windows.Forms.Label();
            this.comboBoxScriptFileList1 = new System.Windows.Forms.ComboBox();
            this.buttonClipboardTextFetch = new System.Windows.Forms.Button();
            this.checkBoxProcessedResult1AppendToEnd = new System.Windows.Forms.CheckBox();
            this.buttonProcessedResult1Copy = new System.Windows.Forms.Button();
            this.buttonProcessedResult1SaveAsFile = new System.Windows.Forms.Button();
            this.comboBoxHistoryOperationList = new System.Windows.Forms.ComboBox();
            this.buttonHistoryPrevious = new System.Windows.Forms.Button();
            this.buttonHistoryNext = new System.Windows.Forms.Button();
            this.comboBoxScriptFileList2 = new System.Windows.Forms.ComboBox();
            this.labelProcessedResult2 = new System.Windows.Forms.Label();
            this.textBoxProcessedResult2 = new System.Windows.Forms.TextBox();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanelClipboardText = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelClipboardTextControls = new System.Windows.Forms.TableLayoutPanel();
            this.checkBoxClipboardTextAutoFetch = new System.Windows.Forms.CheckBox();
            this.checkBoxClipboardTextAutoFetchOnlyWhenActivatingForm = new System.Windows.Forms.CheckBox();
            this.checkBoxClipboardTextAutoProcessAfterAutoFetch = new System.Windows.Forms.CheckBox();
            this.buttonClipboardTextProcess = new System.Windows.Forms.Button();
            this.splitContainerSub = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanelProcessedResult1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelProcessedResult1Controls = new System.Windows.Forms.TableLayoutPanel();
            this.checkBoxProcessedResult1AutoCopy = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanelProcessedResult2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelProcessedResult2Controls = new System.Windows.Forms.TableLayoutPanel();
            this.checkBoxProcessedResult2AppendToEnd = new System.Windows.Forms.CheckBox();
            this.checkBoxProcessedResult2AutoCopy = new System.Windows.Forms.CheckBox();
            this.buttonProcessedResult2Copy = new System.Windows.Forms.Button();
            this.buttonProcessedResult2SaveAsFile = new System.Windows.Forms.Button();
            this.mainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.menuItemFile = new System.Windows.Forms.MenuItem();
            this.menuItemFileExit = new System.Windows.Forms.MenuItem();
            this.menuItemTools = new System.Windows.Forms.MenuItem();
            this.menuItemToolsOptions = new System.Windows.Forms.MenuItem();
            this.menuItemHelp = new System.Windows.Forms.MenuItem();
            this.menuItemHelpAbout = new System.Windows.Forms.MenuItem();
            this.labelHistory = new System.Windows.Forms.Label();
            this.statusBar = new System.Windows.Forms.StatusBar();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelHistory = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelHistoryControls = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.tableLayoutPanelClipboardText.SuspendLayout();
            this.tableLayoutPanelClipboardTextControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerSub)).BeginInit();
            this.splitContainerSub.Panel1.SuspendLayout();
            this.splitContainerSub.Panel2.SuspendLayout();
            this.splitContainerSub.SuspendLayout();
            this.tableLayoutPanelProcessedResult1.SuspendLayout();
            this.tableLayoutPanelProcessedResult1Controls.SuspendLayout();
            this.tableLayoutPanelProcessedResult2.SuspendLayout();
            this.tableLayoutPanelProcessedResult2Controls.SuspendLayout();
            this.tableLayoutPanelMain.SuspendLayout();
            this.tableLayoutPanelHistory.SuspendLayout();
            this.tableLayoutPanelHistoryControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxClipboardText
            // 
            this.tableLayoutPanelClipboardText.SetColumnSpan(this.textBoxClipboardText, 2);
            this.textBoxClipboardText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxClipboardText.Location = new System.Drawing.Point(2, 27);
            this.textBoxClipboardText.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBoxClipboardText.Multiline = true;
            this.textBoxClipboardText.Name = "textBoxClipboardText";
            this.textBoxClipboardText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxClipboardText.Size = new System.Drawing.Size(639, 180);
            this.textBoxClipboardText.TabIndex = 0;
            this.textBoxClipboardText.WordWrap = false;
            this.textBoxClipboardText.TextChanged += new System.EventHandler(this.MultilineTextBox_TextChanged);
            this.textBoxClipboardText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MultilineTextBox_KeyDown);
            // 
            // labelClipboardText
            // 
            this.labelClipboardText.AutoSize = true;
            this.labelClipboardText.Location = new System.Drawing.Point(2, 0);
            this.labelClipboardText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelClipboardText.Name = "labelClipboardText";
            this.labelClipboardText.Size = new System.Drawing.Size(98, 17);
            this.labelClipboardText.TabIndex = 1;
            this.labelClipboardText.Text = "Clipboard text:";
            this.labelClipboardText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxProcessedResult1
            // 
            this.tableLayoutPanelProcessedResult1.SetColumnSpan(this.textBoxProcessedResult1, 2);
            this.textBoxProcessedResult1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxProcessedResult1.Location = new System.Drawing.Point(2, 37);
            this.textBoxProcessedResult1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBoxProcessedResult1.Multiline = true;
            this.textBoxProcessedResult1.Name = "textBoxProcessedResult1";
            this.textBoxProcessedResult1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxProcessedResult1.Size = new System.Drawing.Size(639, 180);
            this.textBoxProcessedResult1.TabIndex = 2;
            this.textBoxProcessedResult1.TextChanged += new System.EventHandler(this.MultilineTextBox_TextChanged);
            this.textBoxProcessedResult1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MultilineTextBox_KeyDown);
            // 
            // labelProcessedResult1
            // 
            this.labelProcessedResult1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelProcessedResult1.AutoSize = true;
            this.labelProcessedResult1.Location = new System.Drawing.Point(2, 8);
            this.labelProcessedResult1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelProcessedResult1.Name = "labelProcessedResult1";
            this.labelProcessedResult1.Size = new System.Drawing.Size(118, 17);
            this.labelProcessedResult1.TabIndex = 3;
            this.labelProcessedResult1.Text = "Processed result:";
            // 
            // comboBoxScriptFileList1
            // 
            this.comboBoxScriptFileList1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxScriptFileList1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxScriptFileList1.FormattingEnabled = true;
            this.comboBoxScriptFileList1.Location = new System.Drawing.Point(212, 4);
            this.comboBoxScriptFileList1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.comboBoxScriptFileList1.Name = "comboBoxScriptFileList1";
            this.comboBoxScriptFileList1.Size = new System.Drawing.Size(429, 24);
            this.comboBoxScriptFileList1.TabIndex = 6;
            // 
            // buttonClipboardTextFetch
            // 
            this.buttonClipboardTextFetch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClipboardTextFetch.Location = new System.Drawing.Point(2, 3);
            this.buttonClipboardTextFetch.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonClipboardTextFetch.Name = "buttonClipboardTextFetch";
            this.buttonClipboardTextFetch.Size = new System.Drawing.Size(113, 28);
            this.buttonClipboardTextFetch.TabIndex = 1;
            this.buttonClipboardTextFetch.Text = "Fetch";
            this.buttonClipboardTextFetch.UseVisualStyleBackColor = true;
            this.buttonClipboardTextFetch.Click += new System.EventHandler(this.ButtonClipboardTextFetch_Click);
            // 
            // checkBoxProcessedResult1AppendToEnd
            // 
            this.checkBoxProcessedResult1AppendToEnd.AutoSize = true;
            this.checkBoxProcessedResult1AppendToEnd.Location = new System.Drawing.Point(4, 109);
            this.checkBoxProcessedResult1AppendToEnd.Margin = new System.Windows.Forms.Padding(4, 3, 2, 3);
            this.checkBoxProcessedResult1AppendToEnd.Name = "checkBoxProcessedResult1AppendToEnd";
            this.checkBoxProcessedResult1AppendToEnd.Size = new System.Drawing.Size(191, 21);
            this.checkBoxProcessedResult1AppendToEnd.TabIndex = 5;
            this.checkBoxProcessedResult1AppendToEnd.Text = "Append new result to end";
            this.checkBoxProcessedResult1AppendToEnd.UseVisualStyleBackColor = true;
            // 
            // buttonProcessedResult1Copy
            // 
            this.buttonProcessedResult1Copy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonProcessedResult1Copy.Location = new System.Drawing.Point(2, 3);
            this.buttonProcessedResult1Copy.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonProcessedResult1Copy.Name = "buttonProcessedResult1Copy";
            this.buttonProcessedResult1Copy.Size = new System.Drawing.Size(270, 28);
            this.buttonProcessedResult1Copy.TabIndex = 3;
            this.buttonProcessedResult1Copy.Text = "Copy";
            this.buttonProcessedResult1Copy.UseVisualStyleBackColor = true;
            this.buttonProcessedResult1Copy.Click += new System.EventHandler(this.ButtonProcessedResult1Copy_Click);
            // 
            // buttonProcessedResult1SaveAsFile
            // 
            this.buttonProcessedResult1SaveAsFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonProcessedResult1SaveAsFile.Location = new System.Drawing.Point(2, 37);
            this.buttonProcessedResult1SaveAsFile.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonProcessedResult1SaveAsFile.Name = "buttonProcessedResult1SaveAsFile";
            this.buttonProcessedResult1SaveAsFile.Size = new System.Drawing.Size(270, 28);
            this.buttonProcessedResult1SaveAsFile.TabIndex = 4;
            this.buttonProcessedResult1SaveAsFile.Text = "Save as file...";
            this.buttonProcessedResult1SaveAsFile.UseVisualStyleBackColor = true;
            this.buttonProcessedResult1SaveAsFile.Click += new System.EventHandler(this.ButtonProcessedResult1SaveAsFile_Click);
            // 
            // comboBoxHistoryOperationList
            // 
            this.comboBoxHistoryOperationList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxHistoryOperationList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxHistoryOperationList.FormattingEnabled = true;
            this.comboBoxHistoryOperationList.Location = new System.Drawing.Point(67, 10);
            this.comboBoxHistoryOperationList.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.comboBoxHistoryOperationList.Name = "comboBoxHistoryOperationList";
            this.comboBoxHistoryOperationList.Size = new System.Drawing.Size(572, 24);
            this.comboBoxHistoryOperationList.TabIndex = 9;
            // 
            // buttonHistoryPrevious
            // 
            this.buttonHistoryPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonHistoryPrevious.Location = new System.Drawing.Point(2, 5);
            this.buttonHistoryPrevious.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonHistoryPrevious.Name = "buttonHistoryPrevious";
            this.buttonHistoryPrevious.Size = new System.Drawing.Size(133, 28);
            this.buttonHistoryPrevious.TabIndex = 10;
            this.buttonHistoryPrevious.Text = "<";
            this.buttonHistoryPrevious.UseVisualStyleBackColor = true;
            // 
            // buttonHistoryNext
            // 
            this.buttonHistoryNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonHistoryNext.Location = new System.Drawing.Point(139, 5);
            this.buttonHistoryNext.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonHistoryNext.Name = "buttonHistoryNext";
            this.buttonHistoryNext.Size = new System.Drawing.Size(133, 28);
            this.buttonHistoryNext.TabIndex = 11;
            this.buttonHistoryNext.Text = ">";
            this.buttonHistoryNext.UseVisualStyleBackColor = true;
            // 
            // comboBoxScriptFileList2
            // 
            this.comboBoxScriptFileList2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxScriptFileList2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxScriptFileList2.FormattingEnabled = true;
            this.comboBoxScriptFileList2.Location = new System.Drawing.Point(212, 5);
            this.comboBoxScriptFileList2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.comboBoxScriptFileList2.Name = "comboBoxScriptFileList2";
            this.comboBoxScriptFileList2.Size = new System.Drawing.Size(429, 24);
            this.comboBoxScriptFileList2.TabIndex = 7;
            // 
            // labelProcessedResult2
            // 
            this.labelProcessedResult2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelProcessedResult2.AutoSize = true;
            this.labelProcessedResult2.Location = new System.Drawing.Point(2, 8);
            this.labelProcessedResult2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelProcessedResult2.Name = "labelProcessedResult2";
            this.labelProcessedResult2.Size = new System.Drawing.Size(189, 17);
            this.labelProcessedResult2.TabIndex = 13;
            this.labelProcessedResult2.Text = "Secondary processed result:";
            // 
            // textBoxProcessedResult2
            // 
            this.textBoxProcessedResult2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelProcessedResult2.SetColumnSpan(this.textBoxProcessedResult2, 2);
            this.textBoxProcessedResult2.Location = new System.Drawing.Point(2, 37);
            this.textBoxProcessedResult2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBoxProcessedResult2.Multiline = true;
            this.textBoxProcessedResult2.Name = "textBoxProcessedResult2";
            this.textBoxProcessedResult2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxProcessedResult2.Size = new System.Drawing.Size(639, 153);
            this.textBoxProcessedResult2.TabIndex = 5;
            this.textBoxProcessedResult2.TextChanged += new System.EventHandler(this.MultilineTextBox_TextChanged);
            this.textBoxProcessedResult2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MultilineTextBox_KeyDown);
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(7, 8);
            this.splitContainerMain.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.splitContainerMain.Name = "splitContainerMain";
            this.splitContainerMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.tableLayoutPanelClipboardText);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.splitContainerSub);
            this.splitContainerMain.Size = new System.Drawing.Size(928, 629);
            this.splitContainerMain.SplitterDistance = 210;
            this.splitContainerMain.SplitterWidth = 3;
            this.splitContainerMain.TabIndex = 0;
            // 
            // tableLayoutPanelClipboardText
            // 
            this.tableLayoutPanelClipboardText.ColumnCount = 4;
            this.tableLayoutPanelClipboardText.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            this.tableLayoutPanelClipboardText.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelClipboardText.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanelClipboardText.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 280F));
            this.tableLayoutPanelClipboardText.Controls.Add(this.labelClipboardText, 0, 0);
            this.tableLayoutPanelClipboardText.Controls.Add(this.textBoxClipboardText, 0, 1);
            this.tableLayoutPanelClipboardText.Controls.Add(this.tableLayoutPanelClipboardTextControls, 3, 1);
            this.tableLayoutPanelClipboardText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelClipboardText.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelClipboardText.Name = "tableLayoutPanelClipboardText";
            this.tableLayoutPanelClipboardText.RowCount = 2;
            this.tableLayoutPanelClipboardText.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanelClipboardText.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelClipboardText.Size = new System.Drawing.Size(928, 210);
            this.tableLayoutPanelClipboardText.TabIndex = 7;
            // 
            // tableLayoutPanelClipboardTextControls
            // 
            this.tableLayoutPanelClipboardTextControls.ColumnCount = 2;
            this.tableLayoutPanelClipboardTextControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43F));
            this.tableLayoutPanelClipboardTextControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57F));
            this.tableLayoutPanelClipboardTextControls.Controls.Add(this.checkBoxClipboardTextAutoFetch, 0, 2);
            this.tableLayoutPanelClipboardTextControls.Controls.Add(this.checkBoxClipboardTextAutoFetchOnlyWhenActivatingForm, 0, 3);
            this.tableLayoutPanelClipboardTextControls.Controls.Add(this.checkBoxClipboardTextAutoProcessAfterAutoFetch, 0, 4);
            this.tableLayoutPanelClipboardTextControls.Controls.Add(this.buttonClipboardTextFetch, 0, 0);
            this.tableLayoutPanelClipboardTextControls.Controls.Add(this.buttonClipboardTextProcess, 1, 0);
            this.tableLayoutPanelClipboardTextControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelClipboardTextControls.Location = new System.Drawing.Point(651, 27);
            this.tableLayoutPanelClipboardTextControls.Name = "tableLayoutPanelClipboardTextControls";
            this.tableLayoutPanelClipboardTextControls.RowCount = 6;
            this.tableLayoutPanelClipboardTextControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanelClipboardTextControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanelClipboardTextControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanelClipboardTextControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanelClipboardTextControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanelClipboardTextControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelClipboardTextControls.Size = new System.Drawing.Size(274, 180);
            this.tableLayoutPanelClipboardTextControls.TabIndex = 3;
            // 
            // checkBoxClipboardTextAutoFetch
            // 
            this.checkBoxClipboardTextAutoFetch.AutoSize = true;
            this.checkBoxClipboardTextAutoFetch.Checked = true;
            this.checkBoxClipboardTextAutoFetch.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tableLayoutPanelClipboardTextControls.SetColumnSpan(this.checkBoxClipboardTextAutoFetch, 2);
            this.checkBoxClipboardTextAutoFetch.Location = new System.Drawing.Point(4, 47);
            this.checkBoxClipboardTextAutoFetch.Margin = new System.Windows.Forms.Padding(4, 3, 2, 3);
            this.checkBoxClipboardTextAutoFetch.Name = "checkBoxClipboardTextAutoFetch";
            this.checkBoxClipboardTextAutoFetch.Size = new System.Drawing.Size(94, 21);
            this.checkBoxClipboardTextAutoFetch.TabIndex = 2;
            this.checkBoxClipboardTextAutoFetch.Text = "Auto fetch";
            this.checkBoxClipboardTextAutoFetch.UseVisualStyleBackColor = true;
            this.checkBoxClipboardTextAutoFetch.CheckedChanged += new System.EventHandler(this.CheckBoxClipboardTextAutoFetch_CheckedChanged);
            // 
            // checkBoxClipboardTextAutoFetchOnlyWhenActivatingForm
            // 
            this.checkBoxClipboardTextAutoFetchOnlyWhenActivatingForm.AutoSize = true;
            this.checkBoxClipboardTextAutoFetchOnlyWhenActivatingForm.Checked = true;
            this.checkBoxClipboardTextAutoFetchOnlyWhenActivatingForm.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tableLayoutPanelClipboardTextControls.SetColumnSpan(this.checkBoxClipboardTextAutoFetchOnlyWhenActivatingForm, 2);
            this.checkBoxClipboardTextAutoFetchOnlyWhenActivatingForm.Location = new System.Drawing.Point(30, 75);
            this.checkBoxClipboardTextAutoFetchOnlyWhenActivatingForm.Margin = new System.Windows.Forms.Padding(30, 3, 2, 3);
            this.checkBoxClipboardTextAutoFetchOnlyWhenActivatingForm.Name = "checkBoxClipboardTextAutoFetchOnlyWhenActivatingForm";
            this.checkBoxClipboardTextAutoFetchOnlyWhenActivatingForm.Size = new System.Drawing.Size(242, 21);
            this.checkBoxClipboardTextAutoFetchOnlyWhenActivatingForm.TabIndex = 4;
            this.checkBoxClipboardTextAutoFetchOnlyWhenActivatingForm.Text = "Only when switched to this window";
            this.checkBoxClipboardTextAutoFetchOnlyWhenActivatingForm.UseVisualStyleBackColor = true;
            // 
            // checkBoxClipboardTextAutoProcessAfterAutoFetch
            // 
            this.checkBoxClipboardTextAutoProcessAfterAutoFetch.AutoSize = true;
            this.checkBoxClipboardTextAutoProcessAfterAutoFetch.Checked = true;
            this.checkBoxClipboardTextAutoProcessAfterAutoFetch.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tableLayoutPanelClipboardTextControls.SetColumnSpan(this.checkBoxClipboardTextAutoProcessAfterAutoFetch, 2);
            this.checkBoxClipboardTextAutoProcessAfterAutoFetch.Location = new System.Drawing.Point(30, 103);
            this.checkBoxClipboardTextAutoProcessAfterAutoFetch.Margin = new System.Windows.Forms.Padding(30, 3, 2, 3);
            this.checkBoxClipboardTextAutoProcessAfterAutoFetch.Name = "checkBoxClipboardTextAutoProcessAfterAutoFetch";
            this.checkBoxClipboardTextAutoProcessAfterAutoFetch.Size = new System.Drawing.Size(200, 21);
            this.checkBoxClipboardTextAutoProcessAfterAutoFetch.TabIndex = 3;
            this.checkBoxClipboardTextAutoProcessAfterAutoFetch.Text = "Auto process after fetching";
            this.checkBoxClipboardTextAutoProcessAfterAutoFetch.UseVisualStyleBackColor = true;
            // 
            // buttonClipboardTextProcess
            // 
            this.buttonClipboardTextProcess.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClipboardTextProcess.Location = new System.Drawing.Point(119, 3);
            this.buttonClipboardTextProcess.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonClipboardTextProcess.Name = "buttonClipboardTextProcess";
            this.buttonClipboardTextProcess.Size = new System.Drawing.Size(153, 28);
            this.buttonClipboardTextProcess.TabIndex = 5;
            this.buttonClipboardTextProcess.Text = "Process";
            this.buttonClipboardTextProcess.UseVisualStyleBackColor = true;
            this.buttonClipboardTextProcess.Click += new System.EventHandler(this.ButtonClipboardTextProcess_Click);
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
            this.splitContainerSub.Panel1.Controls.Add(this.tableLayoutPanelProcessedResult1);
            // 
            // splitContainerSub.Panel2
            // 
            this.splitContainerSub.Panel2.Controls.Add(this.tableLayoutPanelProcessedResult2);
            this.splitContainerSub.Size = new System.Drawing.Size(928, 416);
            this.splitContainerSub.SplitterDistance = 220;
            this.splitContainerSub.SplitterWidth = 3;
            this.splitContainerSub.TabIndex = 0;
            // 
            // tableLayoutPanelProcessedResult1
            // 
            this.tableLayoutPanelProcessedResult1.ColumnCount = 4;
            this.tableLayoutPanelProcessedResult1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            this.tableLayoutPanelProcessedResult1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelProcessedResult1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanelProcessedResult1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 280F));
            this.tableLayoutPanelProcessedResult1.Controls.Add(this.labelProcessedResult1, 0, 0);
            this.tableLayoutPanelProcessedResult1.Controls.Add(this.comboBoxScriptFileList1, 1, 0);
            this.tableLayoutPanelProcessedResult1.Controls.Add(this.textBoxProcessedResult1, 0, 1);
            this.tableLayoutPanelProcessedResult1.Controls.Add(this.tableLayoutPanelProcessedResult1Controls, 3, 1);
            this.tableLayoutPanelProcessedResult1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelProcessedResult1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelProcessedResult1.Name = "tableLayoutPanelProcessedResult1";
            this.tableLayoutPanelProcessedResult1.RowCount = 2;
            this.tableLayoutPanelProcessedResult1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanelProcessedResult1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelProcessedResult1.Size = new System.Drawing.Size(928, 220);
            this.tableLayoutPanelProcessedResult1.TabIndex = 9;
            // 
            // tableLayoutPanelProcessedResult1Controls
            // 
            this.tableLayoutPanelProcessedResult1Controls.ColumnCount = 1;
            this.tableLayoutPanelProcessedResult1Controls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelProcessedResult1Controls.Controls.Add(this.checkBoxProcessedResult1AppendToEnd, 0, 4);
            this.tableLayoutPanelProcessedResult1Controls.Controls.Add(this.checkBoxProcessedResult1AutoCopy, 0, 3);
            this.tableLayoutPanelProcessedResult1Controls.Controls.Add(this.buttonProcessedResult1Copy, 0, 0);
            this.tableLayoutPanelProcessedResult1Controls.Controls.Add(this.buttonProcessedResult1SaveAsFile, 0, 1);
            this.tableLayoutPanelProcessedResult1Controls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelProcessedResult1Controls.Location = new System.Drawing.Point(651, 37);
            this.tableLayoutPanelProcessedResult1Controls.Name = "tableLayoutPanelProcessedResult1Controls";
            this.tableLayoutPanelProcessedResult1Controls.RowCount = 6;
            this.tableLayoutPanelProcessedResult1Controls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanelProcessedResult1Controls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanelProcessedResult1Controls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanelProcessedResult1Controls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanelProcessedResult1Controls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanelProcessedResult1Controls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelProcessedResult1Controls.Size = new System.Drawing.Size(274, 180);
            this.tableLayoutPanelProcessedResult1Controls.TabIndex = 7;
            // 
            // checkBoxProcessedResult1AutoCopy
            // 
            this.checkBoxProcessedResult1AutoCopy.AutoSize = true;
            this.checkBoxProcessedResult1AutoCopy.Location = new System.Drawing.Point(4, 81);
            this.checkBoxProcessedResult1AutoCopy.Margin = new System.Windows.Forms.Padding(4, 3, 2, 3);
            this.checkBoxProcessedResult1AutoCopy.Name = "checkBoxProcessedResult1AutoCopy";
            this.checkBoxProcessedResult1AutoCopy.Size = new System.Drawing.Size(171, 21);
            this.checkBoxProcessedResult1AutoCopy.TabIndex = 7;
            this.checkBoxProcessedResult1AutoCopy.Text = "Auto copy to clipboard";
            this.checkBoxProcessedResult1AutoCopy.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelProcessedResult2
            // 
            this.tableLayoutPanelProcessedResult2.ColumnCount = 4;
            this.tableLayoutPanelProcessedResult2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            this.tableLayoutPanelProcessedResult2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelProcessedResult2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanelProcessedResult2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 280F));
            this.tableLayoutPanelProcessedResult2.Controls.Add(this.tableLayoutPanelProcessedResult2Controls, 3, 1);
            this.tableLayoutPanelProcessedResult2.Controls.Add(this.labelProcessedResult2, 0, 0);
            this.tableLayoutPanelProcessedResult2.Controls.Add(this.comboBoxScriptFileList2, 1, 0);
            this.tableLayoutPanelProcessedResult2.Controls.Add(this.textBoxProcessedResult2, 0, 1);
            this.tableLayoutPanelProcessedResult2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelProcessedResult2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelProcessedResult2.Name = "tableLayoutPanelProcessedResult2";
            this.tableLayoutPanelProcessedResult2.RowCount = 2;
            this.tableLayoutPanelProcessedResult2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanelProcessedResult2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelProcessedResult2.Size = new System.Drawing.Size(928, 193);
            this.tableLayoutPanelProcessedResult2.TabIndex = 15;
            // 
            // tableLayoutPanelProcessedResult2Controls
            // 
            this.tableLayoutPanelProcessedResult2Controls.ColumnCount = 1;
            this.tableLayoutPanelProcessedResult2Controls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelProcessedResult2Controls.Controls.Add(this.checkBoxProcessedResult2AppendToEnd, 0, 4);
            this.tableLayoutPanelProcessedResult2Controls.Controls.Add(this.checkBoxProcessedResult2AutoCopy, 0, 3);
            this.tableLayoutPanelProcessedResult2Controls.Controls.Add(this.buttonProcessedResult2Copy, 0, 0);
            this.tableLayoutPanelProcessedResult2Controls.Controls.Add(this.buttonProcessedResult2SaveAsFile, 0, 1);
            this.tableLayoutPanelProcessedResult2Controls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelProcessedResult2Controls.Location = new System.Drawing.Point(651, 37);
            this.tableLayoutPanelProcessedResult2Controls.Name = "tableLayoutPanelProcessedResult2Controls";
            this.tableLayoutPanelProcessedResult2Controls.RowCount = 6;
            this.tableLayoutPanelProcessedResult2Controls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanelProcessedResult2Controls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanelProcessedResult2Controls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanelProcessedResult2Controls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanelProcessedResult2Controls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanelProcessedResult2Controls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelProcessedResult2Controls.Size = new System.Drawing.Size(274, 153);
            this.tableLayoutPanelProcessedResult2Controls.TabIndex = 14;
            // 
            // checkBoxProcessedResult2AppendToEnd
            // 
            this.checkBoxProcessedResult2AppendToEnd.AutoSize = true;
            this.checkBoxProcessedResult2AppendToEnd.Location = new System.Drawing.Point(4, 109);
            this.checkBoxProcessedResult2AppendToEnd.Margin = new System.Windows.Forms.Padding(4, 3, 2, 3);
            this.checkBoxProcessedResult2AppendToEnd.Name = "checkBoxProcessedResult2AppendToEnd";
            this.checkBoxProcessedResult2AppendToEnd.Size = new System.Drawing.Size(191, 21);
            this.checkBoxProcessedResult2AppendToEnd.TabIndex = 5;
            this.checkBoxProcessedResult2AppendToEnd.Text = "Append new result to end";
            this.checkBoxProcessedResult2AppendToEnd.UseVisualStyleBackColor = true;
            // 
            // checkBoxProcessedResult2AutoCopy
            // 
            this.checkBoxProcessedResult2AutoCopy.AutoSize = true;
            this.checkBoxProcessedResult2AutoCopy.Location = new System.Drawing.Point(4, 81);
            this.checkBoxProcessedResult2AutoCopy.Margin = new System.Windows.Forms.Padding(4, 3, 2, 3);
            this.checkBoxProcessedResult2AutoCopy.Name = "checkBoxProcessedResult2AutoCopy";
            this.checkBoxProcessedResult2AutoCopy.Size = new System.Drawing.Size(171, 21);
            this.checkBoxProcessedResult2AutoCopy.TabIndex = 7;
            this.checkBoxProcessedResult2AutoCopy.Text = "Auto copy to clipboard";
            this.checkBoxProcessedResult2AutoCopy.UseVisualStyleBackColor = true;
            // 
            // buttonProcessedResult2Copy
            // 
            this.buttonProcessedResult2Copy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonProcessedResult2Copy.Location = new System.Drawing.Point(2, 3);
            this.buttonProcessedResult2Copy.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonProcessedResult2Copy.Name = "buttonProcessedResult2Copy";
            this.buttonProcessedResult2Copy.Size = new System.Drawing.Size(270, 28);
            this.buttonProcessedResult2Copy.TabIndex = 3;
            this.buttonProcessedResult2Copy.Text = "Copy";
            this.buttonProcessedResult2Copy.UseVisualStyleBackColor = true;
            this.buttonProcessedResult2Copy.Click += new System.EventHandler(this.ButtonProcessedResult2Copy_Click);
            // 
            // buttonProcessedResult2SaveAsFile
            // 
            this.buttonProcessedResult2SaveAsFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonProcessedResult2SaveAsFile.Location = new System.Drawing.Point(2, 37);
            this.buttonProcessedResult2SaveAsFile.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonProcessedResult2SaveAsFile.Name = "buttonProcessedResult2SaveAsFile";
            this.buttonProcessedResult2SaveAsFile.Size = new System.Drawing.Size(270, 28);
            this.buttonProcessedResult2SaveAsFile.TabIndex = 4;
            this.buttonProcessedResult2SaveAsFile.Text = "Save as file...";
            this.buttonProcessedResult2SaveAsFile.UseVisualStyleBackColor = true;
            this.buttonProcessedResult2SaveAsFile.Click += new System.EventHandler(this.ButtonProcessedResult2SaveAsFile_Click);
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemFile,
            this.menuItemTools,
            this.menuItemHelp});
            // 
            // menuItemFile
            // 
            this.menuItemFile.Index = 0;
            this.menuItemFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemFileExit});
            this.menuItemFile.Text = "&File";
            // 
            // menuItemFileExit
            // 
            this.menuItemFileExit.Index = 0;
            this.menuItemFileExit.Shortcut = System.Windows.Forms.Shortcut.AltF4;
            this.menuItemFileExit.Text = "E&xit";
            this.menuItemFileExit.Click += new System.EventHandler(this.MenuItemFileExit_Click);
            // 
            // menuItemTools
            // 
            this.menuItemTools.Index = 1;
            this.menuItemTools.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemToolsOptions});
            this.menuItemTools.Text = "&Tools";
            // 
            // menuItemToolsOptions
            // 
            this.menuItemToolsOptions.Index = 0;
            this.menuItemToolsOptions.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
            this.menuItemToolsOptions.Text = "&Options";
            this.menuItemToolsOptions.Click += new System.EventHandler(this.MenuItemToolsOptions_Click);
            // 
            // menuItemHelp
            // 
            this.menuItemHelp.Index = 2;
            this.menuItemHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemHelpAbout});
            this.menuItemHelp.Text = "&Help";
            // 
            // menuItemHelpAbout
            // 
            this.menuItemHelpAbout.Index = 0;
            this.menuItemHelpAbout.Text = "&About";
            this.menuItemHelpAbout.Click += new System.EventHandler(this.MenuItemHelpAbout_Click);
            // 
            // labelHistory
            // 
            this.labelHistory.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelHistory.AutoSize = true;
            this.labelHistory.Location = new System.Drawing.Point(2, 13);
            this.labelHistory.Margin = new System.Windows.Forms.Padding(2, 0, 7, 0);
            this.labelHistory.Name = "labelHistory";
            this.labelHistory.Size = new System.Drawing.Size(56, 17);
            this.labelHistory.TabIndex = 16;
            this.labelHistory.Text = "History:";
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 695);
            this.statusBar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(942, 18);
            this.statusBar.TabIndex = 18;
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 1;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.Controls.Add(this.splitContainerMain, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelHistory, 0, 1);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanelMain.RowCount = 2;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(942, 695);
            this.tableLayoutPanelMain.TabIndex = 20;
            // 
            // tableLayoutPanelHistory
            // 
            this.tableLayoutPanelHistory.ColumnCount = 4;
            this.tableLayoutPanelHistory.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelHistory.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelHistory.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanelHistory.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 280F));
            this.tableLayoutPanelHistory.Controls.Add(this.comboBoxHistoryOperationList, 1, 0);
            this.tableLayoutPanelHistory.Controls.Add(this.labelHistory, 0, 0);
            this.tableLayoutPanelHistory.Controls.Add(this.tableLayoutPanelHistoryControls, 3, 0);
            this.tableLayoutPanelHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelHistory.Location = new System.Drawing.Point(8, 643);
            this.tableLayoutPanelHistory.Name = "tableLayoutPanelHistory";
            this.tableLayoutPanelHistory.RowCount = 1;
            this.tableLayoutPanelHistory.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelHistory.Size = new System.Drawing.Size(926, 44);
            this.tableLayoutPanelHistory.TabIndex = 1;
            // 
            // tableLayoutPanelHistoryControls
            // 
            this.tableLayoutPanelHistoryControls.ColumnCount = 2;
            this.tableLayoutPanelHistoryControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelHistoryControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelHistoryControls.Controls.Add(this.buttonHistoryNext, 1, 0);
            this.tableLayoutPanelHistoryControls.Controls.Add(this.buttonHistoryPrevious, 0, 0);
            this.tableLayoutPanelHistoryControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelHistoryControls.Location = new System.Drawing.Point(649, 3);
            this.tableLayoutPanelHistoryControls.Name = "tableLayoutPanelHistoryControls";
            this.tableLayoutPanelHistoryControls.RowCount = 1;
            this.tableLayoutPanelHistoryControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelHistoryControls.Size = new System.Drawing.Size(274, 38);
            this.tableLayoutPanelHistoryControls.TabIndex = 17;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(942, 713);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Controls.Add(this.statusBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MinimumSize = new System.Drawing.Size(453, 480);
            this.Name = "FormMain";
            this.Text = "Clipboard Auto Processor";
            this.Activated += new System.EventHandler(this.FormMain_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.tableLayoutPanelClipboardText.ResumeLayout(false);
            this.tableLayoutPanelClipboardText.PerformLayout();
            this.tableLayoutPanelClipboardTextControls.ResumeLayout(false);
            this.tableLayoutPanelClipboardTextControls.PerformLayout();
            this.splitContainerSub.Panel1.ResumeLayout(false);
            this.splitContainerSub.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerSub)).EndInit();
            this.splitContainerSub.ResumeLayout(false);
            this.tableLayoutPanelProcessedResult1.ResumeLayout(false);
            this.tableLayoutPanelProcessedResult1.PerformLayout();
            this.tableLayoutPanelProcessedResult1Controls.ResumeLayout(false);
            this.tableLayoutPanelProcessedResult1Controls.PerformLayout();
            this.tableLayoutPanelProcessedResult2.ResumeLayout(false);
            this.tableLayoutPanelProcessedResult2.PerformLayout();
            this.tableLayoutPanelProcessedResult2Controls.ResumeLayout(false);
            this.tableLayoutPanelProcessedResult2Controls.PerformLayout();
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelHistory.ResumeLayout(false);
            this.tableLayoutPanelHistory.PerformLayout();
            this.tableLayoutPanelHistoryControls.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxClipboardText;
        private System.Windows.Forms.Label labelClipboardText;
        private System.Windows.Forms.TextBox textBoxProcessedResult1;
        private System.Windows.Forms.Label labelProcessedResult1;
        private System.Windows.Forms.ComboBox comboBoxScriptFileList1;
        private System.Windows.Forms.Button buttonClipboardTextFetch;
        private System.Windows.Forms.CheckBox checkBoxProcessedResult1AppendToEnd;
        private System.Windows.Forms.Button buttonProcessedResult1Copy;
        private System.Windows.Forms.Button buttonProcessedResult1SaveAsFile;
        private System.Windows.Forms.ComboBox comboBoxHistoryOperationList;
        private System.Windows.Forms.Button buttonHistoryPrevious;
        private System.Windows.Forms.Button buttonHistoryNext;
        private System.Windows.Forms.ComboBox comboBoxScriptFileList2;
        private System.Windows.Forms.Label labelProcessedResult2;
        private System.Windows.Forms.TextBox textBoxProcessedResult2;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.SplitContainer splitContainerSub;
        private System.Windows.Forms.MainMenu mainMenu;
        private System.Windows.Forms.MenuItem menuItemFile;
        private System.Windows.Forms.MenuItem menuItemTools;
        private System.Windows.Forms.MenuItem menuItemHelp;
        private System.Windows.Forms.Label labelHistory;
        private System.Windows.Forms.CheckBox checkBoxClipboardTextAutoProcessAfterAutoFetch;
        private System.Windows.Forms.CheckBox checkBoxClipboardTextAutoFetch;
        private System.Windows.Forms.CheckBox checkBoxClipboardTextAutoFetchOnlyWhenActivatingForm;
        private System.Windows.Forms.CheckBox checkBoxProcessedResult1AutoCopy;
        private System.Windows.Forms.Button buttonClipboardTextProcess;
        private System.Windows.Forms.StatusBar statusBar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelClipboardText;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelClipboardTextControls;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelProcessedResult1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelProcessedResult1Controls;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelProcessedResult2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelHistory;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelHistoryControls;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelProcessedResult2Controls;
        private System.Windows.Forms.CheckBox checkBoxProcessedResult2AppendToEnd;
        private System.Windows.Forms.CheckBox checkBoxProcessedResult2AutoCopy;
        private System.Windows.Forms.Button buttonProcessedResult2Copy;
        private System.Windows.Forms.Button buttonProcessedResult2SaveAsFile;
        private System.Windows.Forms.MenuItem menuItemFileExit;
        private System.Windows.Forms.MenuItem menuItemToolsOptions;
        private System.Windows.Forms.MenuItem menuItemHelpAbout;
    }
}

