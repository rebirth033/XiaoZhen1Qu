using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class CY_KCTSController : BaseController
    {
        public ICY_KCTSBLL CY_KCTSBLL { get; set; }

        public ActionResult CY_KCTS()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = CY_KCTSBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + CY_KCTSBLL.GetLBQCByLBID(jcxx.LBID);
            CY_KCTSJBXX CY_KCTSjbxx = JsonHelper.ConvertJsonToObject<CY_KCTSJBXX>(json);
            CY_KCTSjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = CY_KCTSBLL.SaveCY_KCTSJBXX(jcxx, CY_KCTSjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadCY_KCTSJBXX()
        {
            string CY_KCTSJBXXID = Request["CY_KCTSJBXXID"];
            object result = CY_KCTSBLL.LoadCY_KCTSJBXX(CY_KCTSJBXXID);
            return Json(result);
        }
    }
}