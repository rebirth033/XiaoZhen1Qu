using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class QZZP_JZZPController : BaseController
    {
        public IQZZP_JZZPBLL QZZP_JZZPBLL { get; set; }

        public ActionResult QZZP_JZZP()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = QZZP_JZZPBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            QZZP_JZZPJBXX QZZP_JZZPjbxx = JsonHelper.ConvertJsonToObject<QZZP_JZZPJBXX>(json);
            QZZP_JZZPjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            object result = QZZP_JZZPBLL.SaveQZZP_JZZPJBXX(jcxx, QZZP_JZZPjbxx);
            return Json(result);
        }

        public JsonResult LoadQZZP_JZZPJBXX()
        {
            string QZZP_JZZPJBXXID = Request["QZZP_JZZPJBXXID"];
            object result = QZZP_JZZPBLL.LoadQZZP_JZZPJBXX(QZZP_JZZPJBXXID);
            return Json(result);
        }
    }
}