using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IDTechSDK;

namespace USDKDemo
{
    public partial class Decrypt : Form
    {
        public Decrypt()
        {
            InitializeComponent();
        }

        private void removeAllSpaces()
        {
            tBDK.Text = tBDK.Text.Replace(" ", String.Empty);
            comp1.Text = comp1.Text.Replace(" ", String.Empty);
            comp2.Text = comp2.Text.Replace(" ", String.Empty);
            comp3.Text = comp3.Text.Replace(" ", String.Empty);
            tbIPEK.Text = tbIPEK.Text.Replace(" ", String.Empty);
            tKSN.Text = tKSN.Text.Replace(" ", String.Empty);
            tbPAN.Text = tbPAN.Text.Replace(" ", String.Empty);
            tEncryptedData.Text = tEncryptedData.Text.Replace(" ", String.Empty);
            tBDKpin.Text = tBDKpin.Text.Replace(" ", String.Empty);
            tKSNpin.Text = tKSNpin.Text.Replace(" ", String.Empty);
            tbPANpin.Text = tbPANpin.Text.Replace(" ", String.Empty);
            tEncryptedDatapin.Text = tEncryptedDatapin.Text.Replace(" ", String.Empty);
            tBDKdata.Text = tBDKdata.Text.Replace(" ", String.Empty);
            tKSNdata.Text = tKSNdata.Text.Replace(" ", String.Empty);
            tEncryptedDatadata.Text = tEncryptedDatadata.Text.Replace(" ", String.Empty);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            removeAllSpaces();
            if ((tBDK.Text.Length + tbIPEK.Text.Length) != 32)
            {
                tResults.Text = "BDK or IPEK Error.  Provide a BDK or IPEK, and make sure they are 16 bytes (32 characters)";
                return;
            }

            if (tKSN.Text.Length == 0)
            {
                tResults.Text = "Missing KSN";
                return;
            }
            if (tKSN.Text.Length > 20)
            {
                tResults.Text = "KSN too large";
                return;
            }
            if ((tKSN.Text.Length % 2) == 1)
            {
                tResults.Text = "KSN incorrect";
                return;
            }
            if (tbPAN.Text.Length > 0 && (tbPAN.Text.Length < 12 || tbPAN.Text.Length > 19))
            {
                tResults.Text = "Please enter valid PAN between 12 and 19 digits";
                return;
            }
            if (tbPAN.Text.Length > 0 && rbEncrypt.Checked && (tbASCII.Text.Length == 0 || tbASCII.Text.Length > 14))
            {
                tResults.Text = "Please enter valid PIN to encrypt, between 1 and 14 digits";
                return;
            }
            IDTCryptoData data = new IDTCryptoData();
            data.isTDES = (tdes.Checked);
            data.isDecryption = (rbDecrypt.Checked);
            data.MAC_Command = rbMacCode.Checked;
            if (rbData.Checked)
                data.keyVariant = 0;
            else if (rbPIN.Checked)
                data.keyVariant = 1;
            else
                data.keyVariant = 2;
            if (tdes.Checked)
            {
                if (rbType3.Checked) data.PINBlockType = 3;
            }
            else
            {
                data.PINBlockType = 4;
            }
            data.KSN = new byte[10];
            for (int x = 0; x < data.KSN.Length; x++) data.KSN[x] = 0xff;
            byte[] dataKSN = Common.getByteArray(tKSN.Text);
            int offset = 10 - dataKSN.Length;
            System.Array.Copy(dataKSN, 0, data.KSN, offset, dataKSN.Length); data.BDK = Common.getByteArray(tBDK.Text);
            data.IPEK = Common.getByteArray(tbIPEK.Text);
            data.PAN = tbPAN.Text;
            data.dataToProcess = Common.getByteArray(tEncryptedData.Text);

            if (data.PAN != null && data.PAN.Length > 0 && data.isDecryption && !data.MAC_Command)
            {
                if (data.dataToProcess.Length != 8 && data.isTDES)
                {
                    tResults.Text = "PIN Block must be 8 bytes";
                    return;
                }
                else if (data.dataToProcess.Length != 16 && !data.isTDES)
                {
                    tResults.Text = "PIN Block must be 16 bytes";
                    return;
                }

                if (data.isTDES)
                {
                    data.pinBlock = new byte[8];
                    System.Array.Copy(data.dataToProcess, data.pinBlock, 8);
                }
                else
                {
                    data.pinBlock = new byte[16];
                    System.Array.Copy(data.dataToProcess, data.pinBlock, 16);
                }
            }

            if (!data.isDecryption) data.dataToProcess = Encoding.ASCII.GetBytes(tbASCII.Text);
            if (data.MAC_Command)
            {
                tbASCII.Text = tbASCII.Text.Replace(" ", String.Empty);
                if (tbASCII.Text.Length < 2)
                {
                    tResults.Text = "Please provide data to MAC";
                    return;
                }
                data.dataToProcess = Common.getByteArray(tbASCII.Text);
            }

            if (Common.processDUKPT(ref data))
            {

                if (data.PAN != null && data.PAN.Length > 0)
                {
                    if (data.isDecryption)
                    {
                        tResults.Text = "PIN = " + data.PIN;
                    }
                    else
                    {
                        tResults.Text = "PIN Block= " + Common.getHexStringFromBytes(data.pinBlock);

                    }
                }
                else
                {
                    if (data.MAC_Command){
                        tResults.Text = "MAC Value is: " + Common.getHexStringFromBytes(data.dataResults) + "\r\n\r\n";

                    }
                    else
                    {
                        tResults.Text = Common.getHexStringFromBytes(data.dataResults) + "\r\n\r\n" + System.Text.Encoding.UTF8.GetString(data.dataResults);

                    }
                }
            }
            else
            {
                tResults.Text = "Could Not Process Request. Please verify data is complete.";
            }
            if (data.errorString != null && data.errorString.Length > 0)
            {
                tResults.Text = "Error Encountered: " + data.errorString;
                return;
            }

            tResults.Text = tResults.Text +
    "\r\n\r\n           IPEK:  " + Common.getHexStringFromBytes(data.IPEK)
      + "\r\n    Derived Key:  " + Common.getHexStringFromBytes(data.DEK)
      + "\r\n   Data Variant:  " + Common.getHexStringFromBytes(data.DataVariant)
      + "\r\n    PIN Variant:  " + Common.getHexStringFromBytes(data.PINVariant)
      + "\r\n    MAC Variant:  " + Common.getHexStringFromBytes(data.MACVariant);
            if (data.PAN != null && data.PAN.Length > 0)
            {
                tResults.Text = tResults.Text +
    "\r\n\r\n       PIN Block:  " + Common.getHexStringFromBytes(data.pinBlock)
      + "\r\n Clear PIN Block:  " + Common.getHexStringFromBytes(data.clearPinBlock)
      + "\r\n             PAN:  " + data.PAN
      + "\r\n             PIN:  " + data.PIN
      + "\r\n       FINAL PAN:  " + Common.getHexStringFromBytes(data.finalPAN);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            removeAllSpaces();
            if (tBDKdata.Text.Length != 32)
            {
                tResults.Text = "BDK  Error.  Provide a BDK, and make sure they are 16 bytes (32 characters)";
                return;
            }
            if (tKSNdata.Text.Length == 0)
            {
                tResults.Text = "Missing KSN";
                return;
            }
            if (tKSNdata.Text.Length > 20)
            {
                tResults.Text = "KSN too large";
                return;
            }
            if ((tKSNdata.Text.Length % 2) == 1)
            {
                tResults.Text = "KSN incorrect";
                return;
            }




            IDTCryptoData data = new IDTCryptoData();
            data.isTDES = (tdesdata.Checked);
            data.isDecryption = true;

            data.keyVariant = 0;


            data.KSN = new byte[10];
            for (int x = 0; x < data.KSN.Length; x++) data.KSN[x] = 0xff;
            byte[] dataKSN = Common.getByteArray(tKSNdata.Text);
            int offset = 10 - dataKSN.Length;
            System.Array.Copy(dataKSN, 0, data.KSN, offset, dataKSN.Length); data.BDK = Common.getByteArray(tBDKdata.Text);
            data.dataToProcess = Common.getByteArray(tEncryptedDatadata.Text);



            if (Common.processDUKPT(ref data))
            {


                tResults.Text = Common.getHexStringFromBytes(data.dataResults) + "\r\n\r\n" + System.Text.Encoding.UTF8.GetString(data.dataResults);



            }
            else
            {
                tResults.Text = "Could Not Process Request. Please verify data is complete.";
            }

            if (data.errorString != null && data.errorString.Length > 0)
            {
                tResults.Text = "Error Encountered: " + data.errorString;
                return;
            }

            tResults.Text = tResults.Text +
    "\r\n\r\n           IPEK:  " + Common.getHexStringFromBytes(data.IPEK)
      + "\r\n    Derived Key:  " + Common.getHexStringFromBytes(data.DEK)
      + "\r\n   Data Variant:  " + Common.getHexStringFromBytes(data.DataVariant)
      + "\r\n    PIN Variant:  " + Common.getHexStringFromBytes(data.PINVariant)
      + "\r\n    MAC Variant:  " + Common.getHexStringFromBytes(data.MACVariant);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            removeAllSpaces();
            if (tBDKpin.Text.Length != 32)
            {
                tResults.Text = "BDK  Error.  Provide a BDK, and make sure they are 16 bytes (32 characters)";
                return;
            }
            if (tKSNpin.Text.Length == 0)
            {
                tResults.Text = "Missing KSN";
                return;
            }
            if (tKSNpin.Text.Length > 20)
            {
                tResults.Text = "KSN too large";
                return;
            }
            if ((tKSNpin.Text.Length % 2) == 1)
            {
                tResults.Text = "KSN incorrect";
                return;
            }
            if (tbPANpin.Text.Length < 12 || tbPANpin.Text.Length > 19)
            {
                tResults.Text = "Please enter valid PAN between 12 and 19 digits";
                return;
            }

          

            IDTCryptoData data = new IDTCryptoData();
            data.isTDES = (tdespin.Checked);
            data.isDecryption = true;

            data.keyVariant = 1;

            if (tdespin.Checked)
            {
                data.PINBlockType = 0;
            }
            else
            {
                data.PINBlockType = 4;
            }
            data.KSN = new byte[10];
            for (int x = 0; x < data.KSN.Length; x++) data.KSN[x] = 0xff;
            byte[] dataKSN = Common.getByteArray(tKSNpin.Text);
            int offset = 10 - dataKSN.Length;
            System.Array.Copy(dataKSN, 0, data.KSN, offset, dataKSN.Length); data.BDK = Common.getByteArray(tBDKpin.Text);
            data.PAN = tbPANpin.Text;
            data.dataToProcess = Common.getByteArray(tEncryptedDatapin.Text);

            if (data.PAN != null && data.PAN.Length > 0 && data.isDecryption)
            {
                if (data.dataToProcess.Length != 8 && data.isTDES)
                {
                    tResults.Text = "PIN Block must be 8 bytes";
                    return;
                }
                else if (data.dataToProcess.Length != 16 && !data.isTDES)
                {
                    tResults.Text = "PIN Block must be 16 bytes";
                    return;
                }

                if (data.isTDES)
                {
                    data.pinBlock = new byte[8];
                    System.Array.Copy(data.dataToProcess, data.pinBlock, 8);
                }
                else
                {
                    data.pinBlock = new byte[16];
                    System.Array.Copy(data.dataToProcess, data.pinBlock, 16);
                }
            }


            if (Common.processDUKPT(ref data))
            {



                tResults.Text = "PIN = " + data.PIN;





            }
            else
            {
                tResults.Text = "Could Not Process Request. Please verify data is complete.";
            }

            if (data.errorString != null && data.errorString.Length > 0)
            {
                tResults.Text = "Error Encountered: " + data.errorString;
                return;
            }

            tResults.Text = tResults.Text +
    "\r\n\r\n           IPEK:  " + Common.getHexStringFromBytes(data.IPEK)
      + "\r\n    Derived Key:  " + Common.getHexStringFromBytes(data.DEK)
      + "\r\n   Data Variant:  " + Common.getHexStringFromBytes(data.DataVariant)
      + "\r\n    PIN Variant:  " + Common.getHexStringFromBytes(data.PINVariant)
      + "\r\n    MAC Variant:  " + Common.getHexStringFromBytes(data.MACVariant);
            if (data.PAN != null && data.PAN.Length > 0)
            {
                tResults.Text = tResults.Text +
    "\r\n\r\n       PIN Block:  " + Common.getHexStringFromBytes(data.pinBlock)
      + "\r\n Clear PIN Block:  " + Common.getHexStringFromBytes(data.clearPinBlock)
      + "\r\n             PAN:  " + data.PAN
      + "\r\n             PIN:  " + data.PIN
      + "\r\n       FINAL PAN:  " + Common.getHexStringFromBytes(data.finalPAN);
            }

        }
        private void tdes_CheckedChanged(object sender, EventArgs e)
        {
            panelPINBlock.Visible = tdes.Checked;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comp1.Text.Length  != 32)
            {
                tResults.Text = "Key Component 1 must be 16 bytes (32 characters)";
                return;
            }
            if (comp2.Text.Length != 32)
            {
                tResults.Text = "Key Component 2 must be 16 bytes (32 characters)";
                return;
            }
            if (comp3.Text.Length != 32 && comp3.Text.Length > 0 )
            {
                tResults.Text = "Key Component 3 must be 16 bytes (32 characters) or empty";
                return;
            }
            byte[] compk1 = Common.getByteArray(comp1.Text);
            byte[] compk2 = Common.getByteArray(comp2.Text);
            byte[] compk3 = null;
            kcv1.Text = Common.getHexStringFromBytes(Common.getKCV(compk1));
            kcv2.Text = Common.getHexStringFromBytes(Common.getKCV(compk2));
            if (comp3.Text.Length == 32)
            {
                compk3 = Common.getByteArray(comp3.Text);
                kcv3.Text = Common.getHexStringFromBytes(Common.getKCV(compk3));
            }
            byte[] results = Common.getBDKFromComponents(compk1, compk2, compk3);
            byte[] bdkkcv = Common.getKCV(results);

            if (comp3.Text.Length == 32)
            {
                tResults.Text =
"\r\n\r\n        BDK:  " + Common.getHexStringFromBytes(results)
+ "\r\n    BDK KCV:  " + Common.getHexStringFromBytes(bdkkcv)
+ "\r\n\r\n      KEY 1:  " + comp1.Text
+ "\r\n   KEY1 KCV:  " + kcv1.Text
+ "\r\n\r\n      KEY 2:  " + comp2.Text
+ "\r\n   KEY2 KCV:  " + kcv2.Text
+ "\r\n\r\n      KEY 3:  " + comp3.Text
+ "\r\n   KEY3 KCV:  " + kcv3.Text;
            }
            else
            {
                tResults.Text =
"\r\n\r\n        BDK:  " + Common.getHexStringFromBytes(results)
+ "\r\n    BDK KCV:  " + Common.getHexStringFromBytes(bdkkcv)
+ "\r\n\r\n      KEY 1:  " + comp1.Text
+ "\r\n   KEY1 KCV:  " + kcv1.Text
+ "\r\n\r\n      KEY 2:  " + comp2.Text
+ "\r\n   KEY2 KCV:  " + kcv2.Text;
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (theBDK.Text.Length != 32)
            {
                tResults.Text = "BDK must be 16 bytes (32 characters)";
                return;
            }
            byte[] kBDK = Common.getByteArray(theBDK.Text);
            kcv4.Text = Common.getHexStringFromBytes(Common.getKCV(kBDK));


            byte[] compk1 = null;
            byte[] compk2 = null;
            byte[] compk3 = null;

            bool val = Common.getComponentsFromBDK(key3.Checked, kBDK, ref compk1, ref compk2, ref compk3);

            if (!val)
            {
                tResults.Text = "FAILED GENERATING KEYS";
                return;
            }
            byte[] compk1k = Common.getKCV(compk1);
            byte[] compk2k = Common.getKCV(compk2);


            if (key3.Checked)
            {
                byte[] compk3k = Common.getKCV(compk3);
                tResults.Text =
          "\r\n\r\n        BDK:  " + theBDK.Text
            + "\r\n    BDK KCV:  " + kcv4.Text
       + "\r\n\r\n      KEY 1:  " + Common.getHexStringFromBytes(compk1)
            + "\r\n   KEY1 KCV:  " + Common.getHexStringFromBytes(compk1k)
      + "\r\n\r\n      KEY 2:  " + Common.getHexStringFromBytes(compk2)
            + "\r\n   KEY2 KCV:  " + Common.getHexStringFromBytes(compk2k)
      + "\r\n\r\n      KEY 3:  " + Common.getHexStringFromBytes(compk3)
            + "\r\n   KEY3 KCV:  " + Common.getHexStringFromBytes(compk3k);

            }
            else
            {

                tResults.Text =
"\r\n\r\n        BDK:  " + theBDK.Text
+ "\r\n    BDK KCV:  " + kcv4.Text
+ "\r\n\r\n      KEY 1:  " + Common.getHexStringFromBytes(compk1)
+ "\r\n   KEY1 KCV:  " + Common.getHexStringFromBytes(compk1k)
+ "\r\n\r\n      KEY 2:  " + Common.getHexStringFromBytes(compk2)
+ "\r\n   KEY2 KCV:  " + Common.getHexStringFromBytes(compk2k);

            }
        }

        private void comp1_TextChanged(object sender, EventArgs e)
        {
            if (comp1.Text.Trim().Length == 32)
            {
                kcv1.Text = Common.getHexStringFromBytes(Common.getKCV(Common.getByteArray(comp1.Text)));

            }
            else kcv1.Text = "000000";
        }

        private void comp2_TextChanged(object sender, EventArgs e)
        {
            if (comp2.Text.Trim().Length == 32)
            {
                kcv2.Text = Common.getHexStringFromBytes(Common.getKCV(Common.getByteArray(comp2.Text)));

            }
            else kcv2.Text = "000000";
        }

        private void comp3_TextChanged(object sender, EventArgs e)
        {
            if (comp3.Text.Trim().Length == 32)
            {
                kcv3.Text = Common.getHexStringFromBytes(Common.getKCV(Common.getByteArray(comp3.Text)));

            }
            else kcv3.Text = "000000";
        }

        private void theBDK_TextChanged(object sender, EventArgs e)
        {
            if (theBDK.Text.Trim().Length == 32)
            {
                kcv4.Text = Common.getHexStringFromBytes(Common.getKCV(Common.getByteArray(theBDK.Text)));

            }
            else kcv4.Text = "000000";
        }

        private void tdes_CheckedChanged_1(object sender, EventArgs e)
        {
            panelPINBlock.Visible = tdes.Checked;
        }
    }
    }
