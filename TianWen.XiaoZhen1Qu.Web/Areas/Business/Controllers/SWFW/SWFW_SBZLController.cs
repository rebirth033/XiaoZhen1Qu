using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class SWFW_SBZLController : BaseController
    {
        public ISWFW_SBZLBLL SWFW_SBZLBLL { get; set; }

        public ActionResult SWFW_SBZL()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = SWFW_SBZLBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + SWFW_SBZLBLL.GetLBQCByLBID(jcxx.LBID);
            SWFW_SBZLJBXX SWFW_SBZLjbxx = JsonHelper.ConvertJsonToObject<SWFW_SBZLJBXX>(json);
            SWFW_SBZLjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SWFW_SBZLBLL.SaveSWFW_SBZLJBXX(jcxx, SWFW_SBZLjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadSWFW_SBZLJBXX()
        {
            string SWFW_SBZLJBXXID = Request["SWFW_SBZLJBXXID"];
            object result = SWFW_SBZLBLL.LoadSWFW_SBZLJBXX(SWFW_SBZLJBXXID);
            return Json(result);
        }
    }
}