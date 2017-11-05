using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface INLMFY_SCBLL : IBaseBLL
    {
        object SaveNLMFY_SCJBXX(JCXX jcxx, NLMFY_SCJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadNLMFY_SCJBXX(string NLMFY_SCJBXXID);
    }
}
