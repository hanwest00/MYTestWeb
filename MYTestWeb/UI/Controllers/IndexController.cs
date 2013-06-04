using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;
using Business;

namespace UI.Controllers
{
    public class IndexController : Controller
    {
        //
        // GET: /Index/

        public ActionResult Index()
        {
            Data.Tables.User user = new Data.Tables.User { GroupId = 0, Name = "121"};
            Business.Users mng = new Users();
            mng.Insert(user);
            ViewBag.Info = mng.GetAll();
            return View();
        }

    }
}
