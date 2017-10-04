using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class SHFW_CLFW_DJSJWPJBXX_Map : ClassMap<SHFW_CLFW_DJSJWPJBXX>
    {
        public SHFW_CLFW_DJSJWPJBXX_Map()
        {
            Table("SHFW_CLFW_DJSJWPJBXX");
            #region 属性
            Id(x => x.SHFW_CLFW_DJSJWPJBXXID, "SHFW_CLFW_DJSJWPJBXXID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.LB, "LB");
            Map(x => x.JG, "JG");
            Map(x => x.FWQY, "FWQY");
            Map(x => x.BCMS, "BCMS");
            #endregion

            #region OneToMany

            #endregion

            #region ManyToOne

            #endregion

        }
    }
}
