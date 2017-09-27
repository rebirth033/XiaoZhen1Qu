using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class LR_YJController : BaseController
    {
        public ILR_YJBLL LR_YJBLL { get; set; }

        public ActionResult LR_YJ()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = LR_YJBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + LR_YJBLL.GetLBQCByLBID(jcxx.LBID);
            LR_YJJBXX LR_YJjbxx = JsonHelper.ConvertJsonToObject<LR_YJJBXX>(json);
            LR_YJjbxx.BCMS = bcms;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = LR_YJBLL.SaveLR_YJJBXX(jcxx, LR_YJjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadLR_YJJBXX()
        {
            string LR_YJJBXXID = Request["LR_YJJBXXID"];
            object result = LR_YJBLL.LoadLR_YJJBXX(LR_YJJBXXID);
            return Json(result);
        }
    }
}