using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class FCController : BaseController
    {
        public IFC_BLL FC_BLL { get; set; }
        public ActionResult FC_DZF() { ViewData["XZQ"] = Session["XZQ"]; ViewData["YHM"] = Session["YHM"]; return View(); }
        public ActionResult FC_SP() { ViewData["XZQ"] = Session["XZQ"]; ViewData["YHM"] = Session["YHM"]; return View(); }
        public ActionResult FC_XZL() { ViewData["XZQ"] = Session["XZQ"]; ViewData["YHM"] = Session["YHM"]; return View(); }
        public ActionResult FC_ZZF() { ViewData["XZQ"] = Session["XZQ"]; ViewData["YHM"] = Session["YHM"]; return View(); }
        public ActionResult FC_HZF() { ViewData["XZQ"] = Session["XZQ"]; ViewData["YHM"] = Session["YHM"]; return View(); }
        public ActionResult FC_ESF() { ViewData["XZQ"] = Session["XZQ"]; ViewData["YHM"] = Session["YHM"]; return View(); }
        public ActionResult FC_CF() { ViewData["XZQ"] = Session["XZQ"]; ViewData["YHM"] = Session["YHM"]; return View(); }
        public ActionResult FC_CK() { ViewData["XZQ"] = Session["XZQ"]; ViewData["YHM"] = Session["YHM"]; return View(); }
        public ActionResult FC_TD() { ViewData["XZQ"] = Session["XZQ"]; ViewData["YHM"] = Session["YHM"]; return View(); }
        public ActionResult FC_CW() { ViewData["XZQ"] = Session["XZQ"]; ViewData["YHM"] = Session["YHM"]; return View(); }

        [ValidateInput(false)]
        public JsonResult FBFC_DZFJBXX()
        {
            YHJBXX yhjbxx = FC_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string BCMS = Request["BCMS"];
            string fwzp = Request["FWZP"];
            string jygz = Request["JYGZ"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            FC_DZFJBXX dzfjbxx = JsonHelper.ConvertJsonToObject<FC_DZFJBXX>(json);
            dzfjbxx.BCMS = BinaryHelper.StringToBinary(BCMS);
            dzfjbxx.JYGZ = BinaryHelper.StringToBinary(jygz);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = FC_BLL.SaveDZFJBXX(jcxx, dzfjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBFC_SPJBXX()
        {
            YHJBXX yhjbxx = FC_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            FC_SPJBXX spjbxx = JsonHelper.ConvertJsonToObject<FC_SPJBXX>(json);
            spjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = FC_BLL.SaveSPJBXX(jcxx, spjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBFC_XZLJBXX()
        {
            YHJBXX yhjbxx = FC_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            FC_XZLJBXX xzljbxx = JsonHelper.ConvertJsonToObject<FC_XZLJBXX>(json);
            xzljbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = FC_BLL.SaveXZLJBXX(jcxx, xzljbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBFC_ZZFJBXX()
        {
            YHJBXX yhjbxx = FC_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            FC_ZZFJBXX FC_ZZFjbxx = JsonHelper.ConvertJsonToObject<FC_ZZFJBXX>(json);
            FC_ZZFjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = FC_BLL.SaveFC_ZZFJBXX(jcxx, FC_ZZFjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBFC_HZFJBXX()
        {
            YHJBXX yhjbxx = FC_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            FC_HZFJBXX FC_HZFjbxx = JsonHelper.ConvertJsonToObject<FC_HZFJBXX>(json);
            FC_HZFjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = FC_BLL.SaveFC_HZFJBXX(jcxx, FC_HZFjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBFC_ESFJBXX()
        {
            YHJBXX yhjbxx = FC_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            FC_ESFJBXX FC_ESFjbxx = JsonHelper.ConvertJsonToObject<FC_ESFJBXX>(json);
            FC_ESFjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = FC_BLL.SaveFC_ESFJBXX(jcxx, FC_ESFjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBFC_CFJBXX()
        {
            YHJBXX yhjbxx = FC_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            FC_CFJBXX CFjbxx = JsonHelper.ConvertJsonToObject<FC_CFJBXX>(json);
            CFjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = FC_BLL.SaveCFJBXX(jcxx, CFjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBFC_CKJBXX()
        {
            YHJBXX yhjbxx = FC_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            FC_CKJBXX CKjbxx = JsonHelper.ConvertJsonToObject<FC_CKJBXX>(json);
            CKjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = FC_BLL.SaveCKJBXX(jcxx, CKjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBFC_TDJBXX()
        {
            YHJBXX yhjbxx = FC_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            FC_TDJBXX TDjbxx = JsonHelper.ConvertJsonToObject<FC_TDJBXX>(json);
            TDjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = FC_BLL.SaveTDJBXX(jcxx, TDjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBFC_CWJBXX()
        {
            YHJBXX yhjbxx = FC_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            FC_CWJBXX CWjbxx = JsonHelper.ConvertJsonToObject<FC_CWJBXX>(json);
            CWjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = FC_BLL.SaveCWJBXX(jcxx, CWjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadFC_DZFJBXX()
        {
            object result = FC_BLL.LoadFC_DZFJBXX(Request["ID"]);
            return Json(result);
        }
        public JsonResult LoadFC_SPJBXX()
        {
            object result = FC_BLL.LoadFC_SPJBXX(Request["ID"]);
            return Json(result);
        }
        public JsonResult LoadFC_XZLJBXX()
        {
            object result = FC_BLL.LoadFC_XZLJBXX(Request["ID"]);
            return Json(result);
        }
        public JsonResult LoadFC_ZZFJBXX()
        {
            object result = FC_BLL.LoadFC_ZZFJBXX(Request["ID"]);
            return Json(result);
        }
        public JsonResult LoadFC_HZFJBXX()
        {
            object result = FC_BLL.LoadFC_HZFJBXX(Request["ID"]);
            return Json(result);
        }
        public JsonResult LoadFC_ESFJBXX()
        {
            object result = FC_BLL.LoadFC_ESFJBXX(Request["ID"]);
            return Json(result);
        }
        public JsonResult LoadFC_CFJBXX()
        {
            object result = FC_BLL.LoadFC_CFJBXX(Request["ID"]);
            return Json(result);
        }
        public JsonResult LoadFC_CKJBXX()
        {
            object result = FC_BLL.LoadFC_CKJBXX(Request["ID"]);
            return Json(result);
        }
        public JsonResult LoadFC_TDJBXX()
        {
            object result = FC_BLL.LoadFC_TDJBXX(Request["ID"]);
            return Json(result);
        }
        public JsonResult LoadFC_CWJBXX()
        {
            object result = FC_BLL.LoadFC_CWJBXX(Request["ID"]);
            return Json(result);
        }
        public JsonResult LoadXQJBXXSByHZ()
        {
            return Json(FC_BLL.LoadXQJBXXSByHZ(Request["XQMC"], Session["XZQ"].ToString()));
        }
        public JsonResult LoadXQJBXXSByPY()
        {
            return Json(FC_BLL.LoadXQJBXXSByPY(Request["XQMC"], Session["XZQ"].ToString()));
        }
    }
}