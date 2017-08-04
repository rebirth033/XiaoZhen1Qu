using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class YXJBXX_Map : ClassMap<YXJBXX>
    {
        public YXJBXX_Map()
        {
            Table("YXJBXX");
            #region 属性
            Id(x => x.YXJBXXID, "YXJBXXID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.YXMC, "YXMC");
            Map(x => x.SFRMYX, "SFRMYX");
            Map(x => x.YXMCSZM, "YXMCSZM");
            #endregion

            #region OneToMany

            #endregion

            #region ManyToOne

            #endregion

        }
    }
}
