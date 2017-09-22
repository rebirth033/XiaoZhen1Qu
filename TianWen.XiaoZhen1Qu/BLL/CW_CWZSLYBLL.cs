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
    public class CW_CWZSLYBLL : BaseBLL, ICW_CWZSLYBLL
    {
        public object SaveCW_CWZSLYJBXX(JCXX jcxx, CW_CWZSLYJBXX CW_CWZSLYJBXX, List<PHOTOS> photos)
        {
            string[] photoNames = photos.Select(x => x.PHOTONAME).ToArray();
            DirectoryInfo TheFolder = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "/Areas/Business/Photos/");
            FileInfo[] fileinfos = TheFolder.GetFiles();
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM CW_CWZSLYJBXX WHERE CW_CWZSLYJBXXID='{0}'", CW_CWZSLYJBXX.CW_CWZSLYJBXXID));

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

                        CW_CWZSLYJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(CW_CWZSLYJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, CW_CWZSLYJBXXID = CW_CWZSLYJBXX.CW_CWZSLYJBXXID } };
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        LoggerManager.Error("CW_CWZSLYJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
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
                        CW_CWZSLYJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(CW_CWZSLYJBXX);
                        //照片全删全插
                        List<PHOTOS> old_photos = DAO.GetObjectList<PHOTOS>(string.Format("FROM PHOTOS WHERE JCXXID='{0}'", CW_CWZSLYJBXX.JCXXID)).ToList();
                        foreach (var obj in old_photos)
                        {
                            DAO.Remove(obj);
                        }
                        foreach (var obj in photos)
                        {
                            obj.JCXXID = CW_CWZSLYJBXX.JCXXID;
                            DAO.Save(obj);
                        }
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, CW_CWZSLYJBXXID = CW_CWZSLYJBXX.CW_CWZSLYJBXXID } };
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        LoggerManager.Error("CW_CWZSLYJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
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

        public object LoadCW_CWZSLYJBXX(string CW_CWZSLYJBXXID)
        {
            try
            {
                CW_CWZSLYJBXX CW_CWZSLYJBXX = DAO.GetObjectByID<CW_CWZSLYJBXX>(CW_CWZSLYJBXXID);
                if (CW_CWZSLYJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(CW_CWZSLYJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { CW_CWZSLYJBXX = CW_CWZSLYJBXX, JCXX = jcxx, Photos = GetPhtosByJCXXID(CW_CWZSLYJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("CW_CWZSLYJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
