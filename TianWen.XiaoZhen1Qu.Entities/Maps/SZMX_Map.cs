using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class SZMX_Map : ClassMap<SZMX>
    {
        public SZMX_Map()
        {
            Table("SZMX");
            #region 属性
            Id(x => x.SZMXID, "SZMXID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.CJSJ, "CJSJ");
            Map(x => x.LX, "LX");
            Map(x => x.JYSM, "JYSM");
            Map(x => x.JE, "JE");
            Map(x => x.JELX, "JELX");
            #endregion

            #region OneToMany

            #endregion

            #region ManyToOne

            #endregion

        }
    }
}
