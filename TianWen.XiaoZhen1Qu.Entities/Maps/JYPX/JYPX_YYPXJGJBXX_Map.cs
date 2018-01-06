using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class JYPX_YYPXJGJBXX_Map : ClassMap<JYPX_YYPXJGJBXX>
    {
        public JYPX_YYPXJGJBXX_Map()
        {
            Table("JYPX_YYPXJGJBXX");
            #region 属性
            Id(x => x.ID, "ID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.YZ, "YZ");
            Map(x => x.XL, "XL");
            Map(x => x.ZX, "ZX");
            Map(x => x.JB, "JB");
            Map(x => x.FWFW, "FWFW");
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
