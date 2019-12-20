using HappyRentals.Domain.Entities;
using System.Linq;

namespace HappyRentals.Domain.Abstract
{
    public interface IHomeRepository
    {
        IQueryable<Home> Homes { get; }
    }
}
