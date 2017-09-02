using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;
using TianWen.XiaoZhen1Qu.Web.Areas.Business.Common;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class WZYJController:BaseController
    {
        public IWZYJBLL WZYJBLL { get; set; }

        public JsonResult SaveWZYJ()
        {
            string json = Request["Json"];
            string yjnr = Request["YJNR"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = JsonHelper.ConvertJsonToObject<JCXX>(json);
            jcxx.YHID = "2718ced3-996d-427d-925d-a08e127cc0b8";
            jcxx.LLCS = 0;
            jcxx.STATUS = 1;
            jcxx.ZXGXSJ = DateTime.Now;
            jcxx.CJSJ = DateTime.Now;
            jcxx.LXDZ = "福州市";
            WZYJ wzyj = JsonHelper.ConvertJsonToObject<WZYJ>(json);
            wzyj.YJNR = yjnr;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = WZYJBLL.SaveWZYJ(jcxx, wzyj, photos);
            return Json(result);
        }
    }
}