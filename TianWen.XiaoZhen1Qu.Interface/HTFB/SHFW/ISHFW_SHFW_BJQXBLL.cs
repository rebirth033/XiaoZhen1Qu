using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ISHFW_SHFW_BJQXBLL : IBaseBLL
    {
        object SaveSHFW_SHFW_BJQXJBXX(JCXX jcxx, SHFW_SHFW_BJQXJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadSHFW_SHFW_BJQXJBXX(string SHFW_SHFW_BJQXJBXXID);
    }
}
