using System;
using System.Net;
using System.Net.Mail;

namespace MailtrapConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Papercut();
            //MailtrapSMTPServer();
            GmailSMTPServer();
        }


        /// <summary>
        /// https://github.com/ChangemakerStudios/Papercut/releases
        /// </summary>
        static void Papercut()
        {
            var client = new SmtpClient("127.0.0.1", 25);
            client.Send("from@example.com", "to@example.com", "Hello", "testbody");
            Console.WriteLine("Sent");
            Console.ReadLine();
        }


        /// <summary>
        /// https://mailtrap.io
        /// https://www.romaniancoder.com/email-testing-for-developers-with-mailtrap/
        /// </summary>
        static void MailtrapSMTPServer()
        {
            int EmailClientPort = 2525;
            string EmailClientHost = "smtp.mailtrap.io";
            bool EmailClientEnableSSL = true;
            string EmailClientUserName = "username";
            string EmailClientPassword = "password";


            // Create email sender with properties defined bellow
            var smtpClient = new SmtpClient(EmailClientHost, EmailClientPort)
            {
                EnableSsl = EmailClientEnableSSL,
                Credentials = new NetworkCredential(EmailClientUserName, EmailClientPassword)
            };
            // Create mail message
            var from = "from@example.com";
            var to = "to@example.com";
            var subject = "Hello from C# mail sender";
            var body = "This is a test email message sent from a C# app";
            var mailMessage = new MailMessage(from, to, subject, body);
            // Send email
            smtpClient.Send(mailMessage);

            Console.WriteLine("Sent");
            Console.ReadLine();

        }


        /// <summary>
        /// http://csharp.net-informations.com/communications/csharp-smtp-mail.htm
        /// </summary>
        static void GmailSMTPServer()
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("your_email_address@gmail.com");
                mail.To.Add("to_address");
                mail.Subject = "Test Mail";
                mail.Body = "This is for testing SMTP mail from GMAIL";

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("username", "password");
                SmtpServer.EnableSsl = false;

                SmtpServer.Send(mail);
                Console.WriteLine("mail Send");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
