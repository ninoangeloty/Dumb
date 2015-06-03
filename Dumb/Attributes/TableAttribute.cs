using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dumb
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TableAttribute : Attribute
    {
        public TableAttribute(string name)
        {
            this.Name = name;
        }

        public TableAttribute(string name, string connectionString)
        {
            this.Name = name;
            this.ConnectionString = connectionString;
        }

        public string Name { get; set; }
        public string ConnectionString { get; set; }
    }
}
