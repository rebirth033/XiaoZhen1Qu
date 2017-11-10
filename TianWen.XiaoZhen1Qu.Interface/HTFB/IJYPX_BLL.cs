using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IJYPX_BLL : IBaseBLL
    {
        object SaveJYPX_GLPXJBXX(JCXX jcxx, JYPX_GLPXJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadJYPX_GLPXJBXX(string ID);

        object SaveJYPX_ITPXJBXX(JCXX jcxx, JYPX_ITPXJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadJYPX_ITPXJBXX(string ID);

        object SaveJYPX_JJGRJBXX(JCXX jcxx, JYPX_JJGRJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadJYPX_JJGRJBXX(string ID);

        object SaveJYPX_JJJGJBXX(JCXX jcxx, JYPX_JJJGJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadJYPX_JJJGJBXX(string ID);

        object SaveJYPX_LXJBXX(JCXX jcxx, JYPX_LXJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadJYPX_LXJBXX(string ID);

        object SaveJYPX_PBPKJBXX(JCXX jcxx, JYPX_PBPKJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadJYPX_PBPKJBXX(string ID);

        object SaveJYPX_SJPXJBXX(JCXX jcxx, JYPX_SJPXJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadJYPX_SJPXJBXX(string ID);

        object SaveJYPX_TYJLJBXX(JCXX jcxx, JYPX_TYJLJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadJYPX_TYJLJBXX(string ID);

        object SaveJYPX_TYPXJBXX(JCXX jcxx, JYPX_TYPXJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadJYPX_TYPXJBXX(string ID);

        object SaveJYPX_XLJYJBXX(JCXX jcxx, JYPX_XLJYJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadJYPX_XLJYJBXX(string ID);

        object SaveJYPX_YMJBXX(JCXX jcxx, JYPX_YMJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadJYPX_YMJBXX(string ID);

        object SaveJYPX_YSPXJBXX(JCXX jcxx, JYPX_YSPXJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadJYPX_YSPXJBXX(string ID);

        object SaveJYPX_YSPXJSJBXX(JCXX jcxx, JYPX_YSPXJSJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadJYPX_YSPXJSJBXX(string ID);

        object SaveJYPX_YYEJYJBXX(JCXX jcxx, JYPX_YYEJYJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadJYPX_YYEJYJBXX(string ID);

        object SaveJYPX_YYPXJGJBXX(JCXX jcxx, JYPX_YYPXJGJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadJYPX_YYPXJGJBXX(string ID);

        object SaveJYPX_YYPXJSJBXX(JCXX jcxx, JYPX_YYPXJSJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadJYPX_YYPXJSJBXX(string ID);

        object SaveJYPX_ZXXFDBJBXX(JCXX jcxx, JYPX_ZXXFDBJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadJYPX_ZXXFDBJBXX(string ID);

        object SaveJYPX_ZXXYDYJBXX(JCXX jcxx, JYPX_ZXXYDYJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadJYPX_ZXXYDYJBXX(string ID);

        object SaveJYPX_ZYJNPXJBXX(JCXX jcxx, JYPX_ZYJNPXJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadJYPX_ZYJNPXJBXX(string ID);
    }
}
