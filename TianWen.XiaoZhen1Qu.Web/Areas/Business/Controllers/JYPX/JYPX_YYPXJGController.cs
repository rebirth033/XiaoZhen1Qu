using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class JYPX_YYPXJGController : BaseController
    {
        public IJYPX_YYPXJGBLL JYPX_YYPXJGBLL { get; set; }

        public ActionResult JYPX_YYPXJG()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = JYPX_YYPXJGBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + JYPX_YYPXJGBLL.GetLBQCByLBID(jcxx.LBID);
            JYPX_YYPXJGJBXX JYPX_YYPXJGjbxx = JsonHelper.ConvertJsonToObject<JYPX_YYPXJGJBXX>(json);
            JYPX_YYPXJGjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = JYPX_YYPXJGBLL.SaveJYPX_YYPXJGJBXX(jcxx, JYPX_YYPXJGjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadJYPX_YYPXJGJBXX()
        {
            string JYPX_YYPXJGJBXXID = Request["JYPX_YYPXJGJBXXID"];
            object result = JYPX_YYPXJGBLL.LoadJYPX_YYPXJGJBXX(JYPX_YYPXJGJBXXID);
            return Json(result);
        }
    }
}