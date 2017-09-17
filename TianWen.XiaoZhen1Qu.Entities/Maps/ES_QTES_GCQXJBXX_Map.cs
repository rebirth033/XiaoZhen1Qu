using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class ES_QTES_GCQXJBXX_Map : ClassMap<ES_QTES_GCQXJBXX>
    {
        public ES_QTES_GCQXJBXX_Map()
        {
            Table("ES_QTES_GCQXJBXX");
            #region 属性
            Id(x => x.ES_QTES_GCQXJBXXID, "ES_QTES_GCQXJBXXID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.GQ, "GQ");
            Map(x => x.LB, "LB");
            Map(x => x.JG, "JG");
            Map(x => x.BCMS, "BCMS");
            Map(x => x.PP, "PP");
            Map(x => x.XH, "XH");
            Map(x => x.DW, "DW");
            Map(x => x.CCNX, "CCNX");
            Map(x => x.SYSJ, "SYSJ");
            Map(x => x.SZSHENG, "SZSHENG");
            Map(x => x.SZSHI, "SZSHI");
            Map(x => x.SZXZ, "SZXZ");
            #endregion

            #region OneToMany

            #endregion

            #region ManyToOne

            #endregion

        }
    }
}
