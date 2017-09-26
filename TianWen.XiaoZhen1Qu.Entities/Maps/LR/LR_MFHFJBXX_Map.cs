using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class LR_MFHFJBXX_Map : ClassMap<LR_MFHFJBXX>
    {
        public LR_MFHFJBXX_Map()
        {
            Table("LR_MFHFJBXX");
            #region 属性
            Id(x => x.LR_MFHFJBXXID, "LR_MFHFJBXXID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.BCMS, "BCMS");
            Map(x => x.LB, "LB");
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
