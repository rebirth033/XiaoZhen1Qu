using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class FC_DZFController : BaseController
    {
        public IFC_DZFBLL FC_DZFBLL { get; set; }

        public ActionResult FC_DZF()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = FC_DZFBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string fyms = Request["FYMS"];
            string fwzp = Request["FWZP"];
            string jygz = Request["JYGZ"]; 
            JCXX jcxx = JsonHelper.ConvertJsonToObject<JCXX>(json);
            jcxx.YHID = yhjbxx.YHID;
            jcxx.LLCS = 0;
            jcxx.STATUS = 1;
            jcxx.ZXGXSJ = DateTime.Now;
            jcxx.CJSJ = DateTime.Now;
            jcxx.LXDZ = yhjbxx.TXDZ;
            jcxx.DH = Session["XZQ"].ToString() + "-" + FC_DZFBLL.GetLBQCByLBID(jcxx.LBID);
            FC_DZFJBXX dzfjbxx = JsonHelper.ConvertJsonToObject<FC_DZFJBXX>(json);
            dzfjbxx.FYMS = fyms;
            dzfjbxx.JYGZ = jygz;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = FC_DZFBLL.SaveDZFJBXX(jcxx, dzfjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadFC_DZFJBXX()
        {
            string FC_DZFJBXXID = Request["FC_DZFJBXXID"];
            object result = FC_DZFBLL.LoadFC_DZFJBXX(FC_DZFJBXXID);
            return Json(result);
        }
    }
}