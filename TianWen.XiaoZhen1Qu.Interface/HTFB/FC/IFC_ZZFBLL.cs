﻿using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IFC_ZZFBLL : IBaseBLL
    {
        IDAO DAO { get; set; }

        object SaveFC_ZZFJBXX(JCXX jcxx, FC_ZZFJBXX FC_ZZFjbxx, List<PHOTOS> photos);

        object LoadFC_ZZFJBXX(string ID);

        object LoadXQJBXXSByHZ(string XQMC);

        object LoadXQJBXXSByPY(string XQMC);
    }
}
