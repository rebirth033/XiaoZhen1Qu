using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class CL_JCJBXX_Map : ClassMap<CL_JCJBXX>
    {
        public CL_JCJBXX_Map()
        {
            Table("CL_JCJBXX");
            #region 属性
            Id(x => x.CL_JCJBXXID, "CL_JCJBXXID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.PP, "PP");
            Map(x => x.CX, "CX");
            Map(x => x.CLYS, "CLYS");
            Map(x => x.SPNF, "SPNF");
            Map(x => x.SPYF, "SPYF");
            Map(x => x.SFDQBY, "SFDQBY");
            Map(x => x.NJDQNF, "NJDQNF");
            Map(x => x.NJDQYF, "NJDQYF");
            Map(x => x.JQXDQNF, "JQXDQNF");
            Map(x => x.JQXDQYF, "JQXDQYF");
            Map(x => x.SYXDQNF, "SYXDQNF");
            Map(x => x.SYXDQYF, "SYXDQYF");
            Map(x => x.XSLC, "XSLC");
            Map(x => x.JG, "JG");
            Map(x => x.BCMS, "BCMS");
            Map(x => x.CJH, "CJH");
            Map(x => x.BHGHFY, "BHGHFY");
            Map(x => x.ZCFQFK, "ZCFQFK");
            Map(x => x.PZSZSF, "PZSZSF");
            Map(x => x.PZSZCS, "PZSZCS");
            Map(x => x.SFYDY, "SFYDY");
            Map(x => x.CLJZPZ, "CLJZPZ");
            Map(x => x.GHCS, "GHCS");
            Map(x => x.KCDZ, "KCDZ");
            #endregion

            #region OneToMany

            #endregion

            #region ManyToOne

            #endregion

        }
    }
}
