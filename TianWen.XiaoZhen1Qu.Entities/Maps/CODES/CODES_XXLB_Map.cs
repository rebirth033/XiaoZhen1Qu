using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class CODES_XXLB_Map : ClassMap<CODES_XXLB>
    {
        public CODES_XXLB_Map()
        {
            Table("CODES_XXLB");
            #region 属性
            Id(x => x.LBID, "LBID").GeneratedBy.Assigned().CustomType("System.Int32");
            Map(x => x.LBLX, "LBLX");
            Map(x => x.LBNAME, "LBNAME");
            Map(x => x.LBORDER, "LBORDER");
            Map(x => x.PARENTID, "PARENTID");
            Map(x => x.FBYM, "FBYM");
            Map(x => x.FBTABLE, "FBTABLE");
            #endregion

            #region OneToMany

            #endregion

            #region ManyToOne

            #endregion

        }
    }
}
