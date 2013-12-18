using System;
using System.Collections.Generic;
using System.Web;
using UI.Models;
using System.Reflection;
using UI.Handlers;

namespace UI.Modules
{
    public class AsynUploadModule : IHttpModule
    {
        /// <summary>
        /// 您将需要在您网站的 web.config 文件中配置此模块，
        /// 并向 IIS 注册此模块，然后才能使用。有关详细信息，
        /// 请参见下面的链接: http://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpModule Members

        private static IDictionary<string, string> fUploadCol = null;
        public static IDictionary<string, string> FlieAsyncUploadCol
        {
            get
            {
                if (fUploadCol == null) fUploadCol = new Dictionary<string, string>();
                return fUploadCol;
            }
        }

        public void Dispose()
        {
            //此处放置清除代码。
        }

        public void Init(HttpApplication context)
        {
            // 下面是如何处理 LogRequest 事件并为其
            // 提供自定义日志记录实现的示例
            context.BeginRequest += new EventHandler(context_BeginRequest);
        }

        void context_BeginRequest(object sender, EventArgs e)
        {
            if (System.Web.HttpContext.Current.Request.HttpMethod == "POST" && System.Web.HttpContext.Current.Request.QueryString["f"] == "1" && !string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["g"]))
            {
                //int ss = System.Web.HttpContext.Current.Request.ContentLength;
                //HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;
                IServiceProvider provider = System.Web.HttpContext.Current as IServiceProvider;
                HttpWorkerRequest workRqst = provider.GetService(typeof(HttpWorkerRequest)) as HttpWorkerRequest;
                AsyncUpload au = string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["d"]) ? new AsyncUpload(workRqst) : new AsyncUpload(workRqst, System.Web.HttpContext.Current.Request.QueryString["d"]);
                // fPerCol.Add(new KeyValuePair<string, string>(System.Web.HttpContext.Current.Request.QueryString["g"], ""));
                au.uploadProcess += new AsyncUpload.UploadProcess(delegate(float per)
                {
                    if (!FlieAsyncUploadCol.ContainsKey(System.Web.HttpContext.Current.Request.QueryString["g"]))
                        FlieAsyncUploadCol.Add(new KeyValuePair<string, string>(System.Web.HttpContext.Current.Request.QueryString["g"], per.ToString()));
                    else
                        FlieAsyncUploadCol[System.Web.HttpContext.Current.Request.QueryString["g"]] = per.ToString();
                });
                au.SaveFiles();
                //fPerCol.Remove(System.Web.HttpContext.Current.Request.QueryString["g"]);
                typeof(HttpRequest).GetField("_wr", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(HttpContext.Current.Request, workRqst);
            }
        }

        #endregion
    }
}
