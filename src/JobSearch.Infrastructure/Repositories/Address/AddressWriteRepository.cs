using JobSearch.Application.Repositories.Address;
using JobSearch.Infrastructure.Data;

namespace JobSearch.Infrastructure.Repositories.Address
{
    public class AddressWriteRepository : WriteRepository<JobSearch.Domain.Entities.Address>, IAddressWriteRepository
    {
        public AddressWriteRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
