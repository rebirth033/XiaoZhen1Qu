using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.ViewModels.FC
{
    public class FC_ZZFView
    {
        public string BT { get; set; }
        public string CZFS { get; set; }
        public string S { get; set; }
        public string T { get; set; }
        public string W { get; set; }
        public string PFM { get; set; }
        public string ZXQK { get; set; }
        public string CX { get; set; }
        public string C { get; set; }
        public string GJC { get; set; }
        public string XQMC { get; set; }
        public string XQDZ { get; set; }
        public DateTime ZXGXSJ { get; set; }
        public string ZJ { get; set; }
        public string JCXXID { get; set; }
        public string YHID { get; set; }
        public decimal STATUS { get; set; }
        public IList<PHOTOS> PHOTOS { get; set; }
    }
}
