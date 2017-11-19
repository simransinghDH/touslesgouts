using TousLesGouts.Site.Web.Models.Contact;

namespace TousLesGouts.Site.Web.Models.Mails
{
    public interface IMailProcessor
    {
        bool Send(ContactForm contactForm, string toAddress);
    }
}
