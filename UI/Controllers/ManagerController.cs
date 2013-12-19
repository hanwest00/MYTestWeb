using System;
using System.Text;
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
        public ContentResult CategoryModelAddOrModify()
        {
            if (Request.Form["modeName"] == null || Request.Form["modeType"] == null)
                return this.Content("NULL");

            DataModels.Models model = new DataModels.Models { createDate = DateTime.Now, iId = 0, mName = Request.Form["modeName"], mType = int.Parse(Request.Form["modeType"]), order = 0 };

            if (Request.Form["modeId"] != null)
                modelsBIZ.ModifyModelsById(model, Request.Form["modeId"]);
            else
                modelsBIZ.AddModels(model);

            return this.Content("OK");
        }

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

        public ContentResult GetModelJsonData()
        {
            int page = Convert.ToInt32(Request.Form["page"]);
            int rows = Convert.ToInt32(Request.Form["rows"]);
            int countModels = modelsBIZ.GetCount();
            var data = modelsBIZ.GetModels(page, rows);
            StringBuilder sb = new StringBuilder(string.Format("{{\"total\":{0},\"rows\":", countModels));
            sb.Append(Newtonsoft.Json.JsonConvert.SerializeObject(data));
            sb.Append("}");
            return this.Content(sb.ToString());
        }
    }
}
