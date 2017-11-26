using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IFC_BLL : IBaseBLL
    {
        object SaveCFCKTDCWJBXX(JCXX jcxx, FC_CFCKTDCWJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadFC_CFCKTDCWJBXX(string ID);

        object SaveDZFJBXX(JCXX jcxx, FC_DZFJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadFC_DZFJBXX(string ID);

        object SaveFC_ESFJBXX(JCXX jcxx, FC_ESFJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadFC_ESFJBXX(string ID);

        object SaveSPJBXX(JCXX jcxx, FC_SPJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadFC_SPJBXX(string ID);

        object SaveXZLJBXX(JCXX jcxx, FC_XZLJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadFC_XZLJBXX(string ID);

        object SaveFC_ZZFJBXX(JCXX jcxx, FC_ZZFJBXX FC_ZZFjbxx, List<PHOTOS> photos);

        object LoadFC_ZZFJBXX(string ID);

        object SaveFC_HZFJBXX(JCXX jcxx, FC_HZFJBXX FC_HZFjbxx, List<PHOTOS> photos);

        object LoadFC_HZFJBXX(string ID);

        object LoadXQJBXXSByHZ(string XQMC);

        object LoadXQJBXXSByPY(string XQMC);
    }
}
