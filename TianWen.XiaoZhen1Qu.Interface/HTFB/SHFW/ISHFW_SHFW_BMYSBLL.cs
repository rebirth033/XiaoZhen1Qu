using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ISHFW_SHFW_BMYSBLL : IBaseBLL
    {
        object SaveSHFW_SHFW_BMYSJBXX(JCXX jcxx, SHFW_SHFW_BMYSJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadSHFW_SHFW_BMYSJBXX(string SHFW_SHFW_BMYSJBXXID);
    }
}
