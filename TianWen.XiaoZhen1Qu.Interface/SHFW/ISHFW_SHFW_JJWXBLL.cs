using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ISHFW_SHFW_JJWXBLL : IBaseBLL
    {
        object SaveSHFW_SHFW_JJWXJBXX(JCXX jcxx, SHFW_SHFW_JJWXJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadSHFW_SHFW_JJWXJBXX(string SHFW_SHFW_JJWXJBXXID);
    }
}
