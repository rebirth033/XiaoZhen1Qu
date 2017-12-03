using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ISHFW_BLL : IBaseBLL
    {
        object SaveSHFW_BJJBXX(JCXX jcxx, SHFW_BJJBXX jbxx, List<PHOTOS> photos);

        object LoadSHFW_BJJBXX(string ID);

        object SaveSHFW_BJQXJBXX(JCXX jcxx, SHFW_BJQXJBXX jbxx, List<PHOTOS> photos);

        object LoadSHFW_BJQXJBXX(string ID);

        object SaveSHFW_BMYSJBXX(JCXX jcxx, SHFW_BMYSJBXX jbxx, List<PHOTOS> photos);

        object LoadSHFW_BMYSJBXX(string ID);

        object SaveSHFW_BZMDJBXX(JCXX jcxx, SHFW_BZMDJBXX jbxx, List<PHOTOS> photos);

        object LoadSHFW_BZMDJBXX(string ID);

        object SaveSHFW_GDSTQLJBXX(JCXX jcxx, SHFW_GDSTQLJBXX jbxx, List<PHOTOS> photos);

        object LoadSHFW_GDSTQLJBXX(string ID);

        object SaveSHFW_KSHSXSJBXX(JCXX jcxx, SHFW_KSHSXSJBXX jbxx, List<PHOTOS> photos);

        object LoadSHFW_KSHSXSJBXX(string ID);

        object SaveSHFW_SHPSJBXX(JCXX jcxx, SHFW_SHPSJBXX jbxx, List<PHOTOS> photos);

        object LoadSHFW_SHPSJBXX(string ID);

        object SaveSHFW_DNWXJBXX(JCXX jcxx, SHFW_DNWXJBXX jbxx, List<PHOTOS> photos);

        object LoadSHFW_DNWXJBXX(string ID);

        object SaveSHFW_FWWXJBXX(JCXX jcxx, SHFW_FWWXJBXX jbxx, List<PHOTOS> photos);

        object LoadSHFW_FWWXJBXX(string ID);

        object SaveSHFW_JDWXJBXX(JCXX jcxx, SHFW_JDWXJBXX jbxx, List<PHOTOS> photos);

        object LoadSHFW_JDWXJBXX(string ID);

        object SaveSHFW_JJWXJBXX(JCXX jcxx, SHFW_JJWXJBXX jbxx, List<PHOTOS> photos);

        object LoadSHFW_JJWXJBXX(string ID);

        object SaveSHFW_SJWXJBXX(JCXX jcxx, SHFW_SJWXJBXX jbxx, List<PHOTOS> photos);

        object LoadSHFW_SJWXJBXX(string ID);

        object SaveSHFW_SMWXJBXX(JCXX jcxx, SHFW_SMWXJBXX jbxx, List<PHOTOS> photos);

        object LoadSHFW_SMWXJBXX(string ID);
    }
}
