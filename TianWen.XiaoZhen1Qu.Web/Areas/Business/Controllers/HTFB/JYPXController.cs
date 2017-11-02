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
        public IJYPX_GLPXBLL JYPX_GLPXBLL { get; set; }
        public IJYPX_ITPXBLL JYPX_ITPXBLL { get; set; }
        public IJYPX_JJGRBLL JYPX_JJGRBLL { get; set; }
        public IJYPX_JJJGBLL JYPX_JJJGBLL { get; set; }
        public IJYPX_LXBLL JYPX_LXBLL { get; set; }
        public IJYPX_PBPKBLL JYPX_PBPKBLL { get; set; }
        public IJYPX_SJPXBLL JYPX_SJPXBLL { get; set; }
        public IJYPX_TYJLBLL JYPX_TYJLBLL { get; set; }
        public IJYPX_TYPXBLL JYPX_TYPXBLL { get; set; }
        public IJYPX_XLJYBLL JYPX_XLJYBLL { get; set; }
        public IJYPX_YMBLL JYPX_YMBLL { get; set; }
        public IJYPX_YSPXBLL JYPX_YSPXBLL { get; set; }
        public IJYPX_YSPXJSBLL JYPX_YSPXJSBLL { get; set; }
        public IJYPX_YYEJYBLL JYPX_YYEJYBLL { get; set; }
        public IJYPX_YYPXJGBLL JYPX_YYPXJGBLL { get; set; }
        public IJYPX_YYPXJSBLL JYPX_YYPXJSBLL { get; set; }
        public IJYPX_ZXXFDBBLL JYPX_ZXXFDBBLL { get; set; }
        public IJYPX_ZXXYDYBLL JYPX_ZXXYDYBLL { get; set; }
        public IJYPX_ZYJNPXBLL JYPX_ZYJNPXBLL { get; set; }

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
            YHJBXX yhjbxx = JYPX_GLPXBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            JYPX_GLPXJBXX JYPX_GLPXjbxx = JsonHelper.ConvertJsonToObject<JYPX_GLPXJBXX>(json);
            JYPX_GLPXjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = JYPX_GLPXBLL.SaveJYPX_GLPXJBXX(jcxx, JYPX_GLPXjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBJYPX_ITPXJBXX()
        {
            YHJBXX yhjbxx = JYPX_ITPXBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            JYPX_ITPXJBXX JYPX_ITPXjbxx = JsonHelper.ConvertJsonToObject<JYPX_ITPXJBXX>(json);
            JYPX_ITPXjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = JYPX_ITPXBLL.SaveJYPX_ITPXJBXX(jcxx, JYPX_ITPXjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBJYPX_JJGRJBXX()
        {
            YHJBXX yhjbxx = JYPX_JJGRBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            JYPX_JJGRJBXX JYPX_JJGRjbxx = JsonHelper.ConvertJsonToObject<JYPX_JJGRJBXX>(json);
            JYPX_JJGRjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = JYPX_JJGRBLL.SaveJYPX_JJGRJBXX(jcxx, JYPX_JJGRjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBJYPX_JJJGJBXX()
        {
            YHJBXX yhjbxx = JYPX_JJJGBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            JYPX_JJJGJBXX JYPX_JJJGjbxx = JsonHelper.ConvertJsonToObject<JYPX_JJJGJBXX>(json);
            JYPX_JJJGjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = JYPX_JJJGBLL.SaveJYPX_JJJGJBXX(jcxx, JYPX_JJJGjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBJYPX_LXJBXX()
        {
            YHJBXX yhjbxx = JYPX_LXBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            JYPX_LXJBXX JYPX_LXjbxx = JsonHelper.ConvertJsonToObject<JYPX_LXJBXX>(json);
            JYPX_LXjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = JYPX_LXBLL.SaveJYPX_LXJBXX(jcxx, JYPX_LXjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBJYPX_PBPKJBXX()
        {
            YHJBXX yhjbxx = JYPX_PBPKBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            JYPX_PBPKJBXX JYPX_PBPKjbxx = JsonHelper.ConvertJsonToObject<JYPX_PBPKJBXX>(json);
            JYPX_PBPKjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = JYPX_PBPKBLL.SaveJYPX_PBPKJBXX(jcxx, JYPX_PBPKjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBJYPX_SJPXJBXX()
        {
            YHJBXX yhjbxx = JYPX_SJPXBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            JYPX_SJPXJBXX JYPX_SJPXjbxx = JsonHelper.ConvertJsonToObject<JYPX_SJPXJBXX>(json);
            JYPX_SJPXjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = JYPX_SJPXBLL.SaveJYPX_SJPXJBXX(jcxx, JYPX_SJPXjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBJYPX_TYJLJBXX()
        {
            YHJBXX yhjbxx = JYPX_TYJLBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            JYPX_TYJLJBXX JYPX_TYJLjbxx = JsonHelper.ConvertJsonToObject<JYPX_TYJLJBXX>(json);
            JYPX_TYJLjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = JYPX_TYJLBLL.SaveJYPX_TYJLJBXX(jcxx, JYPX_TYJLjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBJYPX_TYPXJBXX()
        {
            YHJBXX yhjbxx = JYPX_TYPXBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            JYPX_TYPXJBXX JYPX_TYPXjbxx = JsonHelper.ConvertJsonToObject<JYPX_TYPXJBXX>(json);
            JYPX_TYPXjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = JYPX_TYPXBLL.SaveJYPX_TYPXJBXX(jcxx, JYPX_TYPXjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBJYPX_XLJYJBXX()
        {
            YHJBXX yhjbxx = JYPX_XLJYBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            JYPX_XLJYJBXX JYPX_XLJYjbxx = JsonHelper.ConvertJsonToObject<JYPX_XLJYJBXX>(json);
            JYPX_XLJYjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = JYPX_XLJYBLL.SaveJYPX_XLJYJBXX(jcxx, JYPX_XLJYjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBJYPX_YMJBXX()
        {
            YHJBXX yhjbxx = JYPX_YMBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            JYPX_YMJBXX JYPX_YMjbxx = JsonHelper.ConvertJsonToObject<JYPX_YMJBXX>(json);
            JYPX_YMjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = JYPX_YMBLL.SaveJYPX_YMJBXX(jcxx, JYPX_YMjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBJYPX_YSPXJBXX()
        {
            YHJBXX yhjbxx = JYPX_YSPXBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            JYPX_YSPXJBXX JYPX_YSPXjbxx = JsonHelper.ConvertJsonToObject<JYPX_YSPXJBXX>(json);
            JYPX_YSPXjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = JYPX_YSPXBLL.SaveJYPX_YSPXJBXX(jcxx, JYPX_YSPXjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBJYPX_YSPXJSJBXX()
        {
            YHJBXX yhjbxx = JYPX_YSPXJSBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            JYPX_YSPXJSJBXX JYPX_YSPXJSjbxx = JsonHelper.ConvertJsonToObject<JYPX_YSPXJSJBXX>(json);
            JYPX_YSPXJSjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = JYPX_YSPXJSBLL.SaveJYPX_YSPXJSJBXX(jcxx, JYPX_YSPXJSjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBJYPX_YYEJYJBXX()
        {
            YHJBXX yhjbxx = JYPX_YYEJYBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            JYPX_YYEJYJBXX JYPX_YYEJYjbxx = JsonHelper.ConvertJsonToObject<JYPX_YYEJYJBXX>(json);
            JYPX_YYEJYjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = JYPX_YYEJYBLL.SaveJYPX_YYEJYJBXX(jcxx, JYPX_YYEJYjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBJYPX_YYPXJGJBXX()
        {
            YHJBXX yhjbxx = JYPX_YYPXJGBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            JYPX_YYPXJGJBXX JYPX_YYPXJGjbxx = JsonHelper.ConvertJsonToObject<JYPX_YYPXJGJBXX>(json);
            JYPX_YYPXJGjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = JYPX_YYPXJGBLL.SaveJYPX_YYPXJGJBXX(jcxx, JYPX_YYPXJGjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBJYPX_YYPXJSJBXX()
        {
            YHJBXX yhjbxx = JYPX_YYPXJSBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            JYPX_YYPXJSJBXX JYPX_YYPXJSjbxx = JsonHelper.ConvertJsonToObject<JYPX_YYPXJSJBXX>(json);
            JYPX_YYPXJSjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = JYPX_YYPXJSBLL.SaveJYPX_YYPXJSJBXX(jcxx, JYPX_YYPXJSjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBJYPX_ZXXFDBJBXX()
        {
            YHJBXX yhjbxx = JYPX_ZXXFDBBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            JYPX_ZXXFDBJBXX JYPX_ZXXFDBjbxx = JsonHelper.ConvertJsonToObject<JYPX_ZXXFDBJBXX>(json);
            JYPX_ZXXFDBjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = JYPX_ZXXFDBBLL.SaveJYPX_ZXXFDBJBXX(jcxx, JYPX_ZXXFDBjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBJYPX_ZXXYDYJBXX()
        {
            YHJBXX yhjbxx = JYPX_ZXXYDYBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            JYPX_ZXXYDYJBXX JYPX_ZXXYDYjbxx = JsonHelper.ConvertJsonToObject<JYPX_ZXXYDYJBXX>(json);
            JYPX_ZXXYDYjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = JYPX_ZXXYDYBLL.SaveJYPX_ZXXYDYJBXX(jcxx, JYPX_ZXXYDYjbxx, photos);
            return Json(result);
        }
        [ValidateInput(false)]
        public JsonResult FBJYPX_ZYJNPXJBXX()
        {
            YHJBXX yhjbxx = JYPX_ZYJNPXBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            string json = Request["Json"];
            string bcms = Request["BCMS"];
            string fwzp = Request["FWZP"];
            JCXX jcxx = CreateJCXX(yhjbxx, json);
            JYPX_ZYJNPXJBXX JYPX_ZYJNPXjbxx = JsonHelper.ConvertJsonToObject<JYPX_ZYJNPXJBXX>(json);
            JYPX_ZYJNPXjbxx.BCMS = BinaryHelper.StringToBinary(bcms);
            List<PHOTOS> photos = GetTP(fwzp);
            object result = JYPX_ZYJNPXBLL.SaveJYPX_ZYJNPXJBXX(jcxx, JYPX_ZYJNPXjbxx, photos);
            return Json(result);
        }

        public JsonResult LoadJYPX_GLPXJBXX()
        {
            string JYPX_GLPXJBXXID = Request["JYPX_GLPXJBXXID"];
            object result = JYPX_GLPXBLL.LoadJYPX_GLPXJBXX(JYPX_GLPXJBXXID);
            return Json(result);
        }
        public JsonResult LoadJYPX_ITPXJBXX()
        {
            string JYPX_ITPXJBXXID = Request["JYPX_ITPXJBXXID"];
            object result = JYPX_ITPXBLL.LoadJYPX_ITPXJBXX(JYPX_ITPXJBXXID);
            return Json(result);
        }
        public JsonResult LoadJYPX_JJGRJBXX()
        {
            string JYPX_JJGRJBXXID = Request["JYPX_JJGRJBXXID"];
            object result = JYPX_JJGRBLL.LoadJYPX_JJGRJBXX(JYPX_JJGRJBXXID);
            return Json(result);
        }
        public JsonResult LoadJYPX_JJJGJBXX()
        {
            string JYPX_JJJGJBXXID = Request["JYPX_JJJGJBXXID"];
            object result = JYPX_JJJGBLL.LoadJYPX_JJJGJBXX(JYPX_JJJGJBXXID);
            return Json(result);
        }
        public JsonResult LoadJYPX_LXJBXX()
        {
            string JYPX_LXJBXXID = Request["JYPX_LXJBXXID"];
            object result = JYPX_LXBLL.LoadJYPX_LXJBXX(JYPX_LXJBXXID);
            return Json(result);
        }
        public JsonResult LoadJYPX_PBPKJBXX()
        {
            string JYPX_PBPKJBXXID = Request["JYPX_PBPKJBXXID"];
            object result = JYPX_PBPKBLL.LoadJYPX_PBPKJBXX(JYPX_PBPKJBXXID);
            return Json(result);
        }
        public JsonResult LoadJYPX_SJPXJBXX()
        {
            string JYPX_SJPXJBXXID = Request["JYPX_SJPXJBXXID"];
            object result = JYPX_SJPXBLL.LoadJYPX_SJPXJBXX(JYPX_SJPXJBXXID);
            return Json(result);
        }
        public JsonResult LoadJYPX_TYJLJBXX()
        {
            string JYPX_TYJLJBXXID = Request["JYPX_TYJLJBXXID"];
            object result = JYPX_TYJLBLL.LoadJYPX_TYJLJBXX(JYPX_TYJLJBXXID);
            return Json(result);
        }
        public JsonResult LoadJYPX_TYPXJBXX()
        {
            string JYPX_TYPXJBXXID = Request["JYPX_TYPXJBXXID"];
            object result = JYPX_TYPXBLL.LoadJYPX_TYPXJBXX(JYPX_TYPXJBXXID);
            return Json(result);
        }
        public JsonResult LoadJYPX_XLJYJBXX()
        {
            string JYPX_XLJYJBXXID = Request["JYPX_XLJYJBXXID"];
            object result = JYPX_XLJYBLL.LoadJYPX_XLJYJBXX(JYPX_XLJYJBXXID);
            return Json(result);
        }
        public JsonResult LoadJYPX_YMJBXX()
        {
            string JYPX_YMJBXXID = Request["JYPX_YMJBXXID"];
            object result = JYPX_YMBLL.LoadJYPX_YMJBXX(JYPX_YMJBXXID);
            return Json(result);
        }
        public JsonResult LoadJYPX_YSPXJBXX()
        {
            string JYPX_YSPXJBXXID = Request["JYPX_YSPXJBXXID"];
            object result = JYPX_YSPXBLL.LoadJYPX_YSPXJBXX(JYPX_YSPXJBXXID);
            return Json(result);
        }
        public JsonResult LoadJYPX_YSPXJSJBXX()
        {
            string JYPX_YSPXJSJBXXID = Request["JYPX_YSPXJSJBXXID"];
            object result = JYPX_YSPXJSBLL.LoadJYPX_YSPXJSJBXX(JYPX_YSPXJSJBXXID);
            return Json(result);
        }
        public JsonResult LoadJYPX_YYEJYJBXX()
        {
            string JYPX_YYEJYJBXXID = Request["JYPX_YYEJYJBXXID"];
            object result = JYPX_YYEJYBLL.LoadJYPX_YYEJYJBXX(JYPX_YYEJYJBXXID);
            return Json(result);
        }
        public JsonResult LoadJYPX_YYPXJGJBXX()
        {
            string JYPX_YYPXJGJBXXID = Request["JYPX_YYPXJGJBXXID"];
            object result = JYPX_YYPXJGBLL.LoadJYPX_YYPXJGJBXX(JYPX_YYPXJGJBXXID);
            return Json(result);
        }
        public JsonResult LoadJYPX_YYPXJSJBXX()
        {
            string JYPX_YYPXJSJBXXID = Request["JYPX_YYPXJSJBXXID"];
            object result = JYPX_YYPXJSBLL.LoadJYPX_YYPXJSJBXX(JYPX_YYPXJSJBXXID);
            return Json(result);
        }
        public JsonResult LoadJYPX_ZXXFDBJBXX()
        {
            string JYPX_ZXXFDBJBXXID = Request["JYPX_ZXXFDBJBXXID"];
            object result = JYPX_ZXXFDBBLL.LoadJYPX_ZXXFDBJBXX(JYPX_ZXXFDBJBXXID);
            return Json(result);
        }
        public JsonResult LoadJYPX_ZXXYDYJBXX()
        {
            string JYPX_ZXXYDYJBXXID = Request["JYPX_ZXXYDYJBXXID"];
            object result = JYPX_ZXXYDYBLL.LoadJYPX_ZXXYDYJBXX(JYPX_ZXXYDYJBXXID);
            return Json(result);
        }
        public JsonResult LoadJYPX_ZYJNPXJBXX()
        {
            string JYPX_ZYJNPXJBXXID = Request["JYPX_ZYJNPXJBXXID"];
            object result = JYPX_ZYJNPXBLL.LoadJYPX_ZYJNPXJBXX(JYPX_ZYJNPXJBXXID);
            return Json(result);
        }
    }
}