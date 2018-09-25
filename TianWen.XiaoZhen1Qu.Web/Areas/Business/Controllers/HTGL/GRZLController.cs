using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.BLL;
using TianWen.XiaoZhen1Qu.Interface;
using TianWen.XiaoZhen1Qu.Entities.Models;
using System;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class GRZLController : BaseController
    {
        public IYHZCBLL YHZCBLL { get; set; }

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
            YHJBXX YHJBXX = YHZCBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            object result = YHZCBLL.UpdateTX(YHJBXX.YHID, Request["TX"]);
            return Json(result);
        }

        public JsonResult GetGRZL()
        {
            YHJBXX YHJBXX = YHZCBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            return Json(new { Result = EnResultType.Success, YHJBXX = YHJBXX });
        }

        public JsonResult UpdateYHM()
        {
            YHJBXX YHJBXX = YHZCBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            object result = YHZCBLL.UpdateYHM(YHJBXX.YHID, Request["YHM"]);
            return Json(result);
        }

        public JsonResult UpdateSJ()
        {
            YHJBXX YHJBXX = YHZCBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            object result = YHZCBLL.UpdateSJ(YHJBXX.YHID, Request["SJ"]);
            return Json(result);
        }

        public JsonResult UpdateQQ()
        {
            YHJBXX YHJBXX = YHZCBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            object result = YHZCBLL.UpdateQQ(YHJBXX.YHID, Request["SJ"]);
            return Json(result);
        }

        public JsonResult UpdateWB()
        {
            YHJBXX YHJBXX = YHZCBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            object result = YHZCBLL.UpdateWB(YHJBXX.YHID, Request["WB"]);
            return Json(result);
        }

        public JsonResult UpdateWX()
        {
            YHJBXX YHJBXX = YHZCBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            object result = YHZCBLL.UpdateWX(YHJBXX.YHID, Request["WX"]);
            return Json(result);
        }

        public JsonResult SendEmail()
        {
            Session["YX"] = Request["YX"];
            YHJBXX YHJBXX = YHZCBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            Random random = new Random();
            string CheckCode = random.Next(100000, 999999).ToString();//6位验证码
            Session["YX"] = Request["YX"];
            object result = YHZCBLL.SendEmail(YHJBXX.YHID, Request["YX"], CheckCode);
            return Json(result);
        }

        public JsonResult YXYZYBC()
        {
            try
            {
                string[] values = Request["para"].Split('|');
                string YHID_Cryptograph = values[0];
                string CheckCode_Cryptograph = values[1];

                object result = YHZCBLL.YHYZ(YHID_Cryptograph, CheckCode_Cryptograph,Session["YX"].ToString());

                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(null);
            }
        }

        public JsonResult MMCZ()
        {
            YHJBXX YHJBXX = YHZCBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            object result = YHZCBLL.MMCZ(YHJBXX.YHID, Request["JMM"], Request["XMM"]);
            return Json(result);
        }
    }
}