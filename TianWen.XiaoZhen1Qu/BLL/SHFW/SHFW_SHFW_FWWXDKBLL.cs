﻿using System;
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
    public class SHFW_SHFW_FWWXDKBLL : BaseBLL, ISHFW_SHFW_FWWXDKBLL
    {
        public object SaveSHFW_SHFW_FWWXDKJBXX(JCXX jcxx, SHFW_SHFW_FWWXDKJBXX SHFW_SHFW_FWWXDKJBXX, List<PHOTOS> photos)
        {
            string[] photoNames = photos.Select(x => x.PHOTONAME).ToArray();
            DirectoryInfo TheFolder = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "/Areas/Business/Photos/");
            FileInfo[] fileinfos = TheFolder.GetFiles();
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM SHFW_SHFW_FWWXDKJBXX WHERE SHFW_SHFW_FWWXDKJBXXID='{0}'", SHFW_SHFW_FWWXDKJBXX.SHFW_SHFW_FWWXDKJBXXID));

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

                        SHFW_SHFW_FWWXDKJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(SHFW_SHFW_FWWXDKJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, SHFW_SHFW_FWWXDKJBXXID = SHFW_SHFW_FWWXDKJBXX.SHFW_SHFW_FWWXDKJBXXID } };
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        LoggerManager.Error("SHFW_SHFW_FWWXDKJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
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
                        SHFW_SHFW_FWWXDKJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(SHFW_SHFW_FWWXDKJBXX);
                        //照片全删全插
                        List<PHOTOS> old_photos = DAO.GetObjectList<PHOTOS>(string.Format("FROM PHOTOS WHERE JCXXID='{0}'", SHFW_SHFW_FWWXDKJBXX.JCXXID)).ToList();
                        foreach (var obj in old_photos)
                        {
                            DAO.Remove(obj);
                        }
                        foreach (var obj in photos)
                        {
                            obj.JCXXID = SHFW_SHFW_FWWXDKJBXX.JCXXID;
                            DAO.Save(obj);
                        }
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, SHFW_SHFW_FWWXDKJBXXID = SHFW_SHFW_FWWXDKJBXX.SHFW_SHFW_FWWXDKJBXXID } };
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        LoggerManager.Error("SHFW_SHFW_FWWXDKJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
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

        public object LoadSHFW_SHFW_FWWXDKJBXX(string SHFW_SHFW_FWWXDKJBXXID)
        {
            try
            {
                SHFW_SHFW_FWWXDKJBXX SHFW_SHFW_FWWXDKJBXX = DAO.GetObjectByID<SHFW_SHFW_FWWXDKJBXX>(SHFW_SHFW_FWWXDKJBXXID);
                if (SHFW_SHFW_FWWXDKJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(SHFW_SHFW_FWWXDKJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { SHFW_SHFW_FWWXDKJBXX = SHFW_SHFW_FWWXDKJBXX, JCXX = jcxx, Photos = GetPhtosByJCXXID(SHFW_SHFW_FWWXDKJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("SHFW_SHFW_FWWXDKJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
