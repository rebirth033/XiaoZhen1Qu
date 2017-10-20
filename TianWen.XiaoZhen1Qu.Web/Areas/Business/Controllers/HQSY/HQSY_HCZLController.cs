using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class HQSY_HCZLController : BaseController
    {
        public IHQSY_HCZLBLL HQSY_HCZLBLL { get; set; }

        public ActionResult HQSY_HCZL()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = HQSY_HCZLBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + HQSY_HCZLBLL.GetLBQCByLBID(jcxx.LBID);
            HQSY_HCZLJBXX HQSY_HCZLjbxx = JsonHelper.ConvertJsonToObject<HQSY_HCZLJBXX>(json);
            HQSY_HCZLjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = HQSY_HCZLBLL.SaveHQSY_HCZLJBXX(jcxx, HQSY_HCZLjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadHQSY_HCZLJBXX()
        {
            string HQSY_HCZLJBXXID = Request["HQSY_HCZLJBXXID"];
            object result = HQSY_HCZLBLL.LoadHQSY_HCZLJBXX(HQSY_HCZLJBXXID);
            return Json(result);
        }
    }
}