using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ISHFW_CLFW_ZCBLL : IBaseBLL
    {
        object SaveSHFW_CLFW_ZCJBXX(JCXX jcxx, SHFW_CLFW_ZCJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadSHFW_CLFW_ZCJBXX(string SHFW_CLFW_ZCJBXXID);
    }
}
