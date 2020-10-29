using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSA
{
    public partial class EncryptForm : Form
    {
        public EncryptForm()
        {
            InitializeComponent();
        }

        private void encryptButton_Click(object sender, EventArgs e)
        {   
            List<string> result = new List<string>();
            string s = richTextBox1.Text.ToUpper();
            BigInteger bigInteger;
            for (int i = 0; i < s.Length; i++)
            {
                int index = Array.IndexOf(Form1.symbols, s[i]);
                bigInteger = new BigInteger(index);
                bigInteger = BigInteger.Pow(bigInteger, (int)Form1.E);
                BigInteger long_n = new BigInteger(Form1.N);
                bigInteger %= long_n;
                result.Add(bigInteger.ToString());
            }
            StreamWriter sw = new StreamWriter("encrypted.txt");
            foreach (var item in result)
                sw.WriteLine(item);
            sw.Close();
            textBox1.Text = Form1.E.ToString();
            textBox2.Text = Form1.N.ToString();
        }
    }
}
