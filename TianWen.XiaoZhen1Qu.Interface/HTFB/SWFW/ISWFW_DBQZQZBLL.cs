using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ISWFW_DBQZQZBLL : IBaseBLL
    {
        object SaveSWFW_DBQZQZJBXX(JCXX jcxx, SWFW_DBQZQZJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadSWFW_DBQZQZJBXX(string ID);
    }
}
