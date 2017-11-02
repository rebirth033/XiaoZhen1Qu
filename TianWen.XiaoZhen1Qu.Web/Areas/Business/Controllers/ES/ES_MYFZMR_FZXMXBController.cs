using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class ES_MYFZMR_FZXMXBController : BaseController
    {
        public IES_MYFZMR_FZXMXBBLL ES_MYFZMR_FZXMXBBLL { get; set; }

        public ActionResult ES_MYFZMR_FZXMXB()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = ES_MYFZMR_FZXMXBBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ES_MYFZMR_FZXMXBJBXX ES_MYFZMR_FZXMXBjbxx = JsonHelper.ConvertJsonToObject<ES_MYFZMR_FZXMXBJBXX>(json);
            ES_MYFZMR_FZXMXBjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ES_MYFZMR_FZXMXBBLL.SaveES_MYFZMR_FZXMXBJBXX(jcxx, ES_MYFZMR_FZXMXBjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadES_MYFZMR_FZXMXBJBXX()
        {
            string ES_MYFZMR_FZXMXBJBXXID = Request["ES_MYFZMR_FZXMXBJBXXID"];
            object result = ES_MYFZMR_FZXMXBBLL.LoadES_MYFZMR_FZXMXBJBXX(ES_MYFZMR_FZXMXBJBXXID);
            return Json(result);
        }
    }
}