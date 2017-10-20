using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class ES_WHYL_TSYXRJController : BaseController
    {
        public IES_WHYL_TSYXRJBLL ES_WHYL_TSYXRJBLL { get; set; }

        public ActionResult ES_WHYL_TSYXRJ()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = ES_WHYL_TSYXRJBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = JsonHelper.ConvertJsonToObject<JCXX>(json);
            jcxx.YHID = yhjbxx.YHID;
            jcxx.LLCS = 0;
            jcxx.STATUS = 1;
            jcxx.ZXGXSJ = DateTime.Now;
            jcxx.CJSJ = DateTime.Now;
            jcxx.LXDZ = yhjbxx.TXDZ;
            jcxx.DH = Session["XZQ"] + "-" + ES_WHYL_TSYXRJBLL.GetLBQCByLBID(jcxx.LBID);
            ES_WHYL_TSYXRJJBXX ES_WHYL_TSYXRJjbxx = JsonHelper.ConvertJsonToObject<ES_WHYL_TSYXRJJBXX>(json);
            ES_WHYL_TSYXRJjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ES_WHYL_TSYXRJBLL.SaveES_WHYL_TSYXRJJBXX(jcxx, ES_WHYL_TSYXRJjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadES_WHYL_TSYXRJJBXX()
        {
            string ES_WHYL_TSYXRJJBXXID = Request["ES_WHYL_TSYXRJJBXXID"];
            object result = ES_WHYL_TSYXRJBLL.LoadES_WHYL_TSYXRJJBXX(ES_WHYL_TSYXRJJBXXID);
            return Json(result);
        }
    }
}