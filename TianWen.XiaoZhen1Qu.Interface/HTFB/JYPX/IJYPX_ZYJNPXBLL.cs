using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IJYPX_ZYJNPXBLL : IBaseBLL
    {
        object SaveJYPX_ZYJNPXJBXX(JCXX jcxx, JYPX_ZYJNPXJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadJYPX_ZYJNPXJBXX(string ID);
    }
}
