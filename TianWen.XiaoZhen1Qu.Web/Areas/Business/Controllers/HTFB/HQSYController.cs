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
        public IHQSY_BLL HQSY_BLL { get; set; }

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

        [ValidateInput(false)]
        public JsonResult FBHQSY_CZZXJBXX()
        {
            YHJBXX YHJBXX = HQSY_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(YHJBXX, json);
            HQSY_CZZXJBXX HQSY_CZZXjbxx = JsonHelper.ConvertJsonToObject<HQSY_CZZXJBXX>(json);
            HQSY_CZZXjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = HQSY_BLL.SaveHQSY_CZZXJBXX(jcxx, HQSY_CZZXjbxx, photos);
            return Json(result);
        }

        [ValidateInput(false)]
        public JsonResult FBHQSY_HCZLJBXX()
        {
            YHJBXX YHJBXX = HQSY_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(YHJBXX, json);
            HQSY_HCZLJBXX HQSY_HCZLjbxx = JsonHelper.ConvertJsonToObject<HQSY_HCZLJBXX>(json);
            HQSY_HCZLjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = HQSY_BLL.SaveHQSY_HCZLJBXX(jcxx, HQSY_HCZLjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBHQSY_HLGPJBXX()
        {
            YHJBXX YHJBXX = HQSY_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(YHJBXX, json);
            HQSY_HLGPJBXX HQSY_HLGPjbxx = JsonHelper.ConvertJsonToObject<HQSY_HLGPJBXX>(json);
            HQSY_HLGPjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = HQSY_BLL.SaveHQSY_HLGPJBXX(jcxx, HQSY_HLGPjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBHQSY_HQGSJBXX()
        {
            YHJBXX YHJBXX = HQSY_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(YHJBXX, json);
            HQSY_HQGSJBXX HQSY_HQGSjbxx = JsonHelper.ConvertJsonToObject<HQSY_HQGSJBXX>(json);
            HQSY_HQGSjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = HQSY_BLL.SaveHQSY_HQGSJBXX(jcxx, HQSY_HQGSjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBHQSY_HQYPJBXX()
        {
            YHJBXX YHJBXX = HQSY_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(YHJBXX, json);
            HQSY_HQYPJBXX HQSY_HQYPjbxx = JsonHelper.ConvertJsonToObject<HQSY_HQYPJBXX>(json);
            HQSY_HQYPjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = HQSY_BLL.SaveHQSY_HQYPJBXX(jcxx, HQSY_HQYPjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBHQSY_HSLFJBXX()
        {
            YHJBXX YHJBXX = HQSY_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(YHJBXX, json);
            HQSY_HSLFJBXX HQSY_HSLFjbxx = JsonHelper.ConvertJsonToObject<HQSY_HSLFJBXX>(json);
            HQSY_HSLFjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = HQSY_BLL.SaveHQSY_HSLFJBXX(jcxx, HQSY_HSLFjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBHQSY_HSSYJBXX()
        {
            YHJBXX YHJBXX = HQSY_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(YHJBXX, json);
            HQSY_HSSYJBXX HQSY_HSSYjbxx = JsonHelper.ConvertJsonToObject<HQSY_HSSYJBXX>(json);
            HQSY_HSSYjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = HQSY_BLL.SaveHQSY_HSSYJBXX(jcxx, HQSY_HSSYjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBHQSY_HYJDJBXX()
        {
            YHJBXX YHJBXX = HQSY_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(YHJBXX, json);
            HQSY_HYJDJBXX HQSY_HYJDjbxx = JsonHelper.ConvertJsonToObject<HQSY_HYJDJBXX>(json);
            HQSY_HYJDjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = HQSY_BLL.SaveHQSY_HYJDJBXX(jcxx, HQSY_HYJDjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBHQSY_SYJBXX()
        {
            YHJBXX YHJBXX = HQSY_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(YHJBXX, json);
            HQSY_SYJBXX HQSY_SYjbxx = JsonHelper.ConvertJsonToObject<HQSY_SYJBXX>(json);
            HQSY_SYjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = HQSY_BLL.SaveHQSY_SYJBXX(jcxx, HQSY_SYjbxx, photos);
            return Json(result);
        }
       
        public JsonResult LoadHQSY_CZZXJBXX()
        {
            string ID = Request["ID"];
            object result = HQSY_BLL.LoadHQSY_CZZXJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadHQSY_HCZLJBXX()
        {
            string ID = Request["ID"];
            object result = HQSY_BLL.LoadHQSY_HCZLJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadHQSY_HLGPJBXX()
        {
            string ID = Request["ID"];
            object result = HQSY_BLL.LoadHQSY_HLGPJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadHQSY_HQGSJBXX()
        {
            string ID = Request["ID"];
            object result = HQSY_BLL.LoadHQSY_HQGSJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadHQSY_HQYPJBXX()
        {
            string ID = Request["ID"];
            object result = HQSY_BLL.LoadHQSY_HQYPJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadHQSY_HSLFJBXX()
        {
            string ID = Request["ID"];
            object result = HQSY_BLL.LoadHQSY_HSLFJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadHQSY_HSSYJBXX()
        {
            string ID = Request["ID"];
            object result = HQSY_BLL.LoadHQSY_HSSYJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadHQSY_HYJDJBXX()
        {
            string ID = Request["ID"];
            object result = HQSY_BLL.LoadHQSY_HYJDJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadHQSY_SYJBXX()
        {
            string ID = Request["ID"];
            object result = HQSY_BLL.LoadHQSY_SYJBXX(ID);
            return Json(result);
        }
    }
}