using HappyRentals.Domain.Abstract;
using HappyRentals.WebUI.Models;
using System.Linq;
using System.Web.Mvc;

namespace HappyRentals.WebUI.Controllers
{
    public class HomeOwnerController : Controller
    {
        private IHomeOwnerRepository repository;
        public int PageSize = 5;

        public HomeOwnerController(IHomeOwnerRepository homeOwnerRepository)
        {
            this.repository = homeOwnerRepository;
        }

        public ViewResult List(int page = 1)
        {
            HomeOwnerListViewModel model = new HomeOwnerListViewModel
            {
                HomeOwners = repository.HomeOwners
                    .OrderBy(p => p.HomeOwnerId)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.HomeOwners.Count()
                }
            };

            return View(model);

            /*return View(repository.HomeOwners
                .OrderBy(ho => ho.HomeOwnerId)
                .Skip((page - 1) * PageSize)
                .Take(PageSize));*/
            //return View(repository.HomeOwners);
        }
    }
}
