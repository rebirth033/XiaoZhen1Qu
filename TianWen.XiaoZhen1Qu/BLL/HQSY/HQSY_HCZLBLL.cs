using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using NHibernate;
using TianWen.Framework.Log;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.BLL
{
    public class HQSY_HCZLBLL : BaseBLL, IHQSY_HCZLBLL
    {
        public object SaveHQSY_HCZLJBXX(JCXX jcxx, HQSY_HCZLJBXX HQSY_HCZLJBXX, List<PHOTOS> photos)
        {
            string[] photoNames = photos.Select(x => x.PHOTONAME).ToArray();
            DirectoryInfo TheFolder = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "/Areas/Business/Photos/");
            FileInfo[] fileinfos = TheFolder.GetFiles();
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM HQSY_HCZLJBXX WHERE HQSY_HCZLJBXXID='{0}'", HQSY_HCZLJBXX.HQSY_HCZLJBXXID));

            if (dt.Rows.Count > 0)
            {
                using (ITransaction transaction = DAO.BeginTransaction())
                {
                    try
                    {
                        if (photos.Count > 0)
                        {
                            //照片全删全插
                            List<PHOTOS> old_photos = DAO.GetObjectList<PHOTOS>(string.Format("FROM PHOTOS WHERE JCXXID='{0}'", dt.Rows[0]["JCXXID"])).ToList();
                            foreach (var obj in old_photos)
                            {
                                DAO.Remove(obj);
                            }
                        }
                        foreach (var obj in photos)
                        {
                            obj.JCXXID = dt.Rows[0]["JCXXID"].ToString();
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

                        HQSY_HCZLJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(HQSY_HCZLJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, HQSY_HCZLJBXXID = HQSY_HCZLJBXX.HQSY_HCZLJBXXID } };
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        LoggerManager.Error("HQSY_HCZLJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                        return new
                        {
                            Result = EnResultType.Failed,
                            Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!",
                            Type = 3
                        };
                    }
                }
            }
            else
            {
                using (ITransaction transaction = DAO.BeginTransaction())
                {
                    try
                    {
                        HQSY_HCZLJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(HQSY_HCZLJBXX);
                        //照片全删全插
                        List<PHOTOS> old_photos = DAO.GetObjectList<PHOTOS>(string.Format("FROM PHOTOS WHERE JCXXID='{0}'", HQSY_HCZLJBXX.JCXXID)).ToList();
                        foreach (var obj in old_photos)
                        {
                            DAO.Remove(obj);
                        }
                        foreach (var obj in photos)
                        {
                            obj.JCXXID = HQSY_HCZLJBXX.JCXXID;
                            DAO.Save(obj);
                        }
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, HQSY_HCZLJBXXID = HQSY_HCZLJBXX.HQSY_HCZLJBXXID } };
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        LoggerManager.Error("HQSY_HCZLJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
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

        public object LoadHQSY_HCZLJBXX(string HQSY_HCZLJBXXID)
        {
            try
            {
                HQSY_HCZLJBXX HQSY_HCZLJBXX = DAO.GetObjectByID<HQSY_HCZLJBXX>(HQSY_HCZLJBXXID);
                if (HQSY_HCZLJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(HQSY_HCZLJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { HQSY_HCZLJBXX = HQSY_HCZLJBXX, JCXX = jcxx, Photos = GetPhtosByJCXXID(HQSY_HCZLJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("HQSY_HCZLJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
