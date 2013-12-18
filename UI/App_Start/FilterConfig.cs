using System.Web;
using System.Web.Mvc;

namespace UI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //添加全局异常捕获过滤
            filters.Add(new UI.Filters.ErrorFliters.ErrorFliter());
            filters.Add(new UI.Filters.PageFliters.PageFliter());
        }
    }
}