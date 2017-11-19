using System;
using System.ComponentModel;

namespace TousLesGouts.Site.Web.Mvc
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class UmbracoDisplayAttribute : DisplayNameAttribute
    {
        private readonly string dictionaryKey;

        // This is a positional argument
        public UmbracoDisplayAttribute(string dictionaryKey)
        {
            this.dictionaryKey = dictionaryKey;
        }

        public override string DisplayName
        {
            get
            {
                return UmbracoValidationHelper.UmbracoHelper.GetDictionaryValue(dictionaryKey);
            }
        }
    }
}