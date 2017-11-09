using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ISHFW_WXFW_SJSMWXBLL : IBaseBLL
    {
        object SaveSHFW_WXFW_SJSMWXJBXX(JCXX jcxx, SHFW_WXFW_SJSMWXJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadSHFW_WXFW_SJSMWXJBXX(string ID);
    }
}
