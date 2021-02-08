namespace USDKDemo
{
    partial class textbox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.logRichTextBox = new System.Windows.Forms.RichTextBox();
            this.ClearLogBtn = new System.Windows.Forms.Button();
            this.CopyToClipboardBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // logRichTextBox
            // 
            this.logRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logRichTextBox.BackColor = System.Drawing.Color.White;
            this.logRichTextBox.Location = new System.Drawing.Point(-2, -4);
            this.logRichTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.logRichTextBox.Name = "logRichTextBox";
            this.logRichTextBox.ReadOnly = true;
            this.logRichTextBox.Size = new System.Drawing.Size(876, 657);
            this.logRichTextBox.TabIndex = 26;
            this.logRichTextBox.Text = "";
            this.logRichTextBox.TextChanged += new System.EventHandler(this.logRichTextBox_TextChanged);
            // 
            // ClearLogBtn
            // 
            this.ClearLogBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ClearLogBtn.Location = new System.Drawing.Point(758, 661);
            this.ClearLogBtn.Margin = new System.Windows.Forms.Padding(4);
            this.ClearLogBtn.Name = "ClearLogBtn";
            this.ClearLogBtn.Size = new System.Drawing.Size(116, 48);
            this.ClearLogBtn.TabIndex = 25;
            this.ClearLogBtn.Text = "Clear";
            this.ClearLogBtn.UseVisualStyleBackColor = true;
            this.ClearLogBtn.Click += new System.EventHandler(this.ClearLogBtn_Click);
            // 
            // CopyToClipboardBtn
            // 
            this.CopyToClipboardBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CopyToClipboardBtn.Location = new System.Drawing.Point(-2, 661);
            this.CopyToClipboardBtn.Margin = new System.Windows.Forms.Padding(4);
            this.CopyToClipboardBtn.Name = "CopyToClipboardBtn";
            this.CopyToClipboardBtn.Size = new System.Drawing.Size(220, 48);
            this.CopyToClipboardBtn.TabIndex = 24;
            this.CopyToClipboardBtn.Text = "Copy To Clipboard";
            this.CopyToClipboardBtn.UseVisualStyleBackColor = true;
            this.CopyToClipboardBtn.Click += new System.EventHandler(this.CopyToClipboardBtn_Click);
            // 
            // textbox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 712);
            this.Controls.Add(this.logRichTextBox);
            this.Controls.Add(this.ClearLogBtn);
            this.Controls.Add(this.CopyToClipboardBtn);
            this.Name = "textbox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ViVO Config Output";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox logRichTextBox;
        private System.Windows.Forms.Button ClearLogBtn;
        private System.Windows.Forms.Button CopyToClipboardBtn;
    }
}