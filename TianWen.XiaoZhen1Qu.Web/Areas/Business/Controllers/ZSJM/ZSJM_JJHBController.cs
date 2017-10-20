using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class ZSJM_JJHBController : BaseController
    {
        public IZSJM_JJHBBLL ZSJM_JJHBBLL { get; set; }

        public ActionResult ZSJM_JJHB()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["XZQDM"] = Session["XZQDM"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = ZSJM_JJHBBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
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
            jcxx.DH = Session["XZQ"] + "-" + ZSJM_JJHBBLL.GetLBQCByLBID(jcxx.LBID);
            ZSJM_JJHBJBXX ZSJM_JJHBjbxx = JsonHelper.ConvertJsonToObject<ZSJM_JJHBJBXX>(json);
            ZSJM_JJHBjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ZSJM_JJHBBLL.SaveZSJM_JJHBJBXX(jcxx, ZSJM_JJHBjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadZSJM_JJHBJBXX()
        {
            string ZSJM_JJHBJBXXID = Request["ZSJM_JJHBJBXXID"];
            object result = ZSJM_JJHBBLL.LoadZSJM_JJHBJBXX(ZSJM_JJHBJBXXID);
            return Json(result);
        }
    }
}