using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class ZSJM_FZXBController : BaseController
    {
        public IZSJM_FZXBBLL ZSJM_FZXBBLL { get; set; }

        public ActionResult ZSJM_FZXB()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["XZQDM"] = Session["XZQDM"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = ZSJM_FZXBBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ZSJM_FZXBJBXX ZSJM_FZXBjbxx = JsonHelper.ConvertJsonToObject<ZSJM_FZXBJBXX>(json);
            ZSJM_FZXBjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ZSJM_FZXBBLL.SaveZSJM_FZXBJBXX(jcxx, ZSJM_FZXBjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadZSJM_FZXBJBXX()
        {
            string ZSJM_FZXBJBXXID = Request["ZSJM_FZXBJBXXID"];
            object result = ZSJM_FZXBBLL.LoadZSJM_FZXBJBXX(ZSJM_FZXBJBXXID);
            return Json(result);
        }
    }
}