using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ISHFW_WXFW_FWWXDKBLL : IBaseBLL
    {
        object SaveSHFW_WXFW_FWWXDKJBXX(JCXX jcxx, SHFW_WXFW_FWWXDKJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadSHFW_WXFW_FWWXDKJBXX(string SHFW_WXFW_FWWXDKJBXXID);
    }
}
