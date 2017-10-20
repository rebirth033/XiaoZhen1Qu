using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class CW_CWGController : BaseController
    {
        public ICW_CWGBLL CW_CWGBLL { get; set; }

        public ActionResult CW_CWG()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = CW_CWGBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + CW_CWGBLL.GetLBQCByLBID(jcxx.LBID);
            CW_CWGJBXX CW_CWGjbxx = JsonHelper.ConvertJsonToObject<CW_CWGJBXX>(json);
            CW_CWGjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = CW_CWGBLL.SaveCW_CWGJBXX(jcxx, CW_CWGjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadCW_CWGJBXX()
        {
            string CW_CWGJBXXID = Request["CW_CWGJBXXID"];
            object result = CW_CWGBLL.LoadCW_CWGJBXX(CW_CWGJBXXID);
            return Json(result);
        }
    }
}