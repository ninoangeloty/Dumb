using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Dumb
{
    public class ModelInfo
    {
        public Type DataType { get; set; }
        public string TableName { get; set; }
        public IEnumerable<PropertyDescription> Properties { get; set; }
    }
}
