using HappyRentals.Domain.Entities;
using System.Linq;

namespace HappyRentals.Domain.Abstract
{
    public interface IHomeOwnerRepository
    {
        IQueryable<HomeOwner> HomeOwners { get; }
    }
}
