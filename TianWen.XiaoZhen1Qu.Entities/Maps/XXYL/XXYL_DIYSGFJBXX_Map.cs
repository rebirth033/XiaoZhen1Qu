using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class XXYL_DIYSGFJBXX_Map : ClassMap<XXYL_DIYSGFJBXX>
    {
        public XXYL_DIYSGFJBXX_Map()
        {
            Table("XXYL_DIYSGFJBXX");
            #region 属性
            Id(x => x.XXYL_DIYSGFJBXXID, "XXYL_DIYSGFJBXXID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.LB, "LB");
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
