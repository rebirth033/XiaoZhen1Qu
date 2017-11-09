using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ISWFW_PHZPBLL : IBaseBLL
    {
        object SaveSWFW_PHZPJBXX(JCXX jcxx, SWFW_PHZPJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadSWFW_PHZPJBXX(string ID);
    }
}
