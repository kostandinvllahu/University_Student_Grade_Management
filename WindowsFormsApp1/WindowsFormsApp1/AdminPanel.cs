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
    public partial class AdminPanel : Form
    {

        Form1 frm = new Form1();
        string conn;
        string sql;
        string pointgrade = "-"; string lettergrade = "-";
        string table;
        bool error = false;
        string name; string subject; string credit;string subjectID;

        public AdminPanel()
        {
            InitializeComponent();
            populateStudents();
            populateSubjects();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MainMenu mn = new MainMenu();
            mn.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Subjects s = new Subjects();
            s.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StudentsPanel std = new StudentsPanel();
            std.Show();
        }

        private void populateStudents()
        {
            
            cmbSemester.SelectedIndex = 0;
            DateTime dt = DateTime.Today;
            txtyear.Text = dt.ToString("yyyy");
            table = "students";
            sql = "select ID, Firstname, Lastname from students where status='"+ 1 + "'";
            frm.populateData(sql, table, dtgstd);
        }

        private void populateSubjects()
        {
            table = "subject";
            sql = "select ID, course, credit from subject where status='" + 1 + "'";
            frm.populateData(sql, table, dataGridView2);
        }

        private void clean()
        {
            populateStudents();
            populateSubjects();
            txtcls.Text = "";
            txtstd.Text = "";
            txtSearchCls.Text = "";
            txtSearchStd.Text = "";
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {

        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            clean();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            error = false;
            if(txtstd.Text == "")
            {
                MessageBox.Show("Please select a student!");
                error = true;
            }

            if(txtcls.Text == "")
            {
                MessageBox.Show("Please select a class!");
                error = true;
            }

            if(txtyear.Text == "")
            {
                MessageBox.Show("Please select year!");
                error = true;
            }

            if (error == false)
            {
                sql = "insert into `classes` (`studentname`, `studentid`, `subject`,`subjectID`, `year`, `semester`,`lettergrade`,`pointgrade`,`credit`) values " +
                    "('" + name + "' " +
                    ",'" + txtstd.Text + "' " +
                    ", '" + subject + "' " +
                    ",'" +txtcls.Text+"' "+
                    ", '" +txtyear.Text + "' "+
                    ", '" + cmbSemester.Text + "' " +
                    ", '"+pointgrade+ "' " +
                    ", '"+lettergrade + "' "+
                    ",'"+credit+"')";
                frm.InsertMethod(sql, "Failed to save students please try again!", "Students saved successfully!");
                clean();
            }
           
        }

        private void txtSearchStd_TextChanged(object sender, EventArgs e)
        {
            sql = "select ID, Firstname, Lastname from students where concat(`ID`,`Firstname`,`Lastname`,`Email`) like '%" + txtSearchStd.Text + "%' and Status='" + 1 + "'";
            frm.searchFilter(sql, table, dtgstd);
        }

        private void dtgstd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dtgstd.Rows[e.RowIndex];
                txtstd.Text = row.Cells["ID"].Value.ToString();
                name = row.Cells["Firstname"].Value.ToString() + " " + row.Cells["Lastname"].Value.ToString();
            }
        }

        private void txtSearchCls_TextChanged(object sender, EventArgs e)
        {
            sql = "select ID, course, credit from subject where concat(`ID`,`course`,`credit`) like '%" + txtSearchCls.Text + "%' and status='" + 1 + "'";
            frm.searchFilter(sql, table, dataGridView2);
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
                txtcls.Text = row.Cells["ID"].Value.ToString();
                subject = row.Cells["course"].Value.ToString();
                credit = row.Cells["credit"].Value.ToString();
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            classes cls = new classes();
            cls.Show();
        }

        private void cmbSemester_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            TranscriptDownload td = new TranscriptDownload();
            td.Show();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            Settings st = new Settings();
            st.Show();
        }
    }
}
