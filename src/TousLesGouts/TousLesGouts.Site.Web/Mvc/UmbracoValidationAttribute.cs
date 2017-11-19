using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace TousLesGouts.Site.Web.Mvc
{
    public abstract class UmbracoValidationAttribute : ValidationAttribute, IClientValidatable
    {
        protected UmbracoValidationAttribute(string umbracoDictionaryKey)
        {
            ErrorMessage = umbracoDictionaryKey;
        }

        public override string FormatErrorMessage(string name)
        {
            return UmbracoValidationHelper.GetDictionaryItem(ErrorMessage);
        }

        public abstract IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context);
    }
}