using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonClassLib.Helper;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Controllers
{
    public class BaseController : Controller
    {
        public IBaseBLL BaseBLL { get; set; }

        public YHJBXX USER
        {
            get
            {
                return GetUser();
            }
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

        public YHJBXX GetUser()
        {
            YHJBXX User = BaseBLL.GetYHJBXXByYHM(Session["YHM"].ToString());
            return User;
        }
    }
}