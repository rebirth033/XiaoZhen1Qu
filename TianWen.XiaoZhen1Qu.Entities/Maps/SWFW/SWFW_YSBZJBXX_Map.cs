using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class SWFW_YSBZJBXX_Map : ClassMap<SWFW_YSBZJBXX>
    {
        public SWFW_YSBZJBXX_Map()
        {
            Table("SWFW_YSBZJBXX");
            #region 属性
            Id(x => x.SWFW_YSBZJBXXID, "SWFW_YSBZJBXXID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.LB, "LB");
            Map(x => x.CZ, "CZ");
            Map(x => x.YT, "YT");
            Map(x => x.BZRQ, "BZRQ");
            Map(x => x.XL, "XL");
            Map(x => x.GY, "GY");
            Map(x => x.FWQY, "FWQY");
            Map(x => x.QY, "QY");
            Map(x => x.DD, "DD");
            Map(x => x.JTDZ, "JTDZ");
            Map(x => x.BCMS, "BCMS");
            #endregion

            #region OneToMany

            #endregion

            #region ManyToOne

            #endregion

        }
    }
}
