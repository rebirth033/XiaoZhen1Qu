﻿using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class FC_SPJBXX_Map : ClassMap<FC_SPJBXX>
    {
        public FC_SPJBXX_Map()
        {
            Table("FC_SPJBXX");
            #region 属性
            Id(x => x.ID, "ID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.SF, "SF");
            Map(x => x.FL, "FL");
            Map(x => x.GQ, "GQ");
            Map(x => x.SPLX, "SPLX"); 
            Map(x => x.QY, "QY");
            Map(x => x.DD, "DD");
            Map(x => x.JTDZ, "JTDZ");
            Map(x => x.ZJ, "ZJ");
            Map(x => x.SJ, "SJ");
            Map(x => x.ZJDW, "ZJDW");
            Map(x => x.MJ, "MJ");
            Map(x => x.BCMS, "BCMS");
            Map(x => x.MK, "MK");
            Map(x => x.JS, "JS");
            Map(x => x.CG, "CG");
            Map(x => x.C, "C");
            Map(x => x.GJC, "GJC");
            Map(x => x.JYHY, "JYHY");
            Map(x => x.JYZT, "JYZT");
            Map(x => x.PT, "PT");
            Map(x => x.DF, "DF");
            Map(x => x.SFEI, "SFEI");
            Map(x => x.WYF, "WYF");
            Map(x => x.YFFS, "YFFS");
            Map(x => x.QZQ, "QZQ");
            Map(x => x.MZQ, "MZQ");
            Map(x => x.SFLJ, "SFLJ");

            #endregion

            #region OneToMany

            #endregion

            #region ManyToOne

            #endregion

        }
    }
}
