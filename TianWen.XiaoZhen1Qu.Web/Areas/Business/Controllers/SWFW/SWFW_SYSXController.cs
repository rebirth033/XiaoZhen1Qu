using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class SWFW_SYSXController : BaseController
    {
        public ISWFW_SYSXBLL SWFW_SYSXBLL { get; set; }

        public ActionResult SWFW_SYSX()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = SWFW_SYSXBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SWFW_SYSXJBXX SWFW_SYSXjbxx = JsonHelper.ConvertJsonToObject<SWFW_SYSXJBXX>(json);
            SWFW_SYSXjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_SYSXBLL.SaveSWFW_SYSXJBXX(jcxx, SWFW_SYSXjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadSWFW_SYSXJBXX()
        {
            string SWFW_SYSXJBXXID = Request["SWFW_SYSXJBXXID"];
            object result = SWFW_SYSXBLL.LoadSWFW_SYSXJBXX(SWFW_SYSXJBXXID);
            return Json(result);
        }
    }
}