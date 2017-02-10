using System.Globalization;
using System.Threading;
using System.Web.Mvc;

namespace CSharp.Helpers.ActionFilterAttributes
{
    public class InternationalizationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            string language = (string)filterContext.RouteData.Values["language"] ?? "de";
            string culture = (string)filterContext.RouteData.Values["culture"] ?? "DE";

            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(string.Format("{0}-{1}", language, culture));
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(string.Format("{0}-{1}", language, culture));

        }
    }
}

/*
 Example:

routes.MapRoute("DefaultLocalized",
            "{language}-{culture}/{controller}/{action}/{id}",
            new
            {
                controller = "Home",
                action = "Index",
                id = "",
                language = "nl",
                culture = "NL"
            });

To activate the Internationalization attribute, simply add it to your class:

[Internationalization]
public class HomeController : Controller {
...

Now whenever a visitor goes to http://example.com/en-US/Home/Index the english site is displayed.
     */
