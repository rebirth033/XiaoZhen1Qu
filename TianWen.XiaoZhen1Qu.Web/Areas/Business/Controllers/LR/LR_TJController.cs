using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class LR_TJController : BaseController
    {
        public ILR_TJBLL LR_TJBLL { get; set; }

        public ActionResult LR_TJ()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = LR_TJBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + LR_TJBLL.GetLBQCByLBID(jcxx.LBID);
            LR_TJJBXX LR_TJjbxx = JsonHelper.ConvertJsonToObject<LR_TJJBXX>(json);
            LR_TJjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = LR_TJBLL.SaveLR_TJJBXX(jcxx, LR_TJjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadLR_TJJBXX()
        {
            string LR_TJJBXXID = Request["LR_TJJBXXID"];
            object result = LR_TJBLL.LoadLR_TJJBXX(LR_TJJBXXID);
            return Json(result);
        }
    }
}