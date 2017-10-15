using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface INLMFY_DZWZMBLL : IBaseBLL
    {
        object SaveNLMFY_DZWZMJBXX(JCXX jcxx, NLMFY_DZWZMJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadNLMFY_DZWZMJBXX(string NLMFY_DZWZMJBXXID);
    }
}
