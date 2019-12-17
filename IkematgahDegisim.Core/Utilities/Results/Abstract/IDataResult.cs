﻿using System;
using System.Collections.Generic;
using System.Text;

namespace IkematgahDegisim.Core.Utilities.Results.Abstract
{
    public interface IDataResult<T>:IResult
    {
        T Data { get; set; }
    }
}
