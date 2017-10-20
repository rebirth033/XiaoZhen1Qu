using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class XXYL_QPZYController : BaseController
    {
        public IXXYL_QPZYBLL XXYL_QPZYBLL { get; set; }

        public ActionResult XXYL_QPZY()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = XXYL_QPZYBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + XXYL_QPZYBLL.GetLBQCByLBID(jcxx.LBID);
            XXYL_QPZYJBXX XXYL_QPZYjbxx = JsonHelper.ConvertJsonToObject<XXYL_QPZYJBXX>(json);
            XXYL_QPZYjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = XXYL_QPZYBLL.SaveXXYL_QPZYJBXX(jcxx, XXYL_QPZYjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadXXYL_QPZYJBXX()
        {
            string XXYL_QPZYJBXXID = Request["XXYL_QPZYJBXXID"];
            object result = XXYL_QPZYBLL.LoadXXYL_QPZYJBXX(XXYL_QPZYJBXXID);
            return Json(result);
        }
    }
}