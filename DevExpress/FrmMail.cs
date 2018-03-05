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


namespace DevExpress
{
    public partial class FrmMail : Form
    {
        public FrmMail()
        {
            InitializeComponent();
        }

        public string mail;
        private void FrmMail_Load(object sender, EventArgs e)
        {
            TxtMail.Text = mail;
        }

        private void BtnGonder_Click(object sender, EventArgs e)
        {
            MailMessage message = new MailMessage();
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Credentials = new System.Net.NetworkCredential("ahmet@ahmetserefoglu.com", "Ahmet.223046");
            smtpClient.Port = 587;
            smtpClient.Host = "mail.ahmetserefoglu.com";
            smtpClient.EnableSsl = true;
            message.To.Add(TxtMail.Text);
            message.From = new MailAddress("ahmet@ahmetserefoglu.com");
            message.Subject = TxtKonu.Text;
            message.Body = RchMesaj.Text;
            smtpClient.Send(message);
        }
    }
}
