using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class HTGL_YHSCXX_Map : ClassMap<HTGL_YHSCXX>
    {
        public HTGL_YHSCXX_Map()
        {
            Table("HTGL_YHSCXX");
            #region 属性
            Id(x => x.YHSCXXID, "YHSCXXID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.YHID, "YHID");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.TYPE, "TYPE");
            Map(x => x.LBID, "LBID");
            Map(x => x.TYPEID, "TYPEID");
            #endregion

            #region OneToMany

            #endregion

            #region ManyToOne

            #endregion

        }
    }
}
