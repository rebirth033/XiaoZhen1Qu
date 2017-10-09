using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IJYPX_YYEJYBLL : IBaseBLL
    {
        object SaveJYPX_YYEJYJBXX(JCXX jcxx, JYPX_YYEJYJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadJYPX_YYEJYJBXX(string JYPX_YYEJYJBXXID);
    }
}
