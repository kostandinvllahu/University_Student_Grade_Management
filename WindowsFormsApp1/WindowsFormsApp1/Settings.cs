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
    public partial class Settings : Form
    {
        Form1 frm = new Form1();
        string conn;
        string sql;
        string table = "settings";
        bool error = true;
        string ID;
        public Settings()
        {
            InitializeComponent();
            populate();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            error = false;

            if(txtLoginPassword.Text == "")
            {
                MessageBox.Show("Please insert password for login.");
                error = true;
            }

            if(txtEmail.Text == "")
            {
                MessageBox.Show("Please insert Email.");
                error = true;
            }

            if(txtEmailPassword.Text == "")
            {
                MessageBox.Show("Please insert email password.");
                error = true;
            }

            if(txtHost.Text == "")
            {
                MessageBox.Show("Please insert the email host service provider.");
                error = true;
            }

            if (!error)
            {
                sql = "update `settings` set `LoginPassword`='" + txtLoginPassword.Text + "', `Email`='" + txtEmail.Text + "', `EmailPassword`='" + txtEmailPassword.Text + "', `Host`='" + txtHost.Text + "' where `ID`='" + ID + "'";
                frm.InsertMethod(sql, "Failed to save settings please try again!", "Settings saved successfully!");
                clean();
                
            }
        }

        private void clean()
        {
            populate();
            ID = "";
            txtLoginPassword.Text = "";
            txtEmail.Text = "";
            txtEmailPassword.Text = "";
            txtHost.Text = "";
        }

        private void populate()
        {
                table = "subject";
                sql = "select * from settings";
                frm.populateData(sql, table, dataGridView1);
        }

        private void Settings_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                ID = row.Cells["ID"].Value.ToString();
                txtLoginPassword.Text = row.Cells["LoginPassword"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtEmailPassword.Text = row.Cells["EmailPassword"].Value.ToString();
                txtHost.Text = row.Cells["Host"].Value.ToString();
            }
        }
    }
}
