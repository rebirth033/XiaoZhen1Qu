using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class SWFW_HYWLController : BaseController
    {
        public ISWFW_HYWLBLL SWFW_HYWLBLL { get; set; }

        public ActionResult SWFW_HYWL()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = SWFW_HYWLBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + SWFW_HYWLBLL.GetLBQCByLBID(jcxx.LBID);
            SWFW_HYWLJBXX SWFW_HYWLjbxx = JsonHelper.ConvertJsonToObject<SWFW_HYWLJBXX>(json);
            SWFW_HYWLjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_HYWLBLL.SaveSWFW_HYWLJBXX(jcxx, SWFW_HYWLjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadSWFW_HYWLJBXX()
        {
            string SWFW_HYWLJBXXID = Request["SWFW_HYWLJBXXID"];
            object result = SWFW_HYWLBLL.LoadSWFW_HYWLJBXX(SWFW_HYWLJBXXID);
            return Json(result);
        }
    }
}