using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;
using TianWen.XiaoZhen1Qu.Web.Areas.Business.Common;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class FC_DZFController : BaseController
    {
        public IFC_DZFBLL FC_DZFBLL { get; set; }

        public ActionResult FC_DZF()
        {
            return View();
        }

        public JsonResult FB()
        {
            string json = Request["Json"];
            string fyms = Request["FYMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = JsonHelper.ConvertJsonToObject<JCXX>(json);
            jcxx.YHID = "2718ced3-996d-427d-925d-a08e127cc0b8";
            jcxx.LLCS = 0;
            jcxx.STATUS = 1;
            jcxx.ZXGXSJ = DateTime.Now;
            jcxx.CJSJ = DateTime.Now;
            jcxx.LXDZ = "福州市";
            FC_DZFJBXX dzfjbxx = JsonHelper.ConvertJsonToObject<FC_DZFJBXX>(json);
            dzfjbxx.FYMS = fyms;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = FC_DZFBLL.SaveDZFJBXX(jcxx, dzfjbxx, photos);
            return Json(result);
        }

        //public JsonResult LoadFWCZXX()
        //{
        //    string FWCZJBXXID = Request["FWCZJBXXID"];
        //    object result = FWCZJBXXBLL.LoadFWCZXX(FWCZJBXXID);
        //    return Json(result);
        //}
    }
}