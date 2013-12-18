using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Handlers
{
    /// <summary>
    /// UploadProcess 的摘要说明
    /// </summary>
    public class UploadProcess : IHttpAsyncHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginProcessRequest(HttpContext context, AsyncCallback cb, object extraData)
        {
            UploadProcessAsyncResult ret = null;
            //if (!string.IsNullOrEmpty(context.Request.QueryString["g"]))
            //{
            //    if (UI.Modules.AsynUploadModule.FlieAsyncUploadCol.ContainsKey(context.Request.QueryString["g"]))
            //        ret = UI.Modules.AsynUploadModule.FlieAsyncUploadCol[context.Request.QueryString["g"]];
            //    else
            //    {
            //        ret = new UploadProcessAsyncResult(context, cb, extraData);
            //        UI.Modules.AsynUploadModule.FlieAsyncUploadCol.Add(new KeyValuePair<string, UploadProcessAsyncResult>(context.Request.QueryString["g"], ret));
            //    }
            //}
            ret = new UploadProcessAsyncResult(context, cb, extraData);
            return ret;
        }

        public void EndProcessRequest(IAsyncResult result)
        {
            if (result != null && result is UploadProcessAsyncResult)
            {
                UploadProcessAsyncResult AsyncResult = result as UploadProcessAsyncResult;
                AsyncResult.httpContext.Response.Write(AsyncResult.CurrentPercent);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}