using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class LYJDController : BaseController
    {
        public ILYJD_BLL LYJD_BLL { get; set; }

        public ActionResult LYJD_DYDDR()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult LYJD_GNY()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult LYJD_JDZSYD()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult LYJD_JP()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult LYJD_LXS()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult LYJD_QZFW()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult LYJD_ZBY()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FBLYJD_DYDDRJBXX()
        {
            YHJBXX yhjbxx = LYJD_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            LYJD_DYDDRJBXX LYJD_DYDDRjbxx = JsonHelper.ConvertJsonToObject<LYJD_DYDDRJBXX>(json);
            LYJD_DYDDRjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = LYJD_BLL.SaveLYJD_DYDDRJBXX(jcxx, LYJD_DYDDRjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBLYJD_GNYJBXX()
        {
            YHJBXX yhjbxx = LYJD_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string xlts = Request["XLTS"];
            string xcap = Request["XCAP"];
            string ydxz = Request["YDXZ"];
            string fybh = Request["FYBH"];
            string zfxm = Request["ZFXM"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            LYJD_GNYJBXX LYJD_GNYjbxx = JsonHelper.ConvertJsonToObject<LYJD_GNYJBXX>(json);
            LYJD_GNYjbxx.XCAP = BinaryHelper.StringToBinary(xcap);
            LYJD_GNYjbxx.FYBH = BinaryHelper.StringToBinary(fybh);
            LYJD_GNYjbxx.ZFXM = BinaryHelper.StringToBinary(zfxm);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = LYJD_BLL.SaveLYJD_GNYJBXX(jcxx, LYJD_GNYjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBLYJD_JDZSYDJBXX()
        {
            YHJBXX yhjbxx = LYJD_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            LYJD_JDZSYDJBXX LYJD_JDZSYDjbxx = JsonHelper.ConvertJsonToObject<LYJD_JDZSYDJBXX>(json);
            LYJD_JDZSYDjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = LYJD_BLL.SaveLYJD_JDZSYDJBXX(jcxx, LYJD_JDZSYDjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBLYJD_JPJBXX()
        {
            YHJBXX yhjbxx = LYJD_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            LYJD_JPJBXX LYJD_JPjbxx = JsonHelper.ConvertJsonToObject<LYJD_JPJBXX>(json);
            LYJD_JPjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = LYJD_BLL.SaveLYJD_JPJBXX(jcxx, LYJD_JPjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBLYJD_LXSJBXX()
        {
            YHJBXX yhjbxx = LYJD_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            LYJD_LXSJBXX LYJD_LXSjbxx = JsonHelper.ConvertJsonToObject<LYJD_LXSJBXX>(json);
            LYJD_LXSjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = LYJD_BLL.SaveLYJD_LXSJBXX(jcxx, LYJD_LXSjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBLYJD_QZFWJBXX()
        {
            YHJBXX yhjbxx = LYJD_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            LYJD_QZFWJBXX LYJD_QZFWjbxx = JsonHelper.ConvertJsonToObject<LYJD_QZFWJBXX>(json);
            LYJD_QZFWjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = LYJD_BLL.SaveLYJD_QZFWJBXX(jcxx, LYJD_QZFWjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBLYJD_ZBYJBXX()
        {
            YHJBXX yhjbxx = LYJD_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            LYJD_ZBYJBXX LYJD_ZBYjbxx = JsonHelper.ConvertJsonToObject<LYJD_ZBYJBXX>(json);
            LYJD_ZBYjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = LYJD_BLL.SaveLYJD_ZBYJBXX(jcxx, LYJD_ZBYjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadLYJD_DYDDRJBXX()
        {
            string ID = Request["ID"];
            object result = LYJD_BLL.LoadLYJD_DYDDRJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadLYJD_GNYJBXX()
        {
            string ID = Request["ID"];
            object result = LYJD_BLL.LoadLYJD_GNYJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadLYJD_JDZSYDJBXX()
        {
            string ID = Request["ID"];
            object result = LYJD_BLL.LoadLYJD_JDZSYDJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadLYJD_JPJBXX()
        {
            string ID = Request["ID"];
            object result = LYJD_BLL.LoadLYJD_JPJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadLYJD_LXSJBXX()
        {
            string ID = Request["ID"];
            object result = LYJD_BLL.LoadLYJD_LXSJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadLYJD_QZFWJBXX()
        {
            string ID = Request["ID"];
            object result = LYJD_BLL.LoadLYJD_QZFWJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadLYJD_ZBYJBXX()
        {
            string ID = Request["ID"];
            object result = LYJD_BLL.LoadLYJD_ZBYJBXX(ID);
            return Json(result);
        }
    }
}