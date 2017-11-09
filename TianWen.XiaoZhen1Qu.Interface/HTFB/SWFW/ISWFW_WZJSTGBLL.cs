using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ISWFW_WZJSTGBLL : IBaseBLL
    {
        object SaveSWFW_WZJSTGJBXX(JCXX jcxx, SWFW_WZJSTGJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadSWFW_WZJSTGJBXX(string ID);
    }
}
