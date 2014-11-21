using Sina.Sports.Server.Common.CustomExceptions;
using Sina.Sports.Server.Common.CustomExceptions.Imp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sina.Sports.Server.Common.Sina.CustomExceptions
{
    public class ServerVerifyImp : VerifyerBase, IJsonVerifyer
    {
        public void Verify(int code, string errorMsg = null)
        {
            switch (code)
            {
                case 0: break;
                //case 2: Throw<LoginFault>(code, errorMsg); break;
                default: Throw<FaultBase>(code, errorMsg); break;
            }
        }
    }
}
