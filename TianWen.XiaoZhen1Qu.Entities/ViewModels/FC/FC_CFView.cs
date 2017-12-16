using System;
using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.ViewModels.FC
{
    public class FC_CFView
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
        //厂房仓库土地车位信息
        public string ID { get; set; }
        public string ZJ { get; set; }
        public string ZJDW { get; set; }
        public string LX { get; set; }
        public string GQ { get; set; }
        public string QY { get; set; }
        public string DD { get; set; }
        public string JTDZ { get; set; }
        public string MJ { get; set; }
        public string SJ { get; set; }
        //图片
        public IList<PHOTOS> PHOTOS { get; set; }
    }
}
