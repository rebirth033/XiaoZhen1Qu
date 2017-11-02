using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class CW_CWYPSPController : BaseController
    {
        public ICW_CWYPSPBLL CW_CWYPSPBLL { get; set; }

        public ActionResult CW_CWYPSP()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = CW_CWYPSPBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            CW_CWYPSPJBXX CW_CWYPSPjbxx = JsonHelper.ConvertJsonToObject<CW_CWYPSPJBXX>(json);
            CW_CWYPSPjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = CW_CWYPSPBLL.SaveCW_CWYPSPJBXX(jcxx, CW_CWYPSPjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadCW_CWYPSPJBXX()
        {
            string CW_CWYPSPJBXXID = Request["CW_CWYPSPJBXXID"];
            object result = CW_CWYPSPBLL.LoadCW_CWYPSPJBXX(CW_CWYPSPJBXXID);
            return Json(result);
        }
    }
}