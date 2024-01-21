using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using TeaTimeDemo2024.Data;
using TeaTimeDemo2024.Models;

namespace TeaTimeDemo2024.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }
        //-------------------------------------------------------------
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }       
    }
}
