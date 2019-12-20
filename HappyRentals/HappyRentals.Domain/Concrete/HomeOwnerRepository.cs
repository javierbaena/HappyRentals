using HappyRentals.Domain.Abstract;
using HappyRentals.Domain.Entities;
using System.Linq;

namespace HappyRentals.Domain.Concrete
{
    public class HomeOwnerRepository : IHomeOwnerRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<HomeOwner> HomeOwners
        {
            get { return context.HomeOwners; }
        }
    }
}
