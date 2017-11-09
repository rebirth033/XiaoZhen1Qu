using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface INLMFY_FLNYBLL : IBaseBLL
    {
        object SaveNLMFY_FLNYJBXX(JCXX jcxx, NLMFY_FLNYJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadNLMFY_FLNYJBXX(string ID);
    }
}
