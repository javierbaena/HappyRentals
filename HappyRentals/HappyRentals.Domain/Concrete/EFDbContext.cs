using HappyRentals.Domain.Entities;
using System.Data.Entity;

namespace HappyRentals.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Home> Homes { get; set; }
        public DbSet<HomeOwner> HomeOwners { get; set; }
    }
}
