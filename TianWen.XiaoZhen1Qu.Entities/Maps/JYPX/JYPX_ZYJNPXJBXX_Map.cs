﻿using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class JYPX_ZYJNPXJBXX_Map : ClassMap<JYPX_ZYJNPXJBXX>
    {
        public JYPX_ZYJNPXJBXX_Map()
        {
            Table("JYPX_ZYJNPXJBXX");
            #region 属性
            Id(x => x.JYPX_ZYJNPXJBXXID, "JYPX_ZYJNPXJBXXID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.LB, "LB");
            Map(x => x.XL, "XL");
            Map(x => x.XS, "XS");
            Map(x => x.ZQ, "ZQ");
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