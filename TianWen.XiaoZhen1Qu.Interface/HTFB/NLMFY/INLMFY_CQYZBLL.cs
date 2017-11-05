using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface INLMFY_CQYZBLL : IBaseBLL
    {
        object SaveNLMFY_CQYZJBXX(JCXX jcxx, NLMFY_CQYZJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadNLMFY_CQYZJBXX(string NLMFY_CQYZJBXXID);
    }
}
