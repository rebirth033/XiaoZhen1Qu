using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class SWFW_HYZXJBXX_Map : ClassMap<SWFW_HYZXJBXX>
    {
        public SWFW_HYZXJBXX_Map()
        {
            Table("SWFW_HYZXJBXX");
            #region 属性
            Id(x => x.SWFW_HYZXJBXXID, "SWFW_HYZXJBXXID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.YSFW, "YSFW");
            Map(x => x.QY, "QY");
            Map(x => x.DD, "DD");
            Map(x => x.DDD, "DDD");
            Map(x => x.HYTD, "HYTD");
            Map(x => x.SFWF, "SFWF");
            Map(x => x.YWZZ, "YWZZ");
            Map(x => x.BC, "BC");
            Map(x => x.TZSJ, "TZSJ");
            Map(x => x.ZHFS, "ZHFS");
            Map(x => x.HWZL, "HWZL");
            Map(x => x.FWYS, "FWYS");
            Map(x => x.YSJG, "YSJG");
            Map(x => x.YSJGDW, "YSJGDW");
            Map(x => x.BCMS, "BCMS");
            #endregion

            #region OneToMany

            #endregion

            #region ManyToOne

            #endregion

        }
    }
}
