using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class SHFWController : BaseController
    {
        public ISHFW_BLL SHFW_BLL { get; set; }
        public ActionResult SHFW_BJ() { ViewData["XZQ"] = Session["XZQ"]; ViewData["YHM"] = Session["YHM"]; return View(); }
        public ActionResult SHFW_BJQX() { ViewData["XZQ"] = Session["XZQ"]; ViewData["YHM"] = Session["YHM"]; return View(); }
        public ActionResult SHFW_BMYS() { ViewData["XZQ"] = Session["XZQ"]; ViewData["YHM"] = Session["YHM"]; return View(); }
        public ActionResult SHFW_BZMD() { ViewData["XZQ"] = Session["XZQ"]; ViewData["YHM"] = Session["YHM"]; return View(); }
        public ActionResult SHFW_GDSTQL() { ViewData["XZQ"] = Session["XZQ"]; ViewData["YHM"] = Session["YHM"]; return View(); }
        public ActionResult SHFW_KSXSHS() { ViewData["XZQ"] = Session["XZQ"]; ViewData["YHM"] = Session["YHM"]; return View(); }
        public ActionResult SHFW_SHPS() { ViewData["XZQ"] = Session["XZQ"]; ViewData["YHM"] = Session["YHM"]; return View(); }
        public ActionResult SHFW_DNWX() { ViewData["XZQ"] = Session["XZQ"]; ViewData["YHM"] = Session["YHM"]; return View(); }
        public ActionResult SHFW_FWWX() { ViewData["XZQ"] = Session["XZQ"]; ViewData["YHM"] = Session["YHM"]; return View(); }
        public ActionResult SHFW_JDWX() { ViewData["XZQ"] = Session["XZQ"]; ViewData["YHM"] = Session["YHM"]; return View(); }
        public ActionResult SHFW_JJWX() { ViewData["XZQ"] = Session["XZQ"]; ViewData["YHM"] = Session["YHM"]; return View(); }
        public ActionResult SHFW_SJWX() { ViewData["XZQ"] = Session["XZQ"]; ViewData["YHM"] = Session["YHM"]; return View(); }
        public ActionResult SHFW_SMWX() { ViewData["XZQ"] = Session["XZQ"]; ViewData["YHM"] = Session["YHM"]; return View(); }

        [ValidateInput(false)]
        public JsonResult FBSHFW_BJJBXX()
        {
            YHJBXX yhjbxx = SHFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_BJJBXX SHFW_BJJBXX = JsonHelper.ConvertJsonToObject<SHFW_BJJBXX>(json);
            SHFW_BJJBXX.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_BLL.SaveSHFW_BJJBXX(jcxx, SHFW_BJJBXX, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSHFW_BJQXJBXX()
        {
            YHJBXX yhjbxx = SHFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_BJQXJBXX SHFW_BJQXJBXX = JsonHelper.ConvertJsonToObject<SHFW_BJQXJBXX>(json);
            SHFW_BJQXJBXX.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_BLL.SaveSHFW_BJQXJBXX(jcxx, SHFW_BJQXJBXX, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSHFW_BMYSJBXX()
        {
            YHJBXX yhjbxx = SHFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_BMYSJBXX SHFW_BMYSJBXX = JsonHelper.ConvertJsonToObject<SHFW_BMYSJBXX>(json);
            SHFW_BMYSJBXX.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_BLL.SaveSHFW_BMYSJBXX(jcxx, SHFW_BMYSJBXX, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSHFW_BZMDJBXX()
        {
            YHJBXX yhjbxx = SHFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_BZMDJBXX SHFW_BZMDJBXX = JsonHelper.ConvertJsonToObject<SHFW_BZMDJBXX>(json);
            SHFW_BZMDJBXX.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_BLL.SaveSHFW_BZMDJBXX(jcxx, SHFW_BZMDJBXX, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSHFW_GDSTQLJBXX()
        {
            YHJBXX yhjbxx = SHFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_GDSTQLJBXX SHFW_GDSTQLJBXX = JsonHelper.ConvertJsonToObject<SHFW_GDSTQLJBXX>(json);
            SHFW_GDSTQLJBXX.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_BLL.SaveSHFW_GDSTQLJBXX(jcxx, SHFW_GDSTQLJBXX, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSHFW_KSXSHSJBXX()
        {
            YHJBXX yhjbxx = SHFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_KSXSHSJBXX SHFW_KSXSHSJBXX = JsonHelper.ConvertJsonToObject<SHFW_KSXSHSJBXX>(json);
            SHFW_KSXSHSJBXX.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_BLL.SaveSHFW_KSXSHSJBXX(jcxx, SHFW_KSXSHSJBXX, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSHFW_SHPSJBXX()
        {
            YHJBXX yhjbxx = SHFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_SHPSJBXX SHFW_SHPSJBXX = JsonHelper.ConvertJsonToObject<SHFW_SHPSJBXX>(json);
            SHFW_SHPSJBXX.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_BLL.SaveSHFW_SHPSJBXX(jcxx, SHFW_SHPSJBXX, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSHFW_DNWXJBXX()
        {
            YHJBXX yhjbxx = SHFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_DNWXJBXX SHFW_DNWXJBXX = JsonHelper.ConvertJsonToObject<SHFW_DNWXJBXX>(json);
            SHFW_DNWXJBXX.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_BLL.SaveSHFW_DNWXJBXX(jcxx, SHFW_DNWXJBXX, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSHFW_FWWXJBXX()
        {
            YHJBXX yhjbxx = SHFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_FWWXJBXX SHFW_FWWXJBXX = JsonHelper.ConvertJsonToObject<SHFW_FWWXJBXX>(json);
            SHFW_FWWXJBXX.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_BLL.SaveSHFW_FWWXJBXX(jcxx, SHFW_FWWXJBXX, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSHFW_JDWXJBXX()
        {
            YHJBXX yhjbxx = SHFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_JDWXJBXX SHFW_JDWXJBXX = JsonHelper.ConvertJsonToObject<SHFW_JDWXJBXX>(json);
            SHFW_JDWXJBXX.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_BLL.SaveSHFW_JDWXJBXX(jcxx, SHFW_JDWXJBXX, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSHFW_JJWXJBXX()
        {
            YHJBXX yhjbxx = SHFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_JJWXJBXX SHFW_JJWXJBXX = JsonHelper.ConvertJsonToObject<SHFW_JJWXJBXX>(json);
            SHFW_JJWXJBXX.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_BLL.SaveSHFW_JJWXJBXX(jcxx, SHFW_JJWXJBXX, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSHFW_SJWXJBXX()
        {
            YHJBXX yhjbxx = SHFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_SJWXJBXX SHFW_SJWXJBXX = JsonHelper.ConvertJsonToObject<SHFW_SJWXJBXX>(json);
            SHFW_SJWXJBXX.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_BLL.SaveSHFW_SJWXJBXX(jcxx, SHFW_SJWXJBXX, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBSHFW_SMWXJBXX()
        {
            YHJBXX yhjbxx = SHFW_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            SHFW_SMWXJBXX SHFW_SMWXJBXX = JsonHelper.ConvertJsonToObject<SHFW_SMWXJBXX>(json);
            SHFW_SMWXJBXX.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = SHFW_BLL.SaveSHFW_SMWXJBXX(jcxx, SHFW_SMWXJBXX, photos);
            return Json(result);
        }

        public JsonResult LoadSHFW_BJJBXX() { string ID = Request["ID"]; object result = SHFW_BLL.LoadSHFW_BJJBXX(ID); return Json(result); }
        public JsonResult LoadSHFW_BZMDJBXX() { string ID = Request["ID"]; object result = SHFW_BLL.LoadSHFW_BZMDJBXX(ID); return Json(result); }
        public JsonResult LoadSHFW_BMYSJBXX() { string ID = Request["ID"]; object result = SHFW_BLL.LoadSHFW_BMYSJBXX(ID); return Json(result); }
        public JsonResult LoadSHFW_BJQXJBXX() { string ID = Request["ID"]; object result = SHFW_BLL.LoadSHFW_BJQXJBXX(ID); return Json(result); }
        public JsonResult LoadSHFW_GDSTQLJBXX() { string ID = Request["ID"]; object result = SHFW_BLL.LoadSHFW_GDSTQLJBXX(ID); return Json(result); }
        public JsonResult LoadSHFW_KSXSHSJBXX() { string ID = Request["ID"]; object result = SHFW_BLL.LoadSHFW_KSXSHSJBXX(ID); return Json(result); }
        public JsonResult LoadSHFW_SHPSJBXX() { string ID = Request["ID"]; object result = SHFW_BLL.LoadSHFW_SHPSJBXX(ID); return Json(result); }
        public JsonResult LoadSHFW_DNWXJBXX() { string ID = Request["ID"]; object result = SHFW_BLL.LoadSHFW_DNWXJBXX(ID); return Json(result); }
        public JsonResult LoadSHFW_FWWXJBXX() { string ID = Request["ID"]; object result = SHFW_BLL.LoadSHFW_FWWXJBXX(ID); return Json(result); }
        public JsonResult LoadSHFW_JDWXJBXX() { string ID = Request["ID"]; object result = SHFW_BLL.LoadSHFW_JDWXJBXX(ID); return Json(result); }
        public JsonResult LoadSHFW_JJWXJBXX() { string ID = Request["ID"]; object result = SHFW_BLL.LoadSHFW_JJWXJBXX(ID); return Json(result); }
        public JsonResult LoadSHFW_SJWXJBXX() { string ID = Request["ID"]; object result = SHFW_BLL.LoadSHFW_SJWXJBXX(ID); return Json(result); }
        public JsonResult LoadSHFW_SMWXJBXX() { string ID = Request["ID"]; object result = SHFW_BLL.LoadSHFW_SMWXJBXX(ID); return Json(result); }
    }
}