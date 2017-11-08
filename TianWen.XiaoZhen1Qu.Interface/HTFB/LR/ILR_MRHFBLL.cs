using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ILR_MRHFBLL : IBaseBLL
    {
        object SaveLR_MRHFJBXX(JCXX jcxx, LR_MRHFJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadLR_MRHFJBXX(string ID);
    }
}
