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

        public ActionResult FC_CFCKTDCW() { ViewData["XZQ"] = Session["XZQ"]; ViewData["YHM"] = Session["YHM"]; return View(); }
        public ActionResult FC_DZF() { ViewData["XZQ"] = Session["XZQ"]; ViewData["YHM"] = Session["YHM"]; return View(); }
        public ActionResult FC_SP() { ViewData["XZQ"] = Session["XZQ"]; ViewData["YHM"] = Session["YHM"]; return View(); }
        public ActionResult FC_XZL() { ViewData["XZQ"] = Session["XZQ"]; ViewData["YHM"] = Session["YHM"]; return View(); }
        public ActionResult FC_ZZF() { ViewData["XZQ"] = Session["XZQ"]; ViewData["YHM"] = Session["YHM"]; return View(); }
        public ActionResult FC_HZF() { ViewData["XZQ"] = Session["XZQ"]; ViewData["YHM"] = Session["YHM"]; return View(); }
        public ActionResult FC_ESF() { ViewData["XZQ"] = Session["XZQ"]; ViewData["YHM"] = Session["YHM"]; return View(); }

        [ValidateInput(false)]
        public JsonResult FBFC_CFCKTDCWJBXX()
        {
            YHJBXX yhjbxx = FC_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            FC_CFCKTDCWJBXX CFCKTDCWjbxx = JsonHelper.ConvertJsonToObject<FC_CFCKTDCWJBXX>(json);
            CFCKTDCWjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = FC_BLL.SaveCFCKTDCWJBXX(jcxx, CFCKTDCWjbxx, photos);
            return Json(result);
        }
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
            dzfjbxx.JYGZ = jygz;
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

        public JsonResult LoadFC_CFCKTDCWJBXX()
        {
            object result = FC_BLL.LoadFC_CFCKTDCWJBXX(Request["ID"]);
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
        public JsonResult LoadXQJBXXSByHZ()
        {
            return Json(FC_BLL.LoadXQJBXXSByHZ(Request["XQMC"]));
        }

        public JsonResult LoadXQJBXXSByPY()
        {
            return Json(FC_BLL.LoadXQJBXXSByPY(Request["XQMC"]));
        }
    }
}