using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IDTechSDK;

namespace USDKDemo
{
    public partial class CAPKForm : Form
    {
        private System.Windows.Forms.TextBox _tb;
        public CAPKForm(ref System.Windows.Forms.TextBox tb)
        {
            InitializeComponent();
            _tb = tb;
            if (_tb != null && _tb.Text.Length > 100)
            {
                string txt = _tb.Text;
                populateCAPK(txt);
            }
        }

        private byte[] calculateCAPKHash(string RID, string index, string modulus, bool is03Exp)
        {

            //CyberChef -> From Hex + SHA1


            StringBuilder sb = new StringBuilder();
            sb.Append(RID);
            sb.Append(index);
            sb.Append(modulus);
            if (is03Exp) sb.Append("03");
            else sb.Append("010001");

            using (SHA1Managed sha1 = new SHA1Managed())
            {
                byte[] hash = sha1.ComputeHash(Common.getByteArray(sb.ToString()));
                return hash;
            }

            return null;
        }

        private void CAPKForm_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void populateCAPK(string txt)
        {
            rid.Text = txt.Substring(0, 10);
            index.Text = txt.Substring(10, 2);
            hash.Text = txt.Substring(16, 40);
            string val = txt.Substring(63, 1);
            if (val.Equals("3")) rb3.Checked = true; else rb1.Checked = true;
            modulus.Text = txt.Substring(68, txt.Length - 68);
        }

        private string createCAPK()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(rid.Text);
            sb.Append(index.Text);
            sb.Append("0101");
            sb.Append(hash.Text);
            if (rb1.Checked)
                sb.Append("00010001");
            else
                sb.Append("00000003");
            int val = modulus.Text.Length / 2;

            byte[] theLen = new byte[] { (byte)(val & 0xff), (byte)((val / 0x100) & 0xff) } ;
            sb.Append(IDTechSDK.Common.getHexStringFromBytes(theLen));
            sb.Append(modulus.Text);
           return sb.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _tb.Text = createCAPK();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = rid.Text + index.Text + ".capk";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(saveFileDialog1.OpenFile());
                writer.WriteLine(createCAPK());
                writer.Dispose();
                writer.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (myStream = openFileDialog1.OpenFile())
                {

                    
                    StreamReader reader = new StreamReader(myStream);


                   populateCAPK(reader.ReadLine());

                    reader.Dispose();
                    reader.Close();
                  

                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            byte[] hashValue = calculateCAPKHash(rid.Text, index.Text, modulus.Text, rb3.Checked);
            hash.Text = Common.getHexStringFromBytes(hashValue);
        }
    }
}
