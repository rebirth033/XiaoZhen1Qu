﻿using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class CY_WMJBXX_Map : ClassMap<CY_WMJBXX>
    {
        public CY_WMJBXX_Map()
        {
            Table("CY_WMJBXX");
            #region 属性
            Id(x => x.CY_WMJBXXID, "CY_WMJBXXID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.RJXF, "RJXF");
            Map(x => x.LB, "LB");
            Map(x => x.TJC, "TJC");
            Map(x => x.YYKSSJ_H, "YYKSSJ_H");
            Map(x => x.YYKSSJ_M, "YYKSSJ_M");
            Map(x => x.YYJSSJ_H, "YYJSSJ_H");
            Map(x => x.YYJSSJ_M, "YYJSSJ_M");
            Map(x => x.BCMS, "BCMS");
            Map(x => x.FWQY, "FWQY");
            Map(x => x.JTXX, "JTXX");
            Map(x => x.JYQY, "JYQY");
            Map(x => x.JYDD, "JYDD");
            Map(x => x.JYJTDZ, "JYJTDZ");
            #endregion

            #region OneToMany

            #endregion

            #region ManyToOne

            #endregion

        }
    }
}