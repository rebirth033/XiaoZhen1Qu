using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ISHFW_SHFW_BJBLL : IBaseBLL
    {
        object SaveSHFW_SHFW_BJJBXX(JCXX jcxx, SHFW_SHFW_BJJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadSHFW_SHFW_BJJBXX(string ID);
    }
}
