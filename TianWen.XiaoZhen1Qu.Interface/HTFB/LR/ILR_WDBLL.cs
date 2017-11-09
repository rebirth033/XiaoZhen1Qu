using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ILR_WDBLL : IBaseBLL
    {
        object SaveLR_WDJBXX(JCXX jcxx, LR_WDJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadLR_WDJBXX(string ID);
    }
}
