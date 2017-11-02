using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class ES_MYFZMR_MYETYPWJController : BaseController
    {
        public IES_MYFZMR_MYETYPWJBLL ES_MYFZMR_MYETYPWJBLL { get; set; }

        public ActionResult ES_MYFZMR_MYETYPWJ()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = ES_MYFZMR_MYETYPWJBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ES_MYFZMR_MYETYPWJJBXX ES_MYFZMR_MYETYPWJjbxx = JsonHelper.ConvertJsonToObject<ES_MYFZMR_MYETYPWJJBXX>(json);
            ES_MYFZMR_MYETYPWJjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ES_MYFZMR_MYETYPWJBLL.SaveES_MYFZMR_MYETYPWJJBXX(jcxx, ES_MYFZMR_MYETYPWJjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadES_MYFZMR_MYETYPWJJBXX()
        {
            string ES_MYFZMR_MYETYPWJJBXXID = Request["ES_MYFZMR_MYETYPWJJBXXID"];
            object result = ES_MYFZMR_MYETYPWJBLL.LoadES_MYFZMR_MYETYPWJJBXX(ES_MYFZMR_MYETYPWJJBXXID);
            return Json(result);
        }
    }
}