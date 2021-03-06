﻿using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class ES_SJSM_TSJJBXX_Map : ClassMap<ES_SJSM_TSJJBXX>
    {
        public ES_SJSM_TSJJBXX_Map()
        {
            Table("ES_SJSM_TSJJBXX");
            #region 属性
            Id(x => x.ID, "ID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.SF, "SF");
            Map(x => x.LB, "LB");
            Map(x => x.XL, "XL");
            Map(x => x.CPUPP, "CPUPP");
            Map(x => x.CPUHS, "CPUHS");
            Map(x => x.NC, "NC");
            Map(x => x.YP, "YP");
            Map(x => x.PMCC, "PMCC");
            Map(x => x.XK, "XK");
            Map(x => x.XJ, "XJ");
            Map(x => x.JG, "JG");
            Map(x => x.BCMS, "BCMS");
            Map(x => x.QY, "QY");
            Map(x => x.DD, "DD");
            Map(x => x.JTDZ, "JTDZ");
            Map(x => x.PSFS, "PSFS");
            #endregion

            #region OneToMany

            #endregion

            #region ManyToOne

            #endregion

        }
    }
}
