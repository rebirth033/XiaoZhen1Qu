using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IPFCG_HWYDBLL : IBaseBLL
    {
        object SavePFCG_HWYDJBXX(JCXX jcxx, PFCG_HWYDJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadPFCG_HWYDJBXX(string PFCG_HWYDJBXXID);
    }
}
