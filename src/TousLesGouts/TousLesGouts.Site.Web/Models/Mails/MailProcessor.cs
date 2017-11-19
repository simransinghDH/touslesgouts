using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using TousLesGouts.Site.Web.Models.Contact;

namespace TousLesGouts.Site.Web.Models.Mails
{
    public class MailProcessor : IMailProcessor
    {
        public bool Send(ContactForm contactFormModel, string toAddress)
        {
            try
            {
                using (var message = new MailMessage())
                {
                    message.From = new MailAddress(contactFormModel.Email, contactFormModel.Name);
                    message.To.Add(new MailAddress(toAddress, "Tous Les Gouts"));
                    message.IsBodyHtml = true;
                    message.Subject = "Iemand nam contact op via touslesgouts.be";
                    message.Body = contactFormModel.ToString();

                    var smtpUser = new NetworkCredential
                    {
                        UserName = ConfigurationManager.AppSettings["Mail.Username"],
                        Password = ConfigurationManager.AppSettings["Mail.Password"],
                    };

                    string host = ConfigurationManager.AppSettings["Mail.Host"];

                    using (var smtpClient = new SmtpClient())
                    {
                        smtpClient.UseDefaultCredentials = false;
                        smtpClient.Credentials = smtpUser;
                        smtpClient.Host = host;
                        smtpClient.Port = 26;
                        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtpClient.Send(message);
                    }
                }
            }
            catch (SmtpException smtpException)
            {
                return false;
            }
            catch (Exception exception)
            {
                return false;
            }

            return true;
        }
    }
}