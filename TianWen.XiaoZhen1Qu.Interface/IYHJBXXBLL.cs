using System.Data;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IYHJBXXBLL : IBaseBLL
    {
        IDAO DAO { get; set; }

        DataTable GetYHJBXXListByPage();

        string ValidateSJ(string SJ);

        object CreateBasic(YHJBXX yhjbxx);

        string GetObjByYHM(string YHM);

        string GetObjByYHMOrSJ(string YHM);

        YHJBXX GetObjBySJ(string SJ);

        object UpdatePassword(string MM, string SJ);

        object UpdateTX(string YHID, string TX);

        void UpdateTX(string YHID);

        object UpdateYHM(string YHID, string YHM);

        object UpdateSJ(string YHID, string SJ);

        object UpdateQQ(string YHID, string QQ);

        object UpdateWB(string YHID, string WB);

        object UpdateWX(string YHID, string WX);

        object MMCZ(string YHID, string JMM, string XMM);

        object GetObjByID(string YHID);

        object SendEmail(string YHID, string YX, string CheckCode);

        object YHYZ(string YHID_Cryptograph, string CheckCode_Cryptograph, string YX);
    }
}
