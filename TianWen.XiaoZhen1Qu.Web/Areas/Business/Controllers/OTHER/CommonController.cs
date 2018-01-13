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
            object result = CommonBLL.GetDistrictXQJByXZQDM(Session["XZQDM"].ToString());
            return Json(result);
        }
        //获取县区级行政区
        public JsonResult GetDistrictXQJByXZQDM()
        {
            object result = CommonBLL.GetDistrictXQJByXZQDM(Session["XZQDM"].ToString());
            return Json(result);
        }
        //根据一个市的所有子记录
        public JsonResult GetAllDistrictByXZQDM()
        {
            object result = CommonBLL.GetAllDistrictByXZQDM(Session["XZQDM"].ToString());
            return Json(result);
        }
        //切换行政区
        public JsonResult QHXZQ()
        {
            Session["XZQ"] = Request["XZQ"];
            Session["XZQDM"] = Request["XZQDM"];
            return Json(new { Result = EnResultType.Success });
        }
        //根据TYPENAME获取字典表
        public JsonResult LoadCODESByTYPENAME()
        {
            string TYPENAME = Request["TYPENAME"];
            string TBName = Request["TBName"];
            return Json(CommonBLL.LoadCODESByTYPENAME(TYPENAME, TBName));
        }
        public JsonResult LoadCODESByTYPENAMES()
        {
            string TYPENAMES = Request["TYPENAMES"];
            string TBName = Request["TBName"];
            return Json(CommonBLL.LoadCODESByTYPENAMES(TYPENAMES, TBName, Session["XZQDM"].ToString()));
        }
        //加载区域
        public JsonResult LoadQY()
        {
            return Json(CommonBLL.LoadQYBySuperName(Session["XZQDM"].ToString()));
        }
        //加载商圈
        public JsonResult LoadDD()
        {
            return Json(CommonBLL.LoadDDByQY(Request["QY"]));
        }
        //加载职位类别信息
        public JsonResult LoadZWLBXX()
        {
            return Json(CommonBLL.LoadZWLBXX(Request["TYPENAME"]));
        }
        //根据CODEVALUE和TYPENAME加载字典表
        public JsonResult LoadByCodeValueAndTypeName()
        {
            return Json(CommonBLL.LoadByCodeValueAndTypeName(Request["CODEVALUE"], Request["TYPENAME"], Request["TBName"]));
        }
        //根据PARENTID加载字典表
        public JsonResult LoadByParentID()
        {
            return Json(CommonBLL.LoadByParentID(Request["ParentID"], Request["TBName"]));
        }
        //加载相关类目
        public JsonResult LoadXGLM()
        {
            string TYPE = Request["TYPE"];
            return Json(CommonBLL.LoadXGLM(TYPE, Session["XZQ"].ToString()));
        }
    }
}