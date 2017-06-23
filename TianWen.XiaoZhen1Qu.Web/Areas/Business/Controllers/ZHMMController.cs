using System.Text;
using System.Web.Mvc;
using System.Xml;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Web.Areas.Business.Common;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class ZHMMController : BaseController
    {
        public ActionResult ZHMM()
        {
            return View();
        }


    }
}