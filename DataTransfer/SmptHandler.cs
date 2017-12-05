using System.Net;
using System.Net.Mail;

namespace DataTransfer
{
    internal class SmtpHandler
    {
        internal static void SendMessage(string subject, string body)
        {
#if DEBUG
            var emailAddress = "";
#else
            var emailAddress = "";
#endif

            var email = new MailMessage("", emailAddress)
            {
                Subject = subject,
                Body = body
            };

            using (var client = new SmtpClient())
            {
                client.Port = 25;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Host = "";
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("",
                    "");

                client.Send(email);
            }
        }
    }
}
