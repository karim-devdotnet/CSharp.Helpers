using System.Web;
using System.Web.Mvc;

namespace CSharp.Helpers.ActionFilterAttributes
{
    public class NoCacheGlobalActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.ActionDescriptor.GetCustomAttributes(typeof(OutputCacheAttribute), false).Length > 0)
                return;

            HttpCachePolicyBase cache = filterContext.HttpContext.Response.Cache;
            cache.SetCacheability(HttpCacheability.NoCache);
            base.OnActionExecuting(filterContext);
        }
    }
}
