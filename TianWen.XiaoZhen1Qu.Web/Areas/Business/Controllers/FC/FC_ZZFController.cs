using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class FC_ZZFController : BaseController
    {
        public IFC_ZZFJBXXBLL FC_ZZFJBXXBLL { get; set; }

        public ActionResult FC_ZZF()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = FC_ZZFJBXXBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            FC_ZZFJBXX FC_ZZFjbxx = JsonHelper.ConvertJsonToObject<FC_ZZFJBXX>(json);
            FC_ZZFjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = FC_ZZFJBXXBLL.SaveFC_ZZFJBXX(jcxx, FC_ZZFjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadFC_ZZFXX()
        {
            string FC_ZZFJBXXID = Request["FC_ZZFJBXXID"];
            object result = FC_ZZFJBXXBLL.LoadFC_ZZFXX(FC_ZZFJBXXID);
            return Json(result);
        }

        public JsonResult LoadXQJBXXSByHZ()
        {
            string XQMC = Request["XQMC"];
            return Json(FC_ZZFJBXXBLL.LoadXQJBXXSByHZ(XQMC));
        }

        public JsonResult LoadXQJBXXSByPY()
        {
            string XQMC = Request["XQMC"];
            return Json(FC_ZZFJBXXBLL.LoadXQJBXXSByPY(XQMC));
        }
    }
}