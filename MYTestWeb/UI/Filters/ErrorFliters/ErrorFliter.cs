using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Filters.ErrorFliters
{
    public class ErrorFliter : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            System.Web.HttpContext.Current.Response.Redirect(string.Format("Error/Index/{0}", Util.Log.LogIoc.GetInstance()[0].Error(filterContext.Exception.ToString()) ? "1" : "0"));
        }
    }
}
