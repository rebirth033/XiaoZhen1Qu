using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class SHFW_CLFW_QCPLJBXX_Map : ClassMap<SHFW_CLFW_QCPLJBXX>
    {
        public SHFW_CLFW_QCPLJBXX_Map()
        {
            Table("SHFW_CLFW_QCPLJBXX");
            #region 属性
            Id(x => x.SHFW_CLFW_QCPLJBXXID, "SHFW_CLFW_QCPLJBXXID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.BCMS, "BCMS");
            Map(x => x.JG, "JG");
            Map(x => x.FWQY, "FWQY");
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
