using HappyRentals.Domain.Abstract;
using HappyRentals.Domain.Concrete;
using HappyRentals.Domain.Entities;
using System.Linq;
using System.Web.Http;

namespace HappyRentals.WebApi.Controllers
{
    public class HomeOwnersController : ApiController
    {
        private IHomeOwnerRepository repository;
        private EFDbContext context = new EFDbContext();

        public IQueryable<HomeOwner> GetAllHomeOwners()
        {
            return repository.HomeOwners;
        }

        public void SaveHomeOwner(HomeOwner homeOwner)
        {
            if (homeOwner.HomeOwnerId == 0)
            {
                context.HomeOwners.Add(homeOwner);
            }
            else
            {
                HomeOwner dbEntry = context.HomeOwners.Find(homeOwner.HomeOwnerId);

                if (dbEntry != null)
                {
                    dbEntry.Name = homeOwner.Name;
                    dbEntry.Phone = homeOwner.Phone;
                    dbEntry.Email = homeOwner.Email;
                }
            }

            context.SaveChanges();
        }

        public HomeOwner DeleteHomeOwner(int HomeOwnerId)
        {
            HomeOwner dbEntry = context.HomeOwners.Find(HomeOwnerId);

            if (dbEntry != null)
            {
                context.HomeOwners.Remove(dbEntry);
                context.SaveChanges();
            }

            return dbEntry;
        }
    }
}
