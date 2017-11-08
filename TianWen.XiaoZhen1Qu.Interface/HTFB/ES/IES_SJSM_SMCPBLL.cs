using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IES_SJSM_SMCPBLL : IBaseBLL
    {
        object SaveES_SJSM_SMCPJBXX(JCXX jcxx, ES_SJSM_SMCPJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadES_SJSM_SMCPJBXX(string ID);
    }
}
