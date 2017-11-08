using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IPFCG_TSBLL : IBaseBLL
    {
        object SavePFCG_TSJBXX(JCXX jcxx, PFCG_TSJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadPFCG_TSJBXX(string ID);
    }
}
