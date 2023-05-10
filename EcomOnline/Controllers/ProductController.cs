using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Services;

namespace EcomOnline.Controllers
{
   //private var service = new UserService();
    public class ProductController : Controller
    {
        private readonly IUserService _userService;

        public ProductController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            var users = _userService.GetAllUsers;

            return View(users);
        }
    }
}
