using DSS_Clothes.Models;
using DSS_Clothes.Repository;
using DSS_Clothes.Services;
using Microsoft.AspNetCore.Mvc;

namespace DSS_Clothes.Controllers
{
    public class BrandController : Controller
    {
        private readonly DBContext db;
        private readonly IBrand brand;
        private readonly IClothe clothe;
        public BrandController(DBContext _db, IBrand _brand, IClothe _clothe)
        {
            db = _db;
            brand = _brand;
            clothe = _clothe;
        }
        public IActionResult Index()
        {
            var model = db.Brands;
            return View(model.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Clothes = clothe.GetClothes;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Brand _brand)
        {
            if (ModelState.IsValid)
            {
                brand.Add(_brand);
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Details(int? ID)
        {
            return View(brand.GetBrand(ID));
        }
        [HttpGet]
        public IActionResult Delete(int? ID)
        {
            return View(brand.GetBrand(ID));
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int? ID)
        {
            brand.Remove(ID);
            
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int? ID)
        {
            
            var model = brand.GetBrand(ID);
            return View("Edit", model);
        }
        [HttpPost]
        public IActionResult Edit(Brand _brand)
        {
            if (ModelState.IsValid)
            {

                db.Brands.Update(_brand);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(brand);
        }

    }
}
