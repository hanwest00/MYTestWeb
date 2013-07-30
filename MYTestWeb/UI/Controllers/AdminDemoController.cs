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

        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult CategoryList()
        {
            ViewData["firstCate"] = cateBIZ.GetCategoryList(0, 0, 0);
            return View();
        }

        public PartialViewResult _CategoryList(int pId)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder("[");
            cateBIZ.GetCategoryList(0, 0, pId).ToList().ForEach(s => {
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
            sb.Append("]");
            ViewBag.content = sb.ToString();
            return PartialView();
        }

        public ActionResult ViewInfoList(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult ViewInfoList(int id)
        {
            return View();
        }
    }
}
