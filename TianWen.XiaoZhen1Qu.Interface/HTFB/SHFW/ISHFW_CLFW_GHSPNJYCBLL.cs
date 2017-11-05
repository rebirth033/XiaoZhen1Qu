using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ISHFW_CLFW_GHSPNJYCBLL : IBaseBLL
    {
        object SaveSHFW_CLFW_GHSPNJYCJBXX(JCXX jcxx, SHFW_CLFW_GHSPNJYCJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadSHFW_CLFW_GHSPNJYCJBXX(string SHFW_CLFW_GHSPNJYCJBXXID);
    }
}
