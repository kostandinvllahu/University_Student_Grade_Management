using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        MySqlConnection con = new MySqlConnection("SERVER=195.179.237.102;DATABASE=u583974297_dtb;UID=u583974297_dtb;PASSWORD=W0>bWizi");
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataAdapter mda = new MySqlDataAdapter();
        DataTable dtb = new DataTable();
        DataSet ds = new DataSet();
        int result;

        //"SERVER=127.0.0.1;PORT=3306;DATABASE=dtb;UID=root;"

        public string connstring = "SERVER=195.179.237.102;DATABASE=u583974297_dtb;UID=u583974297_dtb;PASSWORD=W0>bWizi";


        public void searchFilter(string sql,string table, DataGridView dtg)
        {
            cmd = new MySqlCommand(sql, con);
            mda = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            mda.Fill(ds, table);
            dtg.DataSource = ds.Tables[table];
        }

        public void populateData(string sql, string table, DataGridView dtg)
        {
             mda = new MySqlDataAdapter(sql, con);

            try
            {
                con.Open();
                ds = new DataSet();
                mda.Fill(ds, table);
                dtg.DataSource = ds.Tables[table];
                con.Close();
            }catch(Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }

        public void InsertMethod(string sql, string msg_false, string msg_true)
        {
            try
            {
                con.Open();
                cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = sql;
                result = cmd.ExecuteNonQuery();

                if(result > 0)
                {
                    MessageBox.Show(msg_true);
                }
                else
                {
                    MessageBox.Show(msg_false);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public Form1()
        {
            InitializeComponent();
            label1.Visible = false;
            panel1.Visible = false;
            panel2.Visible = false;
            timer1.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkconnection()
        {
            try
            {
                con = new MySqlConnection();
                con.ConnectionString = connstring;
                con.Open();
                MainMenu mn = new MainMenu();
                mn.Show();
                this.Hide();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show("Opss.. There was an error with the message: " + ex.Message + "please contact the developer of the program!","Connection Error", buttons, MessageBoxIcon.Error);
                button1.Enabled = true;
            }
        }
        
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            panel2.Width += 3;

            if(panel2.Width >= 599)
            {
                timer1.Stop();
                checkconnection();
                timer1.Enabled = false;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            label1.Visible = true;
            panel1.Visible = true;
            panel2.Visible = true;
            timer1.Enabled = true;
            button1.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
