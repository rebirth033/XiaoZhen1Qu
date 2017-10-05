using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ISHFW_CLFW_QCMRZSBLL : IBaseBLL
    {
        object SaveSHFW_CLFW_QCMRZSJBXX(JCXX jcxx, SHFW_CLFW_QCMRZSJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadSHFW_CLFW_QCMRZSJBXX(string SHFW_CLFW_QCMRZSJBXXID);
    }
}
