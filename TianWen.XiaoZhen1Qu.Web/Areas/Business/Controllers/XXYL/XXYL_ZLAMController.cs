using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class XXYL_ZLAMController : BaseController
    {
        public IXXYL_ZLAMBLL XXYL_ZLAMBLL { get; set; }

        public ActionResult XXYL_ZLAM()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = XXYL_ZLAMBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + XXYL_ZLAMBLL.GetLBQCByLBID(jcxx.LBID);
            XXYL_ZLAMJBXX XXYL_ZLAMjbxx = JsonHelper.ConvertJsonToObject<XXYL_ZLAMJBXX>(json);
            XXYL_ZLAMjbxx.BCMS = bcms;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = XXYL_ZLAMBLL.SaveXXYL_ZLAMJBXX(jcxx, XXYL_ZLAMjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadXXYL_ZLAMJBXX()
        {
            string XXYL_ZLAMJBXXID = Request["XXYL_ZLAMJBXXID"];
            object result = XXYL_ZLAMBLL.LoadXXYL_ZLAMJBXX(XXYL_ZLAMJBXXID);
            return Json(result);
        }
    }
}