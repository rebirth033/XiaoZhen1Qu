using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class SHFW_SHFW_BMYSJBXX_Map : ClassMap<SHFW_SHFW_BMYSJBXX>
    {
        public SHFW_SHFW_BMYSJBXX_Map()
        {
            Table("SHFW_SHFW_BMYSJBXX");
            #region 属性
            Id(x => x.SHFW_SHFW_BMYSJBXXID, "SHFW_SHFW_BMYSJBXXID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.BCMS, "BCMS");
            Map(x => x.LB, "LB");
            Map(x => x.QY, "QY");
            Map(x => x.DD, "DD");
            Map(x => x.JTDZ, "JTDZ");
            Map(x => x.FWQY, "FWQY");
            #endregion

            #region OneToMany

            #endregion

            #region ManyToOne

            #endregion

        }
    }
}
