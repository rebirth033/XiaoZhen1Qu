using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IES_QTES_GCQXBLL : IBaseBLL
    {
        object SaveES_QTES_GCQXJBXX(JCXX jcxx, ES_QTES_GCQXJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadES_QTES_GCQXJBXX(string ES_QTES_GCQXJBXXID);
    }
}
