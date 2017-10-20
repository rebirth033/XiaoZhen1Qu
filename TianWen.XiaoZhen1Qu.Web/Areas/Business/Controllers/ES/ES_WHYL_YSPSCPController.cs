using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class ES_WHYL_YSPSCPController : BaseController
    {
        public IES_WHYL_YSPSCPBLL ES_WHYL_YSPSCPBLL { get; set; }

        public ActionResult ES_WHYL_YSPSCP()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = ES_WHYL_YSPSCPBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + ES_WHYL_YSPSCPBLL.GetLBQCByLBID(jcxx.LBID);
            ES_WHYL_YSPSCPJBXX ES_WHYL_YSPSCPjbxx = JsonHelper.ConvertJsonToObject<ES_WHYL_YSPSCPJBXX>(json);
            ES_WHYL_YSPSCPjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ES_WHYL_YSPSCPBLL.SaveES_WHYL_YSPSCPJBXX(jcxx, ES_WHYL_YSPSCPjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadES_WHYL_YSPSCPJBXX()
        {
            string ES_WHYL_YSPSCPJBXXID = Request["ES_WHYL_YSPSCPJBXXID"];
            object result = ES_WHYL_YSPSCPBLL.LoadES_WHYL_YSPSCPJBXX(ES_WHYL_YSPSCPJBXXID);
            return Json(result);
        }
    }
}