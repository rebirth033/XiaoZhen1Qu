using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IBaseBLL
    {
        object LoadCODES(string TYPENAME);

        object LoadCODES_PHONE(string TYPENAME);

        object LoadCODES_COMPUTER(string TYPENAME); 

        object LoadQYBySuperName(string SUPERNAME);

        object LoadSQByQY(string QY);

        object LoadSJXHBySJPP(string SJPP);
        
        object LoadBJBXHByBJBPP(string BJBPP);

        string GetYHZHXXIDByYHID(string YHID);

        YHJBXX GetYHJBXXByYHM(string YHM);

        string GetLBQCByLBID(int LBID);
    }
}
