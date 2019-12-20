using HappyRentals.Domain.Abstract;
using HappyRentals.Domain.Entities;
using System.Linq;

namespace HappyRentals.Domain.Concrete
{
    public class HomeRepository : IHomeRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Home> Homes
        {
            get { return context.Homes; }
        }
    }
}
