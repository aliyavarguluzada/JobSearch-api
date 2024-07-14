using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Models.v1.Phone
{
    public class PhoneRequest
    {
        public string Number { get; set; }
        public int OperatorId { get; set; }
    }
}
