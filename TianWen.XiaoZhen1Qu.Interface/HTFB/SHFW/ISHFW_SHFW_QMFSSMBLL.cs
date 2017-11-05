using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ISHFW_SHFW_QMFSSMBLL : IBaseBLL
    {
        object SaveSHFW_SHFW_QMFSSMJBXX(JCXX jcxx, SHFW_SHFW_QMFSSMJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadSHFW_SHFW_QMFSSMJBXX(string SHFW_SHFW_QMFSSMJBXXID);
    }
}
