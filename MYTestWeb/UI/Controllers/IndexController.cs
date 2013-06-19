using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;

namespace UI.Controllers
{
    public class IndexController : BaseController
    {
        //
        // GET: /Index/
        public ActionResult Index()
        {
            return View();
        }
    }
}
