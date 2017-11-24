using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class CL_QCGZFHJBXX_Map : ClassMap<CL_QCGZFHJBXX>
    {
        public CL_QCGZFHJBXX_Map()
        {
            Table("CL_QCGZFHJBXX");
            #region 属性
            Id(x => x.ID, "ID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.LB, "LB");
            Map(x => x.XL, "XL");
            Map(x => x.JG, "JG");
            Map(x => x.FWQY, "FWQY");
            Map(x => x.BCMS, "BCMS");
            Map(x => x.QY, "QY");
            Map(x => x.DD, "DD");
            Map(x => x.JTDZ, "JTDZ");
            #endregion

            #region OneToMany

            #endregion

            #region ManyToOne

            #endregion

        }
    }
}
