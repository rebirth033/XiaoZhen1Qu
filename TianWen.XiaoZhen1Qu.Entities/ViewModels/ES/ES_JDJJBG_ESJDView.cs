﻿using System;
using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.ViewModels.ES
{
    public class ES_JDJJBG_ESJDView
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
        public string BCMSString { get; set; }

        //二手_家电家具办公_二手家电
        public string ID { get; set; }
        public string GQ { get; set; }
        public string LB { get; set; }
        public string XL { get; set; }
        public string DSPP { get; set; }
        public string DSPMCC { get; set; }
        public string XYJPP { get; set; }
        public string KTPP { get; set; }
        public string KTBPDS { get; set; }
        public string KTGL { get; set; }
        public string BXPP { get; set; }
        public string BGPP { get; set; }
        public string XJ { get; set; }
        public string JG { get; set; }
        public string QY { get; set; }
        public string DD { get; set; }

        //图片
        public IList<PHOTOS> PHOTOS { get; set; }
    }
}
