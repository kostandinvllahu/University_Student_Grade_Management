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
    public partial class classes : Form
    {
        Form1 frm = new Form1();
        string conn;
        string sql;
        int status = 0;
        string table = "classes";
        bool error = false;
        string id = "";

        public classes()
        {
            InitializeComponent();
            populate();
        }

        private void populate()
        {
            sql = "select * from classes";
            frm.populateData(sql, table, dataGridView1);
        }

        private void classes_Load(object sender, EventArgs e)
        {

        }

        private void clean()
        {
            txtsearch.Text = "";
            txtpoint.Text = "";
            txtLetter.Text = "";
            populate();
            id = "";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                id = row.Cells["ID"].Value.ToString();
                txtLetter.Text = row.Cells["lettergrade"].Value.ToString();
                txtpoint.Text = row.Cells["pointgrade"].Value.ToString();
            }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            sql = "select * from classes where concat(`ID`,`studentname`,`subject`,`year`,`studentid`,`semester`,`pointgrade`,`credit`) like '%" + txtsearch.Text + "%'";
            frm.searchFilter(sql, table, dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            error = false;

            if(txtLetter.Text == "")
            {
                MessageBox.Show("Please insert the letter grade!");
                error = true;
            }

            if(txtpoint.Text == "")
            {
                MessageBox.Show("Please insert the points!");
                error = true;
            }

            if (!error)
            {
                sql = "update `classes` set `lettergrade`='" + txtLetter.Text + "', `pointgrade`='" + txtpoint.Text + "'where `ID`='" + id + "'";
                frm.InsertMethod(sql, "Failed to save students please try again!", "Students saved successfully!");
                clean();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clean();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (id == "")
            {
                MessageBox.Show("Please select a student to delete!");
            }
            else
            {
                DialogResult dlg = MessageBox.Show("Warning you are about to delete permantly this student are you sure you want to delete it!", "WARNING", MessageBoxButtons.YesNo);
                if (dlg == DialogResult.Yes)
                {
                    sql = "delete from `classes` where `ID`='" + id + "'";
                    frm.InsertMethod(sql, "Failed to delete student please try again!", "Student deleted successfully!");
                    clean();
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtLetter_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtpoint_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }
    }
}
