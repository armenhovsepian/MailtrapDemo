using System;
using System.Net;
using System.Net.Mail;

namespace MailtrapConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Papercut();
            Mailtrap();
        }


        /// <summary>
        /// https://github.com/ChangemakerStudios/Papercut/releases
        /// </summary>
        static void Papercut()
        {
            var client = new SmtpClient("127.0.0.1", 25);
            client.Send("from@example.com", "to@example.com", "Hello Armen", "testbody");
            Console.WriteLine("Sent");
            Console.ReadLine();
        }


        /// <summary>
        /// https://mailtrap.io
        /// https://www.romaniancoder.com/email-testing-for-developers-with-mailtrap/
        /// </summary>
        static void Mailtrap()
        {
            int EmailClientPort = 2525;
            string EmailClientHost = "smtp.mailtrap.io";
            bool EmailClientEnableSSL = true;
            string EmailClientUserName = "1d369290732e64";
            string EmailClientPassword = "b26f5fbf5a9a60";


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
    }
}
