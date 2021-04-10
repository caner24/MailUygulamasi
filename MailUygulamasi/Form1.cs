using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;

namespace MailUygulamasi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        MailMessage icerik = new MailMessage();
        SmtpClient istemci = new SmtpClient();
        string mail;
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            mail = textBox1.Text;
            if (mail.Substring(mail.IndexOf("@")) == "@hotmail.com")
            {

                istemci.Credentials = new System.Net.NetworkCredential(textBox1.Text, textBox2.Text);
                istemci.Port = 587;
                istemci.Host = "smtp.live.com";
                istemci.EnableSsl = true;
            }
            else if (mail.Substring(mail.IndexOf("@")) == "@outlook.com")
            {
                istemci.Credentials = new System.Net.NetworkCredential(textBox1.Text, textBox2.Text);
                istemci.Port = 587;
                istemci.Host = "smtp.live.com";
                istemci.EnableSsl = true;
            }
            else if (mail.Substring(mail.IndexOf("@")) == "@gmail.com")
            {
                istemci.Credentials = new System.Net.NetworkCredential(textBox1.Text, textBox2.Text);
                istemci.Port = 587;
                istemci.Host = "smtp.gmail.com";
                istemci.EnableSsl = true;
            }
            groupBox3.Visible = true;
            groupBox2.Visible = false;
            groupBox3.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            groupBox3.Visible = false;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            icerik.To.Add(textBox4.Text);
            icerik.From = new MailAddress(mail);
            icerik.Subject = textBox3.Text;
            icerik.Body = richTextBox1.Text;
            istemci.Send(icerik);
        }
    }
}
