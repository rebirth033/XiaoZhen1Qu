using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class CL_KCJBXX_Map : ClassMap<CL_KCJBXX>
    {
        public CL_KCJBXX_Map()
        {
            Table("CL_KCJBXX");
            #region 属性
            Id(x => x.CL_KCJBXXID, "CL_KCJBXXID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.GQ, "GQ");
            Map(x => x.LB, "LB");
            Map(x => x.PP, "PP");
            Map(x => x.XSLC, "XSLC");
            Map(x => x.CCNX, "CCNX");
            Map(x => x.CCYF, "CCYF");
            Map(x => x.EDZZ, "EDZZ");
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
