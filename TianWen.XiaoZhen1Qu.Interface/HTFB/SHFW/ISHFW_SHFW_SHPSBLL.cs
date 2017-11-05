using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ISHFW_SHFW_SHPSBLL : IBaseBLL
    {
        object SaveSHFW_SHFW_SHPSJBXX(JCXX jcxx, SHFW_SHFW_SHPSJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadSHFW_SHFW_SHPSJBXX(string SHFW_SHFW_SHPSJBXXID);
    }
}
