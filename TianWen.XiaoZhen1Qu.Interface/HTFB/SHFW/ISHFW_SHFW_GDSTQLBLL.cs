using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ISHFW_SHFW_GDSTQLBLL : IBaseBLL
    {
        object SaveSHFW_SHFW_GDSTQLJBXX(JCXX jcxx, SHFW_SHFW_GDSTQLJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadSHFW_SHFW_GDSTQLJBXX(string ID);
    }
}
