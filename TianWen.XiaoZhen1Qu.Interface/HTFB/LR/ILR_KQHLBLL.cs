using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ILR_KQHLBLL : IBaseBLL
    {
        object SaveLR_KQHLJBXX(JCXX jcxx, LR_KQHLJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadLR_KQHLJBXX(string LR_KQHLJBXXID);
    }
}
