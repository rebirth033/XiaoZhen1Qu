using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ILR_TJBLL : IBaseBLL
    {
        object SaveLR_TJJBXX(JCXX jcxx, LR_TJJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadLR_TJJBXX(string ID);
    }
}
