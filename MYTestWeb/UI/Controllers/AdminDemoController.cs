using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IBusiness;
using BusinessIocFactory;

namespace UI.Controllers
{
    public class AdminDemoController : BaseController
    {
        //
        // GET: /AdminDemo/

        private ICategoryBIZ cateBIZ = IocFactory.Instance.GetBIZ<ICategoryBIZ>();
        private IModelsBIZ modelsBIZ = IocFactory.Instance.GetBIZ<IModelsBIZ>();

        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult CategoryList()
        {
            ViewData["firstCate"] = cateBIZ.GetCategoryList(0, 0, 0);
            return View();
        }

        public ActionResult _CategoryList(int pId)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder("[");
            var list = cateBIZ.GetCategoryList(0, 0, pId);
            if (list != null)
            {
                list.ToList().ForEach(s =>
                {
                    sb.Append("{");
                    sb.Append("\"name\" : \"");
                    sb.Append(s.cateName);
                    sb.Append("\",");
                    sb.Append("\"id\" : ");
                    sb.Append(s.id);
                    sb.Append(",\"ccount\" : ");
                    sb.Append(cateBIZ.ChildrenCount(s.id));
                    sb.Append("}");
                });
            }
            sb.Append("]");
            return Content(sb.ToString());
        }

        public ActionResult ViewInfoList(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult ViewInfoList()
        {
            return View();
        }

        public ActionResult AddCategory()
        {
            HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;
            return View();
        }

        public JsonResult ModelList()
        {
            return Json(modelsBIZ.GetModels(0, 0));
        }
    }
}
