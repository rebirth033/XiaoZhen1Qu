using System;
using System.Data;
using NHibernate;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;
using TianWen.Framework.Log;
using System.Collections.Generic;
using System.IO;
using TianWen.XiaoZhen1Qu.Entities.Common;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net.Mail;

namespace TianWen.XiaoZhen1Qu.BLL
{
    public class YHJBXXBLL : BaseBLL, IYHJBXXBLL
    {
        public DataTable GetYHJBXXListByPage()
        {
            string sql = "select * from YHJBXX";
            return DAO.GetDataTable(sql);
        }

        public object CreateBasic(YHJBXX yhjbxx)
        {
            object o1 = DAO.Repository.ExecuteScalar(string.Format("SELECT COUNT(1) FROM YHJBXX WHERE YHM='{0}'", yhjbxx.YHM));

            if (o1 != null && int.Parse(o1.ToString()) > 0)
            {
                return new { Result = EnResultType.Failed, Message = "用户名已存在!", Type = 2 };
            }
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    yhjbxx.MM = EncryptionHelper.MD5Encrypt64(yhjbxx.MM);
                    yhjbxx.SQRQ = DateTime.Now;
                    DAO.Save(yhjbxx);
                    DAO.Repository.Session.Flush();
                    transaction.Commit();
                    return new { Result = EnResultType.Success, Message = "保存成功!", Value = new { YHID = yhjbxx.YHID } };
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("YHJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new
                    {
                        Result = EnResultType.Failed,
                        Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!",
                        Type = 3
                    };
                }
            }
        }

        //修改密码
        public object UpdatePassword(string MM, string SJ)
        {
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    YHJBXX yhjbxx = GetObjBySJ(SJ);
                    if (yhjbxx != null)
                    {
                        yhjbxx.MM = EncryptionHelper.MD5Encrypt64(MM);
                        DAO.Update(yhjbxx);
                        DAO.Repository.Session.Flush();
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功", Value = new { YHID = yhjbxx.YHID } };
                    }
                    else
                    {
                        return new { Result = EnResultType.Failed, Message = "手机号为空或不存在" };
                    }

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("YHJBXXBLL", "修改失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new
                    {
                        Result = EnResultType.Failed,
                        Message = "修改失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                    };
                }
            }
        }

        //修改用户名
        public object UpdateYHM(string YHID, string YHM)
        {
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    YHJBXX yhjbxx = DAO.GetObjectByID<YHJBXX>(YHID);
                    if (yhjbxx != null)
                    {
                        yhjbxx.YHM = YHM;
                        DAO.Update(yhjbxx);
                        DAO.Repository.Session.Flush();
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功", Value = new { YHID = yhjbxx.YHID } };
                    }
                    else
                    {
                        return new { Result = EnResultType.Failed, Message = "用户不存在" };
                    }

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("YHJBXXBLL", "修改失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new
                    {
                        Result = EnResultType.Failed,
                        Message = "修改失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                    };
                }
            }
        }

        public object UpdateSJ(string YHID, string SJ)
        {
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    YHJBXX yhjbxx = DAO.GetObjectByID<YHJBXX>(YHID);
                    if (yhjbxx != null)
                    {
                        yhjbxx.SJ = SJ;
                        DAO.Update(yhjbxx);
                        DAO.Repository.Session.Flush();
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功", Value = new { YHID = yhjbxx.YHID } };
                    }
                    else
                    {
                        return new { Result = EnResultType.Failed, Message = "用户不存在" };
                    }

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("YHJBXXBLL", "修改失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new
                    {
                        Result = EnResultType.Failed,
                        Message = "修改失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                    };
                }
            }
        }

        //修改头像
        public object UpdateTX(string YHID, string TX)
        {
            string copyfilename = TX == string.Empty ? TX : TX.Substring(TX.LastIndexOf('/') + 1, TX.Length - TX.LastIndexOf('/') - 1);

            string filepath = Common.GetRootPath() + @"\Areas\Business\Photos\" + YHID + @"\GRZL\";

