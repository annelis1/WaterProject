using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WaterProject.Models;
using WaterProject.Models.ViewModels;

namespace WaterProject.Controllers
{
    public class HomeController : Controller
    {
        private IWaterRepo waterRepo;
        public HomeController(IWaterRepo temp)
        {
            waterRepo = temp;
        }

        public IActionResult Index(int pageNum)
        {
            int pageSize = 5;
            var blah = new ProjectsListViewModel
            {
                Projects = waterRepo.Projects
                    .OrderBy(x => x.ProjectName)
                    .Skip(pageSize * (pageNum - 1))
                    .Take(pageSize),

                PaginationInfo = new PaginationInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = pageSize,
                    TotalItems = waterRepo.Projects.Count()
                }

            };
            
            return View(blah);
        }

        
    }
}
