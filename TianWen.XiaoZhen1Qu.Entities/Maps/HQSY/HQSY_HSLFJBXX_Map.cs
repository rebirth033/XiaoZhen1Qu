using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class HQSY_HSLFJBXX_Map : ClassMap<HQSY_HSLFJBXX>
    {
        public HQSY_HSLFJBXX_Map()
        {
            Table("HQSY_HSLFJBXX");
            #region 属性
            Id(x => x.HQSY_HSLFJBXXID, "HQSY_HSLFJBXXID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.YS, "YS");
            Map(x => x.FG, "FG");
            Map(x => x.LX, "LX");
            Map(x => x.DGZQ, "DGZQ");
            Map(x => x.CZ, "CZ");
            Map(x => x.KS, "KS");
            Map(x => x.JG, "JG");
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
