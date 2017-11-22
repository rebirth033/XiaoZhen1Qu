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
        public INLMFY_BLL NLMFY_BLL { get; set; }

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
            YHJBXX yhjbxx = NLMFY_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            NLMFY_CQYZJBXX NLMFY_CQYZjbxx = JsonHelper.ConvertJsonToObject<NLMFY_CQYZJBXX>(json);
            NLMFY_CQYZjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = NLMFY_BLL.SaveNLMFY_CQYZJBXX(jcxx, NLMFY_CQYZjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBNLMFY_DZWZMJBXX()
        {
            YHJBXX yhjbxx = NLMFY_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            NLMFY_DZWZMJBXX NLMFY_DZWZMjbxx = JsonHelper.ConvertJsonToObject<NLMFY_DZWZMJBXX>(json);
            NLMFY_DZWZMjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = NLMFY_BLL.SaveNLMFY_DZWZMJBXX(jcxx, NLMFY_DZWZMjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBNLMFY_FLNYJBXX()
        {
            YHJBXX yhjbxx = NLMFY_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            NLMFY_FLNYJBXX NLMFY_FLNYjbxx = JsonHelper.ConvertJsonToObject<NLMFY_FLNYJBXX>(json);
            NLMFY_FLNYjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = NLMFY_BLL.SaveNLMFY_FLNYJBXX(jcxx, NLMFY_FLNYjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBNLMFY_SLSYJBXX()
        {
            YHJBXX yhjbxx = NLMFY_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            NLMFY_SLSYJBXX NLMFY_SLSYjbxx = JsonHelper.ConvertJsonToObject<NLMFY_SLSYJBXX>(json);
            NLMFY_SLSYjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = NLMFY_BLL.SaveNLMFY_SLSYJBXX(jcxx, NLMFY_SLSYjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBNLMFY_NCPJGJBXX()
        {
            YHJBXX yhjbxx = NLMFY_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            NLMFY_NCPJGJBXX NLMFY_NCPJGjbxx = JsonHelper.ConvertJsonToObject<NLMFY_NCPJGJBXX>(json);
            NLMFY_NCPJGjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = NLMFY_BLL.SaveNLMFY_NCPJGJBXX(jcxx, NLMFY_NCPJGjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBNLMFY_NJJSBJBXX()
        {
            YHJBXX yhjbxx = NLMFY_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            NLMFY_NJJSBJBXX NLMFY_NJJSBjbxx = JsonHelper.ConvertJsonToObject<NLMFY_NJJSBJBXX>(json);
            NLMFY_NJJSBjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = NLMFY_BLL.SaveNLMFY_NJJSBJBXX(jcxx, NLMFY_NJJSBjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBNLMFY_NZWJBXX()
        {
            YHJBXX yhjbxx = NLMFY_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            NLMFY_NZWJBXX NLMFY_NZWjbxx = JsonHelper.ConvertJsonToObject<NLMFY_NZWJBXX>(json);
            NLMFY_NZWjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = NLMFY_BLL.SaveNLMFY_NZWJBXX(jcxx, NLMFY_NZWjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBNLMFY_SCJBXX()
        {
            YHJBXX yhjbxx = NLMFY_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            NLMFY_SCJBXX NLMFY_SCjbxx = JsonHelper.ConvertJsonToObject<NLMFY_SCJBXX>(json);
            NLMFY_SCjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = NLMFY_BLL.SaveNLMFY_SCJBXX(jcxx, NLMFY_SCjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBNLMFY_YLHHJBXX()
        {
            YHJBXX yhjbxx = NLMFY_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            NLMFY_YLHHJBXX NLMFY_YLHHjbxx = JsonHelper.ConvertJsonToObject<NLMFY_YLHHJBXX>(json);
            NLMFY_YLHHjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = NLMFY_BLL.SaveNLMFY_YLHHJBXX(jcxx, NLMFY_YLHHjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadNLMFY_CQYZJBXX()
        {
            string ID = Request["ID"];
            object result = NLMFY_BLL.LoadNLMFY_CQYZJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadNLMFY_DZWZMJBXX()
        {
            string ID = Request["ID"];
            object result = NLMFY_BLL.LoadNLMFY_DZWZMJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadNLMFY_FLNYJBXX()
        {
            string ID = Request["ID"];
            object result = NLMFY_BLL.LoadNLMFY_FLNYJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadNLMFY_NCPJGJBXX()
        {
            string ID = Request["ID"];
            object result = NLMFY_BLL.LoadNLMFY_NCPJGJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadNLMFY_NJJSBJBXX()
        {
            string ID = Request["ID"];
            object result = NLMFY_BLL.LoadNLMFY_NJJSBJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadNLMFY_NZWJBXX()
        {
            string ID = Request["ID"];
            object result = NLMFY_BLL.LoadNLMFY_NZWJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadNLMFY_SCJBXX()
        {
            string ID = Request["ID"];
            object result = NLMFY_BLL.LoadNLMFY_SCJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadNLMFY_SLSYJBXX()
        {
            string ID = Request["ID"];
            object result = NLMFY_BLL.LoadNLMFY_SLSYJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadNLMFY_YLHHJBXX()
        {
            string ID = Request["ID"];
            object result = NLMFY_BLL.LoadNLMFY_YLHHJBXX(ID);
            return Json(result);
        }
    }
}