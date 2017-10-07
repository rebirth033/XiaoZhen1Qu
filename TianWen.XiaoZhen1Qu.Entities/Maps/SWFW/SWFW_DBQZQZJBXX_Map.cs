﻿using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class SWFW_DBQZQZJBXX_Map : ClassMap<SWFW_DBQZQZJBXX>
    {
        public SWFW_DBQZQZJBXX_Map()
        {
            Table("SWFW_DBQZQZJBXX");
            #region 属性
            Id(x => x.SWFW_DBQZQZJBXXID, "SWFW_DBQZQZJBXXID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.LB, "LB");
            Map(x => x.GJ, "GJ");
            Map(x => x.FWQY, "FWQY");
            Map(x => x.GRTT, "GRTT");
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
