using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ISHFW_WXFW_DNWXBLL : IBaseBLL
    {
        object SaveSHFW_WXFW_DNWXJBXX(JCXX jcxx, SHFW_WXFW_DNWXJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadSHFW_WXFW_DNWXJBXX(string SHFW_WXFW_DNWXJBXXID);
    }
}
