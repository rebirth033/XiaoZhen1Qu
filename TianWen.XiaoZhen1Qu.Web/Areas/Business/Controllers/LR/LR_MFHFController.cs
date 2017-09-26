using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class LR_MFHFController : BaseController
    {
        public ILR_MFHFBLL LR_MFHFBLL { get; set; }

        public ActionResult LR_MFHF()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = LR_MFHFBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + LR_MFHFBLL.GetLBQCByLBID(jcxx.LBID);
            LR_MFHFJBXX LR_MFHFjbxx = JsonHelper.ConvertJsonToObject<LR_MFHFJBXX>(json);
            LR_MFHFjbxx.BCMS = bcms;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = LR_MFHFBLL.SaveLR_MFHFJBXX(jcxx, LR_MFHFjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadLR_MFHFJBXX()
        {
            string LR_MFHFJBXXID = Request["LR_MFHFJBXXID"];
            object result = LR_MFHFBLL.LoadLR_MFHFJBXX(LR_MFHFJBXXID);
            return Json(result);
        }
    }
}