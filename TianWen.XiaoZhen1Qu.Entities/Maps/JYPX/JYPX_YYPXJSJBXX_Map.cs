﻿using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class JYPX_YYPXJSJBXX_Map : ClassMap<JYPX_YYPXJSJBXX>
    {
        public JYPX_YYPXJSJBXX_Map()
        {
            Table("JYPX_YYPXJSJBXX");
            #region 属性
            Id(x => x.ID, "ID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.JCXXID, "JCXXID");
            Map(x => x.XM, "XM");
            Map(x => x.SF, "SF");
            Map(x => x.JXKM, "JXKM");
            Map(x => x.JBSP, "JBSP");
            Map(x => x.JJJY, "JJJY");
            Map(x => x.QWSX_Q, "QWSX_Q");
            Map(x => x.QWSX_Z, "QWSX_Z");
            Map(x => x.FWFW, "FWFW");
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
