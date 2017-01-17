using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace NestLogger.Common
{
    public static class HtmlExtensions
    {
        public static MvcHtmlString Section(this HtmlHelper htmlHelper, Func<object, HelperResult> template, string addToSection)
        {
            if (!Exists(htmlHelper, template(null).ToHtmlString()))
                htmlHelper.ViewContext.HttpContext.Items.Add(String.Concat("_", addToSection, "_", htmlHelper.ViewContext.HttpContext.Items.Count), template);

            return MvcHtmlString.Empty;
        }

        public static IHtmlString RenderSection(this HtmlHelper htmlHelper, string sectionName)
        {
            List<string> keys = new List<string>();

            foreach (object key in htmlHelper.ViewContext.HttpContext.Items.Keys)
            {
                if (key is string)
                    keys.Add((string)key);
            }

            keys = keys.OrderBy(x => x).ToList();

            foreach (object key in keys)
            {
                if (key.ToString().StartsWith(String.Concat("_", sectionName, "_")))
                {
                    var template = htmlHelper.ViewContext.HttpContext.Items[key] as Func<object, HelperResult>;
                    if (template != null)
                    {
                        htmlHelper.ViewContext.Writer.Write(template(null));
                    }
                }
            }
            return MvcHtmlString.Empty;
        }

        private static bool Exists(HtmlHelper htmlHelper, string value)
        {
            foreach (var item in htmlHelper.ViewContext.HttpContext.Items.Values)
            {
                var temp = item as Func<object, HelperResult>;

                if (temp != null)
                {
                    string result = temp(null).ToHtmlString();

                    if (result == value)
                        return true;
                }
            }

            return false;
        }
    }
}