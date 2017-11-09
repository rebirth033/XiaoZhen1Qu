using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ISWFW_ZLBLL : IBaseBLL
    {
        object SaveSWFW_ZLJBXX(JCXX jcxx, SWFW_ZLJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadSWFW_ZLJBXX(string ID);
    }
}
