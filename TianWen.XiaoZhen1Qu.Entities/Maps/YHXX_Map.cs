using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class YHXX_Map : ClassMap<YHXX>
    {
        public YHXX_Map()
        {
            Table("YHXX");
            #region 属性
            Id(x => x.YHXXID, "YHXXID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.FJR, "FJR");
            Map(x => x.XXNR, "XXNR");
            Map(x => x.XXSJ, "XXSJ");
            Map(x => x.XXLB, "XXLB");
            #endregion

            #region OneToMany

            #endregion

            #region ManyToOne

            #endregion

        }
    }
}
