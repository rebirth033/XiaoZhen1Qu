using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IBaseBLL
    {
        
        

        object LoadCODES_SWFW(string TYPENAME);

        object LoadCODES_JYPX(string TYPENAME);

        object LoadCODES_LYJD(string TYPENAME);

        object LoadCODES_ZXJC(string TYPENAME);

        object LoadCODES_HQSY(string TYPENAME);

        object LoadCODES_NLMFY(string TYPENAME);


        object LoadBJQXXX(string LBID);

        object LoadQYBySuperName(string SUPERNAME);

        object LoadSQByQY(string QY);

        string GetYHZHXXIDByYHID(string YHID);

        YHJBXX GetYHJBXXByYHM(string YHM);

        string GetLBQCByLBID(int LBID);

        object LoadZWLBXX(string typename);

        object LoadCODESByTYPENAME(string TYPENAME, string TBName);

        object LoadByParentID(string ParentID, string TBName);

        object LoadByCodeValueAndTypeName(string CODEVALUE, string TYPENAME, string TBName);

    }
}
