using PrimeBuy.Application.Interfaces.Repositories;
using PrimeBuy.Domain.Models;
using PrimeBuy.Infrastructure.Data;

namespace PrimeBuy.Infrastructure.Repositories
{
    public class AddressRepository : GenericRepository<Address>, IAddressRepository
    {
        public AddressRepository(AppDbContext context) : base(context) { }
    }
}
