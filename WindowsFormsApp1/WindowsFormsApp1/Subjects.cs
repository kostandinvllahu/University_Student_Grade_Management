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
            cmbstatus.SelectedIndex = 0;
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
                status = (cmbstatus.Text == "Active" ? 1 : 0);
                sql = "insert into `subject` (`course`, `credit`, `status`) values " +
                    "('" + txtcoursename.Text + "' " +
                    ",'" + txtcredit.Text + "' " +
                    ", '" + status + "')";
                frm.InsertMethod(sql, "Failed to save course please try again!", "Course saved successfully!");
                clean();
            }
        }

        private void clean()
        {
            txtcoursename.Text = "";
            txtcredit.ResetText();
            cmbstatus.Text = "";
            txtSearch.Text = "";
            populate();
        }

        public void populate()
        {
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
            sql = "select * from subject where concat(`ID`,`course`,`credit`,`status`) like '%" + txtSearch.Text +"%'";
            frm.searchFilter(sql,table, dataGridView1);
        }
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            frm.searchFilter("","",dataGridView1);
        }
    }
}
