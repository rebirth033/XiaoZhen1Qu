using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class ZXJC_JFJSController : BaseController
    {
        public IZXJC_JFJSBLL ZXJC_JFJSBLL { get; set; }

        public ActionResult ZXJC_JFJS()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = ZXJC_JFJSBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + ZXJC_JFJSBLL.GetLBQCByLBID(jcxx.LBID);
            ZXJC_JFJSJBXX ZXJC_JFJSjbxx = JsonHelper.ConvertJsonToObject<ZXJC_JFJSJBXX>(json);
            ZXJC_JFJSjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ZXJC_JFJSBLL.SaveZXJC_JFJSJBXX(jcxx, ZXJC_JFJSjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadZXJC_JFJSJBXX()
        {
            string ZXJC_JFJSJBXXID = Request["ZXJC_JFJSJBXXID"];
            object result = ZXJC_JFJSBLL.LoadZXJC_JFJSJBXX(ZXJC_JFJSJBXXID);
            return Json(result);
        }
    }
}