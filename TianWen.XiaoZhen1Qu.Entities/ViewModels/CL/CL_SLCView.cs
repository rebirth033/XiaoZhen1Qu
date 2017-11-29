using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.ViewModels.CL
{
    public class CL_SLCView
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
        //车辆_摩托车信息
        public string ID { get; set; }
        public string GQ { get; set; }
        public string QY { get; set; }
        public string DD { get; set; }
        public string CX { get; set; }
        public string JG { get; set; }
        public string XJ { get; set; }
        //图片
        public IList<PHOTOS> PHOTOS { get; set; }


    }
}
