using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class CY_WMController : BaseController
    {
        public ICY_WMBLL CY_WMBLL { get; set; }

        public ActionResult CY_WM()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = CY_WMBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + CY_WMBLL.GetLBQCByLBID(jcxx.LBID);
            CY_WMJBXX CY_WMjbxx = JsonHelper.ConvertJsonToObject<CY_WMJBXX>(json);
            CY_WMjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = CY_WMBLL.SaveCY_WMJBXX(jcxx, CY_WMjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadCY_WMJBXX()
        {
            string CY_WMJBXXID = Request["CY_WMJBXXID"];
            object result = CY_WMBLL.LoadCY_WMJBXX(CY_WMJBXXID);
            return Json(result);
        }
    }
}