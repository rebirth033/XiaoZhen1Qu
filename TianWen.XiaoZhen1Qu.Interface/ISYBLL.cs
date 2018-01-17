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

        object LoadSY_ML(string XZQ);

        object LoadFCSY(string XZQDM, string XZQ);

        object LoadCLSY(string XZQDM, string XZQ);

        object LoadCWSY(string XZQDM, string XZQ);

        object LoadESSY(string XZQDM, string XZQ);

        object LoadZPSY(string XZQDM, string XZQ);

        object LoadHYLB(string XZQDM, string XZQ);

        object LoadSHFWTOP(string XZQDM, string XZQ);

        object LoadSHFWSY(string XZQDM, string XZQ);
    }
}
