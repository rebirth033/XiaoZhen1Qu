using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ILR_MFHFBLL : IBaseBLL
    {
        object SaveLR_MFHFJBXX(JCXX jcxx, LR_MFHFJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadLR_MFHFJBXX(string LR_MFHFJBXXID);
    }
}
