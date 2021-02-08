using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace USDKDemo
{
    public partial class Signature : Form
    {
        public Signature(Image img)
        {
            InitializeComponent();
            pictureBox1.Image = img;
        }
    }
}
