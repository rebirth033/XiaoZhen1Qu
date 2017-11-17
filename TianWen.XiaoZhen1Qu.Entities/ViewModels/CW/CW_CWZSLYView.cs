using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.ViewModels.CW
{
    public class CW_CWGYView
    {
        //基础信息
        public string JCXXID { get; set; }
        public string BT { get; set; }
        public string YHID { get; set; }
        public decimal STATUS { get; set; }
        public string XQDZ { get; set; }
        public string LXR { get; set; }
        public string LXDH { get; set; }
        public DateTime ZXGXSJ { get; set; }
        public byte[] BCMS { get; set; }
        public string BCMSString { get; set; }
        //宠物_宠物赠送领养信息
        public string ID { get; set; }
        public string GQ { get; set; }
        public string QY { get; set; }
        public string DD { get; set; }
        //图片
        public IList<PHOTOS> PHOTOS { get; set; }
    }
}
