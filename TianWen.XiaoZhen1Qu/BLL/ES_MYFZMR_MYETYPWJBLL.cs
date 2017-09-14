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
    public class ES_MYFZMR_MYETYPWJBLL : BaseBLL, IES_MYFZMR_MYETYPWJBLL
    {
        public object SaveES_MYFZMR_MYETYPWJJBXX(JCXX jcxx, ES_MYFZMR_MYETYPWJJBXX ES_MYFZMR_MYETYPWJJBXX, List<PHOTOS> photos)
        {
            string[] photoNames = photos.Select(x => x.PHOTONAME).ToArray();
            DirectoryInfo TheFolder = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "/Areas/Business/Photos/");
            FileInfo[] fileinfos = TheFolder.GetFiles();
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM ES_MYFZMR_MYETYPWJJBXX WHERE ES_MYFZMR_MYETYPWJJBXXID='{0}'", ES_MYFZMR_MYETYPWJJBXX.ES_MYFZMR_MYETYPWJJBXXID));

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

                        ES_MYFZMR_MYETYPWJJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(ES_MYFZMR_MYETYPWJJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, ES_MYFZMR_MYETYPWJJBXXID = ES_MYFZMR_MYETYPWJJBXX.ES_MYFZMR_MYETYPWJJBXXID } };
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        LoggerManager.Error("ES_MYFZMR_MYETYPWJJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
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
                        ES_MYFZMR_MYETYPWJJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(ES_MYFZMR_MYETYPWJJBXX);
                        //照片全删全插
                        List<PHOTOS> old_photos = DAO.GetObjectList<PHOTOS>(string.Format("FROM PHOTOS WHERE JCXXID='{0}'", ES_MYFZMR_MYETYPWJJBXX.JCXXID)).ToList();
                        foreach (var obj in old_photos)
                        {
                            DAO.Remove(obj);
                        }
                        foreach (var obj in photos)
                        {
                            obj.JCXXID = ES_MYFZMR_MYETYPWJJBXX.JCXXID;
                            DAO.Save(obj);
                        }
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, ES_MYFZMR_MYETYPWJJBXXID = ES_MYFZMR_MYETYPWJJBXX.ES_MYFZMR_MYETYPWJJBXXID } };
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        LoggerManager.Error("ES_MYFZMR_MYETYPWJJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
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

        public object LoadES_MYFZMR_MYETYPWJJBXX(string ES_MYFZMR_MYETYPWJJBXXID)
        {
            try
            {
                ES_MYFZMR_MYETYPWJJBXX ES_MYFZMR_MYETYPWJJBXX = DAO.GetObjectByID<ES_MYFZMR_MYETYPWJJBXX>(ES_MYFZMR_MYETYPWJJBXXID);
                if (ES_MYFZMR_MYETYPWJJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(ES_MYFZMR_MYETYPWJJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { ES_MYFZMR_MYETYPWJJBXX = ES_MYFZMR_MYETYPWJJBXX, JCXX = jcxx, Photos = GetPhtosByJCXXID(ES_MYFZMR_MYETYPWJJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("ES_MYFZMR_MYETYPWJJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
