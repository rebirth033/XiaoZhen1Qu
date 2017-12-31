using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class CW_CWMJBXX_Map : ClassMap<CW_CWMJBXX>
    {
        public CW_CWMJBXX_Map()
        {
            Table("CW_CWMJBXX");
            #region 属性
            Id(x => x.ID, "ID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.GQ, "GQ");
            Map(x => x.SF, "SF");
            Map(x => x.PZ, "PZ");
            Map(x => x.JG, "JG");
            Map(x => x.QY, "QY");
            Map(x => x.DD, "DD");
            Map(x => x.BCMS, "BCMS");
            #endregion

            #region OneToMany

            #endregion

            #region ManyToOne

            #endregion

        }
    }
}
