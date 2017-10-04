using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ISHFW_SHFW_FWWXDKBLL : IBaseBLL
    {
        object SaveSHFW_SHFW_FWWXDKJBXX(JCXX jcxx, SHFW_SHFW_FWWXDKJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadSHFW_SHFW_FWWXDKJBXX(string SHFW_SHFW_FWWXDKJBXXID);
    }
}
