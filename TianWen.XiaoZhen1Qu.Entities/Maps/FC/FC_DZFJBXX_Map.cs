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
            Id(x => x.FC_DZFJBXXID, "FC_DZFJBXXID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.FWLX, "FWLX");
            Map(x => x.ZDZQ, "ZDZQ");
            Map(x => x.ZJ, "ZJ");
            Map(x => x.YZRS, "YZRS");
            Map(x => x.MJ, "MJ");
            Map(x => x.DZ, "DZ");
            Map(x => x.BCMS, "BCMS");
            Map(x => x.JYGZ, "JYGZ"); 
            #endregion

            #region OneToMany

            #endregion

            #region ManyToOne

            #endregion

        }
    }
}
