namespace USDKDemo
{
    partial class ConfigSettings
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbMemo = new System.Windows.Forms.TextBox();
            this.execute = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.cbAids = new System.Windows.Forms.CheckBox();
            this.cbCAPK = new System.Windows.Forms.CheckBox();
            this.cbCRL = new System.Windows.Forms.CheckBox();
            this.cbTerminalData = new System.Windows.Forms.CheckBox();
            this.cbImages = new System.Windows.Forms.CheckBox();
            this.cbReset = new System.Windows.Forms.CheckBox();
            this.cbDFED22 = new System.Windows.Forms.CheckBox();
            this.cb9F1E = new System.Windows.Forms.CheckBox();
            this.cbFinalize = new System.Windows.Forms.CheckBox();
            this.cbConfigGroups = new System.Windows.Forms.CheckBox();
            this.cbCAPKCtls = new System.Windows.Forms.CheckBox();
            this.cbAidCTLS = new System.Windows.Forms.CheckBox();
            this.cbMemo = new System.Windows.Forms.CheckBox();
            this.cbSelfCheckTime = new System.Windows.Forms.CheckBox();
            this.tbTime = new System.Windows.Forms.TextBox();
            this.cbSetDateTime = new System.Windows.Forms.CheckBox();
            this.tbImages = new System.Windows.Forms.TextBox();
            this.cbImageFolder = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.countLabel = new System.Windows.Forms.Label();
            this.rbIDG = new System.Windows.Forms.RadioButton();
            this.rbNGA = new System.Windows.Forms.RadioButton();
            this.rbITP = new System.Windows.Forms.RadioButton();
            this.rbRaw = new System.Windows.Forms.RadioButton();
            this.tbCmd = new System.Windows.Forms.TextBox();
            this.tbSubCmd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbForceProtocol = new System.Windows.Forms.CheckBox();
            this.cbKBModeOnly = new System.Windows.Forms.CheckBox();
            this.tbData = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.idgPanel = new System.Windows.Forms.Panel();
            this.butAdd = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tbVerification = new System.Windows.Forms.TextBox();
            this.cbVerfication = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.idgPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(276, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Config File Write Options";
            // 
            // tbMemo
            // 
            this.tbMemo.Enabled = false;
            this.tbMemo.Location = new System.Drawing.Point(39, 372);
            this.tbMemo.Margin = new System.Windows.Forms.Padding(2);
            this.tbMemo.Multiline = true;
            this.tbMemo.Name = "tbMemo";
            this.tbMemo.Size = new System.Drawing.Size(207, 46);
            this.tbMemo.TabIndex = 146;
            // 
            // execute
            // 
            this.execute.Location = new System.Drawing.Point(508, 395);
            this.execute.Name = "execute";
            this.execute.Size = new System.Drawing.Size(161, 23);
            this.execute.TabIndex = 147;
            this.execute.Text = "Execute Read Device";
            this.execute.UseVisualStyleBackColor = true;
            this.execute.Click += new System.EventHandler(this.execute_Click);
            // 
            // cancel
            // 
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(406, 395);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(82, 23);
            this.cancel.TabIndex = 148;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // cbAids
            // 
            this.cbAids.AutoSize = true;
            this.cbAids.Location = new System.Drawing.Point(23, 48);
            this.cbAids.Name = "cbAids";
            this.cbAids.Size = new System.Drawing.Size(195, 17);
            this.cbAids.TabIndex = 149;
            this.cbAids.Text = "Do Not Erase Existing Contact AIDs";
            this.cbAids.UseVisualStyleBackColor = true;
            // 
            // cbCAPK
            // 
            this.cbCAPK.AutoSize = true;
            this.cbCAPK.Location = new System.Drawing.Point(23, 66);
            this.cbCAPK.Name = "cbCAPK";
            this.cbCAPK.Size = new System.Drawing.Size(205, 17);
            this.cbCAPK.TabIndex = 150;
            this.cbCAPK.Text = "Do Not Erase Existing Contact CAPKs";
            this.cbCAPK.UseVisualStyleBackColor = true;
            // 
            // cbCRL
            // 
            this.cbCRL.AutoSize = true;
            this.cbCRL.Location = new System.Drawing.Point(23, 85);
            this.cbCRL.Name = "cbCRL";
            this.cbCRL.Size = new System.Drawing.Size(198, 17);
            this.cbCRL.TabIndex = 151;
            this.cbCRL.Text = "Do Not Erase Existing Contact CRLs";
            this.cbCRL.UseVisualStyleBackColor = true;
            // 
            // cbTerminalData
            // 
            this.cbTerminalData.AutoSize = true;
            this.cbTerminalData.Location = new System.Drawing.Point(23, 103);
            this.cbTerminalData.Name = "cbTerminalData";
            this.cbTerminalData.Size = new System.Drawing.Size(238, 17);
            this.cbTerminalData.TabIndex = 152;
            this.cbTerminalData.Text = "Do Not Erase Existing Contact Terminal Data";
            this.cbTerminalData.UseVisualStyleBackColor = true;
            // 
            // cbImages
            // 
            this.cbImages.AutoSize = true;
            this.cbImages.Location = new System.Drawing.Point(23, 175);
            this.cbImages.Name = "cbImages";
            this.cbImages.Size = new System.Drawing.Size(166, 17);
            this.cbImages.TabIndex = 153;
            this.cbImages.Text = "Do Not Erase Existing Images";
            this.cbImages.UseVisualStyleBackColor = true;
            // 
            // cbReset
            // 
            this.cbReset.AutoSize = true;
            this.cbReset.Location = new System.Drawing.Point(23, 193);
            this.cbReset.Name = "cbReset";
            this.cbReset.Size = new System.Drawing.Size(191, 17);
            this.cbReset.TabIndex = 154;
            this.cbReset.Text = "Do Not Execute Contactless Reset";
            this.cbReset.UseVisualStyleBackColor = true;
            // 
            // cbDFED22
            // 
            this.cbDFED22.AutoSize = true;
            this.cbDFED22.Location = new System.Drawing.Point(23, 211);
            this.cbDFED22.Name = "cbDFED22";
            this.cbDFED22.Size = new System.Drawing.Size(146, 17);
            this.cbDFED22.TabIndex = 155;
            this.cbDFED22.Text = "Custom Set Tag DFED22";
            this.cbDFED22.UseVisualStyleBackColor = true;
            // 
            // cb9F1E
            // 
            this.cb9F1E.AutoSize = true;
            this.cb9F1E.Location = new System.Drawing.Point(23, 229);
            this.cb9F1E.Name = "cb9F1E";
            this.cb9F1E.Size = new System.Drawing.Size(130, 17);
            this.cb9F1E.TabIndex = 156;
            this.cb9F1E.Text = "Custom Set Tag 9F1E";
            this.cb9F1E.UseVisualStyleBackColor = true;
            // 
            // cbFinalize
            // 
            this.cbFinalize.AutoSize = true;
            this.cbFinalize.Location = new System.Drawing.Point(23, 247);
            this.cbFinalize.Name = "cbFinalize";
            this.cbFinalize.Size = new System.Drawing.Size(119, 17);
            this.cbFinalize.TabIndex = 158;
            this.cbFinalize.Text = "Finalize in KB Mode";
            this.cbFinalize.UseVisualStyleBackColor = true;
            // 
            // cbConfigGroups
            // 
            this.cbConfigGroups.AutoSize = true;
            this.cbConfigGroups.Location = new System.Drawing.Point(23, 157);
            this.cbConfigGroups.Name = "cbConfigGroups";
            this.cbConfigGroups.Size = new System.Drawing.Size(231, 17);
            this.cbConfigGroups.TabIndex = 161;
            this.cbConfigGroups.Text = "Do Not Erase Existing Configuration Groups";
            this.cbConfigGroups.UseVisualStyleBackColor = true;
            // 
            // cbCAPKCtls
            // 
            this.cbCAPKCtls.AutoSize = true;
            this.cbCAPKCtls.Location = new System.Drawing.Point(23, 139);
            this.cbCAPKCtls.Name = "cbCAPKCtls";
            this.cbCAPKCtls.Size = new System.Drawing.Size(223, 17);
            this.cbCAPKCtls.TabIndex = 160;
            this.cbCAPKCtls.Text = "Do Not Erase Existing Contactless CAPKs";
            this.cbCAPKCtls.UseVisualStyleBackColor = true;
            // 
            // cbAidCTLS
            // 
            this.cbAidCTLS.AutoSize = true;
            this.cbAidCTLS.Location = new System.Drawing.Point(23, 121);
            this.cbAidCTLS.Name = "cbAidCTLS";
            this.cbAidCTLS.Size = new System.Drawing.Size(213, 17);
            this.cbAidCTLS.TabIndex = 159;
            this.cbAidCTLS.Text = "Do Not Erase Existing Contactless AIDs";
            this.cbAidCTLS.UseVisualStyleBackColor = true;
            // 
            // cbMemo
            // 
            this.cbMemo.AutoSize = true;
            this.cbMemo.Location = new System.Drawing.Point(23, 350);
            this.cbMemo.Name = "cbMemo";
            this.cbMemo.Size = new System.Drawing.Size(80, 17);
            this.cbMemo.TabIndex = 157;
            this.cbMemo.Text = "Add Memo:";
            this.cbMemo.UseVisualStyleBackColor = true;
            this.cbMemo.CheckedChanged += new System.EventHandler(this.cbMemo_CheckedChanged);
            // 
            // cbSelfCheckTime
            // 
            this.cbSelfCheckTime.AutoSize = true;
            this.cbSelfCheckTime.Location = new System.Drawing.Point(23, 265);
            this.cbSelfCheckTime.Name = "cbSelfCheckTime";
            this.cbSelfCheckTime.Size = new System.Drawing.Size(126, 17);
            this.cbSelfCheckTime.TabIndex = 162;
            this.cbSelfCheckTime.Text = "Set Self Check Time:";
            this.cbSelfCheckTime.UseVisualStyleBackColor = true;
            // 
            // tbTime
            // 
            this.tbTime.Location = new System.Drawing.Point(148, 262);
            this.tbTime.Name = "tbTime";
            this.tbTime.Size = new System.Drawing.Size(70, 20);
            this.tbTime.TabIndex = 163;
            // 
            // cbSetDateTime
            // 
            this.cbSetDateTime.AutoSize = true;
            this.cbSetDateTime.Location = new System.Drawing.Point(23, 283);
            this.cbSetDateTime.Name = "cbSetDateTime";
            this.cbSetDateTime.Size = new System.Drawing.Size(96, 17);
            this.cbSetDateTime.TabIndex = 164;
            this.cbSetDateTime.Text = "Set Date/Time";
            this.cbSetDateTime.UseVisualStyleBackColor = true;
            // 
            // tbImages
            // 
            this.tbImages.Location = new System.Drawing.Point(56, 318);
            this.tbImages.Name = "tbImages";
            this.tbImages.Size = new System.Drawing.Size(158, 20);
            this.tbImages.TabIndex = 166;
            this.tbImages.Text = "images";
            // 
            // cbImageFolder
            // 
            this.cbImageFolder.AutoSize = true;
            this.cbImageFolder.Location = new System.Drawing.Point(23, 301);
            this.cbImageFolder.Name = "cbImageFolder";
            this.cbImageFolder.Size = new System.Drawing.Size(148, 17);
            this.cbImageFolder.TabIndex = 165;
            this.cbImageFolder.Text = "Load Images From Folder:";
            this.cbImageFolder.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Info;
            this.panel1.Controls.Add(this.cbVerfication);
            this.panel1.Controls.Add(this.tbVerification);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.butAdd);
            this.panel1.Controls.Add(this.idgPanel);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.tbData);
            this.panel1.Controls.Add(this.cbKBModeOnly);
            this.panel1.Controls.Add(this.cbForceProtocol);
            this.panel1.Controls.Add(this.countLabel);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.rbIDG);
            this.panel1.Controls.Add(this.rbNGA);
            this.panel1.Controls.Add(this.rbITP);
            this.panel1.Controls.Add(this.rbRaw);
            this.panel1.Location = new System.Drawing.Point(287, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(384, 370);
            this.panel1.TabIndex = 167;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(221, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Include Device Commands";
            // 
            // countLabel
            // 
            this.countLabel.AutoSize = true;
            this.countLabel.Location = new System.Drawing.Point(17, 38);
            this.countLabel.Name = "countLabel";
            this.countLabel.Size = new System.Drawing.Size(144, 13);
            this.countLabel.TabIndex = 2;
            this.countLabel.Text = "Total Commands Defined = 0";
            // 
            // rbIDG
            // 
            this.rbIDG.AutoSize = true;
            this.rbIDG.Checked = true;
            this.rbIDG.Location = new System.Drawing.Point(32, 72);
            this.rbIDG.Name = "rbIDG";
            this.rbIDG.Size = new System.Drawing.Size(94, 17);
            this.rbIDG.TabIndex = 0;
            this.rbIDG.TabStop = true;
            this.rbIDG.Text = "IDG Command";
            this.rbIDG.UseVisualStyleBackColor = true;
            this.rbIDG.CheckedChanged += new System.EventHandler(this.rbIDG_CheckedChanged);
            // 
            // rbNGA
            // 
            this.rbNGA.AutoSize = true;
            this.rbNGA.Location = new System.Drawing.Point(32, 96);
            this.rbNGA.Name = "rbNGA";
            this.rbNGA.Size = new System.Drawing.Size(98, 17);
            this.rbNGA.TabIndex = 1;
            this.rbNGA.Text = "NGA Command";
            this.rbNGA.UseVisualStyleBackColor = true;
            // 
            // rbITP
            // 
            this.rbITP.AutoSize = true;
            this.rbITP.Location = new System.Drawing.Point(139, 72);
            this.rbITP.Name = "rbITP";
            this.rbITP.Size = new System.Drawing.Size(92, 17);
            this.rbITP.TabIndex = 2;
            this.rbITP.Text = "ITP Command";
            this.rbITP.UseVisualStyleBackColor = true;
            // 
            // rbRaw
            // 
            this.rbRaw.AutoSize = true;
            this.rbRaw.Location = new System.Drawing.Point(139, 95);
            this.rbRaw.Name = "rbRaw";
            this.rbRaw.Size = new System.Drawing.Size(97, 17);
            this.rbRaw.TabIndex = 3;
            this.rbRaw.Text = "Raw Command";
            this.rbRaw.UseVisualStyleBackColor = true;
            // 
            // tbCmd
            // 
            this.tbCmd.Location = new System.Drawing.Point(51, 11);
            this.tbCmd.Name = "tbCmd";
            this.tbCmd.Size = new System.Drawing.Size(48, 20);
            this.tbCmd.TabIndex = 4;
            this.tbCmd.TextChanged += new System.EventHandler(this.tbData_TextChanged);
            // 
            // tbSubCmd
            // 
            this.tbSubCmd.Location = new System.Drawing.Point(161, 12);
            this.tbSubCmd.Name = "tbSubCmd";
            this.tbSubCmd.Size = new System.Drawing.Size(48, 20);
            this.tbSubCmd.TabIndex = 5;
            this.tbSubCmd.TextChanged += new System.EventHandler(this.tbData_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Cmd";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(108, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Sub Cmd";
            // 
            // cbForceProtocol
            // 
            this.cbForceProtocol.AutoSize = true;
            this.cbForceProtocol.Location = new System.Drawing.Point(268, 75);
            this.cbForceProtocol.Name = "cbForceProtocol";
            this.cbForceProtocol.Size = new System.Drawing.Size(95, 17);
            this.cbForceProtocol.TabIndex = 150;
            this.cbForceProtocol.Text = "Force Protocol";
            this.cbForceProtocol.UseVisualStyleBackColor = true;
            // 
            // cbKBModeOnly
            // 
            this.cbKBModeOnly.AutoSize = true;
            this.cbKBModeOnly.Location = new System.Drawing.Point(268, 95);
            this.cbKBModeOnly.Name = "cbKBModeOnly";
            this.cbKBModeOnly.Size = new System.Drawing.Size(94, 17);
            this.cbKBModeOnly.TabIndex = 151;
            this.cbKBModeOnly.Text = "KB Mode Only";
            this.cbKBModeOnly.UseVisualStyleBackColor = true;
            // 
            // tbData
            // 
            this.tbData.Location = new System.Drawing.Point(26, 163);
            this.tbData.Multiline = true;
            this.tbData.Name = "tbData";
            this.tbData.Size = new System.Drawing.Size(337, 71);
            this.tbData.TabIndex = 152;
            this.tbData.TextChanged += new System.EventHandler(this.tbData_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 147);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 153;
            this.label6.Text = "Command Data";
            // 
            // idgPanel
            // 
            this.idgPanel.Controls.Add(this.tbSubCmd);
            this.idgPanel.Controls.Add(this.tbCmd);
            this.idgPanel.Controls.Add(this.label4);
            this.idgPanel.Controls.Add(this.label5);
            this.idgPanel.Location = new System.Drawing.Point(151, 122);
            this.idgPanel.Name = "idgPanel";
            this.idgPanel.Size = new System.Drawing.Size(222, 35);
            this.idgPanel.TabIndex = 154;
            // 
            // butAdd
            // 
            this.butAdd.Enabled = false;
            this.butAdd.Location = new System.Drawing.Point(26, 333);
            this.butAdd.Name = "butAdd";
            this.butAdd.Size = new System.Drawing.Size(129, 23);
            this.butAdd.TabIndex = 155;
            this.butAdd.Text = "Add Command";
            this.butAdd.UseVisualStyleBackColor = true;
            this.butAdd.Click += new System.EventHandler(this.butAdd_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(234, 333);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(129, 23);
            this.button2.TabIndex = 156;
            this.button2.Text = "Reset Cmd. List";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tbVerification
            // 
            this.tbVerification.Enabled = false;
            this.tbVerification.Location = new System.Drawing.Point(25, 269);
            this.tbVerification.Multiline = true;
            this.tbVerification.Name = "tbVerification";
            this.tbVerification.Size = new System.Drawing.Size(337, 53);
            this.tbVerification.TabIndex = 157;
            // 
            // cbVerfication
            // 
            this.cbVerfication.AutoSize = true;
            this.cbVerfication.Location = new System.Drawing.Point(25, 246);
            this.cbVerfication.Name = "cbVerfication";
            this.cbVerfication.Size = new System.Drawing.Size(233, 17);
            this.cbVerfication.TabIndex = 158;
            this.cbVerfication.Text = "Verification Command. Expected Response:";
            this.cbVerfication.UseVisualStyleBackColor = true;
            this.cbVerfication.CheckedChanged += new System.EventHandler(this.cvVerfication_CheckedChanged);
            // 
            // ConfigSettings
            // 
            this.AcceptButton = this.execute;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(681, 432);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tbImages);
            this.Controls.Add(this.cbImageFolder);
            this.Controls.Add(this.cbSetDateTime);
            this.Controls.Add(this.tbTime);
            this.Controls.Add(this.cbSelfCheckTime);
            this.Controls.Add(this.cbConfigGroups);
            this.Controls.Add(this.cbCAPKCtls);
            this.Controls.Add(this.cbAidCTLS);
            this.Controls.Add(this.cbFinalize);
            this.Controls.Add(this.cbMemo);
            this.Controls.Add(this.cb9F1E);
            this.Controls.Add(this.cbDFED22);
            this.Controls.Add(this.cbReset);
            this.Controls.Add(this.cbImages);
            this.Controls.Add(this.cbTerminalData);
            this.Controls.Add(this.cbCRL);
            this.Controls.Add(this.cbCAPK);
            this.Controls.Add(this.cbAids);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.execute);
            this.Controls.Add(this.tbMemo);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ConfigSettings";
            this.Text = "Configuration Settings";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.idgPanel.ResumeLayout(false);
            this.idgPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbMemo;
        private System.Windows.Forms.Button execute;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.CheckBox cbAids;
        private System.Windows.Forms.CheckBox cbCAPK;
        private System.Windows.Forms.CheckBox cbCRL;
        private System.Windows.Forms.CheckBox cbTerminalData;
        private System.Windows.Forms.CheckBox cbImages;
        private System.Windows.Forms.CheckBox cbReset;
        private System.Windows.Forms.CheckBox cbDFED22;
        private System.Windows.Forms.CheckBox cb9F1E;
        private System.Windows.Forms.CheckBox cbFinalize;
        private System.Windows.Forms.CheckBox cbConfigGroups;
        private System.Windows.Forms.CheckBox cbCAPKCtls;
        private System.Windows.Forms.CheckBox cbAidCTLS;
        private System.Windows.Forms.CheckBox cbMemo;
        private System.Windows.Forms.CheckBox cbSelfCheckTime;
        private System.Windows.Forms.TextBox tbTime;
        private System.Windows.Forms.CheckBox cbSetDateTime;
        private System.Windows.Forms.TextBox tbImages;
        private System.Windows.Forms.CheckBox cbImageFolder;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button butAdd;
        private System.Windows.Forms.Panel idgPanel;
        private System.Windows.Forms.TextBox tbSubCmd;
        private System.Windows.Forms.TextBox tbCmd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbData;
        private System.Windows.Forms.CheckBox cbKBModeOnly;
        private System.Windows.Forms.CheckBox cbForceProtocol;
        private System.Windows.Forms.Label countLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbIDG;
        private System.Windows.Forms.RadioButton rbNGA;
        private System.Windows.Forms.RadioButton rbITP;
        private System.Windows.Forms.RadioButton rbRaw;
        private System.Windows.Forms.CheckBox cbVerfication;
        private System.Windows.Forms.TextBox tbVerification;
    }
}