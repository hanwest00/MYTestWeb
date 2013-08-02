using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Models.Handlers
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
            AsyncResults.UploadProcessAsyncResult ret = new AsyncResults.UploadProcessAsyncResult(context, cb, extraData);
            return ret;
        }

        public void EndProcessRequest(IAsyncResult result)
        {
            if (result is AsyncResults.UploadProcessAsyncResult)
            {
                AsyncResults.UploadProcessAsyncResult AsyncResult = result as AsyncResults.UploadProcessAsyncResult;
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