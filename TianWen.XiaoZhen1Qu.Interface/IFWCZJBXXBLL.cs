﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IFWCZJBXXBLL
    {
        IDAO DAO { get; set; }

        object SaveFWCZJBXX(JCXX jcxx, FWCZJBXX fwczjbxx);

        object LoadFWCZXX(string FWCZID);

        object LoadXQJBXXS(string XQMC);
    }
}
