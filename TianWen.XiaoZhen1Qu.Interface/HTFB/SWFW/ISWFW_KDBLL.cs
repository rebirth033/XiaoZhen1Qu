using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ISWFW_KDBLL : IBaseBLL
    {
        object SaveSWFW_KDJBXX(JCXX jcxx, SWFW_KDJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadSWFW_KDJBXX(string ID);
    }
}
