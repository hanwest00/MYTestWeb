using System.Web;
using System.Web.Mvc;
using System.Reflection;

namespace UI.Controllers
{
    public class BaseController : Controller
    {
        //初始化语言环境配置
        static BaseController()
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Util.WebConfigManager.DefaultLanguage);
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(Util.WebConfigManager.DefaultLanguage);
        }

        protected string Language
        {
            get
            {
                if (Session["language"] == null) Session["language"] = Util.WebConfigManager.DefaultLanguage;
                return Session["language"].ToString();
            }
            set
            {
                Session["language"] = value;
            }
        }

        protected string CurrentUser
        {
            get
            {
                return Session["currUser"].ToString();
            }
            set
            {
                Session["currUser"] = value;
            }
        }
    }
}
