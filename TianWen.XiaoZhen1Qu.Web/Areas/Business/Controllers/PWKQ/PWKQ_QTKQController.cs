using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class PWKQ_QTKQController : BaseController
    {
        public IPWKQ_QTKQBLL PWKQ_QTKQBLL { get; set; }

        public ActionResult PWKQ_QTKQ()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = PWKQ_QTKQBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            PWKQ_QTKQJBXX PWKQ_QTKQjbxx = JsonHelper.ConvertJsonToObject<PWKQ_QTKQJBXX>(json);
            PWKQ_QTKQjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            object result = PWKQ_QTKQBLL.SavePWKQ_QTKQJBXX(jcxx, PWKQ_QTKQjbxx);
            return Json(result);
        }

        public JsonResult LoadPWKQ_QTKQJBXX()
        {
            string PWKQ_QTKQJBXXID = Request["PWKQ_QTKQJBXXID"];
            object result = PWKQ_QTKQBLL.LoadPWKQ_QTKQJBXX(PWKQ_QTKQJBXXID);
            return Json(result);
        }
    }
}