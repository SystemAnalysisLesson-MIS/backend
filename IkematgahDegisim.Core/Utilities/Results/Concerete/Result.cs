using IkematgahDegisim.Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace IkematgahDegisim.Core.Utilities.Results.Concerete
{
    public class Result : IResult
    {
        public Result(string Message,bool Success) : this(Success)
        {
            this.Message = Message;
        }

        public Result(bool Success)
        {
            this.Success = Success;
        }

        public string Message { get; set; }
        public bool Success { get; set; }
    }
}
