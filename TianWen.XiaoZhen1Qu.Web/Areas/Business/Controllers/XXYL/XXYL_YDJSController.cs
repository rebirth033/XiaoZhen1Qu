using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class XXYL_YDJSController : BaseController
    {
        public IXXYL_YDJSBLL XXYL_YDJSBLL { get; set; }

        public ActionResult XXYL_YDJS()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = XXYL_YDJSBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + XXYL_YDJSBLL.GetLBQCByLBID(jcxx.LBID);
            XXYL_YDJSJBXX XXYL_YDJSjbxx = JsonHelper.ConvertJsonToObject<XXYL_YDJSJBXX>(json);
            XXYL_YDJSjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = XXYL_YDJSBLL.SaveXXYL_YDJSJBXX(jcxx, XXYL_YDJSjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadXXYL_YDJSJBXX()
        {
            string XXYL_YDJSJBXXID = Request["XXYL_YDJSJBXXID"];
            object result = XXYL_YDJSBLL.LoadXXYL_YDJSJBXX(XXYL_YDJSJBXXID);
            return Json(result);
        }
    }
}