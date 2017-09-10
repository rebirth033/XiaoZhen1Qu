using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class FC_SPJBXX_Map : ClassMap<FC_SPJBXX>
    {
        public FC_SPJBXX_Map()
        {
            Table("FC_SPJBXX");
            #region 属性
            Id(x => x.FC_SPJBXXID, "FC_SPJBXXID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.FL, "FL");
            Map(x => x.GQ, "GQ");
            Map(x => x.SPLX, "SPLX"); 
            Map(x => x.LSJY, "LSJY");
            Map(x => x.QY, "QY");
            Map(x => x.SQ, "SQ");
            Map(x => x.DD, "DD");
            Map(x => x.ZJ, "ZJ");
            Map(x => x.ZJDW, "ZJDW");
            Map(x => x.MJ, "MJ");
            Map(x => x.BCMS, "BCMS");
            #endregion

            #region OneToMany

            #endregion

            #region ManyToOne

            #endregion

        }
    }
}
