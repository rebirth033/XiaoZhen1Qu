using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IBaseBLL
    {
        object LoadCODES(string TYPENAME);

        string GetYHZHXXIDByYHID(string YHID);

        YHJBXX GetYHJBXXByYHM(string YHM);
    }
}
