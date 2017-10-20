using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class ES_JDJJBG_JJRYController : BaseController
    {
        public IES_JDJJBG_JJRYBLL ES_JDJJBG_JJRYBLL { get; set; }

        public ActionResult ES_JDJJBG_JJRY()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = ES_JDJJBG_JJRYBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + ES_JDJJBG_JJRYBLL.GetLBQCByLBID(jcxx.LBID);
            ES_JDJJBG_JJRYJBXX ES_JDJJBG_JJRYjbxx = JsonHelper.ConvertJsonToObject<ES_JDJJBG_JJRYJBXX>(json);
            ES_JDJJBG_JJRYjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ES_JDJJBG_JJRYBLL.SaveES_JDJJBG_JJRYJBXX(jcxx, ES_JDJJBG_JJRYjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadES_JDJJBG_JJRYJBXX()
        {
            string ES_JDJJBG_JJRYJBXXID = Request["ES_JDJJBG_JJRYJBXXID"];
            object result = ES_JDJJBG_JJRYBLL.LoadES_JDJJBG_JJRYJBXX(ES_JDJJBG_JJRYJBXXID);
            return Json(result);
        }
    }
}