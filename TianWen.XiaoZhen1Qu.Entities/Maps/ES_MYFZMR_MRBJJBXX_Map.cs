﻿using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class ES_MYFZMR_MRBJJBXX_Map : ClassMap<ES_MYFZMR_MRBJJBXX>
    {
        public ES_MYFZMR_MRBJJBXX_Map()
        {
            Table("ES_MYFZMR_MRBJJBXX");
            #region 属性
            Id(x => x.ES_MYFZMR_MRBJJBXXID, "ES_MYFZMR_MRBJJBXXID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.GQ, "GQ");
            Map(x => x.LB, "LB");
            Map(x => x.XL, "XL");
            Map(x => x.XJ, "XJ");
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
