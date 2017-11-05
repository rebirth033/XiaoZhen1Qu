using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ISHFW_CLFW_QCGZFHBLL : IBaseBLL
    {
        object SaveSHFW_CLFW_QCGZFHJBXX(JCXX jcxx, SHFW_CLFW_QCGZFHJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadSHFW_CLFW_QCGZFHJBXX(string SHFW_CLFW_QCGZFHJBXXID);
    }
}
