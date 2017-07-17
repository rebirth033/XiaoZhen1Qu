using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class PHOTOS_Map : ClassMap<PHOTOS>
    {
        public PHOTOS_Map()
        {
            Table("PHOTOS");
            #region 属性
            Id(x => x.PHOTOID, "PHOTOID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.PHOTOURL, "PHOTOURL");
            Map(x => x.PHOTONAME, "PHOTONAME");
            Map(x => x.JCXXID, "JCXXID");
            #endregion

            #region OneToMany

            #endregion

            #region ManyToOne

            #endregion
        }
    }
}
