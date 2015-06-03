using Dumb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Client.Model
{
    [Table("dwConsolidateDaily")]
    public class ConsolidateDaily : DumbContext<ConsolidateDaily>
    {
        public ConsolidateDaily() : base("DataWarehouse")
        {
        }

        [Field("business_transaction_datetime")]
        public DateTime BusinessTransactionDateTime { get; set; }
        [Field("productCode")]
        public string ProductCode { get; set; }
        [Field("operatorID")]
        public long OperatorId { get; set; }
        [Field("memberCode")]
        public string MemberCode { get; set; }
        [Field("stake_amount")]
        public decimal StakeAmount { get; set; }
        [Field("winlost_amount")]
        public decimal WinLostAmount { get; set; }
        [Field("rakes_amount")]
        public decimal RakesAmount { get; set; }
    }
}
