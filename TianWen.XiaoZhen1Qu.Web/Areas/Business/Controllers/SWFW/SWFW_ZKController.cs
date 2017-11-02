using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class SWFW_ZKController : BaseController
    {
        public ISWFW_ZKBLL SWFW_ZKBLL { get; set; }

        public ActionResult SWFW_ZK()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = SWFW_ZKBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SWFW_ZKJBXX SWFW_ZKjbxx = JsonHelper.ConvertJsonToObject<SWFW_ZKJBXX>(json);
            SWFW_ZKjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_ZKBLL.SaveSWFW_ZKJBXX(jcxx, SWFW_ZKjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadSWFW_ZKJBXX()
        {
            string SWFW_ZKJBXXID = Request["SWFW_ZKJBXXID"];
            object result = SWFW_ZKBLL.LoadSWFW_ZKJBXX(SWFW_ZKJBXXID);
            return Json(result);
        }
    }
}