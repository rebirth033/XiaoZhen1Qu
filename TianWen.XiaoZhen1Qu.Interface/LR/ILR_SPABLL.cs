using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ILR_SPABLL : IBaseBLL
    {
        object SaveLR_SPAJBXX(JCXX jcxx, LR_SPAJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadLR_SPAJBXX(string LR_SPAJBXXID);
    }
}
