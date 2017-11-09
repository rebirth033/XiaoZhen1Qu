using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IJYPX_XLJYBLL : IBaseBLL
    {
        object SaveJYPX_XLJYJBXX(JCXX jcxx, JYPX_XLJYJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadJYPX_XLJYJBXX(string ID);
    }
}
