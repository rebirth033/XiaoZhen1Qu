using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class LYJD_ZBYJBXX_Map : ClassMap<LYJD_ZBYJBXX>
    {
        public LYJD_ZBYJBXX_Map()
        {
            Table("LYJD_ZBYJBXX");
            #region 属性
            Id(x => x.LYJD_ZBYJBXXID, "LYJD_ZBYJBXXID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.CYFS, "CYFS");
            Map(x => x.YWXM, "YWXM");
            Map(x => x.SHRQ, "SHRQ");
            Map(x => x.XCTS_R, "XCTS_R");
            Map(x => x.MSJ, "MSJ");
            Map(x => x.YHJ_CR, "YHJ_CR");
            Map(x => x.YHJ_ET, "YHJ_ET");
            Map(x => x.FWJS, "FWJS");
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
