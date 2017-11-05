using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IPFCG_FSXMBLL : IBaseBLL
    {
        object SavePFCG_FSXMJBXX(JCXX jcxx, PFCG_FSXMJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadPFCG_FSXMJBXX(string PFCG_FSXMJBXXID);
    }
}
