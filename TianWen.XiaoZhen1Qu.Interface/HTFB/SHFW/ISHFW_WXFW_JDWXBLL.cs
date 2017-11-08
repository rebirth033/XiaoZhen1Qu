using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ISHFW_WXFW_JDWXBLL : IBaseBLL
    {
        object SaveSHFW_WXFW_JDWXJBXX(JCXX jcxx, SHFW_WXFW_JDWXJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadSHFW_WXFW_JDWXJBXX(string ID);
    }
}
