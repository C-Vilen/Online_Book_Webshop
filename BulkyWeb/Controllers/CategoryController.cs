using Webshop.DataAccess.Data;
using Webshop.Models;
using Microsoft.AspNetCore.Mvc;
using Webshop.DataAccess.Repository.IRepository;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository db)
        {
            _categoryRepository = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _categoryRepository.GetAll().ToList();
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
                _categoryRepository.Add(createdObject);
                _categoryRepository.Save();
				TempData["success"] = "Category was created successfully";
			    return RedirectToAction("Index", "Category");
            }
            return View();
		}

        public IActionResult Edit(int? id) { 
            if(id == 0 && id == null)
            {
                return NotFound();
			}
            Category? categoryFromDb = _categoryRepository.GetFirstOrDefault(x => x.Id == id);
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
                _categoryRepository.Update(editedObject);
                _categoryRepository.Save();
				TempData["success"] = "Category was updated successfully";
				return RedirectToAction("Index", "Category");
			}
			return View();
		}

		public IActionResult Delete(int? id)
		{
			if (id == 0 && id == null)
			{
				return NotFound();
			}
			Category? categoryFromDb = _categoryRepository.GetFirstOrDefault(x => x.Id == id);
			if (categoryFromDb == null)
			{
				return NotFound();
			}
			return View(categoryFromDb);
		}
		[HttpPost, ActionName("Delete")]
		public IActionResult DeletePOST(int? id)
		{
			Category? categoryFromDb = _categoryRepository.GetFirstOrDefault(x => x.Id == id);
            if (categoryFromDb == null)
			{
				return NotFound();
			}
            _categoryRepository.Delete(categoryFromDb);
            _categoryRepository.Save();
			TempData["success"] = "Category was deleted successfully";
			return RedirectToAction("Index", "Category");
		}
	}
}
