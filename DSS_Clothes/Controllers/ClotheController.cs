using DSS_Clothes.Models;
using DSS_Clothes.Repository;
using DSS_Clothes.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DSS_Clothes.Controllers
{
    public class ClotheController : Controller
    {
        private readonly DBContext db;
        private readonly IClothe clothe;
        private readonly IBrand brand;

        public ClotheController(DBContext _db, IClothe _clothe, IBrand _brand)
        {
            db = _db;
            clothe = _clothe;
            brand = _brand;
        }
        public IActionResult Index()
        {
            var model = clothe.GetClothes;
            return View(model.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["BrandID"] = new SelectList(brand.GetBrands, "BrandID", "BrandName");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Clothe _clothe)
        {
            if (ModelState.IsValid)
            {
                clothe.Add(_clothe);
                return RedirectToAction("Index");
            }
            return View(_clothe);
        }
        public IActionResult Details(int? ID)
        {
            return View(clothe.GetClothe(ID));
        }
        [HttpGet]
        public IActionResult Delete(int? ID)
        {
            return View(clothe.GetClothe(ID));
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int? ID)
        {
            clothe.Remove(ID);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int? ID)
        {
            ViewData["BrandID"] = new SelectList(brand.GetBrands, "BrandID", "BrandName");
            var model = clothe.GetClothe(ID);
            return View("Edit", model);
        }
        [HttpPost]
        public IActionResult Edit(Clothe _clothe)
        {
            if (ModelState.IsValid)
            {

                db.Clothes.Update(_clothe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(_clothe);
        }
    }
}
