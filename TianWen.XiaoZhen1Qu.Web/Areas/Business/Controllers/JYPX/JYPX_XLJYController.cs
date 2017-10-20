using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class JYPX_XLJYController : BaseController
    {
        public IJYPX_XLJYBLL JYPX_XLJYBLL { get; set; }

        public ActionResult JYPX_XLJY()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = JYPX_XLJYBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + JYPX_XLJYBLL.GetLBQCByLBID(jcxx.LBID);
            JYPX_XLJYJBXX JYPX_XLJYjbxx = JsonHelper.ConvertJsonToObject<JYPX_XLJYJBXX>(json);
            JYPX_XLJYjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = JYPX_XLJYBLL.SaveJYPX_XLJYJBXX(jcxx, JYPX_XLJYjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadJYPX_XLJYJBXX()
        {
            string JYPX_XLJYJBXXID = Request["JYPX_XLJYJBXXID"];
            object result = JYPX_XLJYBLL.LoadJYPX_XLJYJBXX(JYPX_XLJYJBXXID);
            return Json(result);
        }
    }
}