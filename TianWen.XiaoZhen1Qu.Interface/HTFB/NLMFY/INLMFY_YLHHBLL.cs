using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface INLMFY_YLHHBLL : IBaseBLL
    {
        object SaveNLMFY_YLHHJBXX(JCXX jcxx, NLMFY_YLHHJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadNLMFY_YLHHJBXX(string NLMFY_YLHHJBXXID);
    }
}
