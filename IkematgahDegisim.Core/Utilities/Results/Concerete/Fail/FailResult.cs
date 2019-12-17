using System;
using System.Collections.Generic;
using System.Text;

namespace IkematgahDegisim.Core.Utilities.Results.Concerete.Fail
{
    public class FailResult:Result
    {
        public FailResult() : base(false)
        {

        }

        public FailResult(string Message) : base(Message, false)
        {

        }
    }
}
