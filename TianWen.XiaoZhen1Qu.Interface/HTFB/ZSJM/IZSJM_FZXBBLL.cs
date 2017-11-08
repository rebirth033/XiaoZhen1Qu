using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IZSJM_FZXBBLL : IBaseBLL
    {
        object SaveZSJM_FZXBJBXX(JCXX jcxx, ZSJM_FZXBJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadZSJM_FZXBJBXX(string ID);
    }
}
