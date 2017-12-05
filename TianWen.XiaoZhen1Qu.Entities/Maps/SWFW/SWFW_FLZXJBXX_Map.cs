using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class SWFW_FLZXJBXX_Map : ClassMap<SWFW_FLZXJBXX>
    {
        public SWFW_FLZXJBXX_Map()
        {
            Table("SWFW_FLZXJBXX");
            #region 属性
            Id(x => x.ID, "ID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.LY, "LY");
            Map(x => x.LB, "LB");
            Map(x => x.ZYZH, "ZYZH");
            Map(x => x.ZYJG, "ZYJG");
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
