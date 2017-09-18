using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class CL_MTCJBXX_Map : ClassMap<CL_MTCJBXX>
    {
        public CL_MTCJBXX_Map()
        {
            Table("CL_MTCJBXX");
            #region 属性
            Id(x => x.CL_MTCJBXXID, "CL_MTCJBXXID").GeneratedBy.Assigned().CustomType("AnsiString");
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
