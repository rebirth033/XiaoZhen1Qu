using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IBaseBLL
    {
        object LoadCODES(string TYPENAME);

        object LoadCODES_PHONE(string TYPENAME);

        object LoadCODES_COMPUTER(string TYPENAME);

        object LoadCODES_JDJJBG(string TYPENAME);

        object LoadCODES_MYFZMR(string TYPENAME); 

        object LoadQYBySuperName(string SUPERNAME);

        object LoadSQByQY(string QY);

        object LoadSJXHBySJPP(string SJPP);
        
        object LoadBJBXHByBJBPP(string BJBPP);

        object LoadPBXHByPBPP(string PBPP);

        string GetYHZHXXIDByYHID(string YHID);

        YHJBXX GetYHJBXXByYHM(string YHM);

        string GetLBQCByLBID(int LBID);
    }
}
