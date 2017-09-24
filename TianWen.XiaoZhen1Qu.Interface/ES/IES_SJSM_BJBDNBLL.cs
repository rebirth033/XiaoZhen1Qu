using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IES_SJSM_BJBDNBLL : IBaseBLL
    {
        object SaveES_SJSM_BJBDNJBXX(JCXX jcxx, ES_SJSM_BJBDNJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadES_SJSM_BJBDNJBXX(string ES_SJSM_BJBDNJBXXID);
    }
}
