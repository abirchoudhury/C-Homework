using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserLogin
{
    public partial class Form1 : Form
    {
        static bool _captchaSuccess;
        static int _captchaAnswer;
        static string userNameOnFile = "brettpubg";
        static string passwordOnFile = "pubg1234";


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Random r = new Random();
            int captchaNumber1 = r.Next(1, 10);
            int captchaNumber2 = r.Next(1, 10);

            firstAdd.Text = captchaNumber1.ToString();
            secondAdd.Text = captchaNumber2.ToString();

            _captchaAnswer = captchaNumber1 + captchaNumber2;


        }

        private void Login_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUser.Text) || string.IsNullOrEmpty(txtPass.Text))
            {
                MessageBox.Show("Please enter both username and password to login.");
                txtUser.Clear();
                txtPass.Clear();
                txtUser.Focus();
            }
            else
            {
                if (int.TryParse(txtTotal.Text, out int b))
                {
                    if (b == _captchaAnswer)
                    {
                        _captchaSuccess = true;
                    }
                    else
                    {
                        _captchaSuccess = false;
                        MessageBox.Show("Please re-enter your answer.");
                        txtTotal.Clear();
                        txtTotal.Focus();
                    }
                }
            }

            if (_captchaSuccess)
            {
                if(txtUser.Text == userNameOnFile && txtPass.Text == passwordOnFile)
                {
                    MessageBox.Show("Congratulations, you have succesfully logged in!");
                }
                else
                {
                    MessageBox.Show("Incorrect user/pass. Please try again");
                    txtUser.Clear();
                    txtPass.Clear();
                    txtTotal.Clear();
                    txtUser.Focus();
                }
            }


        }
    }
}
