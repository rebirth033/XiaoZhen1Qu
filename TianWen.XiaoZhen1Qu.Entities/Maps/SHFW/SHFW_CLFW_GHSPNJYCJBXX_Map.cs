using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class SHFW_CLFW_GHSPNJYCJBXX_Map : ClassMap<SHFW_CLFW_GHSPNJYCJBXX>
    {
        public SHFW_CLFW_GHSPNJYCJBXX_Map()
        {
            Table("SHFW_CLFW_GHSPNJYCJBXX");
            #region 属性
            Id(x => x.SHFW_CLFW_GHSPNJYCJBXXID, "SHFW_CLFW_GHSPNJYCJBXXID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.LB, "LB");
            Map(x => x.JG, "JG");
            Map(x => x.FWQY, "FWQY");
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
