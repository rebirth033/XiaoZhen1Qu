﻿using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class PFCG_FZBLJBXX_Map : ClassMap<PFCG_FZBLJBXX>
    {
        public PFCG_FZBLJBXX_Map()
        {
            Table("PFCG_FZBLJBXX");
            #region 属性
            Id(x => x.PFCG_FZBLJBXXID, "PFCG_FZBLJBXXID").GeneratedBy.Assigned().CustomType("AnsiString");
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