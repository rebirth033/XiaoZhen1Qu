using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.Interface;
using TianWen.XiaoZhen1Qu.Web.Areas.Business.Common;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class WDZJController : BaseController
    {
        public IWDZJBLL WDZJBLL { get; set; }

        public ActionResult WDZJ()
        {
            return View();
        }
    }
}