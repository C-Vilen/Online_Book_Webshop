using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext db)
        {
            _context = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _context.Categories.ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
		public IActionResult Create(Category createdObject)
		{
            if(int.TryParse(createdObject.Name, out _))
            {
                ModelState.AddModelError("name", "The name cannot be a number");
            }

            if (ModelState.IsValid)
            {
                _context.Categories.Add(createdObject);
                _context.SaveChanges();
			    return RedirectToAction("Index", "Category");
            }
            return View();
		}

        public IActionResult Edit(int? id) { 
            if(id == 0 && id == null)
            {
                return NotFound();
			}
            Category? categoryFromDb = _context.Categories.FirstOrDefault(x => x.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
		[HttpPost]
		public IActionResult Edit(Category editedObject)
		{
			if (int.TryParse(editedObject.Name, out _))
			{
				ModelState.AddModelError("name", "The name cannot be a number");
			}

			if (ModelState.IsValid)
			{
				_context.Categories.Update(editedObject);
				_context.SaveChanges();
				return RedirectToAction("Index", "Category");
			}
			return View();
		}
	}
}
