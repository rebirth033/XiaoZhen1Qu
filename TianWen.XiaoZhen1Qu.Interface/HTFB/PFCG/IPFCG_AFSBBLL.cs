using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IPFCG_AFSBBLL : IBaseBLL
    {
        object SavePFCG_AFSBJBXX(JCXX jcxx, PFCG_AFSBJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadPFCG_AFSBJBXX(string ID);
    }
}
