using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ISWFW_YSBZBLL : IBaseBLL
    {
        object SaveSWFW_YSBZJBXX(JCXX jcxx, SWFW_YSBZJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadSWFW_YSBZJBXX(string SWFW_YSBZJBXXID);
    }
}
