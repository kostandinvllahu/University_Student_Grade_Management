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
            txtID.Text = "";
        }

        public void populate()
        {
            cmbstatus.SelectedIndex = 0;
            sql = "select * from students";
            frm.populateData(sql, table, dataGridView1);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //frm.searchFilter("", "", dataGridView1);
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                txtID.Text = row.Cells["ID"].Value.ToString();
                txtFirstName.Text = row.Cells["Firstname"].Value.ToString();
                txtLastName.Text = row.Cells["Lastname"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                status = Convert.ToInt32(row.Cells["Status"].Value.ToString());
                cmbstatus.SelectedIndex = (status == 1 ?  0 : 1);
            }
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
                if(txtID.Text == "")
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
                else
                {
                    status = (cmbstatus.Text == "Active" ? 1 : 0);
                    sql = "update `students` set `Firstname`='" + txtFirstName.Text + "', `Lastname`='" + txtLastName.Text + "', `Email`='" + txtEmail.Text + "', `Status`='" + status + "' where `ID`='"+txtID.Text+"'";
                    frm.InsertMethod(sql, "Failed to save students please try again!", "Students saved successfully!");
                    clean();
                }
                
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            sql = "select * from students where concat(`ID`,`Firstname`,`Lastname`,`Email`,`Status`) like '%" + txtSearch.Text + "%'";
            frm.searchFilter(sql, table, dataGridView1);
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Please select a student to delete!");
            }
            else
            {
                DialogResult dlg = MessageBox.Show("Warning you are about to delete permantly this student are you sure you want to delete it!", "WARNING", MessageBoxButtons.YesNo);
                if (dlg == DialogResult.Yes)
                {
                    sql = "delete from `students` where `ID`='" + txtID.Text + "'";
                    frm.InsertMethod(sql, "Failed to delete student please try again!", "Student deleted successfully!");
                    clean();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }
    }
}
