using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.ViewModels.FC
{
    public class FC_DZFView
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
        //房产信息
        public string ID { get; set; }
        public string ZJ { get; set; }
        public string ZDZQ { get; set; }
        public string ZJDW { get; set; }
        public string YZRS { get; set; }
        public string MJ { get; set; }
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
