using System;
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
            return jcxx;
        }

        public string GetLBQCByLBID(int LBID)
        {
            XXLB xl = DataFactory.GetObjectById<XXLB>(LBID);
            XXLB dl = DataFactory.GetObjectById<XXLB>(xl.PARENTID);
            return dl.LBNAME + "-" + xl.LBNAME;
        }
    }
}