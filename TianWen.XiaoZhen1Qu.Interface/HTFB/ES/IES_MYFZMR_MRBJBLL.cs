using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IES_MYFZMR_MRBJBLL : IBaseBLL
    {
        object SaveES_MYFZMR_MRBJJBXX(JCXX jcxx, ES_MYFZMR_MRBJJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadES_MYFZMR_MRBJJBXX(string ES_MYFZMR_MRBJJBXXID);
    }
}
