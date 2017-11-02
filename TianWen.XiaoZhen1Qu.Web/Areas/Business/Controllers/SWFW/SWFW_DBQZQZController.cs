using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class SWFW_DBQZQZController : BaseController
    {
        public ISWFW_DBQZQZBLL SWFW_DBQZQZBLL { get; set; }

        public ActionResult SWFW_DBQZQZ()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = SWFW_DBQZQZBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SWFW_DBQZQZJBXX SWFW_DBQZQZjbxx = JsonHelper.ConvertJsonToObject<SWFW_DBQZQZJBXX>(json);
            SWFW_DBQZQZjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_DBQZQZBLL.SaveSWFW_DBQZQZJBXX(jcxx, SWFW_DBQZQZjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadSWFW_DBQZQZJBXX()
        {
            string SWFW_DBQZQZJBXXID = Request["SWFW_DBQZQZJBXXID"];
            object result = SWFW_DBQZQZBLL.LoadSWFW_DBQZQZJBXX(SWFW_DBQZQZJBXXID);
            return Json(result);
        }
    }
}