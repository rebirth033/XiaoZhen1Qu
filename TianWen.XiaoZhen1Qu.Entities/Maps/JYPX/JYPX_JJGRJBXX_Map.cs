using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class JYPX_JJGRJBXX_Map : ClassMap<JYPX_JJGRJBXX>
    {
        public JYPX_JJGRJBXX_Map()
        {
            Table("JYPX_JJGRJBXX");
            #region 属性
            Id(x => x.JYPX_JJGRJBXXID, "JYPX_JJGRJBXXID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.XM, "XM");
            Map(x => x.XB, "XB");
            Map(x => x.SF, "SF");
            Map(x => x.JJJY, "JJJY");
            Map(x => x.FDJD, "FDJD");
            Map(x => x.FDKM, "FDKM");
            Map(x => x.QWSX_Q, "QWSX_Q");
            Map(x => x.QWSX_Z, "QWSX_Z");
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
