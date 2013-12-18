using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Handlers
{
    /// <summary>
    /// UploadProcessSync 的摘要说明
    /// </summary>
    public class UploadProcessSync : IHttpHandler
    {
        public static string lastPer = string.Empty;
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            string ret = string.Empty;
            if (!string.IsNullOrEmpty(context.Request.QueryString["g"]))
                if (UI.Modules.AsynUploadModule.FlieAsyncUploadCol.ContainsKey(context.Request.QueryString["g"]))
                {
                    //未使用c#异步方式实现的伪comet
                    while (true) {
                        if (!lastPer.Equals(UI.Modules.AsynUploadModule.FlieAsyncUploadCol[context.Request.QueryString["g"]]))
                        {
                            lastPer = ret = UI.Modules.AsynUploadModule.FlieAsyncUploadCol[context.Request.QueryString["g"]];
                            if (ret == "100") UI.Modules.AsynUploadModule.FlieAsyncUploadCol.Remove(System.Web.HttpContext.Current.Request.QueryString["g"]);
                            context.Response.Write(ret);
                            break;
                        }
                        System.Threading.Thread.Sleep(1000);
                    }
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