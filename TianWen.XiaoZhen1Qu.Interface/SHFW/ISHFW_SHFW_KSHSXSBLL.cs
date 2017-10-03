using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ISHFW_SHFW_KSHSXSBLL : IBaseBLL
    {
        object SaveSHFW_SHFW_KSHSXSJBXX(JCXX jcxx, SHFW_SHFW_KSHSXSJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadSHFW_SHFW_KSHSXSJBXX(string SHFW_SHFW_KSHSXSJBXXID);
    }
}
