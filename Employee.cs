using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForGeneralTests
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }
        public string Department { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Id: {Id} ");
            sb.Append($"Name: {Name} ");
            sb.Append($"Hire Date: {HireDate} ");
            sb.Append($"Salary: {Salary} ");
            return sb.ToString();
        }


    }
}
