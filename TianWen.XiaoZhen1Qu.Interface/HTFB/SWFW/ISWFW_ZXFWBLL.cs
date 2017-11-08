using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ISWFW_ZXFWBLL : IBaseBLL
    {
        object SaveSWFW_ZXFWJBXX(JCXX jcxx, SWFW_ZXFWJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadSWFW_ZXFWJBXX(string ID);
    }
}
