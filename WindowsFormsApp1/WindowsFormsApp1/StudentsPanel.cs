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

        public StudentsPanel()
        {
            InitializeComponent();
            conn = frm.connstring;
            cmbstatus.SelectedIndex = 0;
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
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            status = (cmbstatus.Text == "Active" ? 1 : 0);
            sql = "insert into `students` (`Firstname`, `Lastname`, `Email`, `Status`) values " +
                "('" + txtFirstName.Text + "' " +
                ",'" + txtLastName.Text + "' " +
                ", '" + txtEmail.Text + "' " +
                ", '" + status + "')";
            frm.InsertMethod(sql, "Failed to save students please try again!", "Students saved successfully!");
        }
    }
}
