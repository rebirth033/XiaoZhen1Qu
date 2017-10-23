using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class CL_ZXCDDCSLCJBXX_Map : ClassMap<CL_ZXCDDCSLCJBXX>
    {
        public CL_ZXCDDCSLCJBXX_Map()
        {
            Table("CL_ZXCDDCSLCJBXX");
            #region 属性
            Id(x => x.CL_ZXCDDCSLCJBXXID, "CL_ZXCDDCSLCJBXXID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.GQ, "GQ");
            Map(x => x.LB, "LB");
            Map(x => x.XL, "XL");
            Map(x => x.DDCPP, "DDCPP");
            Map(x => x.ZXCPP, "ZXCPP");
            Map(x => x.CC, "CC");
            Map(x => x.DCDY, "DCDY");
            Map(x => x.DCRL, "DCRL");
            Map(x => x.XJ, "XJ");
            Map(x => x.SYNX, "SYNX");
            Map(x => x.JG, "JG");
            Map(x => x.BCMS, "BCMS");
            Map(x => x.QY, "QY");
            Map(x => x.DD, "DD");
            #endregion

            #region OneToMany

            #endregion

            #region ManyToOne

            #endregion

        }
    }
}
