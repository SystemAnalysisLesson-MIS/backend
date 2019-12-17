using System;
using System.Collections.Generic;
using System.Text;

namespace IkematgahDegisim.Core.Utilities.Results.Concerete.Fail
{
    public class FailDataResult<T>:DataResult<T>
    {
        public FailDataResult(T data, string Message) : base(data, Message,false)
        {

        }

        public FailDataResult(T data) : base(data, false)
        {

        }

        public FailDataResult(string Message) : base(default, Message, false)
        {

        }

        public FailDataResult() : base(default, false)
        {

        }
    }
}
