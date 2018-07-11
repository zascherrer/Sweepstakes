using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace Sweepstakes
{
    public static class MailSender
    {

        public static void SendMail(string message, string recipient)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("zscherrer@carthage.edu");
                mail.To.Add(recipient);
                mail.Subject = "Congratulations, you've won!!!";
                mail.Body = message;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("zscherrer@carthage.edu", EmailPassword.password);
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception caught: {0}", e.Message);
            }
        }
    }
}
