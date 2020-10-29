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
    public partial class DecryptForm : Form
    {
        public DecryptForm()
        {
            InitializeComponent();
        }

        private void decryptButton_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("encrypted.txt");
            List<string> input = new List<string>();
            while(!sr.EndOfStream)
                input.Add(sr.ReadLine());
            sr.Close();
            string result = "";
            BigInteger bigInteger;
            foreach (var item in input)
            {
                bigInteger = new BigInteger(Convert.ToDouble(item));
                bigInteger = BigInteger.Pow(bigInteger, (int)Form1.D);
                BigInteger long_n = new BigInteger(Form1.N);
                bigInteger %= long_n;
                int index = Convert.ToInt32(bigInteger.ToString());
                result += Form1.symbols[index].ToString();
            }
            richTextBox1.Text = result;
        }
    }
}
