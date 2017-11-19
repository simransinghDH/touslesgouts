using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace TousLesGouts.Site.Web.Mvc
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class UmbracoEmailValidationAttribute : UmbracoValidationAttribute
    {
        private readonly string umbracoDictionaryKey;

        public UmbracoEmailValidationAttribute(string umbracoDictionaryKey) : base(umbracoDictionaryKey)
        {
            this.umbracoDictionaryKey = umbracoDictionaryKey;
        }

        public string Name => umbracoDictionaryKey;

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            //No use to check for emptiness in email validation attribute. That's what the [Required] attribute is for.
            string text = value.ToString();
            return string.IsNullOrEmpty(text) || Regex.IsMatch(Regex.Replace(text, "(@)(.+)$", DomainMapper), "^(?(\")(\"[^\"]+?\"@)|(([0-9a-z]((\\.(?!\\.))|[-!#\\$%&'\\*\\+/=\\?\\^`\\{\\}\\|~\\w])*)(?<=[0-9a-z])@))(?(\\[)(\\[(\\d{1,3}\\.){3}\\d{1,3}\\])|(([0-9a-z][-\\w]*[0-9a-z]*\\.)+[a-z0-9]{2,17}))$", RegexOptions.IgnoreCase);
        }

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var modelClientValidationRule = new ModelClientValidationRule
            {
                ErrorMessage = FormatErrorMessage(metadata.DisplayName),
                ValidationType = "translatedcorporatermailvalidationattribute"
            };

            yield return modelClientValidationRule;
        }

        private static string DomainMapper(Match match)
        {
            var idnMapping = new IdnMapping();
            string unicode = match.Groups[2].Value;
            string ascii;
            try
            {
                ascii = idnMapping.GetAscii(unicode);
            }
            catch (ArgumentException)
            {
                return string.Empty;
            }

            return match.Groups[1].Value + ascii;
        }
    }
}