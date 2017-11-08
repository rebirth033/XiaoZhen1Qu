using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IES_SJSM_PBDNBLL : IBaseBLL
    {
        object SaveES_SJSM_PBDNJBXX(JCXX jcxx, ES_SJSM_PBDNJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadES_SJSM_PBDNJBXX(string ID);
    }
}
