using Sina.Sports.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Sina.Sports.UI.WorkerServices.Exceptions.Handlers
{
    class GeneralExceptionHandler : IExceptionHandler
    {
        public Type ExceptionType { get { return typeof(Exception); } }

        private int logIndex = 1;

        private string GetLogIndex()
        {
            string logIndexString = ((int)DateTime.Now.TimeOfDay.TotalSeconds).ToString() + logIndex.ToString();
            logIndex++;
            return logIndexString;
        }

        public void Handle(Exception e)
        {
            //NormalWarning.ShowConfirm(string.Format("发生Crash!Type:{0},Message:{1}",e.GetType().Name,e.Message));
            if (Debugger.IsAttached)
                Debugger.Break();
            //string logIndex = GetLogIndex();
            //if (e.InnerException != null)
            //    Sipo.Common.Log.LogManager.Logger.Error(e.InnerException);
            //Sipo.Common.Log.LogManager.Logger.Fatal(Properties.Resources.Log_RecordExceptionEnd);
            //Ioc<INormalWarning>.Create().Show(string.Format(Properties.Resources.Ex_UnkownError, logIndex));
        }
    }
}
