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
    public class NLMFYController : BaseController
    {
        public INLMFY_CQYZBLL NLMFY_CQYZBLL { get; set; }
        public INLMFY_DZWZMBLL NLMFY_DZWZMBLL { get; set; }
        public INLMFY_FLNYBLL NLMFY_FLNYBLL { get; set; }
        public INLMFY_NCPJGBLL NLMFY_NCPJGBLL { get; set; }
        public INLMFY_NJJSBBLL NLMFY_NJJSBBLL { get; set; }
        public INLMFY_NZWBLL NLMFY_NZWBLL { get; set; }
        public INLMFY_SCBLL NLMFY_SCBLL { get; set; }
        public INLMFY_SLSYBLL NLMFY_SLSYBLL { get; set; }
        public INLMFY_YLHHBLL NLMFY_YLHHBLL { get; set; }

        public ActionResult NLMFY_CQYZ()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult NLMFY_DZWZM()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult NLMFY_FLNY()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult NLMFY_NCPJG()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult NLMFY_NJJSB()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult NLMFY_NZW()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult NLMFY_SC()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult NLMFY_SLSY()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult NLMFY_YLHH()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FBNLMFY_CQYZJBXX()
        {
            YHJBXX yhjbxx = NLMFY_CQYZBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            NLMFY_CQYZJBXX NLMFY_CQYZjbxx = JsonHelper.ConvertJsonToObject<NLMFY_CQYZJBXX>(json);
            NLMFY_CQYZjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = NLMFY_CQYZBLL.SaveNLMFY_CQYZJBXX(jcxx, NLMFY_CQYZjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBNLMFY_DZWZMJBXX()
        {
            YHJBXX yhjbxx = NLMFY_DZWZMBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            NLMFY_DZWZMJBXX NLMFY_DZWZMjbxx = JsonHelper.ConvertJsonToObject<NLMFY_DZWZMJBXX>(json);
            NLMFY_DZWZMjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = NLMFY_DZWZMBLL.SaveNLMFY_DZWZMJBXX(jcxx, NLMFY_DZWZMjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBNLMFY_FLNYJBXX()
        {
            YHJBXX yhjbxx = NLMFY_FLNYBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            NLMFY_FLNYJBXX NLMFY_FLNYjbxx = JsonHelper.ConvertJsonToObject<NLMFY_FLNYJBXX>(json);
            NLMFY_FLNYjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = NLMFY_FLNYBLL.SaveNLMFY_FLNYJBXX(jcxx, NLMFY_FLNYjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBNLMFY_NCPJGJBXX()
        {
            YHJBXX yhjbxx = NLMFY_NCPJGBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            NLMFY_NCPJGJBXX NLMFY_NCPJGjbxx = JsonHelper.ConvertJsonToObject<NLMFY_NCPJGJBXX>(json);
            NLMFY_NCPJGjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = NLMFY_NCPJGBLL.SaveNLMFY_NCPJGJBXX(jcxx, NLMFY_NCPJGjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBNLMFY_NJJSBJBXX()
        {
            YHJBXX yhjbxx = NLMFY_NJJSBBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            NLMFY_NJJSBJBXX NLMFY_NJJSBjbxx = JsonHelper.ConvertJsonToObject<NLMFY_NJJSBJBXX>(json);
            NLMFY_NJJSBjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = NLMFY_NJJSBBLL.SaveNLMFY_NJJSBJBXX(jcxx, NLMFY_NJJSBjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBNLMFY_NZWJBXX()
        {
            YHJBXX yhjbxx = NLMFY_NZWBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            NLMFY_NZWJBXX NLMFY_NZWjbxx = JsonHelper.ConvertJsonToObject<NLMFY_NZWJBXX>(json);
            NLMFY_NZWjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = NLMFY_NZWBLL.SaveNLMFY_NZWJBXX(jcxx, NLMFY_NZWjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBNLMFY_SCJBXX()
        {
            YHJBXX yhjbxx = NLMFY_SCBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            NLMFY_SCJBXX NLMFY_SCjbxx = JsonHelper.ConvertJsonToObject<NLMFY_SCJBXX>(json);
            NLMFY_SCjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = NLMFY_SCBLL.SaveNLMFY_SCJBXX(jcxx, NLMFY_SCjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FB()
        {
            YHJBXX yhjbxx = NLMFY_SLSYBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            NLMFY_SLSYJBXX NLMFY_SLSYjbxx = JsonHelper.ConvertJsonToObject<NLMFY_SLSYJBXX>(json);
            NLMFY_SLSYjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = NLMFY_SLSYBLL.SaveNLMFY_SLSYJBXX(jcxx, NLMFY_SLSYjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBNLMFY_YLHHJBXX()
        {
            YHJBXX yhjbxx = NLMFY_YLHHBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            NLMFY_YLHHJBXX NLMFY_YLHHjbxx = JsonHelper.ConvertJsonToObject<NLMFY_YLHHJBXX>(json);
            NLMFY_YLHHjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = NLMFY_YLHHBLL.SaveNLMFY_YLHHJBXX(jcxx, NLMFY_YLHHjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadNLMFY_CQYZJBXX()
        {
            string NLMFY_CQYZJBXXID = Request["NLMFY_CQYZJBXXID"];
            object result = NLMFY_CQYZBLL.LoadNLMFY_CQYZJBXX(NLMFY_CQYZJBXXID);
            return Json(result);
        }
        public JsonResult LoadNLMFY_DZWZMJBXX()
        {
            string NLMFY_DZWZMJBXXID = Request["NLMFY_DZWZMJBXXID"];
            object result = NLMFY_DZWZMBLL.LoadNLMFY_DZWZMJBXX(NLMFY_DZWZMJBXXID);
            return Json(result);
        }
        public JsonResult LoadNLMFY_FLNYJBXX()
        {
            string NLMFY_FLNYJBXXID = Request["NLMFY_FLNYJBXXID"];
            object result = NLMFY_FLNYBLL.LoadNLMFY_FLNYJBXX(NLMFY_FLNYJBXXID);
            return Json(result);
        }
        public JsonResult LoadNLMFY_NCPJGJBXX()
        {
            string NLMFY_NCPJGJBXXID = Request["NLMFY_NCPJGJBXXID"];
            object result = NLMFY_NCPJGBLL.LoadNLMFY_NCPJGJBXX(NLMFY_NCPJGJBXXID);
            return Json(result);
        }
        public JsonResult LoadNLMFY_NJJSBJBXX()
        {
            string NLMFY_NJJSBJBXXID = Request["NLMFY_NJJSBJBXXID"];
            object result = NLMFY_NJJSBBLL.LoadNLMFY_NJJSBJBXX(NLMFY_NJJSBJBXXID);
            return Json(result);
        }
        public JsonResult LoadNLMFY_NZWJBXX()
        {
            string NLMFY_NZWJBXXID = Request["NLMFY_NZWJBXXID"];
            object result = NLMFY_NZWBLL.LoadNLMFY_NZWJBXX(NLMFY_NZWJBXXID);
            return Json(result);
        }
        public JsonResult LoadNLMFY_SCJBXX()
        {
            string NLMFY_SCJBXXID = Request["NLMFY_SCJBXXID"];
            object result = NLMFY_SCBLL.LoadNLMFY_SCJBXX(NLMFY_SCJBXXID);
            return Json(result);
        }
        public JsonResult LoadNLMFY_SLSYJBXX()
        {
            string NLMFY_SLSYJBXXID = Request["NLMFY_SLSYJBXXID"];
            object result = NLMFY_SLSYBLL.LoadNLMFY_SLSYJBXX(NLMFY_SLSYJBXXID);
            return Json(result);
        }
        public JsonResult LoadNLMFY_YLHHJBXX()
        {
            string NLMFY_YLHHJBXXID = Request["NLMFY_YLHHJBXXID"];
            object result = NLMFY_YLHHBLL.LoadNLMFY_YLHHJBXX(NLMFY_YLHHJBXXID);
            return Json(result);
        }
    }
}