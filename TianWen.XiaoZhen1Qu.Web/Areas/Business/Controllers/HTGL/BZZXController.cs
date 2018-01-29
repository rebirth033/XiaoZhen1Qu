using System.Web.Mvc;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;
using TianWen.XiaoZhen1Qu.Web.Areas.Business.Common;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class BZZXController : BaseController
    {
        public IBZZXBLL BZZXBLL { get; set; }
        public IYHJBXXBLL YHJBXXBLL { get; set; }

        public ActionResult BZZX()
        {
            return View();
        }

        public ActionResult BZZX_SY()
        {
            return View();
        }

        public ActionResult BZZX_CJWT()
        {
            return View();
        }

        public ActionResult BZZX_LXKF()
        {
            return View();
        }

        public ActionResult BZZX_WZJY()
        {
            return View();
        }

        public ActionResult BZZX_SY_ZDJS()
        {
            return View();
        }

        public ActionResult BZZX_SY_ZHMM()
        {
            return View();
        }

        public ActionResult BZZX_SY_DHMYCX()
        {
            return View();
        }

        public ActionResult BZZX_SY_YYYZM()
        {
            return View();
        }

        public ActionResult BZZX_SY_RZSM()
        {
            return View();
        }

        public ActionResult BZZX_SY_YHSYXY()
        {
            return View();
        }

        public ActionResult BZZX_SY_XXBSC()
        {
            return View();
        }

        public ActionResult BZZX_SY_FBGZLTZ()
        {
            return View();
        }
        public ActionResult BZZX_SY_FTBG()
        {
            return View();
        }

        public ActionResult BZZX_SY_KSDH_XSSYZN()
        {
            return View();
        }

        public ActionResult BZZX_SY_KSDH_YHZCYDL()
        {
            return View();
        }

        public ActionResult BZZX_SY_KSDH_XXFBYSC()
        {
            return View();
        }

        public ActionResult BZZX_SY_KSDH_ZHDJYXY()
        {
            return View();
        }

        public ActionResult BZZX_SY_KSDH_WLFPCS()
        {
            return View();
        }

        public ActionResult BZZX_SY_KSDH_JBYSS()
        {
            return View();
        }

        public JsonResult SJCX()
        {
            string SJ = Request["SJ"];
            string TXYZM = Request["TXYZM"];
            if (Session["TXCheckCode"] != null)
            {
                string checkcode = Session["TXCheckCode"].ToString();
                if (TXYZM == checkcode)
                {
                    string result = YHJBXXBLL.GetObjByYHMOrSJ(SJ);
                    if (!string.IsNullOrEmpty(result))
                    {
                        return Json(new { Result = EnResultType.Success, Message = "验证成功" });
                    }
                    else
                    {
                        return Json(new { Result = EnResultType.Failed, Message = "手机号不存在，请重新输入", Type = 1 });
                    }
                }
                else
                {
                    return Json(new { Result = EnResultType.Failed, Message = "验证码错误，请重新输入", Type = 2 });
                }
            }
            else
            {
                return Json(new { Result = EnResultType.Failed, Message = "验证码不存在", Type = 2 });
            }
        }

        public JsonResult YZZH()
        {
            string SJ = Request["SJ"];
            string YZM = Request["YZM"];
            if (Session["CheckCode"] != null)
            {
                string checkcode = Session["CheckCode"].ToString();
                if (YZM == checkcode)
                {
                    string result = YHJBXXBLL.GetObjByYHMOrSJ(SJ);
                    if (!string.IsNullOrEmpty(result))
                    {
                        Session["SJ"] = SJ;
                        return Json(new { Result = EnResultType.Success, Message = "验证成功" });
                    }
                    else
                    {
                        return Json(new { Result = EnResultType.Failed, Message = "手机号不存在，请重新输入", Type = 2 });
                    }
                }
                else
                {
                    return Json(new { Result = EnResultType.Failed, Message = "验证码错误，请重新输入", Type = 1 });
                }
            }
            else
            {
                return Json(new { Result = EnResultType.Failed, Message = "请获取验证码", Type = 1 });
            }
        }
    }
}