using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class XXYL_TQTJBXX_Map : ClassMap<XXYL_TQTJBXX>
    {
        public XXYL_TQTJBXX_Map()
        {
            Table("XXYL_TQTJBXX");
            #region 属性
            Id(x => x.XXYL_TQTJBXXID, "XXYL_TQTJBXXID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.BCMS, "BCMS");
            Map(x => x.QY, "QY");
            Map(x => x.DD, "DD");
            Map(x => x.JTDZ, "JTDZ");
            #endregion

            #region OneToMany

            #endregion

            #region ManyToOne

            #endregion

        }
    }
}
