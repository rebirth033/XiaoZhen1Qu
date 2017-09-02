using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.IO;
using NHibernate;
using TianWen.Framework.Log;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.BLL
{
    public class WZYJBLL: BaseBLL, IWZYJBLL
    {
        public object SaveWZYJ(JCXX jcxx, WZYJ wzyj, List<PHOTOS> photos)
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
                        List<PHOTOS> old_photos = DAO.GetObjectList<PHOTOS>(string.Format("FROM PHOTOS WHERE JCXXID='{0}'", jcxx.JCXXID)).ToList();
                        foreach (var obj in old_photos)
                        {
                            DAO.Remove(obj);
                        }
                    }
                    foreach (var obj in photos)
                    {
                        obj.JCXXID = jcxx.JCXXID;
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
                    
                    DAO.Save(jcxx);
                    DAO.Save(wzyj);
                    transaction.Commit();
                    return new { Result = EnResultType.Success, Message = "保存成功!", Value = new { JCXXID = jcxx.JCXXID, WZYJID = wzyj.WZYJID } };
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("FWCZJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new
                    {
                        Result = EnResultType.Failed,
                        Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!",
                        Type = 3
                    };
                }
            }
        }
    }
}
