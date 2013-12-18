using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Reflection;
using UI.Models;

namespace UI.Filters.PageFliters
{
    public class PageFliter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
          
            //if (System.Web.HttpContext.Current.Request.HttpMethod == "POST")
            //{
            //    //int ss = System.Web.HttpContext.Current.Request.ContentLength;
            //    //HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;
            //    IServiceProvider provider = System.Web.HttpContext.Current as IServiceProvider;
            //    HttpWorkerRequest workRqst = provider.GetService(typeof(HttpWorkerRequest)) as HttpWorkerRequest;
            //    AsyncUpload au = new AsyncUpload(workRqst,Guid.NewGuid().ToString());
            //    au.SaveFiles();
            //    string ssss = workRqst.GetKnownRequestHeader(HttpWorkerRequest.HeaderContentType);
            //    int sssss = workRqst.GetPreloadedEntityBodyLength();
            //    byte[] buf = workRqst.GetPreloadedEntityBody();
            //    string sss = System.Text.Encoding.UTF8.GetString(buf);
            //    int tot = workRqst.GetTotalEntityBodyLength();
            //    byte[] buffer = new byte[8192];
            //    int s = 0;
            //    System.Text.StringBuilder sb = new System.Text.StringBuilder();
            //    if (!workRqst.IsEntireEntityBodyIsPreloaded())
            //    {
            //        var received = sssss;
            //        int rl = 0;
            //        while (tot - received > 0 && workRqst.IsClientConnected())
            //        {
            //            rl = workRqst.ReadEntityBody(buffer, buffer.Length);
            //            sb.Append(System.Text.Encoding.UTF8.GetString(buffer));
            //            received += rl;
            //        }
            //    }

            //    typeof(HttpRequest).GetField("_wr", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(HttpContext.Current.Request, workRqst);
            //}
            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }
    }
}