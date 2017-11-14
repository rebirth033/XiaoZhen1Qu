using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.ViewModels.CW
{
    public class CW_CWGView
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
        //宠物_宠物狗信息
        public string ID { get; set; }
        public string PZ { get; set; }
        public string NL { get; set; }
        public string NLDW { get; set; }
        public string XB { get; set; }
        public string MS { get; set; }
        public string QCQK { get; set; }
        public string YMQK { get; set; }
        public string YMZL { get; set; }
        public string SPKG { get; set; }
        public string SF { get; set; }
        public string JG { get; set; }
        //图片
        public IList<PHOTOS> PHOTOS { get; set; }


    }
}
