using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ISHFW_CLFW_QCWXBYBLL : IBaseBLL
    {
        object SaveSHFW_CLFW_QCWXBYJBXX(JCXX jcxx, SHFW_CLFW_QCWXBYJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadSHFW_CLFW_QCWXBYJBXX(string SHFW_CLFW_QCWXBYJBXXID);
    }
}
