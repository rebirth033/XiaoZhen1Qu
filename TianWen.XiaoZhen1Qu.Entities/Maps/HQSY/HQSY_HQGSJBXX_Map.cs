﻿using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class HQSY_HQGSJBXX_Map : ClassMap<HQSY_HQGSJBXX>
    {
        public HQSY_HQGSJBXX_Map()
        {
            Table("HQSY_HQGSJBXX");
            #region 属性
            Id(x => x.HQSY_HQGSJBXXID, "HQSY_HQGSJBXXID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.TGFW, "TGFW");
            Map(x => x.FWQY, "FWQY");
            Map(x => x.QY, "QY");
            Map(x => x.DD, "DD");
            Map(x => x.JTDZ, "JTDZ");
            Map(x => x.BCMS, "BCMS");
            #endregion

            #region OneToMany

            #endregion

            #region ManyToOne

            #endregion

        }
    }
}