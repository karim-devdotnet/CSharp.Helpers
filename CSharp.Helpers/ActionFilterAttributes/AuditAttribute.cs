using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web.Helpers;
using System.Web.Mvc;

namespace CSharp.Helpers.ActionFilterAttributes
{
    public class AuditAttribute : ActionFilterAttribute
    {
        private Stopwatch stopWatch;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            stopWatch = new Stopwatch();
            stopWatch.Start();
            base.OnActionExecuting(filterContext);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            stopWatch.Stop();
            var request = filterContext.HttpContext.Request;
            int duration = Convert.ToInt32(stopWatch.ElapsedMilliseconds);

            string logData = Json.Encode(new { request.Cookies, request.Headers, request.Files, request.Form, request.QueryString, request.Params });
            //var serverInfo = ServerInfo.GetHtml();
            Dictionary<string, string> messageData = new Dictionary<string, string>();
            messageData.Add("Duration", $"{duration.ToString()} ms");
            messageData.Add("HttpMethod", request.HttpMethod);
            string logMessage = Json.Encode(messageData);
            string userName = request.IsAuthenticated ? filterContext.HttpContext.User.Identity.Name : "Anonymous";
            //TODO: Logging
            //TraceLogger.TraceInfo(userName, "Audit", logMessage, logData);
            base.OnResultExecuted(filterContext);
        }
    }
}
