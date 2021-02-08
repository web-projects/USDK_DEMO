using IDTechSDK.Configs;
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
    public partial class ConfigSettings : Form
    {
        SDKDemo thisForm = null;
        string thisIdent = "";
        public ConfigSettings(SDKDemo theForm, string ident)
        {
            InitializeComponent();
            thisForm = theForm;
            thisIdent = ident;
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void execute_Click(object sender, EventArgs e)
        {
            if (cbSetDateTime.Checked || cbSelfCheckTime.Checked || cbAidCTLS.Checked || cbCAPKCtls.Checked || cbConfigGroups.Checked || cbFinalize.Checked || cbAids.Checked || cb9F1E.Checked || cbCAPK.Checked || cbCRL.Checked || cbTerminalData.Checked || cbImages.Checked || cbReset.Checked || cbDFED22.Checked ) thisForm.rules = new InstallRules();
            if (cbSelfCheckTime.Checked)
            {
                string text = tbTime.Text;
                if (text.Length != 4)
                {
                    MessageBox.Show("Time Error","Invalid reboot time. Time must be HHMM, with HH = 00-23 and MM = 00 - 59", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string hh = text.Substring(0, 2);
                string mm = text.Substring(2, 2);
                int HH = 0;
                int MM = 0;
                try
                {
                    HH = Convert.ToInt32(hh);
                    MM = Convert.ToInt32(mm);
                }
                catch (Exception)
                {

                    MessageBox.Show("Time Error", "Invalid reboot time. Time must be HHMM, with HH = 00-23 and MM = 00 - 59", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (HH < 0 || HH > 23 || MM < 0 || MM > 59)
                {
                    MessageBox.Show("Time Error", "Invalid reboot time. Time must be HHMM, with HH = 00-23 and MM = 00 - 59", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                thisForm.rules.setSelfCheckTime = tbTime.Text;
            }
            if (cbSetDateTime.Checked) thisForm.rules.setDateTime = "true";
            if (cbAids.Checked) thisForm.rules.KeepAllAID = "true";
            if (cbCAPK.Checked) thisForm.rules.KeepAllCAPK = "true";
            if (cbCRL.Checked) thisForm.rules.KeepAllCRL = "true";
            if (cbAidCTLS.Checked) thisForm.rules.KeepAllAIDCtls = "true";
            if (cbCAPKCtls.Checked) thisForm.rules.KeepAllCAPKCtls = "true";
            if (cbConfigGroups.Checked) thisForm.rules.KeepAllConfigGroups = "true";
            if (cbTerminalData.Checked) thisForm.rules.KeepAllTerminalData = "true";
            if (cbImages.Checked) thisForm.rules.KeepAllImages = "true";
            if (cbReset.Checked) thisForm.rules.bypassCTLSReset = "true";
            if (cbDFED22.Checked) thisForm.rules.setDFED22 = "true";
            if (cb9F1E.Checked) thisForm.rules.set9F1E = "true";
            if (cbFinalize.Checked) thisForm.rules.FinalizeInKbMode = "true";
            if (cbMemo.Checked) thisForm.memo = tbMemo.Text;
            if (cbImageFolder.Checked) thisForm.rules.loadImages =tbImages.Text;
            thisForm.executeRead(thisIdent);
            this.Close();
        }

        private void cbMemo_CheckedChanged(object sender, EventArgs e)
        {
            tbMemo.Enabled = cbMemo.Checked;
            if (!cbMemo.Checked) tbMemo.Text = "";
        }

        private void rbIDG_CheckedChanged(object sender, EventArgs e)
        {
            idgPanel.Visible = rbIDG.Checked;
        }

        private void tbData_TextChanged(object sender, EventArgs e)
        {
            if (rbIDG.Checked)
            {
                butAdd.Enabled = ((tbCmd.Text.Length == 2) && (tbSubCmd.Text.Length == 2));
            }
            else
            {
                butAdd.Enabled = (tbData.Text.Length > 1) ;
            }
        }


  

        private void butAdd_Click(object sender, EventArgs e)
        {
            DeviceCommand cmd = new DeviceCommand();
            string protocol = "IDG";
            if (rbITP.Checked)  protocol = "ITP";
            if (rbNGA.Checked) protocol = "NGA";
            if (rbRaw.Checked) protocol = "RAW";
            cmd.protocol = protocol;
            if (rbIDG.Checked) cmd.command = tbCmd.Text + tbSubCmd.Text + tbData.Text;
            else cmd.command = tbCmd.Text + tbSubCmd.Text + tbData.Text;
            cmd.forceProtocolType = cbForceProtocol.Checked;
            cmd.requiresKB = cbKBModeOnly.Checked;
            cmd.isVerify = cbVerfication.Checked;
            if (cmd.isVerify) cmd.verifyResponse = tbVerification.Text;
            else cmd.verifyResponse = null;
            string input =
                                Microsoft.VisualBasic.Interaction.InputBox("Please enter a name for this command", "Command Name",
                                    "", -1, -1);

            if (input.Length == 0)
            {
                return;
            }
            cmd.name = input;
            if (thisForm.cmds == null) thisForm.cmds = new List<DeviceCommand>();
            thisForm.cmds.Add(cmd);
            countLabel.Text = "Total Commands Defined = " + thisForm.cmds.Count.ToString();
            rbIDG.Checked = true;
            tbCmd.Text = "";
            tbSubCmd.Text = "";
            tbData.Text = "";
            cbForceProtocol.Checked = false;
            cbKBModeOnly.Checked = false;
            cbVerfication.Checked = false;
            tbVerification.Text = "";



        }

        private void button2_Click(object sender, EventArgs e)
        {
            thisForm.cmds = new List<DeviceCommand>();
            countLabel.Text = "Total Commands Defined = " + thisForm.cmds.Count.ToString();
        }

        private void cvVerfication_CheckedChanged(object sender, EventArgs e)
        {
            tbVerification.Enabled = cbVerfication.Checked;
        }
    }
}
