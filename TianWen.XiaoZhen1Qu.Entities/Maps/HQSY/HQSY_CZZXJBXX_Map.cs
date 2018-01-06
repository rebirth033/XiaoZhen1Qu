using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class HQSY_CZZXJBXX_Map : ClassMap<HQSY_CZZXJBXX>
    {
        public HQSY_CZZXJBXX_Map()
        {
            Table("HQSY_CZZXJBXX");
            #region 属性
            Id(x => x.ID, "ID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.HZLX, "HZLX");
            Map(x => x.HZXL, "HZXL");
            Map(x => x.FWXS, "FWXS");
            Map(x => x.JG, "JG");
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
