using MySql.Data.MySqlClient;
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
            string query = "select * from settings where LoginPassword='"+textBox1.Text+"'";
            MySqlConnection con = new MySqlConnection("SERVER=127.0.0.1;PORT=3306;DATABASE=dtb;UID=root;");
            MySqlCommand cmd = new MySqlCommand(query,con);
            cmd.CommandTimeout = 60;
            MySqlDataReader reader;
            try
            {
                con.Open();
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        AdminPanel adm = new AdminPanel();
                        adm.Show();
                        this.Close();
                    }

                }
                else
                {
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    MessageBox.Show("Wrong password!", "Error", buttons, MessageBoxIcon.Error);
                    label1.Visible = false;
                    textBox1.Visible = false;
                    button4.Visible = false;
                }
            }catch(Exception ex)
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show("Something Went Wrong!", "Error", buttons, MessageBoxIcon.Error);
                label1.Visible = false;
                textBox1.Visible = false;
                button4.Visible = false;
            }
         }
      

        private void button2_Click(object sender, EventArgs e)
        {
            EmailPanel em = new EmailPanel();
            em.Show();
            this.Close();
        }
    }
}
