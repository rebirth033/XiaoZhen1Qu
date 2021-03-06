﻿using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IBaseBLL
    {
        object LoadQYBySuperName(string SUPERNAME);

        object LoadDDByQY(string QY);

        string GetYHZHXXIDByYHID(string YHID);

        YHJBXX GetYHJBXXByYHM(string YHM);

        string GetLBQCByLBID(int LBID);

        object LoadZWLBXX(string typename);

        object LoadCODESByTYPENAME(string TYPENAME, string TBName);

        object LoadCODESByTYPENAMES(string TYPENAMES, string TBName, string XZQDM);

        object LoadChildByCODENAME(string CODENAME, string TBName);

        object LoadByParentID(string ParentID, string TBName);

        object LoadByCodeValueAndTypeName(string CODEVALUE, string TYPENAME, string TBName);

        object LoadXGLM(string TYPE, string XZQ);

    }
}
