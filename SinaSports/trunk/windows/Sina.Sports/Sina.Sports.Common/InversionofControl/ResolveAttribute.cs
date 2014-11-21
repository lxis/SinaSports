using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sina.Sports.Common.InversionofControl
{
    public class ResolveAttribute : Attribute
    {
        public ResolveAttribute()
        {

        }

        public ResolveAttribute(Type type)
        {
            Type = type;
        }

        public Type Type { get; set; }


        public string Name { get; set; }

    }
}