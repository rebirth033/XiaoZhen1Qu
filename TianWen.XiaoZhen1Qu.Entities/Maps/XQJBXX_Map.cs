using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class XQJBXX_Map : ClassMap<XQJBXX>
    {
        public XQJBXX_Map()
        {
            Table("XQJBXX");
            #region 属性
            Id(x => x.XQJBXXID, "XQJBXXID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.XQMC, "XQMC");
            Map(x => x.XQDZ, "XQDZ");
            Map(x => x.XQMCPY, "XQMCPY");
            Map(x => x.XQMCPYQKG, "XQMCPYQKG");
            Map(x => x.XQMCPYSZM, "XQMCPYSZM"); 
            #endregion

            #region OneToMany

            #endregion

            #region ManyToOne

            #endregion

        }
    }
}
