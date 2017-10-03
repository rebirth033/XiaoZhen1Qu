using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IBaseBLL
    {
        object LoadCODES_FC(string TYPENAME);

        object LoadCODES_ES_SJSM(string TYPENAME);

        object LoadCODES_ES_JDJJBG(string TYPENAME);

        object LoadCODES_ES_MYFZMR(string TYPENAME);

        object LoadCODES_ES_WHYL(string TYPENAME);

        object LoadCODES_ES_QTES(string TYPENAME);

        object LoadCODES_CL(string TYPENAME);

        object LoadCODES_CW(string TYPENAME);

        object LoadCODES_PWKQ(string TYPENAME);

        object LoadCODES_CY(string TYPENAME);

        object LoadCODES_XXYL(string TYPENAME);

        object LoadCODES_LR(string TYPENAME);

        object LoadCODES_ZSJM(string TYPENAME);

        object LoadCODES_PFCG(string TYPENAME);

        object LoadCODES_QZZP(string TYPENAME);

        object LoadCODES_SHFW(string TYPENAME);

        object LoadGCQXJBXX(string GCQX);

        object LoadHCJBXX(string HC);

        object LoadGCCJBXX(string GCC);

        object LoadGCCPPXX(string GCCLX, string GCCBP);

        object LoadLPXX(string LPID);

        object LoadKCPPXX(string KCLX, string KCBQ);

        object LoadJCPPXX(string JCLX, string JCBQ);

        object LoadKCCXXX(string PPID);

        object LoadJXXX(string JXID);

        object LoadHNCYXX(string PZID);

        object LoadCWYPSPXX(string LBID);

        object LoadBJQXXX(string LBID);

        object LoadGCQXXH(string PPID);

        object LoadCWPZXX(string CWBQ);

        object LoadQYBySuperName(string SUPERNAME);

        object LoadSQByQY(string QY);

        object LoadSJXHBySJPP(string SJPP);
        
        object LoadBJBXHByBJBPP(string BJBPP);

        object LoadPBXHByPBPP(string PBPP);

        string GetYHZHXXIDByYHID(string YHID);

        YHJBXX GetYHJBXXByYHM(string YHM);

        string GetLBQCByLBID(int LBID);

        object LoadMRBJXX(string name);

        object LoadLPXSPXX(string name);

        object LoadZWLBXX(string typename);
    }
}
