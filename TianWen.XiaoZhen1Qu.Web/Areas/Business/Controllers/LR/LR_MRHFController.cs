using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class LR_MRHFController : BaseController
    {
        public ILR_MRHFBLL LR_MRHFBLL { get; set; }

        public ActionResult LR_MRHF()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = LR_MRHFBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + LR_MRHFBLL.GetLBQCByLBID(jcxx.LBID);
            LR_MRHFJBXX LR_MRHFjbxx = JsonHelper.ConvertJsonToObject<LR_MRHFJBXX>(json);
            LR_MRHFjbxx.BCMS = bcms;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = LR_MRHFBLL.SaveLR_MRHFJBXX(jcxx, LR_MRHFjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadLR_MRHFJBXX()
        {
            string LR_MRHFJBXXID = Request["LR_MRHFJBXXID"];
            object result = LR_MRHFBLL.LoadLR_MRHFJBXX(LR_MRHFJBXXID);
            return Json(result);
        }
    }
}