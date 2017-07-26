using System.Data;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IYHJBXXBLL
    {
        IDAO DAO { get; set; }

        DataTable GetYHJBXXListByPage();

        object CreateBasic(YHJBXX yhjbxx);

        string GetObjByYHM(string YHM);

        string GetObjByYHMOrSJ(string YHM);

        object UpdatePassword(string MM, string SJ);

        object UpdateTX(string YHID, string TX);

        object UpdateYHM(string YHID, string YHM);

        object UpdateSJ(string YHID, string SJ);

        object GetObjByID(string YHID);

        object SendEmail(string YHID, string YX);
    }
}
