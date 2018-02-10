﻿using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.Nhibernate.TianWen.Nhibernate.Repository;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class BaseController : Controller
    {
        public static IRepository DataFactory = DbFactory.Instance.GetRepository();

        public void GetSession()
        {
            if (Session["XZQ"] == null)
            {
                ViewData["XZQ"] = "北京";
                Session["XZQ"] = "北京";
                Session["XZQDM"] = "28";
            }
            else
            {
                ViewData["XZQ"] = Session["XZQ"];
            }
            ViewData["YHM"] = Session["YHM"];
        }

        public List<PHOTOS> GetTP(string fwzp)
        {
            List<PHOTOS> photos = new List<PHOTOS>();
            string[] zps = fwzp.Split(',');
            foreach (var zp in zps)
            {
                PHOTOS photo = new PHOTOS();
                photo.PHOTOURL = zp;
                photo.PHOTONAME = photo.PHOTOURL.Substring(photo.PHOTOURL.LastIndexOf('/') + 1, photo.PHOTOURL.Length - photo.PHOTOURL.LastIndexOf('/') - 1);
                photos.Add(photo);
            }
            return photos;
        }

        public JCXX CreateJCXX(YHJBXX yhjbxx, string json)
        {
            JCXX jcxx = JsonHelper.ConvertJsonToObject<JCXX>(json);
            jcxx.YHID = yhjbxx.YHID;
            jcxx.LLCS = 0;
            jcxx.STATUS = 1;
            jcxx.ZXGXSJ = DateTime.Now;
            jcxx.CJSJ = DateTime.Now;
            jcxx.LXDZ = yhjbxx.TXDZ;
            jcxx.DH = Session["XZQ"] + "-" + GetLBQCByLBID(jcxx.LBID);
            jcxx.XZQDM = int.Parse(Session["XZQDM"].ToString());
            return jcxx;
        }

        public string GetLBQCByLBID(int LBID)
        {
            CODES_XXLB xl = DataFactory.GetObjectById<CODES_XXLB>(LBID);
            CODES_XXLB dl = DataFactory.GetObjectById<CODES_XXLB>(xl.PARENTID);
            return dl.LBNAME + "-" + xl.LBNAME;
        }
    }
}