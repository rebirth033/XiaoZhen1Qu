using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class XXYL_DIYSGFController : BaseController
    {
        public IXXYL_DIYSGFBLL XXYL_DIYSGFBLL { get; set; }

        public ActionResult XXYL_DIYSGF()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = XXYL_DIYSGFBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + XXYL_DIYSGFBLL.GetLBQCByLBID(jcxx.LBID);
            XXYL_DIYSGFJBXX XXYL_DIYSGFjbxx = JsonHelper.ConvertJsonToObject<XXYL_DIYSGFJBXX>(json);
            XXYL_DIYSGFjbxx.BCMS = bcms;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = XXYL_DIYSGFBLL.SaveXXYL_DIYSGFJBXX(jcxx, XXYL_DIYSGFjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadXXYL_DIYSGFJBXX()
        {
            string XXYL_DIYSGFJBXXID = Request["XXYL_DIYSGFJBXXID"];
            object result = XXYL_DIYSGFBLL.LoadXXYL_DIYSGFJBXX(XXYL_DIYSGFJBXXID);
            return Json(result);
        }
    }
}