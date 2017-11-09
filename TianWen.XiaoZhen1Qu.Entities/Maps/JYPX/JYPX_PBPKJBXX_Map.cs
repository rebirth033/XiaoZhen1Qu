using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class JYPX_PBPKJBXX_Map : ClassMap<JYPX_PBPKJBXX>
    {
        public JYPX_PBPKJBXX_Map()
        {
            Table("JYPX_PBPKJBXX");
            #region 属性
            Id(x => x.ID, "ID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.SF, "SF");
            Map(x => x.CD, "CD");
            Map(x => x.FDJD, "FDJD");
            Map(x => x.FDKM, "FDKM");
            Map(x => x.JGFW_Q, "JGFW_Q");
            Map(x => x.JGFW_Z, "JGFW_Z");
            Map(x => x.PBRS, "PBRS");
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
