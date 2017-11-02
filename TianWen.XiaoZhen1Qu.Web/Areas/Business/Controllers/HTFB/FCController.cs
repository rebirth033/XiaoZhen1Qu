using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class FCController : BaseController
    {
        public IFC_CKCFTDCWBLL FC_CKCFTDCWBLL { get; set; }
        public IFC_DZFBLL FC_DZFBLL { get; set; }
        public IFC_SPBLL FC_SPBLL { get; set; }
        public IFC_XZLBLL FC_XZLBLL { get; set; }
        public IFC_ZZFJBXXBLL FC_ZZFJBXXBLL { get; set; }

        public ActionResult FC_CKCFTDCW()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult FC_DZF()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult FC_SP()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult FC_XZL()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult FC_ZZF()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FBFC_CKCFTDCWJBXX()
        {
            YHJBXX yhjbxx = FC_CKCFTDCWBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            FC_CKCFTDCWJBXX CKCFTDCWjbxx = JsonHelper.ConvertJsonToObject<FC_CKCFTDCWJBXX>(json);
            CKCFTDCWjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = FC_CKCFTDCWBLL.SaveCKCFTDCWJBXX(jcxx, CKCFTDCWjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBFC_DZFJBXX()
        {
            YHJBXX yhjbxx = FC_DZFBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string BCMS = Request["BCMS"];
            string fwzp = Request["FWZP"];
            string jygz = Request["JYGZ"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            FC_DZFJBXX dzfjbxx = JsonHelper.ConvertJsonToObject<FC_DZFJBXX>(json);
            dzfjbxx.BCMS = BinaryHelper.StringToBinary(BCMS);
            dzfjbxx.JYGZ = jygz;
            List<PHOTOS> photos = GetTP(fwzp);
            object result = FC_DZFBLL.SaveDZFJBXX(jcxx, dzfjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBFC_SPJBXX()
        {
            YHJBXX yhjbxx = FC_SPBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            FC_SPJBXX spjbxx = JsonHelper.ConvertJsonToObject<FC_SPJBXX>(json);
            spjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = FC_SPBLL.SaveSPJBXX(jcxx, spjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBFC_XZLJBXX()
        {
            YHJBXX yhjbxx = FC_XZLBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            FC_XZLJBXX xzljbxx = JsonHelper.ConvertJsonToObject<FC_XZLJBXX>(json);
            xzljbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = FC_XZLBLL.SaveXZLJBXX(jcxx, xzljbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBFC_ZZFJBXX()
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

        public JsonResult LoadFC_CKCFTDCWJBXX()
        {
            string FC_CKCFTDCWJBXXID = Request["FC_CKCFTDCWJBXXID"];
            object result = FC_CKCFTDCWBLL.LoadFC_CKCFTDCWJBXX(FC_CKCFTDCWJBXXID);
            return Json(result);
        }
        public JsonResult LoadFC_DZFJBXX()
        {
            string FC_DZFJBXXID = Request["FC_DZFJBXXID"];
            object result = FC_DZFBLL.LoadFC_DZFJBXX(FC_DZFJBXXID);
            return Json(result);
        }
        public JsonResult LoadFC_SPJBXX()
        {
            string FC_SPJBXXID = Request["FC_SPJBXXID"];
            object result = FC_SPBLL.LoadFC_SPJBXX(FC_SPJBXXID);
            return Json(result);
        }
        public JsonResult LoadFC_XZLJBXX()
        {
            string FC_XZLJBXXID = Request["FC_XZLJBXXID"];
            object result = FC_XZLBLL.LoadFC_XZLJBXX(FC_XZLJBXXID);
            return Json(result);
        }
        public JsonResult LoadFC_ZZFJBXX()
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