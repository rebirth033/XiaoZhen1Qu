using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class SWFW_ZXFWJBXX_Map : ClassMap<SWFW_ZXFWJBXX>
    {
        public SWFW_ZXFWJBXX_Map()
        {
            Table("SWFW_ZXFWJBXX");
            #region 属性
            Id(x => x.ID, "ID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.LB, "LB");
            Map(x => x.XL, "XL");
            Map(x => x.YYKSSJ_H, "YYKSSJ_H");
            Map(x => x.YYKSSJ_M, "YYKSSJ_M");
            Map(x => x.YYJSSJ_H, "YYJSSJ_H");
            Map(x => x.YYJSSJ_M, "YYJSSJ_M");
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
