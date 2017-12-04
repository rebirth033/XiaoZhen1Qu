using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IHQSY_BLL : IBaseBLL
    {
        object SaveHQSY_CZZXJBXX(JCXX jcxx, HQSY_CZZXJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadHQSY_CZZXJBXX(string ID);

        object SaveHQSY_HCZLJBXX(JCXX jcxx, HQSY_HCZLJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadHQSY_HCZLJBXX(string ID);

        object SaveHQSY_HLGPJBXX(JCXX jcxx, HQSY_HLGPJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadHQSY_HLGPJBXX(string ID);

        object SaveHQSY_HQGSJBXX(JCXX jcxx, HQSY_HQGSJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadHQSY_HQGSJBXX(string ID);

        object SaveHQSY_HQYPJBXX(JCXX jcxx, HQSY_HQYPJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadHQSY_HQYPJBXX(string ID);

        object SaveHQSY_HSLFJBXX(JCXX jcxx, HQSY_HSLFJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadHQSY_HSLFJBXX(string ID);

        object SaveHQSY_HSSYJBXX(JCXX jcxx, HQSY_HSSYJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadHQSY_HSSYJBXX(string ID);

        object SaveHQSY_HYJDJBXX(JCXX jcxx, HQSY_HYJDJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadHQSY_HYJDJBXX(string ID);

        object SaveHQSY_SYJBXX(JCXX jcxx, HQSY_SYJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadHQSY_SYJBXX(string ID);
    }
}
