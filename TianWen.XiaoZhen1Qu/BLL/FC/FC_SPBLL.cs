﻿using System;
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
    public class FC_SPBLL : BaseBLL, IFC_SPBLL
    {
        public object SaveSPJBXX(JCXX jcxx, FC_SPJBXX SPJBXX, List<PHOTOS> photos)
        {
            string[] photoNames = photos.Select(x => x.PHOTONAME).ToArray();
            DirectoryInfo TheFolder = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "/Areas/Business/Photos/");
            FileInfo[] fileinfos = TheFolder.GetFiles();
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM FC_SPJBXX WHERE FC_SPJBXXID='{0}'", SPJBXX.FC_SPJBXXID));

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

                        SPJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(SPJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, SPJBXXID = SPJBXX.FC_SPJBXXID } };
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        LoggerManager.Error("FC_SPJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
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
                        SPJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(SPJBXX);
                        //照片全删全插
                        List<PHOTOS> old_photos = DAO.GetObjectList<PHOTOS>(string.Format("FROM PHOTOS WHERE JCXXID='{0}'", SPJBXX.JCXXID)).ToList();
                        foreach (var obj in old_photos)
                        {
                            DAO.Remove(obj);
                        }
                        foreach (var obj in photos)
                        {
                            obj.JCXXID = SPJBXX.JCXXID;
                            DAO.Save(obj);
                        }
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, SPJBXXID = SPJBXX.FC_SPJBXXID } };
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        LoggerManager.Error("FC_SPJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
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

        public object LoadFC_SPJBXX(string FC_SPJBXXID)
        {
            try
            {
                FC_SPJBXX SPJBXX = DAO.GetObjectByID<FC_SPJBXX>(FC_SPJBXXID);
                if (SPJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(SPJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { FC_SPJBXX = SPJBXX, JCXX = jcxx, Photos = GetPhtosByJCXXID(SPJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }

            }
            catch (Exception ex)
            {
                LoggerManager.Error("FC_ZZFJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}