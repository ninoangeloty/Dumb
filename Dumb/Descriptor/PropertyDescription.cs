using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Dumb
{
    public class PropertyDescription
    {
        public PropertyInfo Member { get; set; }
        public FieldAttribute Field { get; set; }
    }
}
