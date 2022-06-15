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
    public partial class TranscriptDownload : Form
    {
        Form1 frm = new Form1();
        string conn;
        string sql;
        string pointgrade = "-"; string lettergrade = "-";
        string table = "classes";
        bool error = false;
        string name; string subject; string credit;
        public TranscriptDownload()
        {
            InitializeComponent();
            populateStudents();
        }

        private void populateStudents()
        {
            sql = "select * from classes";
            frm.populateData(sql, table, dataGridView1);
        }

        private void TranscriptDownload_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            txtStudentID.Text = row.Cells["studentId"].Value.ToString();
            sql = "select year from classes where studentId='" + txtStudentID.Text + "'";
            frm.populateComboBox(sql, table, "Year", "Year", cmbYear);
            sql = "select subject, subjectId from classes where studentId='"+txtStudentID.Text+"'";
            frm.populateComboBox(sql, table, "subject", "subjectId", cmbSubject);
            sql = "select semester from classes where studentId='"+txtStudentID.Text+"'";
            frm.populateComboBox(sql, table, "semester", "semester", cmbSemester);
        }
    }
}
