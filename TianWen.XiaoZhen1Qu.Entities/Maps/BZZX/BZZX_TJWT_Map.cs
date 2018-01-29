using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class BZZX_TJWT_Map : ClassMap<BZZX_TJWT>
    {
        public BZZX_TJWT_Map()
        {
            Table("BZZX_TJWT");
            #region 属性
            Id(x => x.ID, "ID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.YHID, "YHID");
            Map(x => x.LB, "LB");
            Map(x => x.YJNR, "YJNR");
            Map(x => x.TP, "TP");
            #endregion

            #region OneToMany

            #endregion

            #region ManyToOne

            #endregion

        }
    }
}
