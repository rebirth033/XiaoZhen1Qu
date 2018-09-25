using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using TianWen.Framework.Common;
using System.Web;
using TianWen.XiaoZhen1Qu.Interface;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business.Ashx
{
    /// <summary>
    /// SaveGRZLPhotos 的摘要说明
    /// </summary>
    public class SaveGRZLPhotos : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        IYHZCBLL YHZCBLL = SpringHelper.GetSpringObject<IYHZCBLL>("YHZCBLL");

        public void ProcessRequest(HttpContext context)
        {
            var data = context.Request["data"];
            if (data != null)
                context.Response.Write(SavePhoto64(context));
            else
                context.Response.Write(SavePhoto(context));
        }

        public string SavePhoto(HttpContext context)
        {
            try
            {
                if (context.Request.Files.Count > 0)
                {
                    HttpPostedFile file = context.Request.Files[0];

                    if (file.ContentLength > 0 && file.ContentType.IndexOf("image/") >= 0)
                    {
                        int width = Convert.ToInt32(context.Request.Form["width"]);
                        int height = Convert.ToInt32(context.Request.Form["height"]);
                        YHJBXX YHJBXX = YHZCBLL.GetYHJBXXByYHM(context.Session["YHM"].ToString());
                        YHZCBLL.UpdateTX(YHJBXX.YHID);
                        string type = context.Request.Form["type"];
                        string filename = context.Request.Form["filename"];
                        YHZCBLL.UpdateTX(YHJBXX.YHID);
                        return ResizeImg(file.InputStream, width, height, YHJBXX.YHID, type, filename);
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return string.Empty;
        }

        public string ResizeImg(Stream ImgFile, int maxWidth, int maxHeight, string yhid, string type, string fileName)
        {
            string RootDir = HttpContext.Current.Server.MapPath(HttpContext.Current.Request.ApplicationPath);//获取程序根目录
            string filePath = RootDir + @"\Areas\Business\Photos\" + yhid + @"\" + type + @"\";

            fileName = fileName == string.Empty ? DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".jpg" : fileName+ ".jpg";

            Image imgPhoto = Image.FromStream(ImgFile);

            decimal desiredRatio = Math.Min((decimal)maxWidth / imgPhoto.Width, (decimal)maxHeight / imgPhoto.Height);
            int iWidth = (int)(imgPhoto.Width * desiredRatio);
            int iHeight = (int)(imgPhoto.Height * desiredRatio);

            Bitmap bmPhoto = new Bitmap(iWidth, iHeight);

            Graphics gbmPhoto = Graphics.FromImage(bmPhoto);

            //设置高质量插值法
            gbmPhoto.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

            Color color = Color.FromArgb(255, 250, 255, 249);    //背景透明

            gbmPhoto.FillRectangle(new SolidBrush(color), new Rectangle(0, 0, iWidth, iHeight));

            gbmPhoto.DrawImage(imgPhoto, new Rectangle(0, 0, iWidth, iHeight), new Rectangle(0, 0, imgPhoto.Width, imgPhoto.Height), GraphicsUnit.Pixel);

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            bmPhoto.Save((filePath + fileName), ImageFormat.Jpeg);

            imgPhoto.Dispose();
            gbmPhoto.Dispose();
            bmPhoto.Dispose();

            return fileName;
        }

        public string SavePhoto64(HttpContext context)
        {
            string RootDir = HttpContext.Current.Server.MapPath(HttpContext.Current.Request.ApplicationPath);//获取程序根目录 
            string virtualpath = context.Request["filepath"];
            string filename = virtualpath.Substring(virtualpath.LastIndexOf('/') + 1, virtualpath.Length - virtualpath.LastIndexOf('/') - 1);
            string physicalpath = RootDir + @"\Areas\Business\Photos\" + filename;
            FileStream fs = File.Create(physicalpath);
            byte[] bytes = Convert.FromBase64String(context.Request["data"]);
            fs.Write(bytes, 0, bytes.Length);
            fs.Close();
            YHJBXX YHJBXX = YHZCBLL.GetYHJBXXByYHM(context.Session["YHM"].ToString());
            YHZCBLL.UpdateTX(YHJBXX.YHID);
            return string.Empty;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}