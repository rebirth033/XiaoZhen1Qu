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
            Id(x => x.ID, "ID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.SF, "SF");
            Map(x => x.PP, "PP");
            Map(x => x.CX, "CX");
            Map(x => x.CLYS, "CLYS");
            Map(x => x.SPNF, "SPNF");
            Map(x => x.SPYF, "SPYF");
            Map(x => x.SFDQBY, "SFDQBY");
            Map(x => x.YWZDSG, "YWZDSG");
            Map(x => x.SGMS, "SGMS");
            Map(x => x.NJDQNF, "NJDQNF");
            Map(x => x.NJDQYF, "NJDQYF");
            Map(x => x.JQXDQNF, "JQXDQNF");
            Map(x => x.JQXDQYF, "JQXDQYF");
            Map(x => x.SYXDQNF, "SYXDQNF");
            Map(x => x.SYXDQYF, "SYXDQYF");
            Map(x => x.XSLC, "XSLC");
            Map(x => x.JG, "JG");
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
