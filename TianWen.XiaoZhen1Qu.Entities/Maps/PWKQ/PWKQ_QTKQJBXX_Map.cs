using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class PWKQ_QTKQJBXX_Map : ClassMap<PWKQ_QTKQJBXX>
    {
        public PWKQ_QTKQJBXX_Map()
        {
            Table("PWKQ_QTKQJBXX");
            #region 属性
            Id(x => x.PWKQ_QTKQJBXXID, "PWKQ_QTKQJBXXID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.GQ, "GQ");
            Map(x => x.JG, "JG");
            Map(x => x.BCMS, "BCMS");
            Map(x => x.JYQY, "JYQY");
            Map(x => x.JYDD, "JYDD");
            #endregion

            #region OneToMany

            #endregion

            #region ManyToOne

            #endregion

        }
    }
}
