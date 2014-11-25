using Sina.Sports.Common.Log.Layout;
using Sina.Sports.Common.Log.Writer;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sina.Sports.Common.Log.Logger
{
    class LoggerImpl : ILogger
    {

        IWriter writer;

        ILayout layout;

        public LoggerImpl(IWriter writer, ILayout layout)
        {
            this.writer = writer;
            this.layout = layout;
        }

        public void Debug(string message)
        {
            Write("Debug:" + message);
        }

        public void DebugFormat(string format, params object[] args)
        {
            Debug(Format(format, args));
        }

        public void Info(string message)
        {
            Write("Info:" + message);
        }

        public void InfoFormat(string format, params object[] args)
        {
            Info(Format(format, args));
        }

        public void Warn(string message)
        {
            Write("Warn:" + message);
        }

        public void WarnFormat(string format, params object[] args)
        {
            Warn(Format(format, args));
        }

        public void Error(string message)
        {
            Write("Error:" + message);
        }

        public void ErrorFormat(string format, params object[] args)
        {
            Error(Format(format, args));
        }

        public void Fatal(string message)
        {
            Write("Fatal:" + message);
        }

        public void FatalFormat(string format, params object[] args)
        {
            Fatal(Format(format, args));
        }

        private string Format(string format, params object[] args)
        {
            return String.Format(CultureInfo.InvariantCulture, format, args);
        }

        public void Error(Exception e)
        {
            Write(layout.Exception(e));
        }

        public void Trace()
        {
            //Universal不支持StackTrace
            //string trace = new StackTrace().ToString();
            //Write("Trace:" + trace);
        }

        private void Write(string message)
        {
            try
            {
                writer.Write(layout.Format(message));
            }
            catch (Exception)
            {
                System.Diagnostics.Debug.WriteLine("DeviceLogger Error.");
            }
        }
    }
}
