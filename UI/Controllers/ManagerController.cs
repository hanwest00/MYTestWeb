using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataModels;
using IBusiness;
using BusinessIocFactory;

namespace UI.Controllers
{
    public class ManagerController : Controller
    {
        //
        // GET: /Manager/
        private IModelsBIZ modelsBIZ = IocFactory.Instance.GetBIZ<IModelsBIZ>();

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

        [HttpPost]
        public ContentResult CategoryModelAdd()
        {
            DataModels.Models model = new DataModels.Models { createDate = DateTime.Now, iId = 0, mName = Request.Form["modeName"], mType = int.Parse(Request.Form["mType"]) , order = 0};
            modelsBIZ.AddModels(model);
            return this.Content("OK");
        }

        public ActionResult Model()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Model()
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

        public JsonResult GetModelJsonData()
        {
            return this.Json(null);
        }
    }
}
