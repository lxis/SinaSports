using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sina.Sports.UI.WorkerServices.Initializers.TestInitializers
{
    class TestInitializer
    {
        public void Init()
        {
            //new ServerTestInitializer().Init();
            new StorageTestInitializer().Init();
        }
    }
}
