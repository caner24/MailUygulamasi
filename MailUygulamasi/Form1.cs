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

        //            *********************************************************** Developed by caner24 *************************************************************** 

        MailMessage icerik = new MailMessage(); // Mail mesajı göndermek için mailmessaje nesnesi oluşturduk.
        SmtpClient istemci = new SmtpClient();  // Mesajımızı göndermek için istemciye ihtiyacımız var , istemcimizi oluşturduk.
        string mail;  // Mail adresimizi string nesneye aktarmak için string mail nesnesi oluşturduk.
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            mail = textBox1.Text; // mail adresimizi textboxa girilen değerden alması için textboxa girilen değeri string nesnesine aktardık.

            if (mail.Substring(mail.IndexOf("@")) == "@hotmail.com") // Farklı uzantıların farklı domainlerin olduğu için String özelliklerinden substring ve ındexof işlemini kullanarak @ den sonraki adrese göre Host adresimizi belirledik.
            {

                istemci.Credentials = new System.Net.NetworkCredential(textBox1.Text, textBox2.Text); // Atacağımız maili gönderecek mail adresinin epostası ve şifresi textboxdan alınan verilerle girildi.
                istemci.Port = 587; // Türkiye'de genellikle 587 portu kullanıldığı için 587 portu seçildi.
                istemci.Host = "smtp.live.com";
                istemci.EnableSsl = true; // SSL güvenlik ilkesi etkinleştirildi
            }
            else if (mail.Substring(mail.IndexOf("@")) == "@outlook.com") // Farklı uzantıların farklı domainlerin olduğu için String özelliklerinden substring ve ındexof işlemini kullanarak @ den sonraki adrese göre Host adresimizi belirledik.
            {
                istemci.Credentials = new System.Net.NetworkCredential(textBox1.Text, textBox2.Text); // Atacağımız maili gönderecek mail adresinin epostası ve şifresi textboxdan alınan verilerle girildi.
                istemci.Port = 587; // Türkiye'de genellikle 587 portu kullanıldığı için 587 portu seçildi.
                istemci.Host = "smtp.live.com";
                istemci.EnableSsl = true; // SSL güvenlik ilkesi etkinleştirildi
            } 
            else if (mail.Substring(mail.IndexOf("@")) == "@gmail.com") // Farklı uzantıların farklı domainlerin olduğu için String özelliklerinden substring ve ındexof işlemini kullanarak @ den sonraki adrese göre Host adresimizi belirledik.
            {
                istemci.Credentials = new System.Net.NetworkCredential(textBox1.Text, textBox2.Text); // Atacağımız maili gönderecek mail adresinin epostası ve şifresi textboxdan alınan verilerle girildi.
                istemci.Port = 587; // Türkiye'de genellikle 587 portu kullanıldığı için 587 portu seçildi.
                istemci.Host = "smtp.gmail.com";
                istemci.EnableSsl = true; // SSL güvenlik ilkesi etkinleştirildi
            }

            // Giriş panelinde 2 tane groupbox olduğu için biri işlemini tamamladığında kapanıp diğerinin açılması için işlemler yapıldı.

            groupBox3.Visible = true;  
            groupBox2.Visible = false;
            groupBox3.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            groupBox3.Visible = false;   // Giriş panelinde 2 tane groupbox olduğu için biri işlemini tamamladığında kapanıp diğerinin açılması için işlemler yapıldı.
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            icerik.To.Add(textBox4.Text);         // Yacazağımız mesaj hangi mail adresine gideceğini belirttik.
            icerik.From = new MailAddress(mail);  // Yazacağımız mesaj hangi mail adresinden gideceğini belirttik.
            icerik.Subject = textBox3.Text;       // Mesajın başlığını belirttik.
            icerik.Body = richTextBox1.Text;      // Mesajın içeriğini belirttik.
            istemci.Send(icerik);                 // İstemciye mesajı yollayarak mesajı ilettik.
        }
    }
}
