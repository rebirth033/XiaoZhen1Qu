using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class YHSCXX_Map : ClassMap<YHSCXX>
    {
        public YHSCXX_Map()
        {
            Table("YHSCXX");
            #region 属性
            Id(x => x.YHSCXXID, "YHSCXXID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.YHID, "YHID");
            Map(x => x.JCXXID, "JCXXID");
            #endregion

            #region OneToMany

            #endregion

            #region ManyToOne

            #endregion

        }
    }
}
