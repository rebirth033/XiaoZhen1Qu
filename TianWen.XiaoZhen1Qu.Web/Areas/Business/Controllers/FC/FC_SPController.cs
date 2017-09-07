using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class FC_SPController : BaseController
    {
        public IFC_SPBLL FC_SPBLL { get; set; }

        public ActionResult FC_SP()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        public JsonResult LoadQY()
        {
            return Json(FC_SPBLL.LoadQYBySuperName(Session["XZQ"].ToString()));
        }
    }
}