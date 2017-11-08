using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class CODES_FUZHOU_XQJBXX_Map : ClassMap<CODES_FUZHOU_XQJBXX>
    {
        public CODES_FUZHOU_XQJBXX_Map()
        {
            Table("CODES_FUZHOU_XQJBXX");
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
