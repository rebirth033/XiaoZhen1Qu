using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Entities.ViewModels.Common;

namespace TianWen.XiaoZhen1Qu.Entities.ViewModels.FC
{
    public class FC_DZFView : BaseView
    {
        //房产信息
        public string ID { get; set; }
        public decimal ZJ { get; set; }
        public string QY { get; set; }
        public string DD { get; set; }
        public string JTDZ { get; set; }
        public string FWLX { get; set; }
        public string RZSJ_H { get; set; }
        public string RZSJ_M { get; set; }
        public string TFSJ_H { get; set; }
        public string TFSJ_M { get; set; }
    }
}
