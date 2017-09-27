using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class LR_KQHLController : BaseController
    {
        public ILR_KQHLBLL LR_KQHLBLL { get; set; }

        public ActionResult LR_KQHL()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = LR_KQHLBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + LR_KQHLBLL.GetLBQCByLBID(jcxx.LBID);
            LR_KQHLJBXX LR_KQHLjbxx = JsonHelper.ConvertJsonToObject<LR_KQHLJBXX>(json);
            LR_KQHLjbxx.BCMS = bcms;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = LR_KQHLBLL.SaveLR_KQHLJBXX(jcxx, LR_KQHLjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadLR_KQHLJBXX()
        {
            string LR_KQHLJBXXID = Request["LR_KQHLJBXXID"];
            object result = LR_KQHLBLL.LoadLR_KQHLJBXX(LR_KQHLJBXXID);
            return Json(result);
        }
    }
}