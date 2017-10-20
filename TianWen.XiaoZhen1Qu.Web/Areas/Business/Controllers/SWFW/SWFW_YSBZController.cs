using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class SWFW_YSBZController : BaseController
    {
        public ISWFW_YSBZBLL SWFW_YSBZBLL { get; set; }

        public ActionResult SWFW_YSBZ()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = SWFW_YSBZBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + SWFW_YSBZBLL.GetLBQCByLBID(jcxx.LBID);
            SWFW_YSBZJBXX SWFW_YSBZjbxx = JsonHelper.ConvertJsonToObject<SWFW_YSBZJBXX>(json);
            SWFW_YSBZjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_YSBZBLL.SaveSWFW_YSBZJBXX(jcxx, SWFW_YSBZjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadSWFW_YSBZJBXX()
        {
            string SWFW_YSBZJBXXID = Request["SWFW_YSBZJBXXID"];
            object result = SWFW_YSBZBLL.LoadSWFW_YSBZJBXX(SWFW_YSBZJBXXID);
            return Json(result);
        }
    }
}