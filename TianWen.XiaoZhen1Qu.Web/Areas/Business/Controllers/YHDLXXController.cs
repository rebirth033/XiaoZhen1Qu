using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Mvc;
using System.Xml;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Web.Areas.Business.Common;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class YHDLXXController : BaseController
    {
        public IYHJBXXBLL YHJBXXBLL { get; set; }

        public ActionResult YHDLXX()
        {
            return View();
        }
    }
}