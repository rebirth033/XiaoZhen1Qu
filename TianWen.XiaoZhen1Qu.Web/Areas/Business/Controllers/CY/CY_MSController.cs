using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class CY_MSController : BaseController
    {
        public ICY_MSBLL CY_MSBLL { get; set; }

        public ActionResult CY_MS()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = CY_MSBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + CY_MSBLL.GetLBQCByLBID(jcxx.LBID);
            CY_MSJBXX CY_MSjbxx = JsonHelper.ConvertJsonToObject<CY_MSJBXX>(json);
            CY_MSjbxx.BCMS = bcms;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = CY_MSBLL.SaveCY_MSJBXX(jcxx, CY_MSjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadCY_MSJBXX()
        {
            string CY_MSJBXXID = Request["CY_MSJBXXID"];
            object result = CY_MSBLL.LoadCY_MSJBXX(CY_MSJBXXID);
            return Json(result);
        }
    }
}