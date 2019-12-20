using HappyRentals.Domain.Entities;
using System.Collections.Generic;

namespace HappyRentals.WebUI.Models
{
    public class HomeListViewModel
    {
        public IEnumerable<Home> Homes { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}