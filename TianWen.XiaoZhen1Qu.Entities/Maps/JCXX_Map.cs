using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class JCXX_Map : ClassMap<JCXX>
    {
        public JCXX_Map()
        {
            Table("JCXX");
            #region 属性
            Id(x => x.JCXXID, "JCXXID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.YHID, "YHID");
            Map(x => x.CJSJ, "CJSJ");
            Map(x => x.ZXGXSJ, "ZXGXSJ");
            Map(x => x.LLCS, "LLCS");
            Map(x => x.LXR, "LXR");
            Map(x => x.LXDH, "LXDH");
            Map(x => x.LXDZ, "LXDZ");
            Map(x => x.QQ, "QQ");
            Map(x => x.BT, "BT");
            Map(x => x.DH, "DH");
            Map(x => x.STATUS, "STATUS");
            Map(x => x.LBID, "LBID");
            #endregion

            #region OneToMany

            #endregion

            #region ManyToOne

            #endregion

        }
    }
}
