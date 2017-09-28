﻿using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class CY_KCTSJBXX_Map : ClassMap<CY_KCTSJBXX>
    {
        public CY_KCTSJBXX_Map()
        {
            Table("CY_KCTSJBXX");
            #region 属性
            Id(x => x.CY_KCTSJBXXID, "CY_KCTSJBXXID").GeneratedBy.Assigned().CustomType("AnsiString");
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