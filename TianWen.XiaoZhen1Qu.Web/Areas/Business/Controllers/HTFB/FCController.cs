using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Entities.Models.FC;
using TianWen.XiaoZhen1Qu.Interface;
using TianWen.XiaoZhen1Qu.Interface.HTFB.FC;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class FCController : BaseController
    {
        public IFC_CKCFTDCWBLL FC_CKCFTDCWBLL { get; set; }
        public IFC_DZFBLL FC_DZFBLL { get; set; }
        public IFC_SPBLL FC_SPBLL { get; set; }
        public IFC_XZLBLL FC_XZLBLL { get; set; }
        public IFC_ZZFBLL FC_ZZFBLL { get; set; }
        public IFC_ESFBLL FC_ESFBLL { get; set; }

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
        public ActionResult FC_ESF()
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
            YHJBXX yhjbxx = FC_ZZFBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            FC_ZZFJBXX FC_ZZFjbxx = JsonHelper.ConvertJsonToObject<FC_ZZFJBXX>(json);
            FC_ZZFjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = FC_ZZFBLL.SaveFC_ZZFJBXX(jcxx, FC_ZZFjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBFC_ESFJBXX()
        {
            YHJBXX yhjbxx = FC_ESFBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            FC_ESFJBXX FC_ESFjbxx = JsonHelper.ConvertJsonToObject<FC_ESFJBXX>(json);
            FC_ESFjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = FC_ESFBLL.SaveFC_ESFJBXX(jcxx, FC_ESFjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadFC_CKCFTDCWJBXX()
        {
            string ID = Request["ID"];
            object result = FC_CKCFTDCWBLL.LoadFC_CKCFTDCWJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadFC_DZFJBXX()
        {
            string ID = Request["ID"];
            object result = FC_DZFBLL.LoadFC_DZFJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadFC_SPJBXX()
        {
            string ID = Request["ID"];
            object result = FC_SPBLL.LoadFC_SPJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadFC_XZLJBXX()
        {
            string ID = Request["ID"];
            object result = FC_XZLBLL.LoadFC_XZLJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadFC_ZZFJBXX()
        {
            string ID = Request["ID"];
            object result = FC_ZZFBLL.LoadFC_ZZFXX(ID);
            return Json(result);
        }
        public JsonResult LoadXQJBXXSByHZ()
        {
            string XQMC = Request["XQMC"];
            return Json(FC_ZZFBLL.LoadXQJBXXSByHZ(XQMC));
        }

        public JsonResult LoadXQJBXXSByPY()
        {
            string XQMC = Request["XQMC"];
            return Json(FC_ZZFBLL.LoadXQJBXXSByPY(XQMC));
        }
    }
}