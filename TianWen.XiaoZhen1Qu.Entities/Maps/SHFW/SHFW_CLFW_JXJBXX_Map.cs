using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class SHFW_CLFW_JXJBXX_Map : ClassMap<SHFW_CLFW_JXJBXX>
    {
        public SHFW_CLFW_JXJBXX_Map()
        {
            Table("SHFW_CLFW_JXJBXX");
            #region 属性
            Id(x => x.SHFW_CLFW_JXJBXXID, "SHFW_CLFW_JXJBXXID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.LB, "LB");
            Map(x => x.JZ, "JZ");
            Map(x => x.BB, "BB");
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
