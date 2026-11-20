using AutoMapper;
using BoardGameHub.Core.Contracts;
using BoardGameHub.ViewModel.Admin;
using Microsoft.AspNetCore.Mvc;

namespace BoardGameHub.Controllers
{
    public class AdminController(IAdminServices adminServices, IMapper mapper) : Controller
    {
        public async Task<IActionResult> Index() 
        {
            var allShopsResponse = await adminServices.Index();
            var allShopsViewModel = mapper.Map<IEnumerable<AdminIndex>>(allShopsResponse);


            return View(allShopsViewModel);
        }
    }
}
