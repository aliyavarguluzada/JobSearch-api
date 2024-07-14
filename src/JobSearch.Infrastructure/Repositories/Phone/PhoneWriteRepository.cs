using JobSearch.Application.Repositories.Phone;
using JobSearch.Infrastructure.Data;

namespace JobSearch.Infrastructure.Repositories.Phone
{
    public class PhoneWriteRepository : WriteRepository<JobSearch.Domain.Entities.Phone>, IPhoneWriteRepository
    {
        public PhoneWriteRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
