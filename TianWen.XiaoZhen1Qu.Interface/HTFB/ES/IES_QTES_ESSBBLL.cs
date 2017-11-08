using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IES_QTES_ESSBBLL : IBaseBLL
    {
        object SaveES_QTES_ESSBJBXX(JCXX jcxx, ES_QTES_ESSBJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadES_QTES_ESSBJBXX(string ID);
    }
}
