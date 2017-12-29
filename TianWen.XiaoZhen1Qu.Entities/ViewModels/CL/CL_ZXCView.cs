using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Entities.ViewModels.Common;

namespace TianWen.XiaoZhen1Qu.Entities.ViewModels.CL
{
    public class CL_ZXCView : BaseView
    {
        //车辆_自行车信息
        public string ID { get; set; }
        public string GQ { get; set; }
        public string QY { get; set; }
        public string DD { get; set; }
        public string JTDZ { get; set; }
        public string CX { get; set; }
        public string JG { get; set; }
        public string PP { get; set; }
        public string CC { get; set; }
        public string XJ { get; set; }
    }
}
