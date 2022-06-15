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
    public partial class Subjects : Form
    {
        Form1 frm = new Form1();
        string conn;
        string sql;
        int status = 0;
        string table = "subject";
        bool error = false;
        
        
        public Subjects()
        {
            InitializeComponent();
            conn = frm.connstring;
            populate();
           
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            error = false;
            if(txtcoursename.Text == "")
            {
                MessageBox.Show("Please insert course name!");
                error = true;
            }

            if(txtcredit.Text == "")
            {
                MessageBox.Show("Please insert credit of course!");
                error = true;
            }

            if (error == false)
            {
                if(txtID.Text == "")
                {
                    status = (cmbstatus.Text == "Active" ? 1 : 0);
                    sql = "insert into `subject` (`course`, `credit`, `status`) values " +
                        "('" + txtcoursename.Text + "' " +
                        ",'" + txtcredit.Text + "' " +
                        ", '" + status + "')";
                    frm.InsertMethod(sql, "Failed to save course please try again!", "Course saved successfully!");
                    clean();
                }
                else
                {
                    status = (cmbstatus.Text == "Active" ? 1 : 0);
                    sql = "update `subject` set `course`='" + txtcoursename.Text + "', `credit`='" + txtcredit.Text + "', `Status`='" + status + "' where `ID`='" + txtID.Text + "'";
                    frm.InsertMethod(sql, "Failed to save course please try again!", "Course saved successfully!");
                    clean();
                }
               
            }
        }

        private void clean()
        {
            txtcoursename.Text = "";
            txtcredit.ResetText();
            cmbstatus.Text = "";
            txtSearch.Text = "";
            populate();
            txtID.Text = "";
        }

        public void populate()
        {
            cmbstatus.SelectedIndex = 0;
            sql = "select * from subject";
            frm.populateData(sql,table, dataGridView1);
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            clean();
        }

        private void Subjects_Load(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            sql = "select * from subject where concat(`ID`,`course`,`credit`,`status`) like '%" + txtSearch.Text + "%'";
            frm.searchFilter(sql, table, dataGridView1);
        }
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //frm.searchFilter("","",dataGridView1);
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                txtID.Text = row.Cells["ID"].Value.ToString();
                txtcoursename.Text = row.Cells["course"].Value.ToString();
                txtcredit.Text = row.Cells["credit"].Value.ToString();
                status = Convert.ToInt32(row.Cells["Status"].Value.ToString());
                cmbstatus.SelectedIndex = (status == 1 ? 0 : 1);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if(txtID.Text == "")
            {
                MessageBox.Show("Please select a course to delete!");
            }
            else
            {
                DialogResult dlg = MessageBox.Show("Warning you are about to delete permantly this course are you sure you want to delete it!", "WARNING", MessageBoxButtons.YesNo);
                if (dlg == DialogResult.Yes)
                {
                    sql = "delete from `subject` where `ID`='" + txtID.Text + "'";
                    frm.InsertMethod(sql, "Failed to delete course please try again!", "Course deleted successfully!");
                    clean();
                }
            }  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
