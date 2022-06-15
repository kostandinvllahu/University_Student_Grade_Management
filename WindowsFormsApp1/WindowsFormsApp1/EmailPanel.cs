using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Web;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class EmailPanel : Form
    {
        MySqlConnection con = new MySqlConnection("SERVER=127.0.0.1;PORT=3306;DATABASE=dtb;UID=root;");
        MySqlCommand cmd = new MySqlCommand("select Email, EmailPassword, Host from settings where ID=1");
        MySqlDataAdapter mda = new MySqlDataAdapter();
        DataTable dtb = new DataTable();
        DataSet ds = new DataSet();

        NetworkCredential login;
        SmtpClient client;
        MailMessage msg;
        string fromAddress;
        string fromPassword;
        string Host;
        public EmailPanel()
        {
            InitializeComponent();
            getSettings();
        }

        private void getSettings()
        {
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            try
            {
                MySqlDataReader dr;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                     fromAddress = dr.GetString("Email");
                     fromPassword = dr.GetString("EmailPassword");
                     Host = dr.GetString("Host");
                }
            }catch(Exception ex)
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(ex.Message, "Error", buttons, MessageBoxIcon.Error);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {

            string toAddress = txtReceiver.Text;
            string subject = txtSubject.Text;
            string body = txtMessage.Text;

            try
            {
                MailMessage mail = new MailMessage(fromAddress, toAddress, subject, body);
                mail.Attachments.Add(new Attachment(txtAttach.Text));
                SmtpClient smtp = new System.Net.Mail.SmtpClient();
                {

                    smtp.Host = Host;
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                    smtp.Timeout = 20000;
                    smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
                }
                smtp.Send(mail);
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show("Email was sent successfully!", "Success", buttons, MessageBoxIcon.Information);
            }catch(Exception ex)
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show("Email failed to sent contact developer if error is repeated!", "Error", buttons, MessageBoxIcon.Error);
            }
         }


       
        private void button3_Click(object sender, EventArgs e)
        {
            MainMenu mn = new MainMenu();
            mn.Show();
            this.Close();
        }

        private void txtAttach_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog.FileName.ToString();
                txtAttach.Text = path;
            }
        }

        private void EmailPanel_Load(object sender, EventArgs e)
        {

        }
    }
}
