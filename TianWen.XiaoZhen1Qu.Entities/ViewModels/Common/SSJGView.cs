﻿using System;
using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.ViewModels.Common
{
    public class SSJGView
    {
        //基础信息
        public int CODEID { get; set; }
        public string CODENAME { get; set; }
        public string TYPENAME { get; set; }
        public string TYPE { get; set; }
        public string URL { get; set; }
        public int PARENTID { get; set; }
        public string CONDITIONS { get; set; }
        public string CODENAMEPY { get; set; }
        public string CODENAMEPYQKG { get; set; }
        public string CODENAMEPYSZM { get; set; }
    }
}
