using FluentNHibernate.Mapping;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Entities.Maps
{
    ///<summary>
    ///
    ///</summary>
    public class YHJBXX_Map : ClassMap<YHJBXX>
    {
        public YHJBXX_Map()
        {
            Table("YHJBXX");
            #region 属性
            Id(x => x.YHID, "YHID").GeneratedBy.Assigned().CustomType("AnsiString");
            Map(x => x.YHM, "YHM");
            Map(x => x.MM, "MM");
            Map(x => x.SQRQ, "SQRQ");
            Map(x => x.ZSXM, "ZSXM");
            Map(x => x.XB, "XB");
            Map(x => x.CSRQ, "CSRQ");
            Map(x => x.TXDZ, "TXDZ");
            Map(x => x.YB, "YB");
            Map(x => x.GXQM, "GXQM");
            Map(x => x.SJ, "SJ");
            Map(x => x.QQ, "QQ");
            Map(x => x.DZYX, "DZYX");
            Map(x => x.DZYXYZM, "DZYXYZM");
            Map(x => x.TX, "TX");
            Map(x => x.XYDJ, "XYDJ");
            #endregion

            #region OneToMany

            #endregion

            #region ManyToOne

            #endregion

        }
    }
}
