using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class CL_GCCJBXX_Map : ClassMap<CL_GCCJBXX>
    {
        public CL_GCCJBXX_Map()
        {
            Table("CL_GCCJBXX");
            #region 属性
            Id(x => x.CL_GCCJBXXID, "CL_GCCJBXXID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.LB, "LB");
            Map(x => x.CX, "CX");
            Map(x => x.PP, "PP");
            Map(x => x.DW, "DW");
            Map(x => x.XSS, "XSS");
            Map(x => x.CCNX, "CCNX");
            Map(x => x.CCYF, "CCYF");
            Map(x => x.JG, "JG");
            Map(x => x.BCMS, "BCMS");
            Map(x => x.QY, "QY");
            Map(x => x.DD, "DD");
            #endregion

            #region OneToMany

            #endregion

            #region ManyToOne

            #endregion

        }
    }
}
