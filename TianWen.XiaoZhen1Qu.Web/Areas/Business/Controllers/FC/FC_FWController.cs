using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class FC_FWController : BaseController
    {
        public IFWCZJBXXBLL FWCZJBXXBLL { get; set; }

        public ActionResult FC_FW()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        public JsonResult FB()
        {
            YHJBXX yhjbxx = FWCZJBXXBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string fyms = Request["FYMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = JsonHelper.ConvertJsonToObject<JCXX>(json);
            jcxx.YHID = yhjbxx.YHID;
            jcxx.LLCS = 0;
            jcxx.STATUS = 1;
            jcxx.ZXGXSJ = DateTime.Now;
            jcxx.CJSJ = DateTime.Now;
            jcxx.LXDZ = "福州市";
            jcxx.DH = Session["XZQ"].ToString() + "-" + FWCZJBXXBLL.GetLBQCByLBID(jcxx.LBID);
            FWCZJBXX fwczjbxx = JsonHelper.ConvertJsonToObject<FWCZJBXX>(json);
            fwczjbxx.FYMS = fyms;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = FWCZJBXXBLL.SaveFWCZJBXX(jcxx, fwczjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadFWCZXX()
        {
            string FWCZJBXXID = Request["FWCZJBXXID"];
            object result = FWCZJBXXBLL.LoadFWCZXX(FWCZJBXXID);
            return Json(result);
        }

        public JsonResult LoadXQJBXXSByHZ()
        {
            string XQMC = Request["XQMC"];
            return Json(FWCZJBXXBLL.LoadXQJBXXSByHZ(XQMC));
        }

        public JsonResult LoadXQJBXXSByPY()
        {
            string XQMC = Request["XQMC"];
            return Json(FWCZJBXXBLL.LoadXQJBXXSByPY(XQMC));
        }
    }
}