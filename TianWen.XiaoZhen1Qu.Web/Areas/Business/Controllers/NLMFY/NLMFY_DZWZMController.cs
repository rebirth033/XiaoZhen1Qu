using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class NLMFY_DZWZMController : BaseController
    {
        public INLMFY_DZWZMBLL NLMFY_DZWZMBLL { get; set; }

        public ActionResult NLMFY_DZWZM()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = NLMFY_DZWZMBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + NLMFY_DZWZMBLL.GetLBQCByLBID(jcxx.LBID);
            NLMFY_DZWZMJBXX NLMFY_DZWZMjbxx = JsonHelper.ConvertJsonToObject<NLMFY_DZWZMJBXX>(json);
            NLMFY_DZWZMjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = NLMFY_DZWZMBLL.SaveNLMFY_DZWZMJBXX(jcxx, NLMFY_DZWZMjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadNLMFY_DZWZMJBXX()
        {
            string NLMFY_DZWZMJBXXID = Request["NLMFY_DZWZMJBXXID"];
            object result = NLMFY_DZWZMBLL.LoadNLMFY_DZWZMJBXX(NLMFY_DZWZMJBXXID);
            return Json(result);
        }
    }
}