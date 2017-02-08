using System.Diagnostics;
using System.Web.Mvc;

namespace CSharp.Helpers.ActionFilterAttributes
{
    /// <summary>
    /// an action filter attribute that stores how much time has taken to execute an action.
    /// </summary>
    public class TrackTimeAttribute : ActionFilterAttribute
    {
        Stopwatch stopWatch;
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            stopWatch = new Stopwatch();
            stopWatch.Start();
            base.OnActionExecuting(filterContext);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            stopWatch.Stop();
            Trace.WriteLine("Elapsed = " + stopWatch.ElapsedMilliseconds);
            base.OnResultExecuted(filterContext);
        }

    }
}
