using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class CW_CWMController : BaseController
    {
        public ICW_CWMBLL CW_CWMBLL { get; set; }

        public ActionResult CW_CWM()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = CW_CWMBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            CW_CWMJBXX CW_CWMjbxx = JsonHelper.ConvertJsonToObject<CW_CWMJBXX>(json);
            CW_CWMjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = CW_CWMBLL.SaveCW_CWMJBXX(jcxx, CW_CWMjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadCW_CWMJBXX()
        {
            string CW_CWMJBXXID = Request["CW_CWMJBXXID"];
            object result = CW_CWMBLL.LoadCW_CWMJBXX(CW_CWMJBXXID);
            return Json(result);
        }
    }
}