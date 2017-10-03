using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ISHFW_SHFW_JDWXBLL : IBaseBLL
    {
        object SaveSHFW_SHFW_JDWXJBXX(JCXX jcxx, SHFW_SHFW_JDWXJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadSHFW_SHFW_JDWXJBXX(string SHFW_SHFW_JDWXJBXXID);
    }
}
