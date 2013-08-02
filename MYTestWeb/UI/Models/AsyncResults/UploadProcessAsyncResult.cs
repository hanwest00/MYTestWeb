using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Models.AsyncResults
{
    public class UploadProcessAsyncResult : IAsyncResult, System.Web.SessionState.IRequiresSessionState
    {
        public object AsyncState { get; set; }

        public System.Threading.WaitHandle AsyncWaitHandle { get; set; }

        public bool CompletedSynchronously { get; set; }

        public bool IsCompleted { get; set; }

        private object exData;
        private static string latestPercent = string.Empty;

        public string CurrentPercent
        {
            get;
            set;
        }

        public HttpContext httpContext
        {
            get;
            private set;
        }

        public AsyncCallback callback
        {
            get;
            private set;
        }

        public UploadProcessAsyncResult(HttpContext context, AsyncCallback cb, object extraData)
        {
            this.httpContext = context;
            this.callback = cb;
            this.exData = extraData;
        }

        public void GetUploadProcess()
        {
            string str = this.httpContext.Session["UploadPercent"] != null ? this.httpContext.Session["UploadPercent"].ToString() : "";
            if (str != latestPercent)
            {
                latestPercent = this.CurrentPercent = str;
                if (this.callback != null) this.callback(this);
            }
        }
    }
}