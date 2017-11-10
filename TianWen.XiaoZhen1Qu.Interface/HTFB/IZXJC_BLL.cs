using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IZXJC_BLL : IBaseBLL
    {
        object SaveZXJC_FWGZJBXX(JCXX jcxx, ZXJC_FWGZJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadZXJC_FWGZJBXX(string ID);

        object SaveZXJC_GZFWJBXX(JCXX jcxx, ZXJC_GZFWJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadZXJC_GZFWJBXX(string ID);

        object SaveZXJC_JCJBXX(JCXX jcxx, ZXJC_JCJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadZXJC_JCJBXX(string ID);

        object SaveZXJC_JFJSJBXX(JCXX jcxx, ZXJC_JFJSJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadZXJC_JFJSJBXX(string ID);

        object SaveZXJC_JJJBXX(JCXX jcxx, ZXJC_JJJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadZXJC_JJJBXX(string ID);

        object SaveZXJC_JZFWJBXX(JCXX jcxx, ZXJC_JZFWJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadZXJC_JZFWJBXX(string ID);
    }
}
