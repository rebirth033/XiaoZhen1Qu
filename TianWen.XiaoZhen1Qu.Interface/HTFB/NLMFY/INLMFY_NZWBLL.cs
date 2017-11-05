using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface INLMFY_NZWBLL : IBaseBLL
    {
        object SaveNLMFY_NZWJBXX(JCXX jcxx, NLMFY_NZWJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadNLMFY_NZWJBXX(string NLMFY_NZWJBXXID);
    }
}
