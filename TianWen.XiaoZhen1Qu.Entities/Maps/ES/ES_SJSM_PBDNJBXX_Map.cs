﻿using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class ES_SJSM_PBDNJBXX_Map : ClassMap<ES_SJSM_PBDNJBXX>
    {
        public ES_SJSM_PBDNJBXX_Map()
        {
            Table("ES_SJSM_PBDNJBXX");
            #region 属性
            Id(x => x.ID, "ID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.SF, "SF");
            Map(x => x.LB, "LB");
            Map(x => x.XL, "XL");
            Map(x => x.PP, "PP");
            Map(x => x.XH, "XH");
            Map(x => x.XJ, "XJ");
            Map(x => x.JG, "JG");
            Map(x => x.BCMS, "BCMS");
            Map(x => x.QY, "QY");
            Map(x => x.DD, "DD");
            #endregion

            #region OneToMany

            #endregion

            #region ManyToOne

            #endregion

        }
    }
}
