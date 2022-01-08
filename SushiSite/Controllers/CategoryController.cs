using Microsoft.AspNetCore.Mvc;
using SushiSite.Data;
using System.Linq;

namespace SushiSite.Controllers
{
    public class CategoryController : Controller
    {
        ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Categories.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
