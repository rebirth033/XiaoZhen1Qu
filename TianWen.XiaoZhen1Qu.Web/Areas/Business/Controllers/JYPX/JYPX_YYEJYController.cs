using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class JYPX_YYEJYController : BaseController
    {
        public IJYPX_YYEJYBLL JYPX_YYEJYBLL { get; set; }

        public ActionResult JYPX_YYEJY()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = JYPX_YYEJYBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            JYPX_YYEJYJBXX JYPX_YYEJYjbxx = JsonHelper.ConvertJsonToObject<JYPX_YYEJYJBXX>(json);
            JYPX_YYEJYjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = JYPX_YYEJYBLL.SaveJYPX_YYEJYJBXX(jcxx, JYPX_YYEJYjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadJYPX_YYEJYJBXX()
        {
            string JYPX_YYEJYJBXXID = Request["JYPX_YYEJYJBXXID"];
            object result = JYPX_YYEJYBLL.LoadJYPX_YYEJYJBXX(JYPX_YYEJYJBXXID);
            return Json(result);
        }
    }
}