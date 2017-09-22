using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class CommonController : BaseController
    {
        public ICommonBLL CommonBLL { get; set; }
        public JsonResult GetIDByJCXXIDAndLBID()
        {
            string LBID = Request["LBID"];
            string JCXXID = Request["JCXXID"];
            object result = CommonBLL.GetIDByJCXXIDAndLBID(JCXXID, LBID);
            return Json(result);
        }

        public JsonResult GetDistrictByGrade()
        {
            string Grade = Request["Grade"];
            object result = CommonBLL.GetDistrictByGrade(Grade);
            return Json(result);
        }

        public JsonResult GetDistrictBySuperCode()
        {
            string SupserCode = Request["SupserCode"];
            object result = CommonBLL.GetDistrictBySuperCode(SupserCode);
            return Json(result);
        }

        public JsonResult LoadCODES_FC()
        {
            string TYPENAME = Request["TYPENAME"];
            return Json(CommonBLL.LoadCODES_FC(TYPENAME));
        }

        public JsonResult LoadCODES_ES_SJSM()
        {
            string TYPENAME = Request["TYPENAME"];
            return Json(CommonBLL.LoadCODES_ES_SJSM(TYPENAME));
        }
        
        public JsonResult LoadCODES_ES_JDJJBG()
        {
            string TYPENAME = Request["TYPENAME"];
            return Json(CommonBLL.LoadCODES_ES_JDJJBG(TYPENAME));
        }

        public JsonResult LoadCODES_ES_MYFZMR()
        {
            string TYPENAME = Request["TYPENAME"];
            return Json(CommonBLL.LoadCODES_ES_MYFZMR(TYPENAME));
        }

        public JsonResult LoadCODES_ES_WHYL()
        {
            string TYPENAME = Request["TYPENAME"];
            return Json(CommonBLL.LoadCODES_ES_WHYL(TYPENAME));
        }

        public JsonResult LoadCODES_ES_QTES()
        {
            string TYPENAME = Request["TYPENAME"];
            return Json(CommonBLL.LoadCODES_ES_QTES(TYPENAME));
        }

        public JsonResult LoadCODES_CL()
        {
            string TYPENAME = Request["TYPENAME"];
            return Json(CommonBLL.LoadCODES_CL(TYPENAME));
        }

        public JsonResult LoadCODES_CW()
        {
            string TYPENAME = Request["TYPENAME"];
            return Json(CommonBLL.LoadCODES_CW(TYPENAME));
        }

        public JsonResult QHXZQ()
        {
            Session["XZQ"] = Request["XZQ"];
            return Json(new { Result = EnResultType.Success });
        }

        public JsonResult LoadQY()
        {
            return Json(CommonBLL.LoadQYBySuperName(Session["XZQ"].ToString()));
        }

        public JsonResult LoadSQ()
        {
            return Json(CommonBLL.LoadSQByQY(Request["QY"]));
        }

        public JsonResult LoadSJXH()
        {
            return Json(CommonBLL.LoadSJXHBySJPP(Request["SJPP"]));
        }

        public JsonResult LoadBJBXH()
        {
            return Json(CommonBLL.LoadBJBXHByBJBPP(Request["BJBPP"]));
        }

        public JsonResult LoadPBXH()
        {
            return Json(CommonBLL.LoadPBXHByPBPP(Request["PBPP"]));
        }

        public JsonResult LoadGCQXJBXX()
        {
            return Json(CommonBLL.LoadGCQXJBXX(Request["GCQX"]));
        }

        public JsonResult LoadHCJBXX()
        {
            return Json(CommonBLL.LoadHCJBXX(Request["HC"]));
        }

        public JsonResult LoadGCCJBXX()
        {
            return Json(CommonBLL.LoadGCCJBXX(Request["GCC"]));
        }

        public JsonResult LoadGCCPPXX()
        {
            return Json(CommonBLL.LoadGCCPPXX(Request["GCCLX"], Request["GCCBQ"]));
        }

        public JsonResult LoadGCQXXH()
        {
            return Json(CommonBLL.LoadGCQXXH(Request["PPID"]));
        }

        public JsonResult LoadKCPPXX()
        {
            return Json(CommonBLL.LoadKCPPXX(Request["KCLX"], Request["KCBQ"]));
        }

        public JsonResult LoadKCCXXX()
        {
            return Json(CommonBLL.LoadKCCXXX(Request["PPID"]));
        }

        public JsonResult LoadCWPZXX()
        {
            return Json(CommonBLL.LoadCWPZXX(Request["CWG"]));
        }

        public JsonResult LoadHNCYXX()
        {
            return Json(CommonBLL.LoadHNCYXX(Request["PZID"]));
        }
    }
}