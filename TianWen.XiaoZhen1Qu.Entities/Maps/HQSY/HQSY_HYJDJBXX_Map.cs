using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class HQSY_HYJDJBXX_Map : ClassMap<HQSY_HYJDJBXX>
    {
        public HQSY_HYJDJBXX_Map()
        {
            Table("HQSY_HYJDJBXX");
            #region 属性
            Id(x => x.HQSY_HYJDJBXXID, "HQSY_HYJDJBXXID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.HLLX, "HLLX");
            Map(x => x.JDLX, "JDLX");
            Map(x => x.JDXJ, "JDXJ");
            Map(x => x.RNZS, "RNZS");
            Map(x => x.JG, "JG");
            Map(x => x.FWQY, "FWQY");
            Map(x => x.QY, "QY");
            Map(x => x.DD, "DD");
            Map(x => x.JTDZ, "JTDZ");
            Map(x => x.BCMS, "BCMS");
            #endregion

            #region OneToMany

            #endregion

            #region ManyToOne

            #endregion

        }
    }
}
