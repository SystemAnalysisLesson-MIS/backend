using IkematgahDegisim.Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace IkematgahDegisim.Core.Utilities.Results.Concerete
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data, string Message,bool Success) : base(Message,Success)
        {
            this.Data = data;
        }

        public DataResult(T data, bool Success) : base(Success)
        {
           this.Data = data;
        }


        public T Data { get; set ; }
    }
}
