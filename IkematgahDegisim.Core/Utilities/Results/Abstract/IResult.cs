using System;
using System.Collections.Generic;
using System.Text;

namespace IkematgahDegisim.Core.Utilities.Results.Abstract
{
    public interface IResult
    {
        string Message { get; set; }
        bool Success { get; set; }
    }
}
