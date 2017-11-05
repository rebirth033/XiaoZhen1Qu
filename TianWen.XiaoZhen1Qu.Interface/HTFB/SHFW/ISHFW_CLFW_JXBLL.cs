using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ISHFW_CLFW_JXBLL : IBaseBLL
    {
        object SaveSHFW_CLFW_JXJBXX(JCXX jcxx, SHFW_CLFW_JXJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadSHFW_CLFW_JXJBXX(string SHFW_CLFW_JXJBXXID);
    }
}
