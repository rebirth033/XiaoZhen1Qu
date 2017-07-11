using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;
using TianWen.XiaoZhen1Qu.Web.Areas.Business.Common;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class FWCZController : BaseController
    {
        public IFWCZJBXXBLL FWCZJBXXBLL { get; set; }
        public IBaseBLL BaseBLL { get; set; }

        public ActionResult FWCZ()
        {
            return View();
        }

        public JsonResult LoadCODES()
        {
            string TYPENAME = Request["TYPENAME"];
            return Json(BaseBLL.LoadCODES(TYPENAME));
        }

        public JsonResult FB()
        {
            string json = Request["Json"];
            string fyms = Request["FYMS"];
            JCXX jcxx = JsonHelper.ConvertJsonToObject<JCXX>(json);
            jcxx.YHID = "2718ced3-996d-427d-925d-a08e127cc0b8";
            jcxx.LLCS = 0;
            jcxx.ZXGXSJ = DateTime.Now;
            jcxx.CJSJ = DateTime.Now;
            jcxx.LXDZ = "福州市";
            FWCZJBXX yhjbxx = JsonHelper.ConvertJsonToObject<FWCZJBXX>(json);
            yhjbxx.FYMS = fyms;
            object result = FWCZJBXXBLL.SaveFWCZJBXX(jcxx, yhjbxx);
            return Json(result);
        }

        public JsonResult LoadFWCZXX()
        {
            string FWCZID = Request["FWCZID"];
            object result = FWCZJBXXBLL.LoadFWCZXX(FWCZID);
            return Json(result);
        }
        public JsonResult LoadXQJBXXSByHZ()
        {
            string XQMC = Request["XQMC"];
            return Json(FWCZJBXXBLL.LoadXQJBXXSByHZ(XQMC));
        }

        public JsonResult LoadXQJBXXSByPY()
        {
            string XQMC = Request["XQMC"];
            return Json(FWCZJBXXBLL.LoadXQJBXXSByPY(XQMC));
        }
    }
}