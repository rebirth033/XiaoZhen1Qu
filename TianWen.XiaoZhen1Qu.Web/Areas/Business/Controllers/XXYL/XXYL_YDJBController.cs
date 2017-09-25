using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class XXYL_YDJBController : BaseController
    {
        public IXXYL_YDJBBLL XXYL_YDJBBLL { get; set; }

        public ActionResult XXYL_YDJB()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = XXYL_YDJBBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + XXYL_YDJBBLL.GetLBQCByLBID(jcxx.LBID);
            XXYL_YDJBJBXX XXYL_YDJBjbxx = JsonHelper.ConvertJsonToObject<XXYL_YDJBJBXX>(json);
            XXYL_YDJBjbxx.BCMS = bcms;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = XXYL_YDJBBLL.SaveXXYL_YDJBJBXX(jcxx, XXYL_YDJBjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadXXYL_YDJBJBXX()
        {
            string XXYL_YDJBJBXXID = Request["XXYL_YDJBJBXXID"];
            object result = XXYL_YDJBBLL.LoadXXYL_YDJBJBXX(XXYL_YDJBJBXXID);
            return Json(result);
        }
    }
}