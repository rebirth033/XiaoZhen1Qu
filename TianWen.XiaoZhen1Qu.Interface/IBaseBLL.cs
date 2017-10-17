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

        object LoadCODES_SWFW(string TYPENAME);

        object LoadCODES_JYPX(string TYPENAME);

        object LoadCODES_LYJD(string TYPENAME);

        object LoadCODES_ZXJC(string TYPENAME);

        object LoadCODES_HQSY(string TYPENAME);

        object LoadCODES_NLMFY(string TYPENAME);


        object LoadBJQXXX(string LBID);

        object LoadCWPZXX(string CWBQ);

        object LoadQYBySuperName(string SUPERNAME);

        object LoadSQByQY(string QY);

        string GetYHZHXXIDByYHID(string YHID);

        YHJBXX GetYHJBXXByYHM(string YHM);

        string GetLBQCByLBID(int LBID);


        object LoadZWLBXX(string typename);



        object LoadBYYXXX(string BYYXBQ);


        object LoadHCPPXX(string HCPPBQ);

        object LoadByParentID(string ParentID, string TBName);

        object LoadByCodeValueAndTypeName(string CODEVALUE, string TYPENAME, string TBName);

        object LoadYLHHXX(string HCPPBQ, string TYPE);
    }
}
