using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class LR_MJController : BaseController
    {
        public ILR_MJBLL LR_MJBLL { get; set; }

        public ActionResult LR_MJ()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = LR_MJBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + LR_MJBLL.GetLBQCByLBID(jcxx.LBID);
            LR_MJJBXX LR_MJjbxx = JsonHelper.ConvertJsonToObject<LR_MJJBXX>(json);
            LR_MJjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = LR_MJBLL.SaveLR_MJJBXX(jcxx, LR_MJjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadLR_MJJBXX()
        {
            string LR_MJJBXXID = Request["LR_MJJBXXID"];
            object result = LR_MJBLL.LoadLR_MJJBXX(LR_MJJBXXID);
            return Json(result);
        }
    }
}