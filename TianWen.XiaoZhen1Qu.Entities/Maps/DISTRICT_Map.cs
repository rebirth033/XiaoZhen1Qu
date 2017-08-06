using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class DISTRICT_Map : ClassMap<DISTRICT>
    {
        public DISTRICT_Map()
        {
            Table("DISTRICT");
            #region 属性
            Id(x => x.CODE, "CODE").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.NAME, "NAME");
            Map(x => x.SUPERCODE, "SUPERCODE");
            Map(x => x.SUPERNAME, "SUPERNAME");
            Map(x => x.GRADE, "GRADE");
            Map(x => x.ADLEVEL, "ADLEVEL");
            Map(x => x.AREA, "AREA");
            Map(x => x.SHORTNAME, "SHORTNAME"); 
            #endregion

            #region OneToMany

            #endregion

            #region ManyToOne

            #endregion

        }
    }
}
