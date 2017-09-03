using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class WZJY_Map : ClassMap<WZJY>
    {
        public WZJY_Map()
        {
            Table("WZJY");
            #region 属性
            Id(x => x.WZJYID, "WZJYID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
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
