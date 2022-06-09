using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            textBox1.Visible = true;
            button4.Visible = true;
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string password = "adminpanel1980";
            if (textBox1.Text.Equals(password))
            {
                AdminPanel adm = new AdminPanel();
                adm.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Wrong password!");
                label1.Visible = false;
                textBox1.Visible = false;
                button4.Visible = false;
            }
        }
    }
}
