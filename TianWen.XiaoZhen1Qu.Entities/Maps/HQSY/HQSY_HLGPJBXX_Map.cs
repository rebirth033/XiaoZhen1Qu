using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class HQSY_HLGPJBXX_Map : ClassMap<HQSY_HLGPJBXX>
    {
        public HQSY_HLGPJBXX_Map()
        {
            Table("HQSY_HLGPJBXX");
            #region 属性
            Id(x => x.ID, "ID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.GPLX, "GPLX");
            Map(x => x.SYSRS, "SYSRS");
            Map(x => x.GPSJ, "GPSJ");
            Map(x => x.SLQC, "SLQC");
            Map(x => x.SLCP, "SLCP");
            Map(x => x.JG, "JG");
            Map(x => x.FWFW, "FWFW");
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
