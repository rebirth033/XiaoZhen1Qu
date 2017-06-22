using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class ZDDLXX_Map: ClassMap<ZDDLXX>
    {
        public ZDDLXX_Map()
        {
            Table("ZDDLXX");
            #region 属性
            Id(x => x.ZDDLID, "ZDDLID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.YHM, "YHM");
            Map(x => x.SESSIONID, "SESSIONID");
            #endregion

            #region OneToMany

            #endregion

            #region ManyToOne

            #endregion

        }
    }
}
