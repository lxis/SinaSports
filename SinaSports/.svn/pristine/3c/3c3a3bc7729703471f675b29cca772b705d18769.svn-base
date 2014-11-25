using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Sina.Sports.Common.Exceptions.Imp
{
    public class ExceptionCenter : IExceptionCenter
    {
        IList<IExceptionHandler> handlers;

        public ExceptionCenter()
        {
            handlers = new List<IExceptionHandler>();
        }

        public void AddHandler(IExceptionHandler handler)
        {
            if (!handler.ExceptionType.GetTypeInfo().IsSubclassOf(typeof(Exception)) && handler.ExceptionType != typeof(Exception))//这个地方的判断是用的Type的Equal，不知道这判断好用不
                throw new ArgumentException("ExceptionType should be exception");
            if (handlers.Count((c) => c.ExceptionType == handler.ExceptionType) != 0)
                throw new ArgumentException("One exception type mustn't has mutiple handler");
            handlers.Add(handler);
        }

        public bool Handle(Exception exception)
        {
            //寻找能处理的Handler
            var legalHandlers = handlers.Where((c) => exception.GetType() == c.ExceptionType);//这个地方的判断是用的Type的Equal，不知道这判断好用不
            if (legalHandlers == null || legalHandlers.Count() == 0)
                return false;
            //递归寻找最上层的异常类处理方法
            Type currentExceptionType = exception.GetType();
            while (legalHandlers.Count((c) => c.ExceptionType == currentExceptionType) == 0)
                currentExceptionType = currentExceptionType.GetTypeInfo().BaseType;
            //每种类型只能由一个异常处理类
            var legalHandler = legalHandlers.Single((c) => c.ExceptionType == currentExceptionType);
            legalHandler.Handle(exception);
            return true;
        }
    }
}
