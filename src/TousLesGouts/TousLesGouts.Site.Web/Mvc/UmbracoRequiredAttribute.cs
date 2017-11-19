using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace TousLesGouts.Site.Web.Mvc
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class UmbracoRequiredAttribute : RequiredAttribute, IClientValidatable
    {
        private readonly string errorMessageDictionaryKey;

        public UmbracoRequiredAttribute(string errorMessageDictionaryKey)
        {
            this.errorMessageDictionaryKey = errorMessageDictionaryKey;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            ErrorMessage = UmbracoValidationHelper.GetDictionaryItem(errorMessageDictionaryKey);

            var error = FormatErrorMessage(metadata.DisplayName);
            var rule = new ModelClientValidationRequiredRule(error);

            yield return rule;
        }
    }
}