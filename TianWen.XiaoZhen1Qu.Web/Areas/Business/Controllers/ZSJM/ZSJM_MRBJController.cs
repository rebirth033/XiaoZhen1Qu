using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class ZSJM_MRBJController : BaseController
    {
        public IZSJM_MRBJBLL ZSJM_MRBJBLL { get; set; }

        public ActionResult ZSJM_MRBJ()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["XZQDM"] = Session["XZQDM"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = ZSJM_MRBJBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + ZSJM_MRBJBLL.GetLBQCByLBID(jcxx.LBID);
            ZSJM_MRBJJBXX ZSJM_MRBJjbxx = JsonHelper.ConvertJsonToObject<ZSJM_MRBJJBXX>(json);
            ZSJM_MRBJjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ZSJM_MRBJBLL.SaveZSJM_MRBJJBXX(jcxx, ZSJM_MRBJjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadZSJM_MRBJJBXX()
        {
            string ZSJM_MRBJJBXXID = Request["ZSJM_MRBJJBXXID"];
            object result = ZSJM_MRBJBLL.LoadZSJM_MRBJJBXX(ZSJM_MRBJJBXXID);
            return Json(result);
        }
    }
}