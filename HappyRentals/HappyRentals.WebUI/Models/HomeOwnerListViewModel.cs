using HappyRentals.Domain.Entities;
using System.Collections.Generic;

namespace HappyRentals.WebUI.Models
{
    public class HomeOwnerListViewModel
    {
        public IEnumerable<HomeOwner> HomeOwners { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}