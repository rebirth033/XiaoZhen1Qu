using System;
using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.ViewModels.FC
{
    public class FC_SPView
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
        //商铺信息
        public string ID { get; set; }
        public string ZJ { get; set; }
        public string ZJDW { get; set; }
        public string FL { get; set; }
        public string GQ { get; set; }
        public string LSJY { get; set; }
        public string QY { get; set; }
        public string SQ { get; set; }
        public string DZ { get; set; }
        public string MJ { get; set; }
        public string SPLX { get; set; }
        public string SJ { get; set; }
        //小区信息
        public string XQMC { get; set; }
        public string KFS { get; set; }
        public string WYGS { get; set; }
        public string WYLX { get; set; }
        public string ZJMJ { get; set; }
        public string ZHS { get; set; }
        public string JZND { get; set; }
        public string RJL { get; set; }
        public string TCW { get; set; }
        public string LHL { get; set; }
        //图片
        public IList<PHOTOS> PHOTOS { get; set; }
    }
}
