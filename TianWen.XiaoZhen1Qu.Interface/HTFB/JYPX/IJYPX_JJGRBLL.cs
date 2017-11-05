using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IJYPX_JJGRBLL : IBaseBLL
    {
        object SaveJYPX_JJGRJBXX(JCXX jcxx, JYPX_JJGRJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadJYPX_JJGRJBXX(string JYPX_JJGRJBXXID);
    }
}
