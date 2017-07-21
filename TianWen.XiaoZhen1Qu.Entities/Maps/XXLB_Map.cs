using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class XXLB_Map: ClassMap<XXLB>
    {
        public XXLB_Map()
        {
            Table("XXLB");
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
