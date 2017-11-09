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
    public class ZXJCController : BaseController
    {
        public IZXJC_FWGZBLL ZXJC_FWGZBLL { get; set; }
        public IZXJC_GZFWBLL ZXJC_GZFWBLL { get; set; }
        public IZXJC_JCBLL ZXJC_JCBLL { get; set; }
        public IZXJC_JFJSBLL ZXJC_JFJSBLL { get; set; }
        public IZXJC_JJBLL ZXJC_JJBLL { get; set; }
        public IZXJC_JZFWBLL ZXJC_JZFWBLL { get; set; }

        public ActionResult ZXJC_FWGZ()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult ZXJC_GZFW()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult ZXJC_JC()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult ZXJC_JFJS()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult ZXJC_JJ()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult ZXJC_JZFW()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FBZXJC_FWGZJBXX()
        {
            YHJBXX yhjbxx = ZXJC_FWGZBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ZXJC_FWGZJBXX ZXJC_FWGZjbxx = JsonHelper.ConvertJsonToObject<ZXJC_FWGZJBXX>(json);
            ZXJC_FWGZjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ZXJC_FWGZBLL.SaveZXJC_FWGZJBXX(jcxx, ZXJC_FWGZjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBZXJC_GZFWJBXX()
        {
            YHJBXX yhjbxx = ZXJC_GZFWBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ZXJC_GZFWJBXX ZXJC_GZFWjbxx = JsonHelper.ConvertJsonToObject<ZXJC_GZFWJBXX>(json);
            ZXJC_GZFWjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ZXJC_GZFWBLL.SaveZXJC_GZFWJBXX(jcxx, ZXJC_GZFWjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBZXJC_JCJBXX()
        {
            YHJBXX yhjbxx = ZXJC_JCBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ZXJC_JCJBXX ZXJC_JCjbxx = JsonHelper.ConvertJsonToObject<ZXJC_JCJBXX>(json);
            ZXJC_JCjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ZXJC_JCBLL.SaveZXJC_JCJBXX(jcxx, ZXJC_JCjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBZXJC_JFJSJBXX()
        {
            YHJBXX yhjbxx = ZXJC_JFJSBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ZXJC_JFJSJBXX ZXJC_JFJSjbxx = JsonHelper.ConvertJsonToObject<ZXJC_JFJSJBXX>(json);
            ZXJC_JFJSjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ZXJC_JFJSBLL.SaveZXJC_JFJSJBXX(jcxx, ZXJC_JFJSjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBZXJC_JJJBXX()
        {
            YHJBXX yhjbxx = ZXJC_JJBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ZXJC_JJJBXX ZXJC_JJjbxx = JsonHelper.ConvertJsonToObject<ZXJC_JJJBXX>(json);
            ZXJC_JJjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ZXJC_JJBLL.SaveZXJC_JJJBXX(jcxx, ZXJC_JJjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBZXJC_JZFWJBXX()
        {
            YHJBXX yhjbxx = ZXJC_JZFWBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ZXJC_JZFWJBXX ZXJC_JZFWjbxx = JsonHelper.ConvertJsonToObject<ZXJC_JZFWJBXX>(json);
            ZXJC_JZFWjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = ZXJC_JZFWBLL.SaveZXJC_JZFWJBXX(jcxx, ZXJC_JZFWjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadZXJC_FWGZJBXX()
        {
            string ID = Request["ID"];
            object result = ZXJC_FWGZBLL.LoadZXJC_FWGZJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadZXJC_GZFWJBXX()
        {
            string ID = Request["ID"];
            object result = ZXJC_GZFWBLL.LoadZXJC_GZFWJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadZXJC_JCJBXX()
        {
            string ID = Request["ID"];
            object result = ZXJC_JCBLL.LoadZXJC_JCJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadZXJC_JFJSJBXX()
        {
            string ID = Request["ID"];
            object result = ZXJC_JFJSBLL.LoadZXJC_JFJSJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadZXJC_JJJBXX()
        {
            string ID = Request["ID"];
            object result = ZXJC_JJBLL.LoadZXJC_JJJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadZXJC_JZFWJBXX()
        {
            string ID = Request["ID"];
            object result = ZXJC_JZFWBLL.LoadZXJC_JZFWJBXX(ID);
            return Json(result);
        }
    }
}