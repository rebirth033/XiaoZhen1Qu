﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Entities.ViewModels.Common;

namespace TianWen.XiaoZhen1Qu.Entities.ViewModels.CL
{
    public class CL_ZCView : BaseView
    {
        //详细信息
        public string ID { get; set; }
        public string LB { get; set; }
        public string PP { get; set; }
        public string XL { get; set; }
        public string QY { get; set; }
        public string DD { get; set; }
        public string JTDZ { get; set; }
        public string FWFW { get; set; }
    }
}
