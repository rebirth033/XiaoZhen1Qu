﻿using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class ZXJC_FWGZJBXX_Map : ClassMap<ZXJC_FWGZJBXX>
    {
        public ZXJC_FWGZJBXX_Map()
        {
            Table("ZXJC_FWGZJBXX");
            #region 属性
            Id(x => x.ZXJC_FWGZJBXXID, "ZXJC_FWGZJBXXID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.LB, "LB");
            Map(x => x.XL, "XL");
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