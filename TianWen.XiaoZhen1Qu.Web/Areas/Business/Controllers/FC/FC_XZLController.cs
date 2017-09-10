using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class FC_XZLController : BaseController
    {
        public IFC_XZLBLL FC_XZLBLL { get; set; }

        public ActionResult FC_XZL()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        //[ValidateInput(false)]
        //public JsonResult FB()
        //{
        //    YHJBXX yhjbxx = FC_SPBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
        //    string json = Request["Json"];
        //    string bcms = Request["BCMS"];
        //    string fwzp = Request["FWZP"];
        //    JCXX jcxx = JsonHelper.ConvertJsonToObject<JCXX>(json);
        //    jcxx.YHID = yhjbxx.YHID;
        //    jcxx.LLCS = 0;
        //    jcxx.STATUS = 1;
        //    jcxx.ZXGXSJ = DateTime.Now;
        //    jcxx.CJSJ = DateTime.Now;
        //    jcxx.LXDZ = yhjbxx.TXDZ;
        //    jcxx.DH = Session["XZQ"] + "-" + FC_SPBLL.GetLBQCByLBID(jcxx.LBID);
        //    FC_SPJBXX spjbxx = JsonHelper.ConvertJsonToObject<FC_SPJBXX>(json);
        //    spjbxx.BCMS = bcms;
        //    List<PHOTOS> photos = GetTP(fwzp);
        //    object result = FC_SPBLL.SaveSPJBXX(jcxx, spjbxx, photos);
        //    return Json(result);
        //}
    }
}