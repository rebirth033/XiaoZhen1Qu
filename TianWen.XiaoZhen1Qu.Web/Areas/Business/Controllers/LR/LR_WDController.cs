using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class LR_WDController : BaseController
    {
        public ILR_WDBLL LR_WDBLL { get; set; }

        public ActionResult LR_WD()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = LR_WDBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + LR_WDBLL.GetLBQCByLBID(jcxx.LBID);
            LR_WDJBXX LR_WDjbxx = JsonHelper.ConvertJsonToObject<LR_WDJBXX>(json);
            LR_WDjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = LR_WDBLL.SaveLR_WDJBXX(jcxx, LR_WDjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadLR_WDJBXX()
        {
            string LR_WDJBXXID = Request["LR_WDJBXXID"];
            object result = LR_WDBLL.LoadLR_WDJBXX(LR_WDJBXXID);
            return Json(result);
        }
    }
}