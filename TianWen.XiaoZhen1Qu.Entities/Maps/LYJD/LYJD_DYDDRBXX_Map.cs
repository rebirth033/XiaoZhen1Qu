using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class LYJD_DYDDRJBXX_Map : ClassMap<LYJD_DYDDRJBXX>
    {
        public LYJD_DYDDRJBXX_Map()
        {
            Table("LYJD_DYDDRJBXX");
            #region 属性
            Id(x => x.ID, "ID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.XM, "XM");
            Map(x => x.XB, "XB");
            Map(x => x.NL, "NL");
            Map(x => x.DYLX, "DYLX");
            Map(x => x.DYYZ, "DYYZ");
            Map(x => x.XL, "XL");
            Map(x => x.DTJY, "DTJY");
            Map(x => x.FWFW, "FWFW");
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
