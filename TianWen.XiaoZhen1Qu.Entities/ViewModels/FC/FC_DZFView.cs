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
        public string FWLX { get; set; }
        public string RZSJ_H { get; set; }
        public string RZSJ_M { get; set; }
        public string TFSJ_H { get; set; }
        public string TFSJ_M { get; set; }
        //图片
        public IList<PHOTOS> PHOTOS { get; set; }


    }
}
