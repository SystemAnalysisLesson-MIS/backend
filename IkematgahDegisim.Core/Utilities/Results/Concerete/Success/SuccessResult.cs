using System;
using System.Collections.Generic;
using System.Text;

namespace IkematgahDegisim.Core.Utilities.Results.Concerete.Success
{
   public class SuccessResult:Result
    {
        public SuccessResult() : base(true)
        {

        }

        public SuccessResult(string Message) : base(Message, true)
        {

        }
    }
}
