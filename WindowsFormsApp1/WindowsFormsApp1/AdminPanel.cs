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
        public AdminPanel()
        {
            InitializeComponent();
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
    }
}
