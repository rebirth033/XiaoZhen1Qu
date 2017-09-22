using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class CW_CWZSLYController : BaseController
    {
        public ICW_CWZSLYBLL CW_CWZSLYBLL { get; set; }

        public ActionResult CW_CWZSLY()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = CW_CWZSLYBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + CW_CWZSLYBLL.GetLBQCByLBID(jcxx.LBID);
            CW_CWZSLYJBXX CW_CWZSLYjbxx = JsonHelper.ConvertJsonToObject<CW_CWZSLYJBXX>(json);
            CW_CWZSLYjbxx.BCMS = bcms;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = CW_CWZSLYBLL.SaveCW_CWZSLYJBXX(jcxx, CW_CWZSLYjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadCW_CWZSLYJBXX()
        {
            string CW_CWZSLYJBXXID = Request["CW_CWZSLYJBXXID"];
            object result = CW_CWZSLYBLL.LoadCW_CWZSLYJBXX(CW_CWZSLYJBXXID);
            return Json(result);
        }
    }
}