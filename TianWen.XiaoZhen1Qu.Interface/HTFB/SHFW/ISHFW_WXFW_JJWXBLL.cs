using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ISHFW_WXFW_JJWXBLL : IBaseBLL
    {
        object SaveSHFW_WXFW_JJWXJBXX(JCXX jcxx, SHFW_WXFW_JJWXJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadSHFW_WXFW_JJWXJBXX(string ID);
    }
}
