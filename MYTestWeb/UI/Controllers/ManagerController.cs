using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class ManagerController : Controller
    {
        //
        // GET: /Manager/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Category()
        {
            return View();
        }

        public ActionResult CategoryModel()
        {
            return View();
        }

        public ActionResult System()
        {
            return View();
        }

        public JsonResult GetCategoryJsonData()
        {
            return this.Json(null);
        }
    }
}
