using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class YHZHXX_Map : ClassMap<YHZHXX>
    {
        public YHZHXX_Map()
        {
            Table("YHZHXX");
            #region 属性
            Id(x => x.YHZHXXID, "YHZHXXID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.XJZJE, "XJZJE");
            Map(x => x.KYJE, "KYJE");
            Map(x => x.DJZJE, "DJZJE");
            Map(x => x.YHID, "YHID");
            #endregion

            #region OneToMany

            #endregion

            #region ManyToOne

            #endregion

        }
    }
}
