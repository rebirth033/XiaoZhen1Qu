using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.BLL;
using TianWen.XiaoZhen1Qu.Interface;
using TianWen.XiaoZhen1Qu.Entities.Models;
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
            YHJBXX yhjbxx = YHJBXXBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            object result = YHJBXXBLL.UpdateTX(yhjbxx.YHID, Request["TX"]);
            return Json(result);
        }

        public JsonResult GetGRZL()
        {
            YHJBXX yhjbxx = YHJBXXBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            return Json(new { Result = EnResultType.Success, YHJBXX = yhjbxx });
        }

        public JsonResult UpdateYHM()
        {
            YHJBXX yhjbxx = YHJBXXBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            object result = YHJBXXBLL.UpdateYHM(yhjbxx.YHID, Request["YHM"]);
            return Json(result);
        }

        public JsonResult UpdateSJ()
        {
            YHJBXX yhjbxx = YHJBXXBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            object result = YHJBXXBLL.UpdateSJ(yhjbxx.YHID, Request["SJ"]);
            return Json(result);
        }

        public JsonResult UpdateQQ()
        {
            YHJBXX yhjbxx = YHJBXXBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            object result = YHJBXXBLL.UpdateQQ(yhjbxx.YHID, Request["SJ"]);
            return Json(result);
        }

        public JsonResult UpdateWB()
        {
            YHJBXX yhjbxx = YHJBXXBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            object result = YHJBXXBLL.UpdateWB(yhjbxx.YHID, Request["WB"]);
            return Json(result);
        }

        public JsonResult UpdateWX()
        {
            YHJBXX yhjbxx = YHJBXXBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            object result = YHJBXXBLL.UpdateWX(yhjbxx.YHID, Request["WX"]);
            return Json(result);
        }

        public JsonResult SendEmail()
        {
            Session["YX"] = Request["YX"];
            YHJBXX yhjbxx = YHJBXXBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            Random random = new Random();
            string CheckCode = random.Next(100000, 999999).ToString();//6位验证码
            Session["YX"] = Request["YX"];
            object result = YHJBXXBLL.SendEmail(yhjbxx.YHID, Request["YX"], CheckCode);
            return Json(result);
        }

        public JsonResult YXYZYBC()
        {
            try
            {
                string[] values = Request["para"].Split('|');
                string YHID_Cryptograph = values[0];
                string CheckCode_Cryptograph = values[1];

                object result = YHJBXXBLL.YHYZ(YHID_Cryptograph, CheckCode_Cryptograph,Session["YX"].ToString());

                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(null);
            }
        }

        public JsonResult MMCZ()
        {
            YHJBXX yhjbxx = YHJBXXBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            object result = YHJBXXBLL.MMCZ(yhjbxx.YHID, Request["JMM"], Request["XMM"]);
            return Json(result);
        }
    }
}