using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class XXYL_XYWQController : BaseController
    {
        public IXXYL_XYWQBLL XXYL_XYWQBLL { get; set; }

        public ActionResult XXYL_XYWQ()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = XXYL_XYWQBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            XXYL_XYWQJBXX XXYL_XYWQjbxx = JsonHelper.ConvertJsonToObject<XXYL_XYWQJBXX>(json);
            XXYL_XYWQjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = XXYL_XYWQBLL.SaveXXYL_XYWQJBXX(jcxx, XXYL_XYWQjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadXXYL_XYWQJBXX()
        {
            string XXYL_XYWQJBXXID = Request["XXYL_XYWQJBXXID"];
            object result = XXYL_XYWQBLL.LoadXXYL_XYWQJBXX(XXYL_XYWQJBXXID);
            return Json(result);
        }
    }
}