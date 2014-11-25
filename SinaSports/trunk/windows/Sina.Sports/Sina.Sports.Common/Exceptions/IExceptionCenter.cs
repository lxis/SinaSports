using Sina.Sports.Common.Exceptions.Imp;
using Sina.Sports.Common.InversionofControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sina.Sports.Common.Exceptions
{
    [Resolve(typeof(ExceptionCenter))]
    public interface IExceptionCenter
    {
        void AddHandler(IExceptionHandler handler);
        bool Handle(Exception exception);
    }
}
