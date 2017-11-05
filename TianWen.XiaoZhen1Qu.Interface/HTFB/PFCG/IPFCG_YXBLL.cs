using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IPFCG_YXBLL : IBaseBLL
    {
        object SavePFCG_YXJBXX(JCXX jcxx, PFCG_YXJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadPFCG_YXJBXX(string PFCG_YXJBXXID);
    }
}
