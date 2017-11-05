using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ILR_MTSSBLL : IBaseBLL
    {
        object SaveLR_MTSSJBXX(JCXX jcxx, LR_MTSSJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadLR_MTSSJBXX(string LR_MTSSJBXXID);
    }
}
