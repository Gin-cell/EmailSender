using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string gmailAcc = textBox1.Text;
            string password = textBox2.Text;
            string to = textBox3.Text;
            string subject = textBox4.Text;
            string message, emailid;

            NetworkCredential logininfo = new NetworkCredential(gmailAcc, password);
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(gmailAcc);
            msg.To.Add(new MailAddress(to));
            msg.Subject = subject;
            msg.Body = richTextBox1.Text;
            msg.IsBodyHtml = true;


            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com");
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = logininfo;
                client.Send(msg);
                MessageBox.Show("Sent succesfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
