using Sina.Sports.Common.Log.Layout;
using Sina.Sports.Common.Log.Logger;
using Sina.Sports.Common.Log.Writer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sina.Sports.Common.Log
{
    class LogManager
    {
        private static IWriter writer = null;
        private static IWriter Writer
        {
            get
            {
                if (writer == null)
                {
                    writer = new DebugWriter();
                }
                return writer;
            }
        }

        private static ILayout layout = null;
        private static ILayout Layout
        {
            get
            {
                if (layout == null)
                {
                    layout = new DebugLayout();
                }
                return layout;
            }
        }

        private static ILogger logger = new LoggerImpl(Writer, Layout);
        public static ILogger Logger
        {
            get { return logger; }
        }
    }
}
