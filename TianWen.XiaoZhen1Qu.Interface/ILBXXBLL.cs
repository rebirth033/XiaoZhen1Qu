using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ILBXXBLL : IBaseBLL
    {
        IDAO DAO { get; set; }

        object LoadDL();

        object LoadXL(string CODEID);

        object LoadLBByID(string LBID);
    }
}
