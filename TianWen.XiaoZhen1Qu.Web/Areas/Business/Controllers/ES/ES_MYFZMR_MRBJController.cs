using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class ES_MYFZMR_MRBJController : BaseController
    {
        public IES_MYFZMR_MRBJBLL ES_MYFZMR_MRBJBLL { get; set; }

        public ActionResult ES_MYFZMR_MRBJ()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = ES_MYFZMR_MRBJBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ES_MYFZMR_MRBJJBXX ES_MYFZMR_MRBJjbxx = JsonHelper.ConvertJsonToObject<ES_MYFZMR_MRBJJBXX>(json);
            ES_MYFZMR_MRBJjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ES_MYFZMR_MRBJBLL.SaveES_MYFZMR_MRBJJBXX(jcxx, ES_MYFZMR_MRBJjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadES_MYFZMR_MRBJJBXX()
        {
            string ES_MYFZMR_MRBJJBXXID = Request["ES_MYFZMR_MRBJJBXXID"];
            object result = ES_MYFZMR_MRBJBLL.LoadES_MYFZMR_MRBJJBXX(ES_MYFZMR_MRBJJBXXID);
            return Json(result);
        }
    }
}