using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ISHFW_SHFW_DNWXBLL : IBaseBLL
    {
        object SaveSHFW_SHFW_DNWXJBXX(JCXX jcxx, SHFW_SHFW_DNWXJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadSHFW_SHFW_DNWXJBXX(string SHFW_SHFW_DNWXJBXXID);
    }
}
