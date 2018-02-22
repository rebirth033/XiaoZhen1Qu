using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class LYJD_LXSJBXX_Map : ClassMap<LYJD_LXSJBXX>
    {
        public LYJD_LXSJBXX_Map()
        {
            Table("LYJD_LXSJBXX");
            #region 属性
            Id(x => x.ID, "ID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
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
