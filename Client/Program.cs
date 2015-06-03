using Client.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var consolidateDaily = new ConsolidateDaily();
            var result = consolidateDaily.Query("SELECT TOP 100 * FROM [dbo].[dwConsolidateDaily]");
        }
    }
}
