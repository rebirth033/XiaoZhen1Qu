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
    public class HQSYController : BaseController
    {
        public IHQSY_CZZXBLL HQSY_CZZXBLL { get; set; }
        public IHQSY_HCZLBLL HQSY_HCZLBLL { get; set; }
        public IHQSY_HLGPBLL HQSY_HLGPBLL { get; set; }
        public IHQSY_HQGSBLL HQSY_HQGSBLL { get; set; }
        public IHQSY_HQYPBLL HQSY_HQYPBLL { get; set; }
        public IHQSY_HSLFBLL HQSY_HSLFBLL { get; set; }
        public IHQSY_HSSYBLL HQSY_HSSYBLL { get; set; }
        public IHQSY_HYJDBLL HQSY_HYJDBLL { get; set; }
        public IHQSY_SYBLL HQSY_SYBLL { get; set; }
        public IHQSY_ZBSSBLL HQSY_ZBSSBLL { get; set; }

        public ActionResult HQSY_CZZX()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult HQSY_HCZL()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult HQSY_HLGP()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult HQSY_HQGS()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult HQSY_HQYP()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult HQSY_HSLF()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult HQSY_HSSY()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult HQSY_HYJD()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult HQSY_SY()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult HQSY_ZBSS()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FBHQSY_CZZXJBXX()
        {
            YHJBXX yhjbxx = HQSY_CZZXBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            HQSY_CZZXJBXX HQSY_CZZXjbxx = JsonHelper.ConvertJsonToObject<HQSY_CZZXJBXX>(json);
            HQSY_CZZXjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = HQSY_CZZXBLL.SaveHQSY_CZZXJBXX(jcxx, HQSY_CZZXjbxx, photos);
            return Json(result);
        }

        [ValidateInput(false)]
        public JsonResult FBHQSY_HCZLJBXX()
        {
            YHJBXX yhjbxx = HQSY_HCZLBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            HQSY_HCZLJBXX HQSY_HCZLjbxx = JsonHelper.ConvertJsonToObject<HQSY_HCZLJBXX>(json);
            HQSY_HCZLjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = HQSY_HCZLBLL.SaveHQSY_HCZLJBXX(jcxx, HQSY_HCZLjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBHQSY_HLGPJBXX()
        {
            YHJBXX yhjbxx = HQSY_HLGPBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            HQSY_HLGPJBXX HQSY_HLGPjbxx = JsonHelper.ConvertJsonToObject<HQSY_HLGPJBXX>(json);
            HQSY_HLGPjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = HQSY_HLGPBLL.SaveHQSY_HLGPJBXX(jcxx, HQSY_HLGPjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBHQSY_HQGSJBXX()
        {
            YHJBXX yhjbxx = HQSY_HQGSBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            HQSY_HQGSJBXX HQSY_HQGSjbxx = JsonHelper.ConvertJsonToObject<HQSY_HQGSJBXX>(json);
            HQSY_HQGSjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = HQSY_HQGSBLL.SaveHQSY_HQGSJBXX(jcxx, HQSY_HQGSjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBHQSY_HQYPJBXX()
        {
            YHJBXX yhjbxx = HQSY_HQYPBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            HQSY_HQYPJBXX HQSY_HQYPjbxx = JsonHelper.ConvertJsonToObject<HQSY_HQYPJBXX>(json);
            HQSY_HQYPjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = HQSY_HQYPBLL.SaveHQSY_HQYPJBXX(jcxx, HQSY_HQYPjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBHQSY_HSLFJBXX()
        {
            YHJBXX yhjbxx = HQSY_HSLFBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            HQSY_HSLFJBXX HQSY_HSLFjbxx = JsonHelper.ConvertJsonToObject<HQSY_HSLFJBXX>(json);
            HQSY_HSLFjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = HQSY_HSLFBLL.SaveHQSY_HSLFJBXX(jcxx, HQSY_HSLFjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBHQSY_HSSYJBXX()
        {
            YHJBXX yhjbxx = HQSY_HSSYBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            HQSY_HSSYJBXX HQSY_HSSYjbxx = JsonHelper.ConvertJsonToObject<HQSY_HSSYJBXX>(json);
            HQSY_HSSYjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = HQSY_HSSYBLL.SaveHQSY_HSSYJBXX(jcxx, HQSY_HSSYjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBHQSY_HYJDJBXX()
        {
            YHJBXX yhjbxx = HQSY_HYJDBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            HQSY_HYJDJBXX HQSY_HYJDjbxx = JsonHelper.ConvertJsonToObject<HQSY_HYJDJBXX>(json);
            HQSY_HYJDjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = HQSY_HYJDBLL.SaveHQSY_HYJDJBXX(jcxx, HQSY_HYJDjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBHQSY_SYJBXX()
        {
            YHJBXX yhjbxx = HQSY_SYBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            HQSY_SYJBXX HQSY_SYjbxx = JsonHelper.ConvertJsonToObject<HQSY_SYJBXX>(json);
            HQSY_SYjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = HQSY_SYBLL.SaveHQSY_SYJBXX(jcxx, HQSY_SYjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBHQSY_ZBSSJBXX()
        {
            YHJBXX yhjbxx = HQSY_ZBSSBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            HQSY_ZBSSJBXX HQSY_ZBSSjbxx = JsonHelper.ConvertJsonToObject<HQSY_ZBSSJBXX>(json);
            HQSY_ZBSSjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = HQSY_ZBSSBLL.SaveHQSY_ZBSSJBXX(jcxx, HQSY_ZBSSjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadHQSY_CZZXJBXX()
        {
            string HQSY_CZZXJBXXID = Request["HQSY_CZZXJBXXID"];
            object result = HQSY_CZZXBLL.LoadHQSY_CZZXJBXX(HQSY_CZZXJBXXID);
            return Json(result);
        }
        public JsonResult LoadHQSY_HCZLJBXX()
        {
            string HQSY_HCZLJBXXID = Request["HQSY_HCZLJBXXID"];
            object result = HQSY_HCZLBLL.LoadHQSY_HCZLJBXX(HQSY_HCZLJBXXID);
            return Json(result);
        }
        public JsonResult LoadHQSY_HLGPJBXX()
        {
            string HQSY_HLGPJBXXID = Request["HQSY_HLGPJBXXID"];
            object result = HQSY_HLGPBLL.LoadHQSY_HLGPJBXX(HQSY_HLGPJBXXID);
            return Json(result);
        }
        public JsonResult LoadHQSY_HQGSJBXX()
        {
            string HQSY_HQGSJBXXID = Request["HQSY_HQGSJBXXID"];
            object result = HQSY_HQGSBLL.LoadHQSY_HQGSJBXX(HQSY_HQGSJBXXID);
            return Json(result);
        }
        public JsonResult LoadHQSY_HQYPJBXX()
        {
            string HQSY_HQYPJBXXID = Request["HQSY_HQYPJBXXID"];
            object result = HQSY_HQYPBLL.LoadHQSY_HQYPJBXX(HQSY_HQYPJBXXID);
            return Json(result);
        }
        public JsonResult LoadHQSY_HSLFJBXX()
        {
            string HQSY_HSLFJBXXID = Request["HQSY_HSLFJBXXID"];
            object result = HQSY_HSLFBLL.LoadHQSY_HSLFJBXX(HQSY_HSLFJBXXID);
            return Json(result);
        }
        public JsonResult LoadHQSY_HSSYJBXX()
        {
            string HQSY_HSSYJBXXID = Request["HQSY_HSSYJBXXID"];
            object result = HQSY_HSSYBLL.LoadHQSY_HSSYJBXX(HQSY_HSSYJBXXID);
            return Json(result);
        }
        public JsonResult LoadHQSY_HYJDJBXX()
        {
            string HQSY_HYJDJBXXID = Request["HQSY_HYJDJBXXID"];
            object result = HQSY_HYJDBLL.LoadHQSY_HYJDJBXX(HQSY_HYJDJBXXID);
            return Json(result);
        }
        public JsonResult LoadHQSY_SYJBXX()
        {
            string HQSY_SYJBXXID = Request["HQSY_SYJBXXID"];
            object result = HQSY_SYBLL.LoadHQSY_SYJBXX(HQSY_SYJBXXID);
            return Json(result);
        }
        public JsonResult LoadHQSY_ZBSSJBXX()
        {
            string HQSY_ZBSSJBXXID = Request["HQSY_ZBSSJBXXID"];
            object result = HQSY_ZBSSBLL.LoadHQSY_ZBSSJBXX(HQSY_ZBSSJBXXID);
            return Json(result);
        }
    }
}