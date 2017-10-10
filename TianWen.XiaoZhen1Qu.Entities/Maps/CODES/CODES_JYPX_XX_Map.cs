using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class CODES_JYPX_XX_Map : ClassMap<CODES_JYPX_XX>
    {
        public CODES_JYPX_XX_Map()
        {
            Table("CODES_JYPX_XX");
            #region 属性
            Id(x => x.CODEID, "CODEID").GeneratedBy.Assigned().CustomType("System.Int32");
            Map(x => x.TYPENAME, "TYPENAME");
            Map(x => x.CODENAME, "CODENAME");
            Map(x => x.CODEVALUE, "CODEVALUE");
            Map(x => x.CODEORDER, "CODEORDER");
            Map(x => x.PARENTID, "PARENTID");
            #endregion

            #region OneToMany

            #endregion

            #region ManyToOne

            #endregion
        }
    }
}
