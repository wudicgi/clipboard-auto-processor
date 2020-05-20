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
            this.Text = I18n._("About Clipboard Auto Processor");
        }

        #endregion
    }
}
