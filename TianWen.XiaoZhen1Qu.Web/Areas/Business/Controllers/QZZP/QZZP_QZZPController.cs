using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class QZZP_QZZPController : BaseController
    {
        public IQZZP_QZZPBLL QZZP_QZZPBLL { get; set; }

        public ActionResult QZZP_QZZP()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = QZZP_QZZPBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + QZZP_QZZPBLL.GetLBQCByLBID(jcxx.LBID);
            QZZP_QZZPJBXX QZZP_QZZPjbxx = JsonHelper.ConvertJsonToObject<QZZP_QZZPJBXX>(json);
            QZZP_QZZPjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = QZZP_QZZPBLL.SaveQZZP_QZZPJBXX(jcxx, QZZP_QZZPjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadQZZP_QZZPJBXX()
        {
            string QZZP_QZZPJBXXID = Request["QZZP_QZZPJBXXID"];
            object result = QZZP_QZZPBLL.LoadQZZP_QZZPJBXX(QZZP_QZZPJBXXID);
            return Json(result);
        }
    }
}