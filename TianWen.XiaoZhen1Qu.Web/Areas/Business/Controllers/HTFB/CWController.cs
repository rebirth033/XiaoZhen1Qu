using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface.HTFB;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class CWController : BaseController
    {
        public ICW_BLL CW_BLL { get; set; }

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
        public ActionResult CW_CWGY()
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
            YHJBXX yhjbxx = CW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            CW_CWFWJBXX CW_CWFWjbxx = JsonHelper.ConvertJsonToObject<CW_CWFWJBXX>(json);
            CW_CWFWjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = CW_BLL.SaveCW_CWFWJBXX(jcxx, CW_CWFWjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBCW_CWGJBXX()
        {
            YHJBXX yhjbxx = CW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            CW_CWGJBXX CW_CWGjbxx = JsonHelper.ConvertJsonToObject<CW_CWGJBXX>(json);
            CW_CWGjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = CW_BLL.SaveCW_CWGJBXX(jcxx, CW_CWGjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBCW_CWMJBXX()
        {
            YHJBXX yhjbxx = CW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            CW_CWMJBXX CW_CWMjbxx = JsonHelper.ConvertJsonToObject<CW_CWMJBXX>(json);
            CW_CWMjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = CW_BLL.SaveCW_CWMJBXX(jcxx, CW_CWMjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBCW_CWYPSPJBXX()
        {
            YHJBXX yhjbxx = CW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            CW_CWYPSPJBXX CW_CWYPSPjbxx = JsonHelper.ConvertJsonToObject<CW_CWYPSPJBXX>(json);
            CW_CWYPSPjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = CW_BLL.SaveCW_CWYPSPJBXX(jcxx, CW_CWYPSPjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBCW_CWGYJBXX()
        {
            YHJBXX yhjbxx = CW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            CW_CWGYJBXX CW_CWGYJBXX = JsonHelper.ConvertJsonToObject<CW_CWGYJBXX>(json);
            CW_CWGYJBXX.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = CW_BLL.SaveCW_CWGYJBXX(jcxx, CW_CWGYJBXX, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBCW_HNYCJBXX()
        {
            YHJBXX yhjbxx = CW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            CW_HNYCJBXX CW_HNYCjbxx = JsonHelper.ConvertJsonToObject<CW_HNYCJBXX>(json);
            CW_HNYCjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = CW_BLL.SaveCW_HNYCJBXX(jcxx, CW_HNYCjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadCW_CWFWJBXX()
        {
            string ID = Request["ID"];
            object result = CW_BLL.LoadCW_CWFWJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadCW_CWGJBXX()
        {
            string ID = Request["ID"];
            object result = CW_BLL.LoadCW_CWGJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadCW_CWMJBXX()
        {
            string ID = Request["ID"];
            object result = CW_BLL.LoadCW_CWMJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadCW_CWYPSPJBXX()
        {
            string ID = Request["ID"];
            object result = CW_BLL.LoadCW_CWYPSPJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadCW_CWGYJBXX()
        {
            string ID = Request["ID"];
            object result = CW_BLL.LoadCW_CWGYJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadCW_HNYCJBXX()
        {
            string ID = Request["ID"];
            object result = CW_BLL.LoadCW_HNYCJBXX(ID);
            return Json(result);
        }
    }
}