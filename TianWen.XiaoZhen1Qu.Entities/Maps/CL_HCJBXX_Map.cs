using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class CL_HCJBXX_Map : ClassMap<CL_HCJBXX>
    {
        public CL_HCJBXX_Map()
        {
            Table("CL_HCJBXX");
            #region 属性
            Id(x => x.CL_HCJBXXID, "CL_HCJBXXID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.GQ, "GQ");
            Map(x => x.LB, "LB");
            Map(x => x.PP, "PP");
            Map(x => x.XSLC, "XSLC");
            Map(x => x.GLS, "GLS");
            Map(x => x.GCSJ, "GCSJ");
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
