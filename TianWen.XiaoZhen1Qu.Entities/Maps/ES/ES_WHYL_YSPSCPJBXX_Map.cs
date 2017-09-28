﻿using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class ES_WHYL_YSPSCPJBXX_Map : ClassMap<ES_WHYL_YSPSCPJBXX>
    {
        public ES_WHYL_YSPSCPJBXX_Map()
        {
            Table("ES_WHYL_YSPSCPJBXX");
            #region 属性
            Id(x => x.ES_WHYL_YSPSCPJBXXID, "ES_WHYL_YSPSCPJBXXID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.GQ, "GQ");
            Map(x => x.LB, "LB");
            Map(x => x.XL, "XL");
            Map(x => x.JG, "JG");
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