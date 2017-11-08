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
    public class QZZPController : BaseController
    {
        public IQZZP_JZZPBLL QZZP_JZZPBLL { get; set; }
        public IQZZP_QZZPBLL QZZP_QZZPBLL { get; set; }

        public ActionResult QZZP_JZZP()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult QZZP_QZZP()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FBQZZP_JZZPJBXX()
        {
            YHJBXX yhjbxx = QZZP_JZZPBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            QZZP_JZZPJBXX QZZP_JZZPjbxx = JsonHelper.ConvertJsonToObject<QZZP_JZZPJBXX>(json);
            QZZP_JZZPjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            object result = QZZP_JZZPBLL.SaveQZZP_JZZPJBXX(jcxx, QZZP_JZZPjbxx);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBQZZP_QZZPJBXX()
        {
            YHJBXX yhjbxx = QZZP_QZZPBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            QZZP_QZZPJBXX QZZP_QZZPjbxx = JsonHelper.ConvertJsonToObject<QZZP_QZZPJBXX>(json);
            QZZP_QZZPjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = QZZP_QZZPBLL.SaveQZZP_QZZPJBXX(jcxx, QZZP_QZZPjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadQZZP_JZZPJBXX()
        {
            string ID = Request["ID"];
            object result = QZZP_JZZPBLL.LoadQZZP_JZZPJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadQZZP_QZZPJBXX()
        {
            string ID = Request["ID"];
            object result = QZZP_QZZPBLL.LoadQZZP_QZZPJBXX(ID);
            return Json(result);
        }
    }
}