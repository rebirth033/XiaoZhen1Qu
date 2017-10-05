﻿using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class SHFW_CLFW_QCWXBYJBXX_Map : ClassMap<SHFW_CLFW_QCWXBYJBXX>
    {
        public SHFW_CLFW_QCWXBYJBXX_Map()
        {
            Table("SHFW_CLFW_QCWXBYJBXX");
            #region 属性
            Id(x => x.SHFW_CLFW_QCWXBYJBXXID, "SHFW_CLFW_QCWXBYJBXXID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.BCMS, "BCMS");
            Map(x => x.LB, "LB");
            Map(x => x.JG, "JG");
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