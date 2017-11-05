using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface INLMFY_NCPJGBLL : IBaseBLL
    {
        object SaveNLMFY_NCPJGJBXX(JCXX jcxx, NLMFY_NCPJGJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadNLMFY_NCPJGJBXX(string NLMFY_NCPJGJBXXID);
    }
}
