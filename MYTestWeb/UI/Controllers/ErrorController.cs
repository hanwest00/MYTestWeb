using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class ErrorController : BaseController
    {
        public ActionResult Index(int Id)
        {
            if (Id == 1)
                ViewBag.LogOk = Resources.Resource.LogOk;
            else
                ViewBag.LogOk = Resources.Resource.LogFail;
            return View();
        }

    }
}
