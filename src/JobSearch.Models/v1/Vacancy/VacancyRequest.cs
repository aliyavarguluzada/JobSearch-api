using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Models.v1.Vacancy
{
    public class VacancyRequest
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int CompanyId { get; set; }
        public int JobTypeId { get; set; }
        public int OpportunityId { get; set; }
        public int SeniorityId { get; set; }
        public int AddressId { get; set; }
        public int PhoneId { get; set; }
        public int SalaryId { get; set; }
        public bool IsPremium { get; set; }
        public string Website { get; set; }
        public string Description { get; set; }
    }
}
