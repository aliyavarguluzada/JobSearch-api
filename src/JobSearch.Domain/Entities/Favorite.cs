using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Domain.Entities
{
    public class Favorite : BaseEntity
    {
        public int VacancyId { get; set; }
     
    }
}
