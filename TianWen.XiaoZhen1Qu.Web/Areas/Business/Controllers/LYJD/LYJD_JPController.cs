using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class LYJD_JPController : BaseController
    {
        public ILYJD_JPBLL LYJD_JPBLL { get; set; }

        public ActionResult LYJD_JP()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = LYJD_JPBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + LYJD_JPBLL.GetLBQCByLBID(jcxx.LBID);
            LYJD_JPJBXX LYJD_JPjbxx = JsonHelper.ConvertJsonToObject<LYJD_JPJBXX>(json);
            LYJD_JPjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = LYJD_JPBLL.SaveLYJD_JPJBXX(jcxx, LYJD_JPjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadLYJD_JPJBXX()
        {
            string LYJD_JPJBXXID = Request["LYJD_JPJBXXID"];
            object result = LYJD_JPBLL.LoadLYJD_JPJBXX(LYJD_JPJBXXID);
            return Json(result);
        }
    }
}