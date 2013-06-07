using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class BaseController : Controller
    {
        protected string Language
        {
            get
            {
                if (Session["language"] == null)
                    Session["language"] = "en-US";
                return Session["language"].ToString();
            }
            set
            {
                Session["language"] = value;
            }
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            App_GlobalResources.Resource.Culture = new System.Globalization.CultureInfo(Language);
        }

    }
}
