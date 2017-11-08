using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ISWFW_BGSBWXBLL : IBaseBLL
    {
        object SaveSWFW_BGSBWXJBXX(JCXX jcxx, SWFW_BGSBWXJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadSWFW_BGSBWXJBXX(string ID);
    }
}
