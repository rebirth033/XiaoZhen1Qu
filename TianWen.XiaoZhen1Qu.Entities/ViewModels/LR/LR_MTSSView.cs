using System;
using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.ViewModels.LR
{
    public class LR_MTSSView
    {
        //基础信息
        public string JCXXID { get; set; }
        public string BT { get; set; }
        public string YHID { get; set; }
        public decimal STATUS { get; set; }
        public string XQDZ { get; set; }
        public string LXDH { get; set; }
        public DateTime ZXGXSJ { get; set; }
        public byte[] BCMS { get; set; }
        public string BCMSString { get; set; }
        //详细信息
        public string ID { get; set; }
        public string LB { get; set; }
        public string XL { get; set; }
        public string QY { get; set; }
        public string DD { get; set; }
        public string JTDZ { get; set; }
        public string FWQY { get; set; }
        //图片
        public IList<PHOTOS> PHOTOS { get; set; }


    }
}
