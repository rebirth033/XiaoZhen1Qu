using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class LYJD_GNYJBXX_Map : ClassMap<LYJD_GNYJBXX>
    {
        public LYJD_GNYJBXX_Map()
        {
            Table("LYJD_GNYJBXX");
            #region 属性
            Id(x => x.LYJD_GNYJBXXID, "LYJD_GNYJBXXID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.XLTS, "XLTS");
            Map(x => x.CYFS, "CYFS");
            Map(x => x.FTRQ, "FTRQ");
            Map(x => x.WFJT_Q, "WFJT_Q");
            Map(x => x.WFJT_H, "WFJT_H");
            Map(x => x.XCTS_R, "XCTS_R");
            Map(x => x.XCTS_W, "XCTS_W");
            Map(x => x.XCAP, "XCAP");
            Map(x => x.YDXZ, "YDXZ");
            Map(x => x.MSJ, "MSJ");
            Map(x => x.YHJ_CR, "YHJ_CR");
            Map(x => x.YHJ_ET, "YHJ_ET");
            Map(x => x.FYBH, "FYBH");
            Map(x => x.ZFXM, "ZFXM");
            Map(x => x.QY, "QY");
            Map(x => x.DD, "DD");
            Map(x => x.JTDZ, "JTDZ");
            #endregion

            #region OneToMany

            #endregion

            #region ManyToOne

            #endregion

        }
    }
}
