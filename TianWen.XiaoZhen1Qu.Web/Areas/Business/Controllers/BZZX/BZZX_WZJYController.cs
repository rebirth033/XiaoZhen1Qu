using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;
using TianWen.XiaoZhen1Qu.Web.Areas.Business.Common;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class BZZX_WZJYController : BaseController
    {
        public IBZZX_WZJYBLL BZZX_WZJYBLL { get; set; }

        public JsonResult SaveWZJY()
        {
            string LB = Request["LB"];
            string yjnr = Request["YJNR"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = new JCXX();
            jcxx.YHID = "2718ced3-996d-427d-925d-a08e127cc0b8";
            jcxx.LLCS = 0;
            jcxx.STATUS = 1;
            jcxx.ZXGXSJ = DateTime.Now;
            jcxx.CJSJ = DateTime.Now;
            jcxx.LXDZ = "福州市";
            BZZX_WZJY wzjy = new BZZX_WZJY();
            wzjy.YJNR = yjnr;
            wzjy.LB = LB;
            wzjy.JCXXID = jcxx.JCXXID;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = BZZX_WZJYBLL.SaveWZJY(jcxx, wzjy, photos);
            return Json(result);
        }
    }
}