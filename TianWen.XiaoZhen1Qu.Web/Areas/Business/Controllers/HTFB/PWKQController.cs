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
    public class PWKQController : BaseController
    {
        public IPWKQ_DYPBLL PWKQ_DYPBLL { get; set; }
        public IPWKQ_QTKQBLL PWKQ_QTKQBLL { get; set; }
        public IPWKQ_XFKGWQBLL PWKQ_XFKGWQBLL { get; set; }
        public IPWKQ_YCMPBLL PWKQ_YCMPBLL { get; set; }
        public IPWKQ_YLYJDPBLL PWKQ_YLYJDPBLL { get; set; }

        public ActionResult PWKQ_DYP()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult PWKQ_QTKQ()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult PWKQ_XFKGWQ()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult PWKQ_YCMP()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult PWKQ_YLYJDP()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FBPWKQ_DYPJBXX()
        {
            YHJBXX yhjbxx = PWKQ_DYPBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            PWKQ_DYPJBXX PWKQ_DYPjbxx = JsonHelper.ConvertJsonToObject<PWKQ_DYPJBXX>(json);
            PWKQ_DYPjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            object result = PWKQ_DYPBLL.SavePWKQ_DYPJBXX(jcxx, PWKQ_DYPjbxx);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBPWKQ_QTKQJBXX()
        {
            YHJBXX yhjbxx = PWKQ_QTKQBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            PWKQ_QTKQJBXX PWKQ_QTKQjbxx = JsonHelper.ConvertJsonToObject<PWKQ_QTKQJBXX>(json);
            PWKQ_QTKQjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            object result = PWKQ_QTKQBLL.SavePWKQ_QTKQJBXX(jcxx, PWKQ_QTKQjbxx);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBPWKQ_XFKGWQJBXX()
        {
            YHJBXX yhjbxx = PWKQ_XFKGWQBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            PWKQ_XFKGWQJBXX PWKQ_XFKGWQjbxx = JsonHelper.ConvertJsonToObject<PWKQ_XFKGWQJBXX>(json);
            PWKQ_XFKGWQjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            object result = PWKQ_XFKGWQBLL.SavePWKQ_XFKGWQJBXX(jcxx, PWKQ_XFKGWQjbxx);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBPWKQ_YCMPJBXX()
        {
            YHJBXX yhjbxx = PWKQ_YCMPBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            PWKQ_YCMPJBXX PWKQ_YCMPjbxx = JsonHelper.ConvertJsonToObject<PWKQ_YCMPJBXX>(json);
            PWKQ_YCMPjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            object result = PWKQ_YCMPBLL.SavePWKQ_YCMPJBXX(jcxx, PWKQ_YCMPjbxx);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBPWKQ_YLYJDPJBXX()
        {
            YHJBXX yhjbxx = PWKQ_YLYJDPBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            PWKQ_YLYJDPJBXX PWKQ_YLYJDPjbxx = JsonHelper.ConvertJsonToObject<PWKQ_YLYJDPJBXX>(json);
            PWKQ_YLYJDPjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            object result = PWKQ_YLYJDPBLL.SavePWKQ_YLYJDPJBXX(jcxx, PWKQ_YLYJDPjbxx);
            return Json(result);
        }

        public JsonResult LoadPWKQ_DYPJBXX()
        {
            string ID = Request["ID"];
            object result = PWKQ_DYPBLL.LoadPWKQ_DYPJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadPWKQ_QTKQJBXX()
        {
            string ID = Request["ID"];
            object result = PWKQ_QTKQBLL.LoadPWKQ_QTKQJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadPWKQ_XFKGWQJBXX()
        {
            string ID = Request["ID"];
            object result = PWKQ_XFKGWQBLL.LoadPWKQ_XFKGWQJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadPWKQ_YCMPJBXX()
        {
            string ID = Request["ID"];
            object result = PWKQ_YCMPBLL.LoadPWKQ_YCMPJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadPWKQ_YLYJDPJBXX()
        {
            string ID = Request["ID"];
            object result = PWKQ_YLYJDPBLL.LoadPWKQ_YLYJDPJBXX(ID);
            return Json(result);
        }
    }
}