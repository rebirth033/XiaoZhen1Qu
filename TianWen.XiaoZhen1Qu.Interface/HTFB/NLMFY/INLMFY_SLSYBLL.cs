using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface INLMFY_SLSYBLL : IBaseBLL
    {
        object SaveNLMFY_SLSYJBXX(JCXX jcxx, NLMFY_SLSYJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadNLMFY_SLSYJBXX(string ID);
    }
}
