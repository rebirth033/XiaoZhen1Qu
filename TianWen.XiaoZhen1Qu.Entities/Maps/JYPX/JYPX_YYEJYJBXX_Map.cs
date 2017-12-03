using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class JYPX_YYEJYJBXX_Map : ClassMap<JYPX_YYEJYJBXX>
    {
        public JYPX_YYEJYJBXX_Map()
        {
            Table("JYPX_YYEJYJBXX");
            #region 属性
            Id(x => x.ID, "ID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.LB, "LB");
            Map(x => x.FWLX, "FWLX");
            Map(x => x.BXXZ, "BXXZ");
            Map(x => x.RTTJ, "RTTJ");
            Map(x => x.YYKSSJ_H, "YYKSSJ_H");
            Map(x => x.YYKSSJ_M, "YYKSSJ_M");
            Map(x => x.YYJSSJ_H, "YYJSSJ_H");
            Map(x => x.YYJSSJ_M, "YYJSSJ_M");
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
