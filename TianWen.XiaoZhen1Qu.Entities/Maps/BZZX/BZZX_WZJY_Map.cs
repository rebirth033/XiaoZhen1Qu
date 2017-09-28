﻿using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class BZZX_WZJY_Map : ClassMap<BZZX_WZJY>
    {
        public BZZX_WZJY_Map()
        {
            Table("BZZX_WZJY");
            #region 属性
            Id(x => x.WZJYID, "WZJYID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.LB, "LB");
            Map(x => x.YJNR, "YJNR");
            Map(x => x.TP, "TP");
            #endregion

            #region OneToMany

            #endregion

            #region ManyToOne

            #endregion

        }
    }
}