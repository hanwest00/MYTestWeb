using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Filters.PageFliters
{
    public class PageFliter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (System.Web.HttpContext.Current.Request.HttpMethod == "POST")
            {
                int ss = System.Web.HttpContext.Current.Request.ContentLength;
                HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;
                IServiceProvider provider = System.Web.HttpContext.Current as IServiceProvider;
                HttpWorkerRequest workRqst = provider.GetService(typeof(HttpWorkerRequest)) as HttpWorkerRequest;
                int n = 2;
                byte[] buffer = new byte[n];

            }
            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }
    }
}