using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class SHFW_CLFW_QCMRZSJBXX_Map : ClassMap<SHFW_CLFW_QCMRZSJBXX>
    {
        public SHFW_CLFW_QCMRZSJBXX_Map()
        {
            Table("SHFW_CLFW_QCMRZSJBXX");
            #region 属性
            Id(x => x.ID, "ID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.LB, "LB");
            Map(x => x.XCDD, "XCDD");
            Map(x => x.XCFS, "XCFS");
            Map(x => x.PP, "PP");
            Map(x => x.PZ, "PZ");
            Map(x => x.TMFW, "TMFW");
            Map(x => x.JG, "JG");
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
