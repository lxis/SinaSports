using Sina.Sports.UI.WorkerServices.Initializers.TestInitializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sina.Sports.UI.WorkerServices.Initializers
{
    public class ApplicationInitializer
    {
        public void Init()
        {
            new TestInitializer().Init();
        }
    }
}
