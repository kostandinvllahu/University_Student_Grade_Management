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
    public partial class StudentsPanel : Form
    {
        Form1 frm = new Form1();
        string conn;
        string sql;
        int status = 0;
        string table = "students";
        bool error = false;

        public StudentsPanel()
        {
            InitializeComponent();
            conn = frm.connstring;
            cmbstatus.SelectedIndex = 0;
            populate();
        }

        private void StudentsPanel_Load(object sender, EventArgs e)
        {

        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            clean();
        }

        private void clean()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            cmbstatus.Text = "";
            txtSearch.Text = "";
            txtEmail.Text = "";
            populate();
        }

        public void populate()
        {
            sql = "select * from students";
            frm.populateData(sql, table, dataGridView1);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            frm.searchFilter("", "", dataGridView1);
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            error = false;
            if(txtFirstName.Text == "")
            {
                MessageBox.Show("Please fill the first name!");
                error = true;
            }

            if(txtLastName.Text == "")
            {
                MessageBox.Show("Please fill the last name!");
                error = true;
            }

            if(txtEmail.Text == "")
            {
                MessageBox.Show("Please fill the email!");
                error = true;
            }


            if (error == false)
            {
                status = (cmbstatus.Text == "Active" ? 1 : 0);
                sql = "insert into `students` (`Firstname`, `Lastname`, `Email`, `Status`) values " +
                    "('" + txtFirstName.Text + "' " +
                    ",'" + txtLastName.Text + "' " +
                    ", '" + txtEmail.Text + "' " +
                    ", '" + status + "')";
                frm.InsertMethod(sql, "Failed to save students please try again!", "Students saved successfully!");
                clean();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            sql = "select * from students where concat(`ID`,`Firstname`,`Lastname`,`Email`,`Status`) like '%" + txtSearch.Text + "%'";
            frm.searchFilter(sql, table, dataGridView1);
        }
    }
}
