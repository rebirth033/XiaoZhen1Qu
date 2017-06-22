using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IYHDLXXBLL
    {
        IDAO DAO { get; set; }

        object CheckLogin(string YHM, string MM);
    }
}
