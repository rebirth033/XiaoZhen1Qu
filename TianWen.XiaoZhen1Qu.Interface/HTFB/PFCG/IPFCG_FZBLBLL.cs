using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IPFCG_FZBLBLL : IBaseBLL
    {
        object SavePFCG_FZBLJBXX(JCXX jcxx, PFCG_FZBLJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadPFCG_FZBLJBXX(string ID);
    }
}
