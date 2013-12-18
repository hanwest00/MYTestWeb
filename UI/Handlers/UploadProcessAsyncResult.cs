using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Handlers
{
    public class UploadProcessAsyncResult : IAsyncResult, System.Web.SessionState.IRequiresSessionState
    {
        public object AsyncState { get; set; }

        public System.Threading.WaitHandle AsyncWaitHandle { get; set; }

        public bool CompletedSynchronously { get; set; }

        public bool IsCompleted { get; set; }

        private object exData;
        private static string latestPercent;

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

        public void GetUploadProcess(string per)
        {
            if (string.IsNullOrEmpty(per)) return;
            if (per != latestPercent)
            {
                latestPercent = this.CurrentPercent = per;
                if (this.callback != null) this.callback(this);
            }
        }
    }
}