using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class FC_SPController : BaseController
    {
        public IFC_SPBLL FC_SPBLL { get; set; }

        public ActionResult FC_SP()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = FC_SPBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + FC_SPBLL.GetLBQCByLBID(jcxx.LBID);
            FC_SPJBXX spjbxx = JsonHelper.ConvertJsonToObject<FC_SPJBXX>(json);
            spjbxx.BCMS = bcms;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = FC_SPBLL.SaveSPJBXX(jcxx, spjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadQY()
        {
            return Json(FC_SPBLL.LoadQYBySuperName(Session["XZQ"].ToString()));
        }

        public JsonResult LoadSQ()
        {
            return Json(FC_SPBLL.LoadSQByQY(Request["QY"].ToString()));
        }

        public JsonResult LoadFC_SPJBXX()
        {
            string FC_SPJBXXID = Request["FC_SPJBXXID"];
            object result = FC_SPBLL.LoadFC_SPJBXX(FC_SPJBXXID);
            return Json(result);
        }
    }
}