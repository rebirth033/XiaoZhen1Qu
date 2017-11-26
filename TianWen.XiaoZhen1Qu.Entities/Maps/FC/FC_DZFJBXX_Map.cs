using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class FC_DZFJBXX_Map : ClassMap<FC_DZFJBXX>
    {
        public FC_DZFJBXX_Map()
        {
            Table("FC_DZFJBXX");
            #region 属性
            Id(x => x.ID, "ID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.FWLX, "FWLX");
            Map(x => x.ZDZQ, "ZDZQ");
            Map(x => x.ZJ, "ZJ");
            Map(x => x.ZJDW, "ZJDW");
            Map(x => x.YZRS, "YZRS");
            Map(x => x.MJ, "MJ");
            Map(x => x.DZ, "DZ");
            Map(x => x.JYGZ, "JYGZ");
            Map(x => x.BCMS, "BCMS");
            Map(x => x.WSS, "WSS");
            Map(x => x.SRCS, "SRCS");
            Map(x => x.DRCS, "DRCS");
            Map(x => x.RZSJ_H, "RZSJ_H");
            Map(x => x.RZSJ_M, "RZSJ_M");
            Map(x => x.TFSJ_H, "TFSJ_H");
            Map(x => x.TFSJ_M, "TFSJ_M");
            Map(x => x.YJ, "YJ");
            Map(x => x.DJ, "DJ");
            Map(x => x.YEWFY, "YEWFY");
            Map(x => x.FKFS, "FKFS");
            #endregion

            #region OneToMany

            #endregion

            #region ManyToOne

            #endregion

        }
    }
}
