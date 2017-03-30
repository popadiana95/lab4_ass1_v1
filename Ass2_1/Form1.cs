using Ass2_1;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ass2_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        
        private void login()
        {
            UserLogin ul = new UserLogin();

            User user = ul.Login(textBox1.Text, textBox2.Text);
            if (user == null)
                MessageBox.Show("Username or pass incorrect");
            else
            if (user.tip.Equals("a"))
            {
                // Application.EnableVisualStyles();
                //Application.SetCompatibleTextRenderingDefault(false);
                //Application.Run(new FormAdmin());
                Form fa = new FormAdmin();
                fa.Show();
            }
            else
            {
                // Application.EnableVisualStyles();
                // Application.SetCompatibleTextRenderingDefault(false);
                // Application.Run(new FormUser());
                Form fu = new FormUser(user.idUser);
                fu.Show();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            login();
        }
        private void enterPressed(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                login();
            }
        }
    }
}
