using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ISHFW_CLFW_DJSJWPBLL : IBaseBLL
    {
        object SaveSHFW_CLFW_DJSJWPJBXX(JCXX jcxx, SHFW_CLFW_DJSJWPJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadSHFW_CLFW_DJSJWPJBXX(string ID);
    }
}
