using System;
using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.ViewModels.FC
{
    public class QZZP_JZZPView
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
        //求职招聘信息
        public string ID { get; set; }
        public string XZ { get; set; }
        public string XZDW { get; set; }
        public string XZJS { get; set; }
        public string ZPRS { get; set; }
        public string ZWFL { get; set; }
        public string GZNX { get; set; }
        public string XLYQ { get; set; }
        public string ZWLB { get; set; }
        //图片
        public IList<PHOTOS> PHOTOS { get; set; }


    }
}
