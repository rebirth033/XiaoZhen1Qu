using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IES_QTES_CRYPBLL : IBaseBLL
    {
        object SaveES_QTES_CRYPJBXX(JCXX jcxx, ES_QTES_CRYPJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadES_QTES_CRYPJBXX(string ES_QTES_CRYPJBXXID);
    }
}
