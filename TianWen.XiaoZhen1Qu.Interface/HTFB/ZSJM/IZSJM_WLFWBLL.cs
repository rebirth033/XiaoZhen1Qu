using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IZSJM_WLFWBLL : IBaseBLL
    {
        object SaveZSJM_WLFWJBXX(JCXX jcxx, ZSJM_WLFWJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadZSJM_WLFWJBXX(string ID);
    }
}
