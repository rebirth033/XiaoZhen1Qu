﻿using System;
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
using System.Linq;
using System.Net.Mail;
using System.Text;

namespace TianWen.XiaoZhen1Qu.BLL
{
    public class YHZCBLL : BaseBLL, IYHZCBLL
    {
        public DataTable GetYHJBXXListByPage()
        {
            string sql = "SELECT * FROM YHJBXX";
            return DAO.GetDataTable(sql);
        }

        public string ValidateSJ(string SJ)
        {
            object o1 = DAO.Repository.ExecuteScalar(string.Format("SELECT COUNT(1) FROM YHJBXX WHERE SJ='{0}'", SJ));

            if (o1 != null && int.Parse(o1.ToString()) > 0)
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }

        public object CreateBasic(YHJBXX YHJBXX)
        {
            object o1 = DAO.Repository.ExecuteScalar(string.Format("SELECT COUNT(1) FROM YHJBXX WHERE YHM='{0}'", YHJBXX.YHM));

            if (o1 != null && int.Parse(o1.ToString()) > 0)
            {
                LoggerManager.Info("用户创建", "用户：" + YHJBXX.YHM + "用户名已存在");
                return new { Result = EnResultType.Failed, Message = "用户名已存在!", Type = 2 };
            }
            o1 = DAO.Repository.ExecuteScalar(string.Format("SELECT COUNT(1) FROM YHJBXX WHERE SJ='{0}'", YHJBXX.SJ));

