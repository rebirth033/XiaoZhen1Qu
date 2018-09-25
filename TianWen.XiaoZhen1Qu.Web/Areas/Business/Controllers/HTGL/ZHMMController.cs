using System.Text;
using System.Web.Mvc;
using System.Xml;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Web.Areas.Business.Common;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class ZHMMController : BaseController
    {
        public IYHZCBLL YHZCBLL { get; set; }
        public ActionResult ZHMM()
        {
            return View();
        }

        public JsonResult QRZH()
        {
            string Value = Request["Value"];
            string TXYZM = Request["TXYZM"];
            if (Session["TXCheckCode"] != null)
            {
                string checkcode = Session["TXCheckCode"].ToString();
                if (TXYZM == checkcode)
                {
                    string result = YHZCBLL.GetObjByYHMOrSJ(Value);
                    if (!string.IsNullOrEmpty(result))
                    {
                        return Json(new { Result = EnResultType.Success, Message = "验证成功" });
                    }
                    else
                    {
                        return Json(new { Result = EnResultType.Failed, Message = "账户不存在，请重新输入", Type = 2 });
                    }
                }
                else
                {
                    return Json(new { Result = EnResultType.Failed, Message = "验证码错误，请重新输入", Type = 1 });
                }
            }
            else
            {
                return Json(new { Result = EnResultType.Failed, Message = "验证码不存在", Type = 1 });
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
                    Session["SJ"] = SJ;
                    return Json(new { Result = EnResultType.Success, Message = "验证成功" });
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

        public JsonResult YZSJ()
        {
            string SJ = Request["SJ"];
            string DQYHM = Request["DQYHM"];
            YHJBXX result = YHZCBLL.GetYHJBXXByYHMOrSJ(DQYHM);
            if (result != null && SJ == result.SJ)
            {
                Session["SJ"] = result.SJ;
                return Json(new { Result = EnResultType.Success, Message = "验证成功" });
            }
            else
            {
                return Json(new { Result = EnResultType.Failed, Message = "手机号与用户名不匹配，请重新输入", Type = 2 });
            }
        }

        public JsonResult CZMM()
        {
            string MM = Request["MM"];
            string SJ = Session["SJ"].ToString();
            object result = YHZCBLL.UpdatePassword(MM, SJ);
            return Json(result);
        }

        public JsonResult YZMQR()
        {
            string YZM = Request["YZM"];
            if (Session["CheckCode"] != null)
            {
                string checkcode = Session["CheckCode"].ToString();
                if (YZM == checkcode)
                {
                    return Json(new { Result = EnResultType.Success, Message = "验证成功" });
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