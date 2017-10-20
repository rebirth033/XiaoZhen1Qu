using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class XXYL_TQTController : BaseController
    {
        public IXXYL_TQTBLL XXYL_TQTBLL { get; set; }

        public ActionResult XXYL_TQT()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = XXYL_TQTBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = JsonHelper.ConvertJsonToObject<JCXX>(json);
            jcxx.YHID = yhjbxx.YHID;
            jcxx.LLCS = 0;
            jcxx.STATUS = 1;
            jcxx.ZXGXSJ = DateTime.Now;
            jcxx.CJSJ = DateTime.Now;
            jcxx.LXDZ = yhjbxx.TXDZ;
            jcxx.DH = Session["XZQ"] + "-" + XXYL_TQTBLL.GetLBQCByLBID(jcxx.LBID);
            XXYL_TQTJBXX XXYL_TQTjbxx = JsonHelper.ConvertJsonToObject<XXYL_TQTJBXX>(json);
            XXYL_TQTjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = XXYL_TQTBLL.SaveXXYL_TQTJBXX(jcxx, XXYL_TQTjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadXXYL_TQTJBXX()
        {
            string XXYL_TQTJBXXID = Request["XXYL_TQTJBXXID"];
            object result = XXYL_TQTBLL.LoadXXYL_TQTJBXX(XXYL_TQTJBXXID);
            return Json(result);
        }
    }
}