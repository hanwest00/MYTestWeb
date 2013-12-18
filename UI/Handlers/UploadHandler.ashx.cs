using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Handlers
{
    /// <summary>
    /// UploadHandler 的摘要说明
    /// </summary>
    public class UploadHandler : IHttpHandler,System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            IServiceProvider provider = context as IServiceProvider;
            HttpWorkerRequest workRqst = provider.GetService(typeof(HttpWorkerRequest)) as HttpWorkerRequest;
            int rqstLen = workRqst.GetPreloadedEntityBodyLength();
            int totLen = workRqst.GetTotalEntityBodyLength();
            byte[] buffer = new byte[1024];
            workRqst.ReadEntityBody(buffer, 0, buffer.Length);
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