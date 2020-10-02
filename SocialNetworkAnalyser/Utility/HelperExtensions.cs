using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialNetworkAnalyser.Utility
{
    public static class HelperExtensions
    {
        public static IHtmlString ButtonJsClick(this HtmlHelper helper, string text, string code, object htmlAttributes = null)
        {
            TagBuilder tb = new TagBuilder("input");
            tb.Attributes.Add("type", "button");
            tb.Attributes.Add("value", text);
            tb.Attributes.Add("onclick", code);
    
            if (htmlAttributes != null)
            {
                var attributes = new System.Web.Routing.RouteValueDictionary(htmlAttributes);

                foreach (var attribute in attributes)
                {
                    tb.Attributes.Add(attribute.Key, (string)attribute.Value);
                }
            }

            return new MvcHtmlString(tb.ToString());
        }
    }
}