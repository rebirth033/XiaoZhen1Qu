using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class JYPX_YYPXJSJBXX_Map : ClassMap<JYPX_YYPXJSJBXX>
    {
        public JYPX_YYPXJSJBXX_Map()
        {
            Table("JYPX_YYPXJSJBXX");
            #region 属性
            Id(x => x.JYPX_YYPXJSJBXXID, "JYPX_YYPXJSJBXXID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.YZ, "YZ");
            Map(x => x.XL, "XL");
            Map(x => x.ZX, "ZX");
            Map(x => x.JB, "JB");
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
