using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Models.v1.Favorite
{
    public class CreateFavoriteResponse
    {
        public int Id { get; set; }
        public int CookieId { get; set; }
        public int VacancyId { get; set; }
    }
}
