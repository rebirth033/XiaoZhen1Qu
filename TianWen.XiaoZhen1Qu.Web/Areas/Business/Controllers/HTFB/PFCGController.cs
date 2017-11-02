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
        public IPFCG_AFSBBLL PFCG_AFSBBLL { get; set; }
        public IPFCG_BZBLL PFCG_BZBLL { get; set; }
        public IPFCG_DGDLBLL PFCG_DGDLBLL { get; set; }
        public IPFCG_DJZMBLL PFCG_DJZMBLL { get; set; }
        public IPFCG_YCLBLL PFCG_YCLBLL { get; set; }
        public IPFCG_DZYQJBLL PFCG_DZYQJBLL { get; set; }
        public IPFCG_FSXMBLL PFCG_FSXMBLL { get; set; }
        public IPFCG_FZBLBLL PFCG_FZBLBLL { get; set; }
        public IPFCG_HWYDBLL PFCG_HWYDBLL { get; set; }
        public IPFCG_HXPBLL PFCG_HXPBLL { get; set; }
        public IPFCG_HZPBLL PFCG_HZPBLL { get; set; }
        public IPFCG_JXJGBLL PFCG_JXJGBLL { get; set; }
        public IPFCG_KQBLL PFCG_KQBLL { get; set; }
        public IPFCG_LPBLL PFCG_LPBLL { get; set; }
        public IPFCG_MYWJBLL PFCG_MYWJBLL { get; set; }
        public IPFCG_SCSBBLL PFCG_SCSBBLL { get; set; }
        public IPFCG_SJSMBLL PFCG_SJSMBLL { get; set; }
        public IPFCG_SPBLL PFCG_SPBLL { get; set; }
        public IPFCG_TSBLL PFCG_TSBLL { get; set; }
        public IPFCG_XBSPBLL PFCG_XBSPBLL { get; set; }
        public IPFCG_YBYQBLL PFCG_YBYQBLL { get; set; }
        public IPFCG_YXBLL PFCG_YXBLL { get; set; }

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
        public ActionResult PFCG_YX()
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
            YHJBXX yhjbxx = PFCG_AFSBBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            PFCG_AFSBJBXX PFCG_AFSBjbxx = JsonHelper.ConvertJsonToObject<PFCG_AFSBJBXX>(json);
            PFCG_AFSBjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = PFCG_AFSBBLL.SavePFCG_AFSBJBXX(jcxx, PFCG_AFSBjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBPFCG_YXJBXX()
        {
            YHJBXX yhjbxx = PFCG_YXBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            PFCG_YXJBXX PFCG_YXjbxx = JsonHelper.ConvertJsonToObject<PFCG_YXJBXX>(json);
            PFCG_YXjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = PFCG_YXBLL.SavePFCG_YXJBXX(jcxx, PFCG_YXjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBPFCG_BZJBXX()
        {
            YHJBXX yhjbxx = PFCG_BZBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            PFCG_BZJBXX PFCG_BZjbxx = JsonHelper.ConvertJsonToObject<PFCG_BZJBXX>(json);
            PFCG_BZjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = PFCG_BZBLL.SavePFCG_BZJBXX(jcxx, PFCG_BZjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBPFCG_DGDLJBXX()
        {
            YHJBXX yhjbxx = PFCG_DGDLBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            PFCG_DGDLJBXX PFCG_DGDLjbxx = JsonHelper.ConvertJsonToObject<PFCG_DGDLJBXX>(json);
            PFCG_DGDLjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = PFCG_DGDLBLL.SavePFCG_DGDLJBXX(jcxx, PFCG_DGDLjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBPFCG_YCLJBXX()
        {
            YHJBXX yhjbxx = PFCG_DJZMBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            PFCG_YCLJBXX PFCG_YCLjbxx = JsonHelper.ConvertJsonToObject<PFCG_YCLJBXX>(json);
            PFCG_YCLjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = PFCG_YCLBLL.SavePFCG_YCLJBXX(jcxx, PFCG_YCLjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBPFCG_DJZMJBXX()
        {
            YHJBXX yhjbxx = PFCG_DJZMBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            PFCG_DJZMJBXX PFCG_DJZMjbxx = JsonHelper.ConvertJsonToObject<PFCG_DJZMJBXX>(json);
            PFCG_DJZMjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = PFCG_DJZMBLL.SavePFCG_DJZMJBXX(jcxx, PFCG_DJZMjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBPFCG_DZYQJJBXX()
        {
            YHJBXX yhjbxx = PFCG_DZYQJBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            PFCG_DZYQJJBXX PFCG_DZYQJjbxx = JsonHelper.ConvertJsonToObject<PFCG_DZYQJJBXX>(json);
            PFCG_DZYQJjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = PFCG_DZYQJBLL.SavePFCG_DZYQJJBXX(jcxx, PFCG_DZYQJjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBPFCG_FSXMJBXX()
        {
            YHJBXX yhjbxx = PFCG_FSXMBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            PFCG_FSXMJBXX PFCG_FSXMjbxx = JsonHelper.ConvertJsonToObject<PFCG_FSXMJBXX>(json);
            PFCG_FSXMjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = PFCG_FSXMBLL.SavePFCG_FSXMJBXX(jcxx, PFCG_FSXMjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBPFCG_FZBLJBXX()
        {
            YHJBXX yhjbxx = PFCG_FZBLBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            PFCG_FZBLJBXX PFCG_FZBLjbxx = JsonHelper.ConvertJsonToObject<PFCG_FZBLJBXX>(json);
            PFCG_FZBLjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = PFCG_FZBLBLL.SavePFCG_FZBLJBXX(jcxx, PFCG_FZBLjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBPFCG_HWYDJBXX()
        {
            YHJBXX yhjbxx = PFCG_HWYDBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            PFCG_HWYDJBXX PFCG_HWYDjbxx = JsonHelper.ConvertJsonToObject<PFCG_HWYDJBXX>(json);
            PFCG_HWYDjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = PFCG_HWYDBLL.SavePFCG_HWYDJBXX(jcxx, PFCG_HWYDjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBPFCG_HXPJBXX()
        {
            YHJBXX yhjbxx = PFCG_HXPBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            PFCG_HXPJBXX PFCG_HXPjbxx = JsonHelper.ConvertJsonToObject<PFCG_HXPJBXX>(json);
            PFCG_HXPjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = PFCG_HXPBLL.SavePFCG_HXPJBXX(jcxx, PFCG_HXPjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBPFCG_HZP()
        {
            YHJBXX yhjbxx = PFCG_HZPBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            PFCG_HZPJBXX PFCG_HZPjbxx = JsonHelper.ConvertJsonToObject<PFCG_HZPJBXX>(json);
            PFCG_HZPjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = PFCG_HZPBLL.SavePFCG_HZPJBXX(jcxx, PFCG_HZPjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBPFCG_JXJGJBXX()
        {
            YHJBXX yhjbxx = PFCG_JXJGBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            PFCG_JXJGJBXX PFCG_JXJGjbxx = JsonHelper.ConvertJsonToObject<PFCG_JXJGJBXX>(json);
            PFCG_JXJGjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = PFCG_JXJGBLL.SavePFCG_JXJGJBXX(jcxx, PFCG_JXJGjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBPFCG_KQJBXX()
        {
            YHJBXX yhjbxx = PFCG_KQBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            PFCG_KQJBXX PFCG_KQjbxx = JsonHelper.ConvertJsonToObject<PFCG_KQJBXX>(json);
            PFCG_KQjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = PFCG_KQBLL.SavePFCG_KQJBXX(jcxx, PFCG_KQjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBPFCG_LPJBXX()
        {
            YHJBXX yhjbxx = PFCG_LPBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            PFCG_LPJBXX PFCG_LPjbxx = JsonHelper.ConvertJsonToObject<PFCG_LPJBXX>(json);
            PFCG_LPjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = PFCG_LPBLL.SavePFCG_LPJBXX(jcxx, PFCG_LPjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBPFCG_MYWJJBXX()
        {
            YHJBXX yhjbxx = PFCG_MYWJBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            PFCG_MYWJJBXX PFCG_MYWJjbxx = JsonHelper.ConvertJsonToObject<PFCG_MYWJJBXX>(json);
            PFCG_MYWJjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = PFCG_MYWJBLL.SavePFCG_MYWJJBXX(jcxx, PFCG_MYWJjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBPFCG_SCSBJBXX()
        {
            YHJBXX yhjbxx = PFCG_SCSBBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            PFCG_SCSBJBXX PFCG_SCSBjbxx = JsonHelper.ConvertJsonToObject<PFCG_SCSBJBXX>(json);
            PFCG_SCSBjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = PFCG_SCSBBLL.SavePFCG_SCSBJBXX(jcxx, PFCG_SCSBjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBPFCG_SJSMJBXX()
        {
            YHJBXX yhjbxx = PFCG_SJSMBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            PFCG_SJSMJBXX PFCG_SJSMjbxx = JsonHelper.ConvertJsonToObject<PFCG_SJSMJBXX>(json);
            PFCG_SJSMjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = PFCG_SJSMBLL.SavePFCG_SJSMJBXX(jcxx, PFCG_SJSMjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBPFCG_SPJBXX()
        {
            YHJBXX yhjbxx = PFCG_SPBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            PFCG_SPJBXX PFCG_SPjbxx = JsonHelper.ConvertJsonToObject<PFCG_SPJBXX>(json);
            PFCG_SPjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = PFCG_SPBLL.SavePFCG_SPJBXX(jcxx, PFCG_SPjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBPFCG_TSBJBXX()
        {
            YHJBXX yhjbxx = PFCG_TSBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            PFCG_TSJBXX PFCG_TSjbxx = JsonHelper.ConvertJsonToObject<PFCG_TSJBXX>(json);
            PFCG_TSjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = PFCG_TSBLL.SavePFCG_TSJBXX(jcxx, PFCG_TSjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBPFCG_XBSPJBXX()
        {
            YHJBXX yhjbxx = PFCG_XBSPBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            PFCG_XBSPJBXX PFCG_XBSPjbxx = JsonHelper.ConvertJsonToObject<PFCG_XBSPJBXX>(json);
            PFCG_XBSPjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = PFCG_XBSPBLL.SavePFCG_XBSPJBXX(jcxx, PFCG_XBSPjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBPFCG_YBYQJBXX()
        {
            YHJBXX yhjbxx = PFCG_YBYQBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            PFCG_YBYQJBXX PFCG_YBYQjbxx = JsonHelper.ConvertJsonToObject<PFCG_YBYQJBXX>(json);
            PFCG_YBYQjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = PFCG_YBYQBLL.SavePFCG_YBYQJBXX(jcxx, PFCG_YBYQjbxx, photos);
            return Json(result);
        }


        public JsonResult LoadPFCG_AFSBJBXX()
        {
            string PFCG_AFSBJBXXID = Request["PFCG_AFSBJBXXID"];
            object result = PFCG_AFSBBLL.LoadPFCG_AFSBJBXX(PFCG_AFSBJBXXID);
            return Json(result);
        }
        public JsonResult LoadPFCG_YXBXX()
        {
            string PFCG_YXJBXXID = Request["PFCG_YXJBXXID"];
            object result = PFCG_YXBLL.LoadPFCG_YXJBXX(PFCG_YXJBXXID);
            return Json(result);
        }
        public JsonResult LoadPFCG_BZJBXX()
        {
            string PFCG_BZJBXXID = Request["PFCG_BZJBXXID"];
            object result = PFCG_BZBLL.LoadPFCG_BZJBXX(PFCG_BZJBXXID);
            return Json(result);
        }
        public JsonResult LoadPFCG_DGDLJBXX()
        {
            string PFCG_DGDLJBXXID = Request["PFCG_DGDLJBXXID"];
            object result = PFCG_DGDLBLL.LoadPFCG_DGDLJBXX(PFCG_DGDLJBXXID);
            return Json(result);
        }
        public JsonResult LoadPFCG_DJZMJBXX()
        {
            string PFCG_DJZMJBXXID = Request["PFCG_DJZMJBXXID"];
            object result = PFCG_DJZMBLL.LoadPFCG_DJZMJBXX(PFCG_DJZMJBXXID);
            return Json(result);
        }
        public JsonResult LoadPFCG_YCLJBXX()
        {
            string PFCG_YCLJBXXID = Request["PFCG_YCLJBXXID"];
            object result = PFCG_YCLBLL.LoadPFCG_YCLJBXX(PFCG_YCLJBXXID);
            return Json(result);
        }
        public JsonResult LoadPFCG_DZYQJJBXX()
        {
            string PFCG_DZYQJJBXXID = Request["PFCG_DZYQJJBXXID"];
            object result = PFCG_DZYQJBLL.LoadPFCG_DZYQJJBXX(PFCG_DZYQJJBXXID);
            return Json(result);
        }
        public JsonResult LoadPFCG_FSXMJBXX()
        {
            string PFCG_FSXMJBXXID = Request["PFCG_FSXMJBXXID"];
            object result = PFCG_FSXMBLL.LoadPFCG_FSXMJBXX(PFCG_FSXMJBXXID);
            return Json(result);
        }
        public JsonResult LoadPFCG_FZBLJBXX()
        {
            string PFCG_FZBLJBXXID = Request["PFCG_FZBLJBXXID"];
            object result = PFCG_FZBLBLL.LoadPFCG_FZBLJBXX(PFCG_FZBLJBXXID);
            return Json(result);
        }
        public JsonResult LoadPFCG_HWYDJBXX()
        {
            string PFCG_HWYDJBXXID = Request["PFCG_HWYDJBXXID"];
            object result = PFCG_HWYDBLL.LoadPFCG_HWYDJBXX(PFCG_HWYDJBXXID);
            return Json(result);
        }
        public JsonResult LoadPFCG_HXPJBXX()
        {
            string PFCG_HXPJBXXID = Request["PFCG_HXPJBXXID"];
            object result = PFCG_HXPBLL.LoadPFCG_HXPJBXX(PFCG_HXPJBXXID);
            return Json(result);
        }
        public JsonResult LoadPFCG_HZPJBXX()
        {
            string PFCG_HZPJBXXID = Request["PFCG_HZPJBXXID"];
            object result = PFCG_HZPBLL.LoadPFCG_HZPJBXX(PFCG_HZPJBXXID);
            return Json(result);
        }
        public JsonResult LoadPFCG_JXJGJBXX()
        {
            string PFCG_JXJGJBXXID = Request["PFCG_JXJGJBXXID"];
            object result = PFCG_JXJGBLL.LoadPFCG_JXJGJBXX(PFCG_JXJGJBXXID);
            return Json(result);
        }
        public JsonResult LoadPFCG_KQJBXX()
        {
            string PFCG_KQJBXXID = Request["PFCG_KQJBXXID"];
            object result = PFCG_KQBLL.LoadPFCG_KQJBXX(PFCG_KQJBXXID);
            return Json(result);
        }
        public JsonResult LoadPFCG_LPJBXX()
        {
            string PFCG_LPJBXXID = Request["PFCG_LPJBXXID"];
            object result = PFCG_LPBLL.LoadPFCG_LPJBXX(PFCG_LPJBXXID);
            return Json(result);
        }
        public JsonResult LoadPFCG_MYWJJBXX()
        {
            string PFCG_MYWJJBXXID = Request["PFCG_MYWJJBXXID"];
            object result = PFCG_MYWJBLL.LoadPFCG_MYWJJBXX(PFCG_MYWJJBXXID);
            return Json(result);
        }
        public JsonResult LoadPFCG_SCSBJBXX()
        {
            string PFCG_SCSBJBXXID = Request["PFCG_SCSBJBXXID"];
            object result = PFCG_SCSBBLL.LoadPFCG_SCSBJBXX(PFCG_SCSBJBXXID);
            return Json(result);
        }
        public JsonResult LoadPFCG_SJSMJBXX()
        {
            string PFCG_SJSMJBXXID = Request["PFCG_SJSMJBXXID"];
            object result = PFCG_SJSMBLL.LoadPFCG_SJSMJBXX(PFCG_SJSMJBXXID);
            return Json(result);
        }
        public JsonResult LoadPFCG_SPJBXX()
        {
            string PFCG_SPJBXXID = Request["PFCG_SPJBXXID"];
            object result = PFCG_SPBLL.LoadPFCG_SPJBXX(PFCG_SPJBXXID);
            return Json(result);
        }
        public JsonResult LoadPFCG_TSJBXX()
        {
            string PFCG_TSJBXXID = Request["PFCG_TSJBXXID"];
            object result = PFCG_TSBLL.LoadPFCG_TSJBXX(PFCG_TSJBXXID);
            return Json(result);
        }
        public JsonResult LoadPFCG_XBSPJBXX()
        {
            string PFCG_XBSPJBXXID = Request["PFCG_XBSPJBXXID"];
            object result = PFCG_XBSPBLL.LoadPFCG_XBSPJBXX(PFCG_XBSPJBXXID);
            return Json(result);
        }
        public JsonResult LoadPFCG_YBYQJBXX()
        {
            string PFCG_YBYQJBXXID = Request["PFCG_YBYQJBXXID"];
            object result = PFCG_YBYQBLL.LoadPFCG_YBYQJBXX(PFCG_YBYQJBXXID);
            return Json(result);
        }
    }
}