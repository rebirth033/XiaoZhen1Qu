using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class ES_MYFZMR_MYETYPWJJBXX_Map : ClassMap<ES_MYFZMR_MYETYPWJJBXX>
    {
        public ES_MYFZMR_MYETYPWJJBXX_Map()
        {
            Table("ES_MYFZMR_MYETYPWJJBXX");
            #region 属性
            Id(x => x.ES_MYFZMR_MYETYPWJJBXXID, "ES_MYFZMR_MYETYPWJJBXXID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.GQ, "GQ");
            Map(x => x.LB, "LB");
            Map(x => x.XL, "XL");
            Map(x => x.XJ, "XJ");
            Map(x => x.JG, "JG");
            Map(x => x.BCMS, "BCMS");
            Map(x => x.JYQY, "JYQY");
            Map(x => x.JYDD, "JYDD");
            #endregion

            #region OneToMany

            #endregion

            #region ManyToOne

            #endregion

        }
    }
}
