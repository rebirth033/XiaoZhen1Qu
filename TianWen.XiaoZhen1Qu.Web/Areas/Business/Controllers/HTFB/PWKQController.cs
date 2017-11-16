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
        public IPWKQ_BLL PWKQ_BLL { get; set; }

        public ActionResult ES_PWKQ_DYP()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult ES_PWKQ_QTKQ()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult ES_PWKQ_XFKGWQ()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult ES_PWKQ_YCMP()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult ES_PWKQ_YLYJDP()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FBES_PWKQ_DYPJBXX()
        {
            YHJBXX yhjbxx = PWKQ_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ES_PWKQ_DYPJBXX ES_PWKQ_DYPjbxx = JsonHelper.ConvertJsonToObject<ES_PWKQ_DYPJBXX>(json);
            ES_PWKQ_DYPjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            object result = PWKQ_BLL.SaveES_PWKQ_DYPJBXX(jcxx, ES_PWKQ_DYPjbxx);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBES_PWKQ_QTKQJBXX()
        {
            YHJBXX yhjbxx = PWKQ_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ES_PWKQ_QTKQJBXX ES_PWKQ_QTKQjbxx = JsonHelper.ConvertJsonToObject<ES_PWKQ_QTKQJBXX>(json);
            ES_PWKQ_QTKQjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            object result = PWKQ_BLL.SaveES_PWKQ_QTKQJBXX(jcxx, ES_PWKQ_QTKQjbxx);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBES_PWKQ_XFKGWQJBXX()
        {
            YHJBXX yhjbxx = PWKQ_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ES_PWKQ_XFKGWQJBXX ES_PWKQ_XFKGWQjbxx = JsonHelper.ConvertJsonToObject<ES_PWKQ_XFKGWQJBXX>(json);
            ES_PWKQ_XFKGWQjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            object result = PWKQ_BLL.SaveES_PWKQ_XFKGWQJBXX(jcxx, ES_PWKQ_XFKGWQjbxx);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBES_PWKQ_YCMPJBXX()
        {
            YHJBXX yhjbxx = PWKQ_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ES_PWKQ_YCMPJBXX ES_PWKQ_YCMPjbxx = JsonHelper.ConvertJsonToObject<ES_PWKQ_YCMPJBXX>(json);
            ES_PWKQ_YCMPjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            object result = PWKQ_BLL.SaveES_PWKQ_YCMPJBXX(jcxx, ES_PWKQ_YCMPjbxx);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBES_PWKQ_YLYJDPJBXX()
        {
            YHJBXX yhjbxx = PWKQ_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            ES_PWKQ_YLYJDPJBXX ES_PWKQ_YLYJDPjbxx = JsonHelper.ConvertJsonToObject<ES_PWKQ_YLYJDPJBXX>(json);
            ES_PWKQ_YLYJDPjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            object result = PWKQ_BLL.SaveES_PWKQ_YLYJDPJBXX(jcxx, ES_PWKQ_YLYJDPjbxx);
            return Json(result);
        }

        public JsonResult LoadES_PWKQ_DYPJBXX()
        {
            string ID = Request["ID"];
            object result = PWKQ_BLL.LoadES_PWKQ_DYPJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadES_PWKQ_QTKQJBXX()
        {
            string ID = Request["ID"];
            object result = PWKQ_BLL.LoadES_PWKQ_QTKQJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadES_PWKQ_XFKGWQJBXX()
        {
            string ID = Request["ID"];
            object result = PWKQ_BLL.LoadES_PWKQ_XFKGWQJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadES_PWKQ_YCMPJBXX()
        {
            string ID = Request["ID"];
            object result = PWKQ_BLL.LoadES_PWKQ_YCMPJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadES_PWKQ_YLYJDPJBXX()
        {
            string ID = Request["ID"];
            object result = PWKQ_BLL.LoadES_PWKQ_YLYJDPJBXX(ID);
            return Json(result);
        }
    }
}