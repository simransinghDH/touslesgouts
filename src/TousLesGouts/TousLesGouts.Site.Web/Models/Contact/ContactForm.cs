using TousLesGouts.Site.Web.Mvc;

namespace TousLesGouts.Site.Web.Models.Contact
{
    public class ContactForm
    {
        [UmbracoDisplay("Contact.Labels.Naam")]
        [UmbracoRequired("Contact.Validatie.Naam")]
        public string Name { get; set; }

        [UmbracoDisplay("Contact.Labels.Email")]
        [UmbracoRequired("Contact.Validatie.Email")]
        [UmbracoRegexValidation("^\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*$", ErrorMessage = "Contact.Validatie.EmailGeldig")]
        public string Email { get; set; }

        [UmbracoDisplay("Contact.Labels.Telefoon")]
        [UmbracoRequired("Contact.Validatie.Telefoon")]
        [UmbracoRegexValidation("^\\+?[\\d \\./]*$", ErrorMessage = "Contact.Validatie.TelefoonGeldig")]
        public string Telephone { get; set; }

        [UmbracoDisplay("Contact.Labels.Boodschap")]
        [UmbracoRequired("Contact.Validatie.Boodschap")]
        public string Message { get; set; }

        public override string ToString()
        {
            return string.Format("Naam: {0}<br />Email: {1}<br />Telefoon: {2}<br />Boodschap:<br />{3}", Name, Email, Telephone, Message);
        }
    }
}