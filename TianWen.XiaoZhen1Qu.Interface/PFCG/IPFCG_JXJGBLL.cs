using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IPFCG_JXJGBLL : IBaseBLL
    {
        object SavePFCG_JXJGJBXX(JCXX jcxx, PFCG_JXJGJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadPFCG_JXJGJBXX(string PFCG_JXJGJBXXID);
    }
}
