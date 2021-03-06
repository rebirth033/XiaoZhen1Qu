﻿using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class CL_HCJBXX_Map : ClassMap<CL_HCJBXX>
    {
        public CL_HCJBXX_Map()
        {
            Table("CL_HCJBXX");
            #region 属性
            Id(x => x.ID, "ID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.LB, "LB");
            Map(x => x.PP, "PP");
            Map(x => x.SF, "SF");
            Map(x => x.CX, "CX");
            Map(x => x.XSLC, "XSLC");
            Map(x => x.CCNF, "CCNF");
            Map(x => x.CCYF, "CCYF");
            Map(x => x.EDZZ, "EDZZ");
            Map(x => x.JG, "JG");
            Map(x => x.BCMS, "BCMS");
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
