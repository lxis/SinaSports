using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sina.Sports.Server.Common.CustomExceptions.Imp
{
    public class VerifyerBase
    {
        public void Throw<V>(int code, string errorMsg) where V : FaultBase, new()
        {
            throw new RestServiceException<V>(
                new V()
                {
                    Code = code,
                    ErrorMsg = errorMsg
                });
        }

    }
}
