using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Entities.ViewModels.Common;

namespace TianWen.XiaoZhen1Qu.Entities.ViewModels.FC
{
    public class FC_ZZFView : BaseView
    {
        //房产信息
        public string ID { get; set; }
        public decimal ZJ { get; set; }
        public string CZFS { get; set; }
        public string S { get; set; }
        public string T { get; set; }
        public string W { get; set; }
        public string PFM { get; set; }
        public string ZXQK { get; set; }
        public string CX { get; set; }
        public string C { get; set; }
        public string GJC { get; set; }
        public string YFFS { get; set; }
        public string FWPZ { get; set; }
        public string FWLD { get; set; }
        //小区信息
        public string XQMC { get; set; }
        public string XQDZ { get; set; }
        public string SZS { get; set; }
        public string SZX { get; set; }
        public string KFS { get; set; }
        public string WYGS { get; set; }
        public string WYLX { get; set; }
        public string WYF { get; set; }
        public string ZJMJ { get; set; }
        public string ZHS { get; set; }
        public int JZND { get; set; }
        public string RJL { get; set; }
        public string TCW { get; set; }
        public string LHL { get; set; }
    }
}
