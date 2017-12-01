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
    public class PFCGController : BaseController
    {
        public IPFCG_BLL PFCG_BLL { get; set; }

        public ActionResult PFCG_AFSB()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult PFCG_BZ()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult PFCG_DGDL()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult PFCG_DJZM()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult PFCG_YCL()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult PFCG_DZYQJ()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult PFCG_FSXM()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult PFCG_FZBL()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult PFCG_HWYD()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult PFCG_HXP()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult PFCG_HZP()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult PFCG_JXJG()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult PFCG_KQ()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult PFCG_LP()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult PFCG_MYWJ()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult PFCG_SCSB()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult PFCG_SJSM()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult PFCG_SP()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult PFCG_TS()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult PFCG_XBSP()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult PFCG_YBYQ()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FBPFCG_AFSBJBXX()
        {
            YHJBXX yhjbxx = PFCG_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            PFCG_AFSBJBXX PFCG_AFSBjbxx = JsonHelper.ConvertJsonToObject<PFCG_AFSBJBXX>(json);
            PFCG_AFSBjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = PFCG_BLL.SavePFCG_AFSBJBXX(jcxx, PFCG_AFSBjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBPFCG_BZJBXX()
        {
            YHJBXX yhjbxx = PFCG_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            PFCG_BZJBXX PFCG_BZjbxx = JsonHelper.ConvertJsonToObject<PFCG_BZJBXX>(json);
            PFCG_BZjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = PFCG_BLL.SavePFCG_BZJBXX(jcxx, PFCG_BZjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBPFCG_DGDLJBXX()
        {
            YHJBXX yhjbxx = PFCG_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            PFCG_DGDLJBXX PFCG_DGDLjbxx = JsonHelper.ConvertJsonToObject<PFCG_DGDLJBXX>(json);
            PFCG_DGDLjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = PFCG_BLL.SavePFCG_DGDLJBXX(jcxx, PFCG_DGDLjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBPFCG_YCLJBXX()
        {
            YHJBXX yhjbxx = PFCG_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            PFCG_YCLJBXX PFCG_YCLjbxx = JsonHelper.ConvertJsonToObject<PFCG_YCLJBXX>(json);
            PFCG_YCLjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = PFCG_BLL.SavePFCG_YCLJBXX(jcxx, PFCG_YCLjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBPFCG_DJZMJBXX()
        {
            YHJBXX yhjbxx = PFCG_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            PFCG_DJZMJBXX PFCG_DJZMjbxx = JsonHelper.ConvertJsonToObject<PFCG_DJZMJBXX>(json);
            PFCG_DJZMjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = PFCG_BLL.SavePFCG_DJZMJBXX(jcxx, PFCG_DJZMjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBPFCG_DZYQJJBXX()
        {
            YHJBXX yhjbxx = PFCG_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            PFCG_DZYQJJBXX PFCG_DZYQJjbxx = JsonHelper.ConvertJsonToObject<PFCG_DZYQJJBXX>(json);
            PFCG_DZYQJjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = PFCG_BLL.SavePFCG_DZYQJJBXX(jcxx, PFCG_DZYQJjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBPFCG_FSXMJBXX()
        {
            YHJBXX yhjbxx = PFCG_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            PFCG_FSXMJBXX PFCG_FSXMjbxx = JsonHelper.ConvertJsonToObject<PFCG_FSXMJBXX>(json);
            PFCG_FSXMjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = PFCG_BLL.SavePFCG_FSXMJBXX(jcxx, PFCG_FSXMjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBPFCG_FZBLJBXX()
        {
            YHJBXX yhjbxx = PFCG_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            PFCG_FZBLJBXX PFCG_FZBLjbxx = JsonHelper.ConvertJsonToObject<PFCG_FZBLJBXX>(json);
            PFCG_FZBLjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = PFCG_BLL.SavePFCG_FZBLJBXX(jcxx, PFCG_FZBLjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBPFCG_HWYDJBXX()
        {
            YHJBXX yhjbxx = PFCG_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            PFCG_HWYDJBXX PFCG_HWYDjbxx = JsonHelper.ConvertJsonToObject<PFCG_HWYDJBXX>(json);
            PFCG_HWYDjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = PFCG_BLL.SavePFCG_HWYDJBXX(jcxx, PFCG_HWYDjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBPFCG_HXPJBXX()
        {
            YHJBXX yhjbxx = PFCG_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            PFCG_HXPJBXX PFCG_HXPjbxx = JsonHelper.ConvertJsonToObject<PFCG_HXPJBXX>(json);
            PFCG_HXPjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = PFCG_BLL.SavePFCG_HXPJBXX(jcxx, PFCG_HXPjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBPFCG_HZPJBXX()
        {
            YHJBXX yhjbxx = PFCG_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            PFCG_HZPJBXX PFCG_HZPjbxx = JsonHelper.ConvertJsonToObject<PFCG_HZPJBXX>(json);
            PFCG_HZPjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = PFCG_BLL.SavePFCG_HZPJBXX(jcxx, PFCG_HZPjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBPFCG_JXJGJBXX()
        {
            YHJBXX yhjbxx = PFCG_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            PFCG_JXJGJBXX PFCG_JXJGjbxx = JsonHelper.ConvertJsonToObject<PFCG_JXJGJBXX>(json);
            PFCG_JXJGjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = PFCG_BLL.SavePFCG_JXJGJBXX(jcxx, PFCG_JXJGjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBPFCG_KQJBXX()
        {
            YHJBXX yhjbxx = PFCG_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            PFCG_KQJBXX PFCG_KQjbxx = JsonHelper.ConvertJsonToObject<PFCG_KQJBXX>(json);
            PFCG_KQjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = PFCG_BLL.SavePFCG_KQJBXX(jcxx, PFCG_KQjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBPFCG_LPJBXX()
        {
            YHJBXX yhjbxx = PFCG_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            PFCG_LPJBXX PFCG_LPjbxx = JsonHelper.ConvertJsonToObject<PFCG_LPJBXX>(json);
            PFCG_LPjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = PFCG_BLL.SavePFCG_LPJBXX(jcxx, PFCG_LPjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBPFCG_MYWJJBXX()
        {
            YHJBXX yhjbxx = PFCG_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            PFCG_MYWJJBXX PFCG_MYWJjbxx = JsonHelper.ConvertJsonToObject<PFCG_MYWJJBXX>(json);
            PFCG_MYWJjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = PFCG_BLL.SavePFCG_MYWJJBXX(jcxx, PFCG_MYWJjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBPFCG_SCSBJBXX()
        {
            YHJBXX yhjbxx = PFCG_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            PFCG_SCSBJBXX PFCG_SCSBjbxx = JsonHelper.ConvertJsonToObject<PFCG_SCSBJBXX>(json);
            PFCG_SCSBjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = PFCG_BLL.SavePFCG_SCSBJBXX(jcxx, PFCG_SCSBjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBPFCG_SJSMJBXX()
        {
            YHJBXX yhjbxx = PFCG_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            PFCG_SJSMJBXX PFCG_SJSMjbxx = JsonHelper.ConvertJsonToObject<PFCG_SJSMJBXX>(json);
            PFCG_SJSMjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = PFCG_BLL.SavePFCG_SJSMJBXX(jcxx, PFCG_SJSMjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBPFCG_SPJBXX()
        {
            YHJBXX yhjbxx = PFCG_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            PFCG_SPJBXX PFCG_SPjbxx = JsonHelper.ConvertJsonToObject<PFCG_SPJBXX>(json);
            PFCG_SPjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = PFCG_BLL.SavePFCG_SPJBXX(jcxx, PFCG_SPjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBPFCG_TSBJBXX()
        {
            YHJBXX yhjbxx = PFCG_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            PFCG_TSJBXX PFCG_TSjbxx = JsonHelper.ConvertJsonToObject<PFCG_TSJBXX>(json);
            PFCG_TSjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = PFCG_BLL.SavePFCG_TSJBXX(jcxx, PFCG_TSjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBPFCG_XBSPJBXX()
        {
            YHJBXX yhjbxx = PFCG_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            PFCG_XBSPJBXX PFCG_XBSPjbxx = JsonHelper.ConvertJsonToObject<PFCG_XBSPJBXX>(json);
            PFCG_XBSPjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = PFCG_BLL.SavePFCG_XBSPJBXX(jcxx, PFCG_XBSPjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBPFCG_YBYQJBXX()
        {
            YHJBXX yhjbxx = PFCG_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            PFCG_YBYQJBXX PFCG_YBYQjbxx = JsonHelper.ConvertJsonToObject<PFCG_YBYQJBXX>(json);
            PFCG_YBYQjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = PFCG_BLL.SavePFCG_YBYQJBXX(jcxx, PFCG_YBYQjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadPFCG_AFSBJBXX()
        {
            string ID = Request["ID"];
            object result = PFCG_BLL.LoadPFCG_AFSBJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadPFCG_BZJBXX()
        {
            string ID = Request["ID"];
            object result = PFCG_BLL.LoadPFCG_BZJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadPFCG_DGDLJBXX()
        {
            string ID = Request["ID"];
            object result = PFCG_BLL.LoadPFCG_DGDLJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadPFCG_DJZMJBXX()
        {
            string ID = Request["ID"];
            object result = PFCG_BLL.LoadPFCG_DJZMJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadPFCG_YCLJBXX()
        {
            string ID = Request["ID"];
            object result = PFCG_BLL.LoadPFCG_YCLJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadPFCG_DZYQJJBXX()
        {
            string ID = Request["ID"];
            object result = PFCG_BLL.LoadPFCG_DZYQJJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadPFCG_FSXMJBXX()
        {
            string ID = Request["ID"];
            object result = PFCG_BLL.LoadPFCG_FSXMJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadPFCG_FZBLJBXX()
        {
            string ID = Request["ID"];
            object result = PFCG_BLL.LoadPFCG_FZBLJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadPFCG_HWYDJBXX()
        {
            string ID = Request["ID"];
            object result = PFCG_BLL.LoadPFCG_HWYDJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadPFCG_HXPJBXX()
        {
            string ID = Request["ID"];
            object result = PFCG_BLL.LoadPFCG_HXPJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadPFCG_HZPJBXX()
        {
            string ID = Request["ID"];
            object result = PFCG_BLL.LoadPFCG_HZPJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadPFCG_JXJGJBXX()
        {
            string ID = Request["ID"];
            object result = PFCG_BLL.LoadPFCG_JXJGJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadPFCG_KQJBXX()
        {
            string ID = Request["ID"];
            object result = PFCG_BLL.LoadPFCG_KQJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadPFCG_LPJBXX()
        {
            string ID = Request["ID"];
            object result = PFCG_BLL.LoadPFCG_LPJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadPFCG_MYWJJBXX()
        {
            string ID = Request["ID"];
            object result = PFCG_BLL.LoadPFCG_MYWJJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadPFCG_SCSBJBXX()
        {
            string ID = Request["ID"];
            object result = PFCG_BLL.LoadPFCG_SCSBJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadPFCG_SJSMJBXX()
        {
            string ID = Request["ID"];
            object result = PFCG_BLL.LoadPFCG_SJSMJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadPFCG_SPJBXX()
        {
            string ID = Request["ID"];
            object result = PFCG_BLL.LoadPFCG_SPJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadPFCG_TSJBXX()
        {
            string ID = Request["ID"];
            object result = PFCG_BLL.LoadPFCG_TSJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadPFCG_XBSPJBXX()
        {
            string ID = Request["ID"];
            object result = PFCG_BLL.LoadPFCG_XBSPJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadPFCG_YBYQJBXX()
        {
            string ID = Request["ID"];
            object result = PFCG_BLL.LoadPFCG_YBYQJBXX(ID);
            return Json(result);
        }
    }
}