using System;
using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.ViewModels.Common
{
    public class BaseView
    {
        //基础信息
        public string JCXXID { get; set; }
        public string BT { get; set; }
        public string YHID { get; set; }
        public decimal STATUS { get; set; }
        public string XQDZ { get; set; }
        public string LXR { get; set; }
        public string LXDH { get; set; }
        public decimal LLCS { get; set; }
        public DateTime CJSJ { get; set; }
        public DateTime ZXGXSJ { get; set; }
        public byte[] BCMS { get; set; }
        public string BCMSString { get; set; }
        public decimal LBID { get; set; }

        //图片
        public IList<PHOTOS> PHOTOS { get; set; }
    }
}
