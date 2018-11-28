﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLGeneratorLogic.Mapper
{
    public interface IMapper<in TInput, out TOutput>
    {
        TOutput Map(TInput value);
    }
}
