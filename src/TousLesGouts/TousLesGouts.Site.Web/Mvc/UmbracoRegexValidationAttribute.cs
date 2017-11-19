using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace TousLesGouts.Site.Web.Mvc
{
    public class UmbracoRegexValidationAttribute : RegularExpressionAttribute, IClientValidatable
    {
        public UmbracoRegexValidationAttribute(string pattern) : base(pattern)
        {
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }

            var regex = new Regex(Pattern, RegexOptions.Compiled);
            return regex.IsMatch(value.ToString());
        }

        public override string FormatErrorMessage(string name)
        {
            return UmbracoValidationHelper.GetDictionaryItem(ErrorMessage);
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            yield return new ModelClientValidationRegexRule(FormatErrorMessage(metadata.DisplayName), Pattern);
        }
    }
}