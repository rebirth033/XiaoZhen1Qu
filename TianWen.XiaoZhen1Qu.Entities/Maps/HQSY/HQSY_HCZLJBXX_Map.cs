using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class HQSY_HCZLJBXX_Map : ClassMap<HQSY_HCZLJBXX>
    {
        public HQSY_HCZLJBXX_Map()
        {
            Table("HQSY_HCZLJBXX");
            #region 属性
            Id(x => x.ID, "ID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.TCCZ, "TCCZ");
            Map(x => x.TCPP, "TCPP");
            Map(x => x.TCYS, "TCYS");
            Map(x => x.GCSL, "GCSL");
            Map(x => x.GCPP, "GCPP");
            Map(x => x.GCYS, "GCYS");
            Map(x => x.MFTGCH, "MFTGCH");
            Map(x => x.JNSJ, "JNSJ");
            Map(x => x.JNGLS, "JNGLS");
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
