using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class CommonController : BaseController
    {
        public ICommonBLL CommonBLL { get; set; }

        //根据基础信息ID和类别ID获取
        public JsonResult GetIDByJCXXIDAndLBID()
        {
            string LBID = Request["LBID"];
            string JCXXID = Request["JCXXID"];
            object result = CommonBLL.GetIDByJCXXIDAndLBID(JCXXID, LBID);
            return Json(result);
        }
        //根据行政区级别获取行政区
        public JsonResult GetDistrictByGrade()
        {
            string Grade = Request["Grade"];
            object result = CommonBLL.GetDistrictByGrade(Grade);
            return Json(result);
        }
        //根据行政区简称获取行政区
        public JsonResult GetDistrictByShortName()
        {
            string Grade = Request["ShortName"];
            object result = CommonBLL.GetDistrictByShortName(Grade);
            return Json(result);
        }
        //获取父级行政区
        public JsonResult GetDistrictBySuperCode()
        {
            string SuperCode = Request["SuperCode"];
            object result = CommonBLL.GetDistrictBySuperCode(SuperCode);
            return Json(result);
        }
        //根据行政区编码获取省内同级行政区
        public JsonResult GetDistrictTJByXZQDM()
        {
            string XZQDM = Request["XZQDM"];
            object result = CommonBLL.GetDistrictTJByXZQDM(XZQDM);
            return Json(result);
        }
        //切换行政区
        public JsonResult QHXZQ()
        {
            Session["XZQ"] = Request["XZQ"];
            Session["XZQDM"] = Request["XZQDM"];
            return Json(new { Result = EnResultType.Success });
        }

        #region 根据TYPENAME获取字典表

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

        public JsonResult LoadCODES_PWKQ()
        {
            string TYPENAME = Request["TYPENAME"];
            return Json(CommonBLL.LoadCODES_PWKQ(TYPENAME));
        }

        public JsonResult LoadCODES_CY()
        {
            string TYPENAME = Request["TYPENAME"];
            return Json(CommonBLL.LoadCODES_CY(TYPENAME));
        }

        public JsonResult LoadCODES_XXYL()
        {
            string TYPENAME = Request["TYPENAME"];
            return Json(CommonBLL.LoadCODES_XXYL(TYPENAME));
        }

        public JsonResult LoadCODES_LR()
        {
            string TYPENAME = Request["TYPENAME"];
            return Json(CommonBLL.LoadCODES_LR(TYPENAME));
        }

        public JsonResult LoadCODES_ZSJM()
        {
            string TYPENAME = Request["TYPENAME"];
            return Json(CommonBLL.LoadCODES_ZSJM(TYPENAME));
        }

        public JsonResult LoadCODES_PFCG()
        {
            string TYPENAME = Request["TYPENAME"];
            return Json(CommonBLL.LoadCODES_PFCG(TYPENAME));
        }

        public JsonResult LoadCODES_QZZP()
        {
            string TYPENAME = Request["TYPENAME"];
            return Json(CommonBLL.LoadCODES_QZZP(TYPENAME));
        }

        public JsonResult LoadCODES_SHFW()
        {
            string TYPENAME = Request["TYPENAME"];
            return Json(CommonBLL.LoadCODES_SHFW(TYPENAME));
        }

        public JsonResult LoadCODES_SWFW()
        {
            string TYPENAME = Request["TYPENAME"];
            return Json(CommonBLL.LoadCODES_SWFW(TYPENAME));
        }

        public JsonResult LoadCODES_JYPX()
        {
            string TYPENAME = Request["TYPENAME"];
            return Json(CommonBLL.LoadCODES_JYPX(TYPENAME));
        }

        public JsonResult LoadCODES_LYJD()
        {
            string TYPENAME = Request["TYPENAME"];
            return Json(CommonBLL.LoadCODES_LYJD(TYPENAME));
        }

        public JsonResult LoadCODES_ZXJC()
        {
            string TYPENAME = Request["TYPENAME"];
            return Json(CommonBLL.LoadCODES_ZXJC(TYPENAME));
        }

        public JsonResult LoadCODES_HQSY()
        {
            string TYPENAME = Request["TYPENAME"];
            return Json(CommonBLL.LoadCODES_HQSY(TYPENAME));
        }

        public JsonResult LoadCODES_NLMFY()
        {
            string TYPENAME = Request["TYPENAME"];
            return Json(CommonBLL.LoadCODES_NLMFY(TYPENAME));
        }

        #endregion

        public JsonResult LoadQY()
        {
            return Json(CommonBLL.LoadQYBySuperName(Session["XZQ"].ToString()));
        }

        public JsonResult LoadSQ()
        {
            return Json(CommonBLL.LoadSQByQY(Request["QY"]));
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

        public JsonResult LoadKCPPXX()
        {
            return Json(CommonBLL.LoadKCPPXX(Request["KCLX"], Request["KCBQ"]));
        }

        public JsonResult LoadJCPPXX()
        {
            return Json(CommonBLL.LoadJCPPXX(Request["JCLX"], Request["JCBQ"]));
        }

        public JsonResult LoadCWPZXX()
        {
            return Json(CommonBLL.LoadCWPZXX(Request["CWG"]));
        }

        public JsonResult LoadMRBJXX()
        {
            return Json(CommonBLL.LoadMRBJXX(Request["name"]));
        }

        public JsonResult LoadLPXSPXX()
        {
            return Json(CommonBLL.LoadLPXSPXX(Request["name"]));
        }

        public JsonResult LoadZWLBXX()
        {
            return Json(CommonBLL.LoadZWLBXX(Request["TYPENAME"]));
        }

        public JsonResult LoadYZXX()
        {
            return Json(CommonBLL.LoadYZXX(Request["YZBQ"]));
        }

        public JsonResult LoadGJXX()
        {
            return Json(CommonBLL.LoadGJXX(Request["GJBQ"]));
        }

        public JsonResult LoadLXGJXX()
        {
            return Json(CommonBLL.LoadLXGJXX(Request["GJBQ"]));
        }

        public JsonResult LoadBYYXXX()
        {
            return Json(CommonBLL.LoadBYYXXX(Request["BYYXBQ"]));
        }

        public JsonResult LoadHCPPXX()
        {
            return Json(CommonBLL.LoadHCPPXX(Request["HCPPBQ"]));
        }

        public JsonResult LoadByParentID()
        {
            return Json(CommonBLL.LoadByParentID(Request["ParentID"], Request["TBName"]));
        }

        public JsonResult LoadYLHHXX()
        {
            return Json(CommonBLL.LoadYLHHXX(Request["HCPPBQ"], Request["TYPE"]));
        }

    }
}