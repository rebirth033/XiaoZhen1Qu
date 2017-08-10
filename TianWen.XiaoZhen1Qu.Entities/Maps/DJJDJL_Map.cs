using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    public class DJJDJL_Map : ClassMap<DJJDJL>
    {
        public DJJDJL_Map()
        {
            Table("DJJDJL");
            #region 属性
            Id(x => x.DJJDJLID, "DJJDJLID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.CJSJ, "CJSJ");
            Map(x => x.JE, "JE");
            Map(x => x.LX, "LX");
            Map(x => x.BZ, "BZ");
            Map(x => x.YHZHXXID, "YHZHXXID");
            #endregion

            #region OneToMany

            #endregion

            #region ManyToOne

            #endregion

        }
    }
}
