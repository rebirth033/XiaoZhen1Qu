﻿using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class NLMFY_CQYZJBXX_Map : ClassMap<NLMFY_CQYZJBXX>
    {
        public NLMFY_CQYZJBXX_Map()
        {
            Table("NLMFY_CQYZJBXX");
            #region 属性
            Id(x => x.NLMFY_CQYZJBXXID, "NLMFY_CQYZJBXXID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.LB, "LB");
            Map(x => x.XL, "XL");
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