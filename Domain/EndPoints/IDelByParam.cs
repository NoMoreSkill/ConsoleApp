﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.EndPoints
{
    public interface IDelByParam
    {
        void DeleteByParameter(Purify pure);
    }
}
