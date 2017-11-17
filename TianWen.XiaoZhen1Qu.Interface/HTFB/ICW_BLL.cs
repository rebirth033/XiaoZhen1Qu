using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface.HTFB
{
    public interface ICW_BLL : IBaseBLL
    {
        object SaveCW_CWFWJBXX(JCXX jcxx, CW_CWFWJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadCW_CWFWJBXX(string ID);

        object SaveCW_CWGJBXX(JCXX jcxx, CW_CWGJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadCW_CWGJBXX(string ID);

        object SaveCW_CWMJBXX(JCXX jcxx, CW_CWMJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadCW_CWMJBXX(string ID);

        object SaveCW_CWYPSPJBXX(JCXX jcxx, CW_CWYPSPJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadCW_CWYPSPJBXX(string ID);

        object SaveCW_CWGYJBXX(JCXX jcxx, CW_CWGYJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadCW_CWGYJBXX(string ID);

        object SaveCW_HNYCJBXX(JCXX jcxx, CW_HNYCJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadCW_HNYCJBXX(string ID);
    }
}
