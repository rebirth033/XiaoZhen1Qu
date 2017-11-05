using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IES_SJSM_TSJBLL : IBaseBLL
    {
        object SaveES_SJSM_TSJJBXX(JCXX jcxx, ES_SJSM_TSJJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadES_SJSM_TSJJBXX(string ES_SJSM_TSJJBXXID);
    }
}
