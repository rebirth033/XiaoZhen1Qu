using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NHibernate;
using TianWen.Framework.Log;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.BLL
{
    public class BZZXBLL : BaseBLL, IBZZXBLL
    {
        public object SaveTJWT(BZZX_TJWT tjwt, List<PHOTOS> photos)
        {
            string[] photoNames = photos.Select(x => x.PHOTONAME).ToArray();
            DirectoryInfo TheFolder = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "/Areas/Business/Photos/");
            FileInfo[] fileinfos = TheFolder.GetFiles();
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (photos.Count > 0)
                    {
                        //照片全删全插
                        List<PHOTOS> old_photos = DAO.GetObjectList<PHOTOS>(string.Format("FROM PHOTOS WHERE JCXXID='{0}'", tjwt.ID)).ToList();
                        foreach (var obj in old_photos)
                        {
                            DAO.Remove(obj);
                        }
                    }
                    foreach (var obj in photos)
                    {
                        obj.JCXXID = tjwt.ID;
                        DAO.Save(obj);
                    }

                    if (photos.Count > 0)
                    {
                        //删除多余照片文件
                        foreach (FileInfo fileobj in fileinfos)
                        {
                            if (!photoNames.Contains(fileobj.Name))
                                File.Delete(AppDomain.CurrentDomain.BaseDirectory + "/Areas/Business/Photos/" + fileobj.Name);
                        }
                    }

                    DAO.Save(tjwt);
                    transaction.Commit();
                    return new { Result = EnResultType.Success, Message = "提交成功，感谢您的反馈，我们会在3天内回复您!", Value = new { ID = tjwt.ID } };
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("FC_ZZFJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }
        public object SaveWZJY(BZZX_WZJY wzjy, List<PHOTOS> photos)
        {
            string[] photoNames = photos.Select(x => x.PHOTONAME).ToArray();
            DirectoryInfo TheFolder = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "/Areas/Business/Photos/");
            FileInfo[] fileinfos = TheFolder.GetFiles();
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (photos.Count > 0)
                    {
                        //照片全删全插
                        List<PHOTOS> old_photos = DAO.GetObjectList<PHOTOS>(string.Format("FROM PHOTOS WHERE JCXXID='{0}'", wzjy.ID)).ToList();
                        foreach (var obj in old_photos)
                        {
                            DAO.Remove(obj);
                        }
                    }
                    foreach (var obj in photos)
                    {
                        obj.JCXXID = wzjy.ID;
                        DAO.Save(obj);
                    }

                    if (photos.Count > 0)
                    {
                        //删除多余照片文件
                        foreach (FileInfo fileobj in fileinfos)
                        {
                            if (!photoNames.Contains(fileobj.Name))
                                File.Delete(AppDomain.CurrentDomain.BaseDirectory + "/Areas/Business/Photos/" + fileobj.Name);
                        }
                    }

                    DAO.Save(wzjy);
                    transaction.Commit();
                    return new { Result = EnResultType.Success, Message = "提交成功，感谢您的建议!", Value = new { ID = wzjy.ID } };
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("FC_ZZFJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }
    }
}
