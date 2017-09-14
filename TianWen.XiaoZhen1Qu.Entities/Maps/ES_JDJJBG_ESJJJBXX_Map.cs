﻿using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class ES_JDJJBG_ESJJJBXX_Map : ClassMap<ES_JDJJBG_ESJJJBXX>
    {
        public ES_JDJJBG_ESJJJBXX_Map()
        {
            Table("ES_JDJJBG_ESJJJBXX");
            #region 属性
            Id(x => x.ES_JDJJBG_ESJJJBXXID, "ES_JDJJBG_ESJJJBXXID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.GQ, "GQ");
            Map(x => x.LB, "LB");
            Map(x => x.XL, "XL");
            Map(x => x.XJ, "XJ");
            Map(x => x.JG, "JG");
            Map(x => x.BCMS, "BCMS");
            Map(x => x.JYQY, "JYQY");
            Map(x => x.JYDD, "JYDD");
            Map(x => x.CCC, "CCC");
            Map(x => x.CDCC, "CDCC");
            #endregion

            #region OneToMany

            #endregion

            #region ManyToOne

            #endregion

        }
    }
}