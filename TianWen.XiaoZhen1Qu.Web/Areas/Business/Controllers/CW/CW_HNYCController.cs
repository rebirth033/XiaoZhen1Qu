using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class CW_HNYCController : BaseController
    {
        public ICW_HNYCBLL CW_HNYCBLL { get; set; }

        public ActionResult CW_HNYC()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = CW_HNYCBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + CW_HNYCBLL.GetLBQCByLBID(jcxx.LBID);
            CW_HNYCJBXX CW_HNYCjbxx = JsonHelper.ConvertJsonToObject<CW_HNYCJBXX>(json);
            CW_HNYCjbxx.BCMS = bcms;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = CW_HNYCBLL.SaveCW_HNYCJBXX(jcxx, CW_HNYCjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadCW_HNYCJBXX()
        {
            string CW_HNYCJBXXID = Request["CW_HNYCJBXXID"];
            object result = CW_HNYCBLL.LoadCW_HNYCJBXX(CW_HNYCJBXXID);
            return Json(result);
        }
    }
}