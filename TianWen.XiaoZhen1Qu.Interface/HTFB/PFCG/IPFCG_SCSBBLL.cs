using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IPFCG_SCSBBLL : IBaseBLL
    {
        object SavePFCG_SCSBJBXX(JCXX jcxx, PFCG_SCSBJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadPFCG_SCSBJBXX(string ID);
    }
}
