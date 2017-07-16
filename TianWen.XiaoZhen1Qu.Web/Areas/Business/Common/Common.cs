using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Common
{
    public class Common
    {
        #region 物理路径和相对路径的转换
        //本地路径转换成URL相对路径  
        public string urlconvertor(string imagesurl1)
        {
            string tmpRootDir = HttpContext.Current.Server.MapPath(System.Web.HttpContext.Current.Request.ApplicationPath.ToString());//获取程序根目录
            string imagesurl2 = imagesurl1.Replace(tmpRootDir, ""); //转换成相对路径
            imagesurl2 = imagesurl2.Replace(@"\", @"/");
            //imagesurl2 = imagesurl2.Replace(@"Aspx_Uc/", @"");
            return imagesurl2;
        }
        //相对路径转换成服务器本地物理路径  
        public string urlconvertorlocal(string imagesurl1)
        {
            string tmpRootDir = HttpContext.Current.Server.MapPath(System.Web.HttpContext.Current.Request.ApplicationPath.ToString());//获取程序根目录 
            string imagesurl2 = tmpRootDir + imagesurl1.Replace(@"/", @"\"); //转换成绝对路径 
            return imagesurl2;
        }
        #endregion
    }
}