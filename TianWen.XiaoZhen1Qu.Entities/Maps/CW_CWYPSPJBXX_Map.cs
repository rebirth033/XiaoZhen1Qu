﻿using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class CW_CWYPSPJBXX_Map : ClassMap<CW_CWYPSPJBXX>
    {
        public CW_CWYPSPJBXX_Map()
        {
            Table("CW_CWYPSPJBXX");
            #region 属性
            Id(x => x.CW_CWYPSPJBXXID, "CW_CWYPSPJBXXID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.GQ, "GQ");
            Map(x => x.LB, "LB");
            Map(x => x.XL, "XL");
            Map(x => x.XJ, "XJ");
            Map(x => x.JG, "JG");
            Map(x => x.BCMS, "BCMS");
            #endregion

            #region OneToMany

            #endregion

            #region ManyToOne

            #endregion

        }
    }
}