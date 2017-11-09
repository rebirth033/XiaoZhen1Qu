using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface INLMFY_NJJSBBLL : IBaseBLL
    {
        object SaveNLMFY_NJJSBJBXX(JCXX jcxx, NLMFY_NJJSBJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadNLMFY_NJJSBJBXX(string ID);
    }
}
