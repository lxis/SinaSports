using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sina.Sports.Common.Exceptions
{
    public interface IExceptionHandler
    {
        Type ExceptionType { get; }
        void Handle(Exception e);
    }
}
