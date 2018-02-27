using System;
using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Entities.ViewModels.Common;

namespace TianWen.XiaoZhen1Qu.Entities.ViewModels.LYJD
{
    public class LYJD_GNYView : BaseView
    {
        //详细信息
        public string ID { get; set; }
        public byte[] XCAP { get; set; }
        public string CYFS { get; set; }
        public string FTRQ { get; set; }
        public string WFJT_Q { get; set; }
        public string WFJT_H { get; set; }
        public string XCTS_R { get; set; }
        public string XCTS_W { get; set; }
        public string QY { get; set; }
        public string DD { get; set; }
        public string JTDZ { get; set; }
        public string FWFW { get; set; }
        public string JG { get; set; }
    }
}
