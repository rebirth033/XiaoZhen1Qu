using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ISHFW_CLFW_QCPLBLL : IBaseBLL
    {
        object SaveSHFW_CLFW_QCPLJBXX(JCXX jcxx, SHFW_CLFW_QCPLJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadSHFW_CLFW_QCPLJBXX(string SHFW_CLFW_QCPLJBXXID);
    }
}
