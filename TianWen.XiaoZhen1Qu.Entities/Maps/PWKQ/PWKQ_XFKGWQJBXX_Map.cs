﻿using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class PWKQ_XFKGWQJBXX_Map : ClassMap<PWKQ_XFKGWQJBXX>
    {
        public PWKQ_XFKGWQJBXX_Map()
        {
            Table("PWKQ_XFKGWQJBXX");
            #region 属性
            Id(x => x.PWKQ_XFKGWQJBXXID, "PWKQ_XFKGWQJBXXID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.GQ, "GQ");
            Map(x => x.LB, "LB");
            Map(x => x.JG, "JG");
            Map(x => x.YXQZ, "YXQZ");
            Map(x => x.BCMS, "BCMS");
            Map(x => x.JYQY, "JYQY");
            Map(x => x.JYDD, "JYDD");
            #endregion

            #region OneToMany

            #endregion

            #region ManyToOne

            #endregion

        }
    }
}