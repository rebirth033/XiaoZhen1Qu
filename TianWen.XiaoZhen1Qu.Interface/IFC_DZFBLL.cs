using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IFC_DZFBLL
    {
        IDAO DAO { get; set; }
        
        object SaveDZFJBXX(JCXX jcxx, FC_DZFJBXX dzfjbxx, List<PHOTOS> photos);
        
        object LoadFC_DZFJBXX(string FC_DZFJBXXID);
    }
}
