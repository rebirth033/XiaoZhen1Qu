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
    public class CWController : BaseController
    {
        public ICW_CWFWBLL CW_CWFWBLL { get; set; }
        public ICW_CWGBLL CW_CWGBLL { get; set; }
        public ICW_CWMBLL CW_CWMBLL { get; set; }
        public ICW_CWYPSPBLL CW_CWYPSPBLL { get; set; }
        public ICW_CWZSLYBLL CW_CWZSLYBLL { get; set; }
        public ICW_HNYCBLL CW_HNYCBLL { get; set; }

        public ActionResult CW_CWFW()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult CW_CWG()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult CW_CWM()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult CW_CWYPSP()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult CW_CWZSLY()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult CW_HNYC()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FBCW_CWFWJBXX()
        {
            YHJBXX yhjbxx = CW_CWFWBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            CW_CWFWJBXX CW_CWFWjbxx = JsonHelper.ConvertJsonToObject<CW_CWFWJBXX>(json);
            CW_CWFWjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = CW_CWFWBLL.SaveCW_CWFWJBXX(jcxx, CW_CWFWjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBCW_CWGJBXX()
        {
            YHJBXX yhjbxx = CW_CWGBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            CW_CWGJBXX CW_CWGjbxx = JsonHelper.ConvertJsonToObject<CW_CWGJBXX>(json);
            CW_CWGjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = CW_CWGBLL.SaveCW_CWGJBXX(jcxx, CW_CWGjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBCW_CWMJBXX()
        {
            YHJBXX yhjbxx = CW_CWMBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            CW_CWMJBXX CW_CWMjbxx = JsonHelper.ConvertJsonToObject<CW_CWMJBXX>(json);
            CW_CWMjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = CW_CWMBLL.SaveCW_CWMJBXX(jcxx, CW_CWMjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBCW_CWYPSPJBXX()
        {
            YHJBXX yhjbxx = CW_CWYPSPBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            CW_CWYPSPJBXX CW_CWYPSPjbxx = JsonHelper.ConvertJsonToObject<CW_CWYPSPJBXX>(json);
            CW_CWYPSPjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = CW_CWYPSPBLL.SaveCW_CWYPSPJBXX(jcxx, CW_CWYPSPjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBCW_CWZSLYJBXX()
        {
            YHJBXX yhjbxx = CW_CWZSLYBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            CW_CWZSLYJBXX CW_CWZSLYjbxx = JsonHelper.ConvertJsonToObject<CW_CWZSLYJBXX>(json);
            CW_CWZSLYjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = CW_CWZSLYBLL.SaveCW_CWZSLYJBXX(jcxx, CW_CWZSLYjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBCW_HNYCJBXX()
        {
            YHJBXX yhjbxx = CW_HNYCBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            CW_HNYCJBXX CW_HNYCjbxx = JsonHelper.ConvertJsonToObject<CW_HNYCJBXX>(json);
            CW_HNYCjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = CW_HNYCBLL.SaveCW_HNYCJBXX(jcxx, CW_HNYCjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadCW_CWFWJBXX()
        {
            string CW_CWFWJBXXID = Request["CW_CWFWJBXXID"];
            object result = CW_CWFWBLL.LoadCW_CWFWJBXX(CW_CWFWJBXXID);
            return Json(result);
        }
        public JsonResult LoadCW_CWGJBXX()
        {
            string CW_CWGJBXXID = Request["CW_CWGJBXXID"];
            object result = CW_CWGBLL.LoadCW_CWGJBXX(CW_CWGJBXXID);
            return Json(result);
        }
        public JsonResult LoadCW_CWMJBXX()
        {
            string CW_CWMJBXXID = Request["CW_CWMJBXXID"];
            object result = CW_CWMBLL.LoadCW_CWMJBXX(CW_CWMJBXXID);
            return Json(result);
        }
        public JsonResult LoadCW_CWYPSPJBXX()
        {
            string CW_CWYPSPJBXXID = Request["CW_CWYPSPJBXXID"];
            object result = CW_CWYPSPBLL.LoadCW_CWYPSPJBXX(CW_CWYPSPJBXXID);
            return Json(result);
        }
        public JsonResult LoadCW_CWZSLYJBXX()
        {
            string CW_CWZSLYJBXXID = Request["CW_CWZSLYJBXXID"];
            object result = CW_CWZSLYBLL.LoadCW_CWZSLYJBXX(CW_CWZSLYJBXXID);
            return Json(result);
        }
        public JsonResult LoadCW_HNYCJBXX()
        {
            string CW_HNYCJBXXID = Request["CW_HNYCJBXXID"];
            object result = CW_HNYCBLL.LoadCW_HNYCJBXX(CW_HNYCJBXXID);
            return Json(result);
        }
    }
}