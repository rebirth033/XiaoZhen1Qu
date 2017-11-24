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
    public class XXYLController : BaseController
    {
        public IXXYL_BLL XXYL_BLL { get; set; }
        public ActionResult XXYL_DIYSGF() { ViewData["XZQ"] = Session["XZQ"]; ViewData["YHM"] = Session["YHM"]; return View(); }
        public ActionResult XXYL_HW() { ViewData["XZQ"] = Session["XZQ"]; ViewData["YHM"] = Session["YHM"]; return View(); }
        public ActionResult XXYL_HPG() { ViewData["XZQ"] = Session["XZQ"]; ViewData["YHM"] = Session["YHM"]; return View(); }
        public ActionResult XXYL_TQT() { ViewData["XZQ"] = Session["XZQ"]; ViewData["YHM"] = Session["YHM"]; return View(); }
        public ActionResult XXYL_QPZY() { ViewData["XZQ"] = Session["XZQ"]; ViewData["YHM"] = Session["YHM"]; return View(); }
        public ActionResult XXYL_XYWQ() { ViewData["XZQ"] = Session["XZQ"]; ViewData["YHM"] = Session["YHM"]; return View(); }
        public ActionResult XXYL_YDJB() { ViewData["XZQ"] = Session["XZQ"]; ViewData["YHM"] = Session["YHM"]; return View(); }
        public ActionResult XXYL_KTV() { ViewData["XZQ"] = Session["XZQ"]; ViewData["YHM"] = Session["YHM"]; return View(); }
        public ActionResult XXYL_YDJS() { ViewData["XZQ"] = Session["XZQ"]; ViewData["YHM"] = Session["YHM"]; return View(); }
        public ActionResult XXYL_ZLAM() { ViewData["XZQ"] = Session["XZQ"]; ViewData["YHM"] = Session["YHM"]; return View(); }

        [ValidateInput(false)]
        public JsonResult FBXXYL_DIYSGFJBXX()
        {
            YHJBXX yhjbxx = XXYL_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            XXYL_DIYSGFJBXX XXYL_DIYSGFjbxx = JsonHelper.ConvertJsonToObject<XXYL_DIYSGFJBXX>(json);
            XXYL_DIYSGFjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = XXYL_BLL.SaveXXYL_DIYSGFJBXX(jcxx, XXYL_DIYSGFjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBXXYL_HWJBXX()
        {
            YHJBXX yhjbxx = XXYL_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            XXYL_HWJBXX XXYL_HWjbxx = JsonHelper.ConvertJsonToObject<XXYL_HWJBXX>(json);
            XXYL_HWjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = XXYL_BLL.SaveXXYL_HWJBXX(jcxx, XXYL_HWjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBXXYL_HPGJBXX()
        {
            YHJBXX yhjbxx = XXYL_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            XXYL_HPGJBXX XXYL_HPGjbxx = JsonHelper.ConvertJsonToObject<XXYL_HPGJBXX>(json);
            XXYL_HPGjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = XXYL_BLL.SaveXXYL_HPGJBXX(jcxx, XXYL_HPGjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBXXYL_TQTJBXX()
        {
            YHJBXX yhjbxx = XXYL_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            XXYL_TQTJBXX XXYL_TQTjbxx = JsonHelper.ConvertJsonToObject<XXYL_TQTJBXX>(json);
            XXYL_TQTjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = XXYL_BLL.SaveXXYL_TQTJBXX(jcxx, XXYL_TQTjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBXXYL_QPZYJBXX()
        {
            YHJBXX yhjbxx = XXYL_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            XXYL_QPZYJBXX XXYL_QPZYjbxx = JsonHelper.ConvertJsonToObject<XXYL_QPZYJBXX>(json);
            XXYL_QPZYjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = XXYL_BLL.SaveXXYL_QPZYJBXX(jcxx, XXYL_QPZYjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBXXYL_XYWQJBXX()
        {
            YHJBXX yhjbxx = XXYL_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            XXYL_XYWQJBXX XXYL_XYWQjbxx = JsonHelper.ConvertJsonToObject<XXYL_XYWQJBXX>(json);
            XXYL_XYWQjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = XXYL_BLL.SaveXXYL_XYWQJBXX(jcxx, XXYL_XYWQjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBXXYL_YDJBJBXX()
        {
            YHJBXX yhjbxx = XXYL_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            XXYL_YDJBJBXX XXYL_YDJBjbxx = JsonHelper.ConvertJsonToObject<XXYL_YDJBJBXX>(json);
            XXYL_YDJBjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = XXYL_BLL.SaveXXYL_YDJBJBXX(jcxx, XXYL_YDJBjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBXXYL_KTVJBXX()
        {
            YHJBXX yhjbxx = XXYL_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            XXYL_KTVJBXX XXYL_KTVjbxx = JsonHelper.ConvertJsonToObject<XXYL_KTVJBXX>(json);
            XXYL_KTVjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = XXYL_BLL.SaveXXYL_KTVJBXX(jcxx, XXYL_KTVjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBXXYL_YDJSJBXX()
        {
            YHJBXX yhjbxx = XXYL_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            XXYL_YDJSJBXX XXYL_YDJSjbxx = JsonHelper.ConvertJsonToObject<XXYL_YDJSJBXX>(json);
            XXYL_YDJSjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = XXYL_BLL.SaveXXYL_YDJSJBXX(jcxx, XXYL_YDJSjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBXXYL_ZLAMJBXX()
        {
            YHJBXX yhjbxx = XXYL_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            XXYL_ZLAMJBXX XXYL_ZLAMjbxx = JsonHelper.ConvertJsonToObject<XXYL_ZLAMJBXX>(json);
            XXYL_ZLAMjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = XXYL_BLL.SaveXXYL_ZLAMJBXX(jcxx, XXYL_ZLAMjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadXXYL_DIYSGFJBXX() { string ID = Request["ID"]; object result = XXYL_BLL.LoadXXYL_DIYSGFJBXX(ID); return Json(result); }
        public JsonResult LoadXXYL_HWJBXX() { string ID = Request["ID"]; object result = XXYL_BLL.LoadXXYL_HWJBXX(ID); return Json(result); }
        public JsonResult LoadXXYL_HPGJBXX() { string ID = Request["ID"]; object result = XXYL_BLL.LoadXXYL_HPGJBXX(ID); return Json(result); }
        public JsonResult LoadXXYL_TQTJBXX() { string ID = Request["ID"]; object result = XXYL_BLL.LoadXXYL_TQTJBXX(ID); return Json(result); }
        public JsonResult LoadXXYL_QPZYJBXX() { string ID = Request["ID"]; object result = XXYL_BLL.LoadXXYL_QPZYJBXX(ID); return Json(result); }
        public JsonResult LoadXXYL_XYWQJBXX() { string ID = Request["ID"]; object result = XXYL_BLL.LoadXXYL_XYWQJBXX(ID); return Json(result); }
        public JsonResult LoadXXYL_YDJBJBXX() { string ID = Request["ID"]; object result = XXYL_BLL.LoadXXYL_YDJBJBXX(ID); return Json(result); }
        public JsonResult LoadXXYL_KTVJBXX() { string ID = Request["ID"]; object result = XXYL_BLL.LoadXXYL_KTVJBXX(ID); return Json(result); }
        public JsonResult LoadXXYL_YDJSJBXX() { string ID = Request["ID"]; object result = XXYL_BLL.LoadXXYL_YDJSJBXX(ID); return Json(result); }
        public JsonResult LoadXXYL_ZLAMJBXX() { string ID = Request["ID"]; object result = XXYL_BLL.LoadXXYL_ZLAMJBXX(ID); return Json(result); }
    }
}