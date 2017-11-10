using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface INLMFY_BLL : IBaseBLL
    {
        object SaveNLMFY_CQYZJBXX(JCXX jcxx, NLMFY_CQYZJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadNLMFY_CQYZJBXX(string ID);

        object SaveNLMFY_DZWZMJBXX(JCXX jcxx, NLMFY_DZWZMJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadNLMFY_DZWZMJBXX(string ID);

        object SaveNLMFY_FLNYJBXX(JCXX jcxx, NLMFY_FLNYJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadNLMFY_FLNYJBXX(string ID);

        object SaveNLMFY_NCPJGJBXX(JCXX jcxx, NLMFY_NCPJGJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadNLMFY_NCPJGJBXX(string ID);

        object SaveNLMFY_NJJSBJBXX(JCXX jcxx, NLMFY_NJJSBJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadNLMFY_NJJSBJBXX(string ID);

        object SaveNLMFY_NZWJBXX(JCXX jcxx, NLMFY_NZWJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadNLMFY_NZWJBXX(string ID);

        object SaveNLMFY_SCJBXX(JCXX jcxx, NLMFY_SCJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadNLMFY_SCJBXX(string ID);

        object SaveNLMFY_SLSYJBXX(JCXX jcxx, NLMFY_SLSYJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadNLMFY_SLSYJBXX(string ID);

        object SaveNLMFY_YLHHJBXX(JCXX jcxx, NLMFY_YLHHJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadNLMFY_YLHHJBXX(string ID);
    }
}
