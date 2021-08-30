using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Softia_FP.Models
{
    public class Mail
    {
        static string FromAddress = "gerant.plateforme@gmail.com";
        static string FromAdressTitle = "Responsable Formation Plus";
        static string ToAddress = "crespel.romain@gmail.com";
        
        static string SmtpServer = "smtp.gmail.com";
        static int SmtpPortNumber = 587;

        public static void SendMail(string message, string mail)
        {
            

            var mimeMessage = new MimeMessage();
            mimeMessage.From.Add(new MailboxAddress
                                    (FromAdressTitle,
                                     FromAddress
                                     ));

            mimeMessage.To.Add(new MailboxAddress
                                    ("Etudiant",
                                    ToAddress
                                     ));
            mimeMessage.Subject = "Envoi de l'attestation";
            mimeMessage.Body = new TextPart("plain")
            {
                Text = message
            };

            try
            {
                using (var client = new SmtpClient())
                {
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                    client.Connect(SmtpServer, SmtpPortNumber, SecureSocketOptions.Auto); //SecureSocketOptions.StartTls
                    client.Authenticate(
                        "gerant.plateforme@gmail.com",
                        "Admin1111"
                        );
                    client.Send(mimeMessage);
                    client.Disconnect(true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
