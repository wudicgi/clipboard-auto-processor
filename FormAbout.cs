using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClipboardAutoProcessor
{
    public partial class FormAbout : Form
    {
        #region Constructor

        public FormAbout()
        {
            InitializeComponent();

            UpdateTexts();
        }

        #endregion

        #region I18n

        private void UpdateTexts()
        {
            labelTitle.Text = I18n._("Clipboard Auto Processor");

            labelGithubPage.Text = I18n._("View on GitHub:");

            this.Text = I18n._("About Clipboard Auto Processor");
        }

        #endregion

        private void FormAbout_Load(object sender, EventArgs e)
        {
            labelTitle.Font = new Font("Arial", 13.5f); // Arial, Calibri, Segoe UI, Tahoma, Verdana

            labelVersion.Text = "v" + ApplicationService.GetCurrentVersion();

            labelCopyright.Text = ApplicationService.GetCopyrightInformation();
        }

        private void FormAbout_Shown(object sender, EventArgs e)
        {
            labelTitle.Focus();
        }

        private void LinkLabelGithubPage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(linkLabelGithubPage.Text);
        }
    }
}
