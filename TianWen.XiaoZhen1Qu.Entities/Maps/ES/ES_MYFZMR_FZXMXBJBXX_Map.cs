using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class ES_MYFZMR_FZXMXBJBXX_Map : ClassMap<ES_MYFZMR_FZXMXBJBXX>
    {
        public ES_MYFZMR_FZXMXBJBXX_Map()
        {
            Table("ES_MYFZMR_FZXMXBJBXX");
            #region 属性
            Id(x => x.ES_MYFZMR_FZXMXBJBXXID, "ES_MYFZMR_FZXMXBJBXXID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.GQ, "GQ");
            Map(x => x.LB, "LB");
            Map(x => x.XL, "XL");
            Map(x => x.XJ, "XJ");
            Map(x => x.JG, "JG");
            Map(x => x.BCMS, "BCMS");
            Map(x => x.QY, "QY");
            Map(x => x.DD, "DD");
            #endregion

            #region OneToMany

            #endregion

            #region ManyToOne

            #endregion

        }
    }
}
