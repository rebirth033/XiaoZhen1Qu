using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IPFCG_YCLBLL : IBaseBLL
    {
        object SavePFCG_YCLJBXX(JCXX jcxx, PFCG_YCLJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadPFCG_YCLJBXX(string PFCG_YCLJBXXID);
    }
}
