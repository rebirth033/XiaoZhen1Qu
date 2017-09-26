using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ILR_MJBLL : IBaseBLL
    {
        object SaveLR_MJJBXX(JCXX jcxx, LR_MJJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadLR_MJJBXX(string LR_MJJBXXID);
    }
}
