using HappyRentals.Domain.Abstract;
using HappyRentals.WebUI.Models;
using System.Linq;
using System.Web.Mvc;

namespace HappyRentals.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IHomeRepository repository;
        public int PageSize = 5;

        public HomeController(IHomeRepository homeRepository)
        {
            this.repository = homeRepository;
        }

        public ViewResult List(int page = 1)
        {
            HomeListViewModel model = new HomeListViewModel
            {
                Homes = repository.Homes
                    .OrderBy(p => p.HomeOwnerId)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Homes.Count()
                }
            };

            return View(model);
            /*return View(repository.Homes
                .OrderBy(h => h.HomeId)
                .Skip((page - 1) * PageSize)
                .Take(PageSize));*/
            //return View(repository.Homes);
        }        
    }
}
