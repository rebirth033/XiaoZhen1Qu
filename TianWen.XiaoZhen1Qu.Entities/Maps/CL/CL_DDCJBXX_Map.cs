using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class CL_DDCJBXX_Map : ClassMap<CL_DDCJBXX>
    {
        public CL_DDCJBXX_Map()
        {
            Table("CL_DDCJBXX");
            #region 属性
            Id(x => x.ID, "ID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.SF, "SF");
            Map(x => x.CX, "CX");
            Map(x => x.PP, "PP");
            Map(x => x.DCDY, "DCDY");
            Map(x => x.DCRL, "DCRL");
            Map(x => x.SYNX, "SYNX");
            Map(x => x.XJ, "XJ");
            Map(x => x.JG, "JG");
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
