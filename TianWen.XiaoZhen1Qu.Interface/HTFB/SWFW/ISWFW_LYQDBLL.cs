using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ISWFW_LYQDBLL : IBaseBLL
    {
        object SaveSWFW_LYQDJBXX(JCXX jcxx, SWFW_LYQDJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadSWFW_LYQDJBXX(string ID);
    }
}
