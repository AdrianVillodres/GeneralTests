using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ForGeneralTests
{
    public class SalesEmployee : Employee
    {
        public decimal SalesAmount { get; set; }
        public int SalesCount { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.Append($"Sales Amount: {SalesAmount} ");
            sb.Append($"Sales Count: {SalesCount}");
            return sb.ToString();
        }
    }
}
