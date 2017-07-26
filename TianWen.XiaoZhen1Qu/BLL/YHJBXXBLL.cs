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
using System.Text;

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

                    string url = "http://www.infotownlet.com/email/?para=E7D7D47927E72493FAAF099BF4087DD2|1ccefa740ADD0684184C8D35775397A253AD13F3|C095A3368A45D8E9EEA845F430F12B92116ADE0C645041FD|0&utm_source=email-interaction&utm_medium=attestation-email&utm_campaign=attestation-email";
                    StringBuilder sb = new StringBuilder();
                    sb.AppendFormat(@"<div style='width: 650px; margin-left: 27%; height: 600px; border: 1px solid #bce9f6; '>
                                <div style='background-color: #5bc0de; width: 100%; height: 80px; vertical-align: middle;'>
                                    <div style='float: left; width: 120px; margin-left: 50px; margin-top: 5px;'>
                                        <img style='width: 100%; text-align: center; color: white; font-size: 25px; float: left;' src='http://localhost/XiaoZhen1Qu/Areas/Business/Css/images/logo.png' />
                                        <span style='width: 100%; color:#fff; text-align: center; font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif; color: white; font-size: 17px; float: left; cursor: default;'>infotownlet.com</span>
                                    </div>
                                </div>
                                <div style='width: 600px; text-align: left; height: 520px; font-size: 14px; padding: 30px 20px; line-height: 24px; word-wrap: break-word; font-family:宋体'>
                                    <p style='margin-bottom: 10px;'>亲爱的信息小镇用户 {0}：</p>
                                    <p>
                                        &nbsp;&nbsp;&nbsp;&nbsp;请点击以下链接完成邮件认证（如无法打开请把此链接复制粘贴到浏览器打开）<br />
                                        认证成功后可获得 50 个信用。信用值越高，每天可发布的信息数量越多，认证后的邮箱<br />
                                        可用于登录和找回密码。<br /><br />
                                    </p>
                                    <p><a style='color: #5bc0de; font-size: 16px; cursor: pointer'>{1}<br /><br /></a></p>
                                    <p style='text-align: right'>信息小镇邮件中心</p>
                                    <p style='text-align: right'> {2}</p>
                                </div>
                                </div>'", yhjbxx.YHM, url, DateTime.Now.ToShortDateString());
                    msg.Body = sb.ToString();
                    msg.BodyEncoding = Encoding.UTF8;//邮件内容编码 
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
