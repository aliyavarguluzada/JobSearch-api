using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Models.v1.Salary
{
    public class SalaryRequest
    {
        public int CurrencyId { get; set; }
        public string Value { get; set; }
    }
}
