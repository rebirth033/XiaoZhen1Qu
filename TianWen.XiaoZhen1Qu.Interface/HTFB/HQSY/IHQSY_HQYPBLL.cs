using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IHQSY_HQYPBLL : IBaseBLL
    {
        object SaveHQSY_HQYPJBXX(JCXX jcxx, HQSY_HQYPJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadHQSY_HQYPJBXX(string ID);
    }
}
