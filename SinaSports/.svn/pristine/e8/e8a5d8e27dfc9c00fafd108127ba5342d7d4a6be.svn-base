using Sina.Sports.Common.Exceptions;
using Sina.Sports.Server.Common.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sina.Sports.UI.WorkerServices.Exceptions.Handlers
{
    class NetworkBrokenCanceledExceptionHandler : IExceptionHandler
    {
        public Type ExceptionType { get { return typeof(NetworkBrokenCanceledException); } }

        public void Handle(Exception e)
        {
            //NormalWarning.ShowNegligible("网络超时");

            //Ioc<INormalWarning>.Create().Show(Resources.NetError_WebServiceExceptionContent, caption: Resources.NetError_WebServiceExceptionTitle);
        }
    }
}
