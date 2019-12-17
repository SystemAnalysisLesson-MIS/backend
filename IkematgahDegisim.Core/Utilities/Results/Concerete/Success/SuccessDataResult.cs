using System;
using System.Collections.Generic;
using System.Text;

namespace IkematgahDegisim.Core.Utilities.Results.Concerete.Success
{
    public class SuccessDataResult<T>:DataResult<T>
    {
        public SuccessDataResult(T data,string Message) : base(data, Message, true)
        {

        }

        public SuccessDataResult(T data) : base(data, true)
        {

        }

        public SuccessDataResult(string Message) : base(default,Message,true)
        {

        }

        public SuccessDataResult() : base(default, true)
        {

        }
    }
}
