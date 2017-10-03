using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ISHFW_SHFW_BZMDBLL : IBaseBLL
    {
        object SaveSHFW_SHFW_BZMDJBXX(JCXX jcxx, SHFW_SHFW_BZMDJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadSHFW_SHFW_BZMDJBXX(string SHFW_SHFW_BZMDJBXXID);
    }
}