            if (o1 != null && int.Parse(o1.ToString()) > 0)
            {
                LoggerManager.Info("用户创建", "手机号：" + YHJBXX.SJ + "该手机号已注册过");
                return new { Result = EnResultType.Failed, Message = "该手机号已注册过!", Type = 4 };
            }
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    YHJBXX.MM = EncryptionHelper.MD5Encrypt64(YHJBXX.MM);
                    YHJBXX.SQRQ = DateTime.Now;
                    DAO.Save(YHJBXX);
                    DAO.Repository.Session.Flush();
                    transaction.Commit();
                    LoggerManager.Info("用户创建", "用户：" + YHJBXX.YHM + "创建成功");
                    return new { Result = EnResultType.Success, Message = "保存成功!", Value = new { YHID = YHJBXX.YHID } };
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Info("用户创建", "用户：" + YHJBXX.YHM + "创建失败");
                    return new
                    {
                        Result = EnResultType.Failed,
                        Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!",
                        Type = 3
                    };
                }
            }
        }

        public YHJBXX CreateBasicBySJ(string SJ,string MM)
        {
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                YHJBXX newobj = new YHJBXX();
                try
                {
                    newobj.MM = EncryptionHelper.MD5Encrypt64(MM);
                    Random random = new Random();
                    newobj.YHM = "风铃用户" + SJ.Substring(0, 7) + random.Next(100000, 999999).ToString();
                    newobj.SQRQ = DateTime.Now;
                    newobj.SJ = SJ;
                    DAO.Save(newobj);
                    DAO.Repository.Session.Flush();
                    transaction.Commit();
                    LoggerManager.Info("用户创建", "用户：" + newobj.YHM + "创建成功");
                    return newobj;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Info("用户创建", "用户：" + newobj.YHM + "创建失败");
                    return null;
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
                    YHJBXX YHJBXX = GetObjBySJ(SJ);
                    if (YHJBXX != null)
                    {
                        YHJBXX.MM = EncryptionHelper.MD5Encrypt64(MM);
                        DAO.Update(YHJBXX);
                        DAO.Repository.Session.Flush();
                        transaction.Commit();
                        LoggerManager.Info("修改密码", "用户：" + YHJBXX.YHM + "修改密码成功");
                        return new { Result = EnResultType.Success, Message = "修改成功", Value = new { YHID = YHJBXX.YHID } };
                    }
                    else
                    {
                        LoggerManager.Info("修改密码", "手机号：" + SJ + "修改密码失败,手机号为空或不存在");
                        return new { Result = EnResultType.Failed, Message = "手机号为空或不存在" };
                    }

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("YHJBXXBLL", "修改失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    LoggerManager.Info("修改密码", "手机号：" + SJ + "修改密码失败【" + ex.InnerException + "】");
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
                    YHJBXX YHJBXX = DAO.GetObjectByID<YHJBXX>(YHID);
                    if (YHJBXX != null)
                    {
                        YHJBXX.YHM = YHM;
                        DAO.Update(YHJBXX);
                        DAO.Repository.Session.Flush();
                        transaction.Commit();
                        LoggerManager.Info("修改用户名", "用户：" + YHM + "修改用户名成功");
                        return new { Result = EnResultType.Success, Message = "修改成功", Value = new { YHID = YHJBXX.YHID } };
                    }
                    else
                    {
                        LoggerManager.Info("修改用户名", "用户：" + YHM + "修改用户名失败,用户不存在");
                        return new { Result = EnResultType.Failed, Message = "用户不存在" };
                    }

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Info("修改用户名", "用户：" + YHM + "修改用户名失败:" + ex.InnerException);
                    return new
                    {
                        Result = EnResultType.Failed,
                        Message = "修改失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                    };
                }
            }
        }

        //修改QQ
        public object UpdateQQ(string YHID, string QQ)
        {
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    YHJBXX YHJBXX = DAO.GetObjectByID<YHJBXX>(YHID);
                    if (YHJBXX != null)
                    {
                        YHJBXX.QQ = QQ;
                        DAO.Update(YHJBXX);
                        DAO.Repository.Session.Flush();
                        transaction.Commit();
                        LoggerManager.Info("修改QQ", "用户：" + YHJBXX.YHM + "修改QQ成功");
                        return new { Result = EnResultType.Success, Message = "修改成功", Value = new { YHID = YHJBXX.YHID } };
                    }
                    else
                    {
                        LoggerManager.Info("修改QQ", "用户：" + YHID + "修改QQ失败,用户不存在");
                        return new { Result = EnResultType.Failed, Message = "用户不存在" };
                    }

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Info("修改QQ", "用户：" + YHID + "修改QQ失败:" + ex.InnerException);
                    return new
                    {
                        Result = EnResultType.Failed,
                        Message = "修改失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                    };
                }
            }
        }

        //绑定手机号
        public object UpdateSJ(string YHID, string SJ)
        {
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    YHJBXX YHJBXX = DAO.GetObjectByID<YHJBXX>(YHID);
                    if (YHJBXX != null)
                    {
                        YHJBXX.SJ = SJ;
                        DAO.Update(YHJBXX);
                        DAO.Repository.Session.Flush();
                        transaction.Commit();
                        LoggerManager.Info("绑定手机号", "用户：" + YHID + "绑定手机号成功");
                        return new { Result = EnResultType.Success, Message = "绑定成功", Value = new { YHID = YHJBXX.YHID } };
                    }
                    else
                    {
                        LoggerManager.Info("绑定手机号", "用户：" + YHID + "绑定手机号失败,用户不存在");
                        return new { Result = EnResultType.Failed, Message = "用户不存在" };
                    }

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Info("绑定手机号", "用户：" + YHID + "绑定手机号失败:" + ex.InnerException);
                    return new
                    {
                        Result = EnResultType.Failed,
                        Message = "绑定失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                    };
                }
            }
        }

        //修改微博
        public object UpdateWB(string YHID, string WB)
        {
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    YHJBXX YHJBXX = DAO.GetObjectByID<YHJBXX>(YHID);
                    if (YHJBXX != null)
                    {
                        YHJBXX.WB = WB;
                        DAO.Update(YHJBXX);
                        DAO.Repository.Session.Flush();
                        transaction.Commit();
                        LoggerManager.Info("修改微博", "用户：" + YHID + "修改微博成功");
                        return new { Result = EnResultType.Success, Message = "修改成功", Value = new { YHID = YHJBXX.YHID } };
                    }
                    else
                    {
                        LoggerManager.Info("修改微博", "用户：" + YHID + "修改微博失败,用户不存在");
                        return new { Result = EnResultType.Failed, Message = "用户不存在" };
                    }

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Info("修改微博", "用户：" + YHID + "修改微博失败：" + ex.InnerException);
                    return new
                    {
                        Result = EnResultType.Failed,
                        Message = "修改失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                    };
                }
            }
        }

        //修改邮箱
        public object UpdateYX(string YHID, string YX)
        {
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    YHJBXX YHJBXX = DAO.GetObjectByID<YHJBXX>(YHID);
                    if (YHJBXX != null)
                    {
                        YHJBXX.DZYX = YX;
                        DAO.Update(YHJBXX);
                        DAO.Repository.Session.Flush();
                        transaction.Commit();
                        LoggerManager.Info("修改邮箱", "用户：" + YHID + "修改邮箱成功");
                        return new { Result = EnResultType.Success, Message = "修改成功", Value = new { YHID = YHJBXX.YHID } };
                    }
                    else
                    {
                        LoggerManager.Info("修改邮箱", "用户：" + YHID + "修改邮箱失败,用户不存在");
                        return new { Result = EnResultType.Failed, Message = "用户不存在" };
                    }

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Info("修改邮箱", "用户：" + YHID + "修改邮箱失败:" + ex.InnerException);
                    return new
                    {
                        Result = EnResultType.Failed,
                        Message = "修改失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                    };
                }
            }
        }

        //修改微信
        public object UpdateWX(string YHID, string WX)
        {
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    YHJBXX YHJBXX = DAO.GetObjectByID<YHJBXX>(YHID);
                    if (YHJBXX != null)
                    {
                        YHJBXX.WX = WX;
                        DAO.Update(YHJBXX);
                        DAO.Repository.Session.Flush();
                        transaction.Commit();
                        LoggerManager.Info("修改微信", "用户：" + YHID + "修改微信成功");
                        return new { Result = EnResultType.Success, Message = "修改成功", Value = new { YHID = YHJBXX.YHID } };
                    }
                    else
                    {
                        LoggerManager.Info("修改微信", "用户：" + YHID + "修改微信失败,用户不存在");
                        return new { Result = EnResultType.Failed, Message = "用户不存在" };
                    }

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Info("修改微信", "用户：" + YHID + "修改微信失败:" + ex.InnerException);
                    return new
                    {
                        Result = EnResultType.Failed,
                        Message = "修改失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                    };
                }
            }
        }

        //修改密码
        public object MMCZ(string YHID, string JMM, string XMM)
        {
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    YHJBXX YHJBXX = DAO.GetObjectByID<YHJBXX>(YHID);
                    if (YHJBXX != null)
                    {
                        if (YHJBXX.MM == EncryptionHelper.MD5Encrypt64(JMM))
                        {
                            YHJBXX.MM = EncryptionHelper.MD5Encrypt64(XMM);
                            DAO.Update(YHJBXX);
                            DAO.Repository.Session.Flush();
                            transaction.Commit();
                            LoggerManager.Info("修改密码", "用户：" + YHID + "修改密码成功");
                            return new { Result = EnResultType.Success, Message = "修改成功", Value = new { YHID = YHJBXX.YHID } };
                        }
                        else
                        {
                            LoggerManager.Info("修改密码", "用户：" + YHID + "修改密码失败,旧密码不正确");
                            return new { Result = EnResultType.Failed, Message = "旧密码不正确", Type = 2 };
                        }
                    }
                    else
                    {
                        LoggerManager.Info("修改密码", "用户：" + YHID + "修改密码失败，用户不存在");
                        return new { Result = EnResultType.Failed, Message = "用户不存在", Type = 1 };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Info("修改密码", "用户：" + YHID + "修改密码失败:" + ex.InnerException);
                    return new
                    {
                        Result = EnResultType.Failed,
                        Message = "修改失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!",
                        Type = 1
                    };
                }
            }
        }

        //修改邮箱验证码
        public object UpdateYXYZM(string YHID, string YXYZM)
        {
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    YHJBXX YHJBXX = DAO.GetObjectByID<YHJBXX>(YHID);
                    if (YHJBXX != null)
                    {
                        YHJBXX.DZYXYZM = YXYZM;
                        DAO.Update(YHJBXX);
                        DAO.Repository.Session.Flush();
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功", Value = new { YHID = YHJBXX.YHID } };
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

            string copypath = Common.GetRootPath() + @"\Areas\Business\Css\images\HTGL\";

            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    YHJBXX YHJBXX = DAO.GetObjectByID<YHJBXX>(YHID);
                    if (YHJBXX != null)
                    {
                        YHJBXX.TX = "TX.jpg";

                        DAO.Update(YHJBXX);

                        Bitmap bm = Common.ReadImageFile(copypath + copyfilename);

                        if (!Directory.Exists(filepath))
                        {
                            Directory.CreateDirectory(filepath);
                        }

                        bm.Save((filepath + "TX.jpg"), ImageFormat.Jpeg);
                        bm.Dispose();

                        DAO.Repository.Session.Flush();
                        transaction.Commit();
                        LoggerManager.Info("修改头像", "用户：" + YHID + "上传头像成功");
                        return new { Result = EnResultType.Success, Message = "上传头像成功", Value = new { YHID = YHJBXX.YHID } };
                    }
                    else
                    {
                        LoggerManager.Info("修改头像", "用户：" + YHID + "修改头像失败,用户不存在");
                        return new { Result = EnResultType.Failed, Message = "用户不存在" };
                    }

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Info("修改头像", "用户：" + YHID + "修改头像失败:" + ex.InnerException);
                    return new
                    {
                        Result = EnResultType.Failed,
                        Message = "修改失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                    };
                }
            }
        }

        //修改头像
        public void UpdateTX(string YHID)
        {
            YHJBXX YHJBXX = DAO.GetObjectByID<YHJBXX>(YHID);
            if (YHJBXX != null)
            {
                YHJBXX.TX = "TX.jpg";

                DAO.Update(YHJBXX);
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

        public YHJBXX GetYHJBXXByYHMOrSJ(string Value)
        {
            IList<YHJBXX> list = DAO.Repository.GetObjectList<YHJBXX>(String.Format("FROM YHJBXX WHERE YHM='{0}' or SJ='{0}'", Value));
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
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "修改失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }

        //发送邮件
        public object SendEmail(string YHID, string YX, string CheckCode)
        {
            try
            {
                YHJBXX YHJBXX = DAO.GetObjectByID<YHJBXX>(YHID);
                if (YHJBXX != null)
                {
                    UpdateYXYZM(YHID, EncryptionHelper.MD5Encrypt64(CheckCode));
                    MailMessage msg = new MailMessage();
                    msg.To.Add(YX);
                    msg.From = new MailAddress(YX, "风铃网", Encoding.UTF8);
                    msg.Subject = "邮件认证 - 风铃网";
                    msg.SubjectEncoding = Encoding.UTF8;//邮件标题编码 
                    string url = "http://www.915fl.com" + Common.GetVirtualRootPath() + "/GRZL/YXYZCG?para=" + EncryptionHelper.MD5Encrypt64(YHID) + "|" + EncryptionHelper.MD5Encrypt64(CheckCode);
                    StringBuilder sb = new StringBuilder();
                    sb.AppendFormat(@"<div style='width: 650px; margin-left: 27%; height: 600px; border: 1px solid #bc6ba6; '>
                                <div style='background-color: #bc6ba6; width: 100%; height: 80px; vertical-align: middle;'>
                                    <div style='float: left; width: 120px; margin-left: 50px; margin-top: 5px;'>
                                        <img style='width: 100%; text-align: center; color: white; font-size: 25px; float: left;' src='http://www.915fl.com/Areas/Business/Css/images/logo.png' />
                                        <span style='width: 100%; color:#fff; text-align: center; font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif; color: white; font-size: 17px; float: left; cursor: default;'>915fl.com</span>
                                    </div>
                                </div>
                                <div style='width: 600px; text-align: left; height: 520px; font-size: 14px; padding: 30px 20px; line-height: 24px; word-wrap: break-word; font-family:宋体'>
                                    <p style='margin-bottom: 10px;'>亲爱的风铃网用户 {0}：</p>
                                    <p>
                                        &nbsp;&nbsp;&nbsp;&nbsp;请点击以下链接完成邮件认证（如无法打开请把此链接复制粘贴到浏览器打开）<br />
                                        认证成功后可获得 50 个信用。信用值越高，每天可发布的信息数量越多，认证后的邮箱<br />
                                        可用于登录和找回密码。<br /><br />
                                    </p>
                                    <p><a style='color: #bc6ba6; font-size: 16px; cursor: pointer' href='{1}' target='_blank'>{1}<br /><br /></a></p>
                                    <p style='text-align: right'>风铃网邮件中心</p>
                                    <p style='text-align: right'> {2}</p>
                                </div>
                                </div>'", YHJBXX.YHM, url, DateTime.Now.ToString("yyyy年MM月dd日"));
                    msg.Body = sb.ToString();
                    msg.BodyEncoding = Encoding.UTF8;//邮件内容编码 
                    msg.IsBodyHtml = true;//是否是HTML邮件
                    msg.Priority = MailPriority.High;//邮件优先级 

                    SmtpClient client = new SmtpClient();
                    client.Credentials = new System.Net.NetworkCredential(YX, "mmyqtztqjxwebfjf");//邮箱用户名，smtp服务授权密码,需要开启qq邮箱smtp服务
                    client.Host = "smtp.qq.com";//SMTP服务器地址  
                    client.Port = 587;//SMTP端口，QQ邮箱填写587
                    client.EnableSsl = true;//启用SSL加密  
                    object userState = msg;
                    client.SendAsync(msg, userState);
                    LoggerManager.Info("发送邮件", "用户：" + YHID + "发送邮件成功");
                    return new { Result = EnResultType.Success, Message = "发送成功", Value = new { YHID = YHJBXX.YHID } };
                }
                else
                {
                    LoggerManager.Info("发送邮件", "用户：" + YHID + "发送邮件失败,用户不存在");
                    return new { Result = EnResultType.Failed, Message = "用户不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Info("发送邮件", "用户：" + YHID + "发送邮件失败:" + ex.InnerException);
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "修改失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
        //用户验证
        public object YHYZ(string YHID_Cryptograph, string CheckCode_Cryptograph, string YX)
        {
            try
            {
                List<YHJBXX> YHJBXXs = DAO.GetObjectList<YHJBXX>(string.Format("FROM YHJBXX")).ToList();
                foreach (var YHJBXX in YHJBXXs)
                {
                    if (EncryptionHelper.MD5Encrypt64(YHJBXX.YHID) == YHID_Cryptograph)
                    {
                        if (YHJBXX.DZYXYZM == CheckCode_Cryptograph)
                        {
                            UpdateYX(YHJBXX.YHID, YX);
                            return new { Result = EnResultType.Success, Message = "验证成功", Value = new { YHM = YHJBXX.YHM, DZYX = YHJBXX.DZYX } };
                        }
                        else
                        {
                            return new { Result = EnResultType.Failed, Message = "验证失败,链接不正确" };
                        }
                    }
                }
                return new { Result = EnResultType.Failed, Message = "验证失败,链接不正确" };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("YHZCBLL", "验证失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "验证失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
