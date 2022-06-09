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
        MySqlConnection con = new MySqlConnection("SERVER= 127.0.0.1;PORT=3306;DATABASE=dtb;UID=root;");
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataAdapter mda = new MySqlDataAdapter();
        DataTable dtb = new DataTable();
        DataSet ds = new DataSet();
        int result;
        

        public string connstring = "SERVER= 127.0.0.1;PORT=3306;DATABASE=dtb;UID=root;PASSWORD=";


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
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                con = new MySqlConnection();
                con.ConnectionString = connstring;
                con.Open();
                MainMenu mn = new MainMenu();
                mn.Show();
                this.Hide();
            }catch(MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Opss.. There was an error with the message: " + ex.Message + "please contact the developer of the program!");
            }
        }
    }
}
