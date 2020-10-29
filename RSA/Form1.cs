using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSA
{
    public partial class Form1 : Form
    {
        public static char[] symbols = new char[] {'#','A','B','C','D',
            'E','F','G','H','I','J','K','L','M','N','O','P','Q',
            'R','S','T','U','V','W','X','Y','Z','А','Б','В','Г',
            'Д','Е','Ё','Ж','З','И','Й','К','Л','М','Н','О','П',
            'Р','С','Т','У','Ф','Х','Ц','Ч','Ш','Щ','Ъ','Ы','Ь',
            'Э','Ю','Я','0','1','2','3','4','5','6','7','8','9',' ',',','?','!','.'};
        public static long E, D, N;
        public Form1()
        {
            InitializeComponent();
        }
        public static bool IsPrime(long a)
        {
            int counter = 0;
            for (long i = 1; i <= a; i++)
                if (a % i == 0) counter++;
            if (counter == 2) return true;
            return false;
        }
        public static long CountE(long d, long m)
        {
            long e = 10;
            while (true)
            {
                if ((e * d) % m == 1) break;
                else e++;
            }
            return e;
        }
        public static long CountD(long m)
        {
            long d = m - 1;
            for (long i = 2; i <= m; i++)
                if ((m % i == 0) && (d % i == 0))
                {
                    d--;
                    i = 1;
                }
            return d;
        }

        private void encryptButton_Click(object sender, EventArgs e)
        {
            EncryptForm encryptForm = new EncryptForm();
            encryptForm.ShowDialog();
        }

        private void decryptButton_Click(object sender, EventArgs e)
        {
            DecryptForm decryptForm = new DecryptForm();
            decryptForm.ShowDialog();
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            try
            {
                long P = long.Parse(textBoxP.Text),
                Q = long.Parse(textBoxQ.Text);
                if (IsPrime(P) && IsPrime(Q))
                {
                    N = P * Q;
                    long M = (P - 1) * (Q - 1);
                    D = CountD(M);
                    E = CountE(D, M);
                    MessageBox.Show("Keys have been generated successfully!", "Success");
                }
                else MessageBox.Show("P and Q must be prime numbers!", "Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
