using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class CW_CWFWController : BaseController
    {
        public ICW_CWFWBLL CW_CWFWBLL { get; set; }

        public ActionResult CW_CWFW()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = CW_CWFWBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + CW_CWFWBLL.GetLBQCByLBID(jcxx.LBID);
            CW_CWFWJBXX CW_CWFWjbxx = JsonHelper.ConvertJsonToObject<CW_CWFWJBXX>(json);
            CW_CWFWjbxx.BCMS = bcms;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = CW_CWFWBLL.SaveCW_CWFWJBXX(jcxx, CW_CWFWjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadCW_CWFWJBXX()
        {
            string CW_CWFWJBXXID = Request["CW_CWFWJBXXID"];
            object result = CW_CWFWBLL.LoadCW_CWFWJBXX(CW_CWFWJBXXID);
            return Json(result);
        }
    }
}