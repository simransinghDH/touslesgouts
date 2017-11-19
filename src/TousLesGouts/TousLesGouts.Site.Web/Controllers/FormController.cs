using System.Collections.Specialized;
using System.Web.Mvc;
using TousLesGouts.Site.Web.Models.Contact;
using TousLesGouts.Site.Web.Models.Mails;
using Umbraco.Web.Mvc;

namespace TousLesGouts.Site.Web.Controllers
{
    public class FormController : SurfaceController
    {
        private IMailProcessor mailProcessor;

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(ContactForm model)
        {
            if (!ModelState.IsValid)
            {
                return CurrentUmbracoPage();
            }

            var contactPage = Umbraco.Content(1078);
            mailProcessor = new MailProcessor();
            string result = mailProcessor.Send(model, contactPage.mailAddress).ToString().ToLowerInvariant();

            var queryString = new NameValueCollection();
            queryString.Add("succes", result);

            return RedirectToCurrentUmbracoPage(queryString);
        }
    }
}