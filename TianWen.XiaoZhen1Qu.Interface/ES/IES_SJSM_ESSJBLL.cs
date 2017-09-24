using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IES_SJSM_ESSJBLL : IBaseBLL
    {
        object SaveES_SJSM_ESSJJBXX(JCXX jcxx, ES_SJSM_ESSJJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadES_SJSM_ESSJJBXX(string ES_SJSM_ESSJJBXXID);
    }
}
