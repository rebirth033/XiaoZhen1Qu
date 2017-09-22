using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class CW_HNYCJBXX_Map : ClassMap<CW_HNYCJBXX>
    {
        public CW_HNYCJBXX_Map()
        {
            Table("CW_HNYCJBXX");
            #region 属性
            Id(x => x.CW_HNYCJBXXID, "CW_HNYCJBXXID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.GQ, "GQ");
            Map(x => x.PZ, "PZ");
            Map(x => x.JG, "JG");
            Map(x => x.XL, "XL");
            Map(x => x.BCMS, "BCMS");
            #endregion

            #region OneToMany

            #endregion

            #region ManyToOne

            #endregion

        }
    }
}
