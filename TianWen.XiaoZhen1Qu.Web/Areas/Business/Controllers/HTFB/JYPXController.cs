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
    public class JYPXController : BaseController
    {
        public IJYPX_BLL JYPX_BLL { get; set; }

        public ActionResult JYPX_GLPX()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult JYPX_ITPX()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult JYPX_JJGR()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult JYPX_JJJG()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult JYPX_LX()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult JYPX_PBPK()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult JYPX_SJPX()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult JYPX_TYJL()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult JYPX_TYPX()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult JYPX_XLJY()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult JYPX_YM()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult JYPX_YSPX()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult JYPX_YSPXJS()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult JYPX_YYEJY()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult JYPX_YYPXJG()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult JYPX_YYPXJS()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult JYPX_ZXXFDB()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult JYPX_ZXXYDY()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }
        public ActionResult JYPX_ZYJNPX()
        {
            ViewData["XZQ"] = Session["XZQ"];
            ViewData["YHM"] = Session["YHM"];
            return View();
        }

        [ValidateInput(false)]
        public JsonResult FBJYPX_GLPXJBXX()
        {
            YHJBXX yhjbxx = JYPX_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            JYPX_GLPXJBXX JYPX_GLPXjbxx = JsonHelper.ConvertJsonToObject<JYPX_GLPXJBXX>(json);
            JYPX_GLPXjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = JYPX_BLL.SaveJYPX_GLPXJBXX(jcxx, JYPX_GLPXjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBJYPX_ITPXJBXX()
        {
            YHJBXX yhjbxx = JYPX_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            JYPX_ITPXJBXX JYPX_ITPXjbxx = JsonHelper.ConvertJsonToObject<JYPX_ITPXJBXX>(json);
            JYPX_ITPXjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = JYPX_BLL.SaveJYPX_ITPXJBXX(jcxx, JYPX_ITPXjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBJYPX_JJGRJBXX()
        {
            YHJBXX yhjbxx = JYPX_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            JYPX_JJGRJBXX JYPX_JJGRjbxx = JsonHelper.ConvertJsonToObject<JYPX_JJGRJBXX>(json);
            JYPX_JJGRjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = JYPX_BLL.SaveJYPX_JJGRJBXX(jcxx, JYPX_JJGRjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBJYPX_JJJGJBXX()
        {
            YHJBXX yhjbxx = JYPX_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            JYPX_JJJGJBXX JYPX_JJJGjbxx = JsonHelper.ConvertJsonToObject<JYPX_JJJGJBXX>(json);
            JYPX_JJJGjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = JYPX_BLL.SaveJYPX_JJJGJBXX(jcxx, JYPX_JJJGjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBJYPX_LXJBXX()
        {
            YHJBXX yhjbxx = JYPX_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            JYPX_LXJBXX JYPX_LXjbxx = JsonHelper.ConvertJsonToObject<JYPX_LXJBXX>(json);
            JYPX_LXjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = JYPX_BLL.SaveJYPX_LXJBXX(jcxx, JYPX_LXjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBJYPX_PBPKJBXX()
        {
            YHJBXX yhjbxx = JYPX_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            JYPX_PBPKJBXX JYPX_PBPKjbxx = JsonHelper.ConvertJsonToObject<JYPX_PBPKJBXX>(json);
            JYPX_PBPKjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = JYPX_BLL.SaveJYPX_PBPKJBXX(jcxx, JYPX_PBPKjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBJYPX_SJPXJBXX()
        {
            YHJBXX yhjbxx = JYPX_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            JYPX_SJPXJBXX JYPX_SJPXjbxx = JsonHelper.ConvertJsonToObject<JYPX_SJPXJBXX>(json);
            JYPX_SJPXjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = JYPX_BLL.SaveJYPX_SJPXJBXX(jcxx, JYPX_SJPXjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBJYPX_TYJLJBXX()
        {
            YHJBXX yhjbxx = JYPX_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            JYPX_TYJLJBXX JYPX_TYJLjbxx = JsonHelper.ConvertJsonToObject<JYPX_TYJLJBXX>(json);
            JYPX_TYJLjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = JYPX_BLL.SaveJYPX_TYJLJBXX(jcxx, JYPX_TYJLjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBJYPX_TYPXJBXX()
        {
            YHJBXX yhjbxx = JYPX_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            JYPX_TYPXJBXX JYPX_TYPXjbxx = JsonHelper.ConvertJsonToObject<JYPX_TYPXJBXX>(json);
            JYPX_TYPXjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = JYPX_BLL.SaveJYPX_TYPXJBXX(jcxx, JYPX_TYPXjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBJYPX_XLJYJBXX()
        {
            YHJBXX yhjbxx = JYPX_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            JYPX_XLJYJBXX JYPX_XLJYjbxx = JsonHelper.ConvertJsonToObject<JYPX_XLJYJBXX>(json);
            JYPX_XLJYjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = JYPX_BLL.SaveJYPX_XLJYJBXX(jcxx, JYPX_XLJYjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBJYPX_YMJBXX()
        {
            YHJBXX yhjbxx = JYPX_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            JYPX_YMJBXX JYPX_YMjbxx = JsonHelper.ConvertJsonToObject<JYPX_YMJBXX>(json);
            JYPX_YMjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = JYPX_BLL.SaveJYPX_YMJBXX(jcxx, JYPX_YMjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBJYPX_YSPXJBXX()
        {
            YHJBXX yhjbxx = JYPX_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            JYPX_YSPXJBXX JYPX_YSPXjbxx = JsonHelper.ConvertJsonToObject<JYPX_YSPXJBXX>(json);
            JYPX_YSPXjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = JYPX_BLL.SaveJYPX_YSPXJBXX(jcxx, JYPX_YSPXjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBJYPX_YSPXJSJBXX()
        {
            YHJBXX yhjbxx = JYPX_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            JYPX_YSPXJSJBXX JYPX_YSPXJSjbxx = JsonHelper.ConvertJsonToObject<JYPX_YSPXJSJBXX>(json);
            JYPX_YSPXJSjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = JYPX_BLL.SaveJYPX_YSPXJSJBXX(jcxx, JYPX_YSPXJSjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBJYPX_YYEJYJBXX()
        {
            YHJBXX yhjbxx = JYPX_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            JYPX_YYEJYJBXX JYPX_YYEJYjbxx = JsonHelper.ConvertJsonToObject<JYPX_YYEJYJBXX>(json);
            JYPX_YYEJYjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = JYPX_BLL.SaveJYPX_YYEJYJBXX(jcxx, JYPX_YYEJYjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBJYPX_YYPXJGJBXX()
        {
            YHJBXX yhjbxx = JYPX_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            JYPX_YYPXJGJBXX JYPX_YYPXJGjbxx = JsonHelper.ConvertJsonToObject<JYPX_YYPXJGJBXX>(json);
            JYPX_YYPXJGjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = JYPX_BLL.SaveJYPX_YYPXJGJBXX(jcxx, JYPX_YYPXJGjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBJYPX_YYPXJSJBXX()
        {
            YHJBXX yhjbxx = JYPX_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            JYPX_YYPXJSJBXX JYPX_YYPXJSjbxx = JsonHelper.ConvertJsonToObject<JYPX_YYPXJSJBXX>(json);
            JYPX_YYPXJSjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = JYPX_BLL.SaveJYPX_YYPXJSJBXX(jcxx, JYPX_YYPXJSjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBJYPX_ZXXFDBJBXX()
        {
            YHJBXX yhjbxx = JYPX_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            JYPX_ZXXFDBJBXX JYPX_ZXXFDBjbxx = JsonHelper.ConvertJsonToObject<JYPX_ZXXFDBJBXX>(json);
            JYPX_ZXXFDBjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = JYPX_BLL.SaveJYPX_ZXXFDBJBXX(jcxx, JYPX_ZXXFDBjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBJYPX_ZXXYDYJBXX()
        {
            YHJBXX yhjbxx = JYPX_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            JYPX_ZXXYDYJBXX JYPX_ZXXYDYjbxx = JsonHelper.ConvertJsonToObject<JYPX_ZXXYDYJBXX>(json);
            JYPX_ZXXYDYjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = JYPX_BLL.SaveJYPX_ZXXYDYJBXX(jcxx, JYPX_ZXXYDYjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBJYPX_ZYJNPXJBXX()
        {
            YHJBXX yhjbxx = JYPX_BLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            JYPX_ZYJNPXJBXX JYPX_ZYJNPXjbxx = JsonHelper.ConvertJsonToObject<JYPX_ZYJNPXJBXX>(json);
            JYPX_ZYJNPXjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = JYPX_BLL.SaveJYPX_ZYJNPXJBXX(jcxx, JYPX_ZYJNPXjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadJYPX_GLPXJBXX()
        {
            string ID = Request["ID"];
            object result = JYPX_BLL.LoadJYPX_GLPXJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadJYPX_ITPXJBXX()
        {
            string ID = Request["ID"];
            object result = JYPX_BLL.LoadJYPX_ITPXJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadJYPX_JJGRJBXX()
        {
            string ID = Request["ID"];
            object result = JYPX_BLL.LoadJYPX_JJGRJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadJYPX_JJJGJBXX()
        {
            string ID = Request["ID"];
            object result = JYPX_BLL.LoadJYPX_JJJGJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadJYPX_LXJBXX()
        {
            string ID = Request["ID"];
            object result = JYPX_BLL.LoadJYPX_LXJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadJYPX_PBPKJBXX()
        {
            string ID = Request["ID"];
            object result = JYPX_BLL.LoadJYPX_PBPKJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadJYPX_SJPXJBXX()
        {
            string ID = Request["ID"];
            object result = JYPX_BLL.LoadJYPX_SJPXJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadJYPX_TYJLJBXX()
        {
            string ID = Request["ID"];
            object result = JYPX_BLL.LoadJYPX_TYJLJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadJYPX_TYPXJBXX()
        {
            string ID = Request["ID"];
            object result = JYPX_BLL.LoadJYPX_TYPXJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadJYPX_XLJYJBXX()
        {
            string ID = Request["ID"];
            object result = JYPX_BLL.LoadJYPX_XLJYJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadJYPX_YMJBXX()
        {
            string ID = Request["ID"];
            object result = JYPX_BLL.LoadJYPX_YMJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadJYPX_YSPXJBXX()
        {
            string ID = Request["ID"];
            object result = JYPX_BLL.LoadJYPX_YSPXJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadJYPX_YSPXJSJBXX()
        {
            string ID = Request["ID"];
            object result = JYPX_BLL.LoadJYPX_YSPXJSJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadJYPX_YYEJYJBXX()
        {
            string ID = Request["ID"];
            object result = JYPX_BLL.LoadJYPX_YYEJYJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadJYPX_YYPXJGJBXX()
        {
            string ID = Request["ID"];
            object result = JYPX_BLL.LoadJYPX_YYPXJGJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadJYPX_YYPXJSJBXX()
        {
            string ID = Request["ID"];
            object result = JYPX_BLL.LoadJYPX_YYPXJSJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadJYPX_ZXXFDBJBXX()
        {
            string ID = Request["ID"];
            object result = JYPX_BLL.LoadJYPX_ZXXFDBJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadJYPX_ZXXYDYJBXX()
        {
            string ID = Request["ID"];
            object result = JYPX_BLL.LoadJYPX_ZXXYDYJBXX(ID);
            return Json(result);
        }
        public JsonResult LoadJYPX_ZYJNPXJBXX()
        {
            string ID = Request["ID"];
            object result = JYPX_BLL.LoadJYPX_ZYJNPXJBXX(ID);
            return Json(result);
        }
    }
}