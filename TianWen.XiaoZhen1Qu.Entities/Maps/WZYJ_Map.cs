using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class WZYJ_Map : ClassMap<WZYJ>
    {
        public WZYJ_Map()
        {
            Table("WZYJ");
            #region 属性
            Id(x => x.WZYJID, "WZYJID").GeneratedBy.Assigned().CustomType("AnsiString");
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
