using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Models.v1.Address
{
    public class CreateAddressResponse
    {
        public string Address { get; set; }
        public int CityId { get; set; }
        public string Street { get; set; }  

    }
}
