using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class LR_WSController : BaseController
    {
        public ILR_WSBLL LR_WSBLL { get; set; }

        public ActionResult LR_WS()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = LR_WSBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            LR_WSJBXX LR_WSjbxx = JsonHelper.ConvertJsonToObject<LR_WSJBXX>(json);
            LR_WSjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = LR_WSBLL.SaveLR_WSJBXX(jcxx, LR_WSjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadLR_WSJBXX()
        {
            string LR_WSJBXXID = Request["LR_WSJBXXID"];
            object result = LR_WSBLL.LoadLR_WSJBXX(LR_WSJBXXID);
            return Json(result);
        }
    }
}