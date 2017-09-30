﻿using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class PFCG_DGDLJBXX_Map : ClassMap<PFCG_DGDLJBXX>
    {
        public PFCG_DGDLJBXX_Map()
        {
            Table("PFCG_DGDLJBXX");
            #region 属性
            Id(x => x.PFCG_DGDLJBXXID, "PFCG_DGDLJBXXID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.BCMS, "BCMS");
            Map(x => x.LB, "LB");
            Map(x => x.QY, "QY");
            Map(x => x.DD, "DD");
            Map(x => x.JTDZ, "JTDZ");
            #endregion

            #region OneToMany

            #endregion

            #region ManyToOne

            #endregion

        }
    }
}