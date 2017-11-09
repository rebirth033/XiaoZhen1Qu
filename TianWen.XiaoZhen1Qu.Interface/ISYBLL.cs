using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ISYBLL : IBaseBLL
    {
        IDAO DAO { get; set; }

        object LoadZXFBXX();

        object LoadLBByJCXX(string lbid, string jcxxid);

        object LoadSY_ML(string TYPENAME, string XZQ);
    }
}
