using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.ViewModels.CL
{
    public class CL_KCView
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
        //车辆_客车信息
        public string ID { get; set; }
        public string SPNF { get; set; }
        public string SPYF { get; set; }
        public string JG { get; set; }
        public string PP { get; set; }
        public string NJDQNF { get; set; }
        public string NJDQYF { get; set; }
        public string CX { get; set; }
        public string SFDQBY { get; set; }
        public string XSLC { get; set; }
        public string CLYS { get; set; }
        public string YWZDSG { get; set; }
        public string JQXDQNF { get; set; }
        public string JQXDQYF { get; set; }
        public string SYXDQNF { get; set; }
        public string SYXDQYF { get; set; }
        //图片
        public IList<PHOTOS> PHOTOS { get; set; }


    }
}
