using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.BLL;
using TianWen.XiaoZhen1Qu.Interface;
using TianWen.XiaoZhen1Qu.Web.Areas.Business.Common;
using System;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class GRZLController : BaseController
    {
        public IYHJBXXBLL YHJBXXBLL { get; set; }
        public ActionResult GRZL()
        {
            return View();
        }

        public ActionResult HBSJ()
        {
            return View();
        }

        public ActionResult YXYZ()
        {
            return View();
        }

        public ActionResult YXYZCG()
        {
            return View();
        }

        public ActionResult MMSZ()
        {
            return View();
        }

        public JsonResult SaveXTTX()
        {
            object result = YHJBXXBLL.UpdateTX(Request["YHID"], Request["TX"]);
            return Json(result);
        }

        public JsonResult GetGRZL()
        {
            object result = YHJBXXBLL.GetObjByID(Request["YHID"]);
            return Json(result);
        }

        public JsonResult UpdateYHM()
        {
            object result = YHJBXXBLL.UpdateYHM(Request["YHID"], Request["YHM"]);
            return Json(result);
        }

        public JsonResult UpdateSJ()
        {
            object result = YHJBXXBLL.UpdateSJ(Request["YHID"], Request["SJ"]);
            return Json(result);
        }

        public JsonResult UpdateQQ()
        {
            object result = YHJBXXBLL.UpdateQQ(Request["YHID"], Request["QQ"]);
            return Json(result);
        }

        public JsonResult UpdateWB()
        {
            object result = YHJBXXBLL.UpdateWB(Request["YHID"], Request["WB"]);
            return Json(result);
        }

        public JsonResult UpdateWX()
        {
            object result = YHJBXXBLL.UpdateWX(Request["YHID"], Request["WX"]);
            return Json(result);
        }

        public JsonResult SendEmail()
        {
            Random random = new Random();
            string CheckCode = random.Next(100000, 999999).ToString();//6位验证码
            object result = YHJBXXBLL.SendEmail(Request["YHID"], Request["YX"], CheckCode);
            return Json(result);
        }

        public JsonResult YXYZYBC()
        {
            try
            {
                string[] values = Request["para"].Split('|');
                string YHID_Cryptograph = values[0];
                string CheckCode_Cryptograph = values[1];
                object result = YHJBXXBLL.YHYZ(YHID_Cryptograph, CheckCode_Cryptograph);

                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(null);
            }
        }

        public JsonResult MMCZ()
        {
            object result = YHJBXXBLL.MMCZ(Request["YHID"], Request["JMM"], Request["XMM"]);
            return Json(result);
        }
    }
}