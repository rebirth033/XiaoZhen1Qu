using System;
using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Entities.ViewModels.Common;

namespace TianWen.XiaoZhen1Qu.Entities.ViewModels.FC
{
    public class FC_CFView : BaseView
    {
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
    }
}
