using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sina.Sports.Common.UI.Controls.Warning
{
    public interface IToastMessage
    {
        void ShowToastMessage(string msg, int? second = null);

        void CloseToastMessage();
    }
}
