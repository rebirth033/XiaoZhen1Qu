using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models.CODES;

namespace TianWen.XiaoZhen1Qu.Entities.Maps.CODES
{
    public class CODES_SY_ML_Map : ClassMap<CODES_SY_ML>
    {
        public CODES_SY_ML_Map()
        {
            Table("CODES_SY_ML");
            #region 属性
            Id(x => x.ID, "ID").GeneratedBy.Assigned().CustomType("System.Int32");
            Map(x => x.LBID, "LBID");
            Map(x => x.LBNAME, "LBNAME");
            Map(x => x.LBORDER, "LBORDER");
            Map(x => x.PARENTID, "PARENTID");
            Map(x => x.TYPE, "TYPE");
            Map(x => x.TYPENAME, "TYPENAME");
            Map(x => x.CONDITION, "CONDITION");
            Map(x => x.ISHOT, "ISHOT");
            Map(x => x.TYPESHOWNAME, "TYPESHOWNAME");
            #endregion

            #region OneToMany

            #endregion

            #region ManyToOne

            #endregion
        }
    }
}
