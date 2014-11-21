using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sina.Sports.Common.JsonConverter
{
    public interface IJsonConverter
    {
        T DeserializeObject<T>(string value);

        string SerializeObject(object value);
    }
}
