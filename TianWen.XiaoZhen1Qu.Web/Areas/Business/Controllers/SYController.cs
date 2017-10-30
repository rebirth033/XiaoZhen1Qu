using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class SYController : BaseController
    {
        public ISYBLL SYBLL { get; set; }
        public ActionResult SY()
        {
            //ViewData["XZQ"] = Session["XZQ"];
            ViewData["XZQ"] = "福州";
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
    }
}