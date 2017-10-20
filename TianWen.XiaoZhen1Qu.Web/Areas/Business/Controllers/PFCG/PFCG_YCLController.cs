using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class PFCG_YCLController : BaseController
    {
        public IPFCG_YCLBLL PFCG_YCLBLL { get; set; }

        public ActionResult PFCG_YCL()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = PFCG_YCLBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + PFCG_YCLBLL.GetLBQCByLBID(jcxx.LBID);
            PFCG_YCLJBXX PFCG_YCLjbxx = JsonHelper.ConvertJsonToObject<PFCG_YCLJBXX>(json);
            PFCG_YCLjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = PFCG_YCLBLL.SavePFCG_YCLJBXX(jcxx, PFCG_YCLjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadPFCG_YCLJBXX()
        {
            string PFCG_YCLJBXXID = Request["PFCG_YCLJBXXID"];
            object result = PFCG_YCLBLL.LoadPFCG_YCLJBXX(PFCG_YCLJBXXID);
            return Json(result);
        }
    }
}