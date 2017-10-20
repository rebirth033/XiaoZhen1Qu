using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class FC_CKCFTDCWController : BaseController
    {
        public IFC_CKCFTDCWBLL FC_CKCFTDCWBLL { get; set; }

        public ActionResult FC_CKCFTDCW()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = FC_CKCFTDCWBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + FC_CKCFTDCWBLL.GetLBQCByLBID(jcxx.LBID);
            FC_CKCFTDCWJBXX CKCFTDCWjbxx = JsonHelper.ConvertJsonToObject<FC_CKCFTDCWJBXX>(json);
            CKCFTDCWjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = FC_CKCFTDCWBLL.SaveCKCFTDCWJBXX(jcxx, CKCFTDCWjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadFC_CKCFTDCWJBXX()
        {
            string FC_CKCFTDCWJBXXID = Request["FC_CKCFTDCWJBXXID"];
            object result = FC_CKCFTDCWBLL.LoadFC_CKCFTDCWJBXX(FC_CKCFTDCWJBXXID);
            return Json(result);
        }
    }
}