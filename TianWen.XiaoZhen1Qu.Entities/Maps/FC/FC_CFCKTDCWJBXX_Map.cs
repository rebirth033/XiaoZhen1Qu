using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;
namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class FC_CFCKTDCWJBXX_Map : ClassMap<FC_CFCKTDCWJBXX>
    {
        public FC_CFCKTDCWJBXX_Map()
        {
            Table("FC_CFCKTDCWJBXX");
            #region 属性
            Id(x => x.ID, "ID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.GQ, "GQ");
            Map(x => x.LX, "LX");
            Map(x => x.QY, "QY");
            Map(x => x.DD, "DD");
            Map(x => x.JTDZ, "JTDZ");
            Map(x => x.ZJ, "ZJ");
            Map(x => x.SJ, "SJ");
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
