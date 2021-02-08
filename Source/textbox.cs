using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace USDKDemo
{
    public partial class textbox : Form
    {
        public textbox()
        {
            InitializeComponent();
            logRichTextBox.ScrollBars = RichTextBoxScrollBars.Both;
            logRichTextBox.WordWrap = false;
        }

        private void CopyToClipboardBtn_Click(object sender, EventArgs e)
        {
            if (logRichTextBox.Text.Length > 0)
                Clipboard.SetText(logRichTextBox.Text);
        }

        private void ClearLogBtn_Click(object sender, EventArgs e)
        {
            logRichTextBox.Text = "";
        }

        public void appendText(string text)
        {
            logRichTextBox.AppendText(text);
        }

        private void logRichTextBox_TextChanged(object sender, EventArgs e)
        {
            logRichTextBox.SelectionStart = logRichTextBox.Text.Length;
            logRichTextBox.ScrollToCaret();
            bool logHasText = !String.IsNullOrWhiteSpace(logRichTextBox.Text);
            CopyToClipboardBtn.Enabled = logHasText;
            ClearLogBtn.Enabled = logHasText;
        }
    }
}