            string copypath = Common.GetRootPath() + @"\Areas\Business\Css\images\";

            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    YHJBXX yhjbxx = DAO.GetObjectByID<YHJBXX>(YHID);
                    if (yhjbxx != null)
                    {
                        yhjbxx.TX = "TX.jpg";

                        DAO.Update(yhjbxx);

                        Bitmap bm = Common.ReadImageFile(copypath + copyfilename);

                        if (!Directory.Exists(filepath))
                        {
                            Directory.CreateDirectory(filepath);
                        }

                        bm.Save((filepath + "TX.jpg"), ImageFormat.Jpeg);
                        bm.Dispose();

                        DAO.Repository.Session.Flush();
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "上传头像成功", Value = new { YHID = yhjbxx.YHID } };
                    }
                    else
                    {
                        return new { Result = EnResultType.Failed, Message = "用户不存在" };
                    }

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("YHJBXXBLL", "修改失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new
                    {
                        Result = EnResultType.Failed,
                        Message = "修改失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                    };
                }
            }
        }

        public string GetObjByYHM(string YHM)
        {
            object o1 = DAO.Repository.ExecuteScalar(string.Format("SELECT COUNT(1) FROM YHJBXX WHERE YHM='{0}'", YHM));
            if (o1 != null && int.Parse(o1.ToString()) > 0)
                return o1.ToString();
            else
                return string.Empty;
        }

        public YHJBXX GetObjBySJ(string SJ)
        {
            IList<YHJBXX> list = DAO.Repository.GetObjectList<YHJBXX>(String.Format("FROM YHJBXX WHERE SJ='{0}'", SJ));
            if (list.Count > 0)
                return list[0];
            else
                return null;
        }

        public string GetObjByYHMOrSJ(string YHM)
        {
            object o1 = DAO.Repository.ExecuteScalar(string.Format("SELECT COUNT(1) FROM YHJBXX WHERE YHM='{0}' or SJ='{0}'", YHM));
            if (o1 != null && int.Parse(o1.ToString()) > 0)
                return o1.ToString();
            else
                return string.Empty;
        }

        public object GetObjByID(string YHID)
        {
            try
            {
                YHJBXX obj = DAO.GetObjectByID<YHJBXX>(YHID);
                return new
                {
                    Result = EnResultType.Success,
                    YHJBXX = obj
                };

            }
            catch (Exception ex)
            {
                LoggerManager.Error("YHJBXXBLL", "修改失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "修改失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }

        public object SendEmail(string YHID, string YX)
        {
            try
            {
                
                YHJBXX yhjbxx = DAO.GetObjectByID<YHJBXX>(YHID);
                
                if (yhjbxx != null)
                {
                    MailMessage msg = new MailMessage();
                    msg.To.Add(YX);
                    msg.From = new MailAddress("980381266@qq.com", "信息小镇", System.Text.Encoding.UTF8);
                    msg.Subject = "邮件认证 - 信息小镇";
                    msg.SubjectEncoding = System.Text.Encoding.UTF8;//邮件标题编码 
                    msg.Body = "亲爱的信息小镇用户 " + yhjbxx.YHM + @"：请点击以下链接完成邮件认证（如无法打开请把此链接复制粘贴到浏览器打开）
认证成功后可获得 50 个信用。信用值越高，每天可发布的信息数量越多，认证后的邮箱可用于登录和找回密码。\n\r58同城邮件中心
\n\r2017.07.26";//邮件内容  
                    msg.BodyEncoding = System.Text.Encoding.UTF8;//邮件内容编码 
                    msg.IsBodyHtml = true;//是否是HTML邮件
                    msg.Priority = MailPriority.High;//邮件优先级 

                    SmtpClient client = new SmtpClient();
                    client.Credentials = new System.Net.NetworkCredential("980381266@qq.com", "vbfhologcvanbfch");//邮箱用户名，smtp服务授权密码
                    client.Host = "smtp.qq.com";//SMTP服务器地址  
                    client.Port = 587;//SMTP端口，QQ邮箱填写587
                    client.EnableSsl = true;//启用SSL加密  
                    object userState = msg;
                    client.SendAsync(msg, userState); 
                    return new { Result = EnResultType.Success, Message = "发送成功", Value = new { YHID = yhjbxx.YHID } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "用户不存在" };
                }

            }
            catch (Exception ex)
            {
                LoggerManager.Error("YHJBXXBLL", "修改失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "修改失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
