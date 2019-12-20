using HappyRentals.Domain.Abstract;
using HappyRentals.Domain.Concrete;
using HappyRentals.Domain.Entities;
using System.Linq;
using System.Web.Http;

namespace HappyRentals.WebApi.Controllers
{
    public class HomesController : ApiController
    {
        private IHomeRepository repository;
        private EFDbContext context = new EFDbContext();

        public IQueryable<Home> GetAllHomeOwners()
        {
            return repository.Homes;
        }

        public IQueryable<Home> GetHomesByOwner(int HomeOwnerId)
        {
            return context.Homes.Where(h => h.HomeOwnerId == HomeOwnerId);
        }

        public void SaveHome(Home home)
        {
            if (home.HomeId == 0)
            {
                context.Homes.Add(home);
            }
            else
            {
                Home dbEntry = context.Homes.Find(home.HomeId);

                if (dbEntry != null)
                {
                    dbEntry.Name = home.Name;
                    dbEntry.Description = home.Description;
                    dbEntry.Address = home.Address;
                    dbEntry.City = home.Country;
                    dbEntry.Price = home.Price;
                    dbEntry.HomeOwnerId = home.HomeOwnerId;
                }
            }

            context.SaveChanges();
        }

        public Home DeleteHome(int HomeId)
        {
            Home dbEntry = context.Homes.Find(HomeId);

            if (dbEntry != null)
            {
                context.Homes.Remove(dbEntry);
                context.SaveChanges();
            }

            return dbEntry;
        }
    }
}
