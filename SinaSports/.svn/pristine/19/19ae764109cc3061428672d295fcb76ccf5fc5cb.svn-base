using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sina.Sports.Common.Log.Layout
{
    class DebugLayout : ILayout
    {
        public string Exception(Exception e)
        {
            return "Type:" + e.GetType().ToString() + Environment.NewLine + "nMessage:" + e.Message + Environment.NewLine + "Time:" + DateTime.Now.ToString();
        }

        public string Format(string log)
        {
            return log + "(" + DateTime.Now.ToString() + ")";
        }
    }
}
