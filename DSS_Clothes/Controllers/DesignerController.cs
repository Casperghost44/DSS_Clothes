using DSS_Clothes.Models;
using DSS_Clothes.Repository;
using DSS_Clothes.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DSS_Clothes.Controllers
{
    public class DesignerController : Controller
    {
        private readonly IClothe clothe;
        private readonly IStore store;
        private readonly IDesigner designer;
        private readonly DBContext db;

        public DesignerController(IDesigner _designer, IStore _store, IClothe _clothe, DBContext _db)
        {
            designer = _designer;
            store = _store;
            clothe = _clothe;
            db = _db;
        }
        public IActionResult Index()
        {
            var model = designer.GetDesigners;
            return View(model.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["StoreID"] = new SelectList(store.GetStores, "StoreID", "StoreName");
            ViewData["ClotheID"] = new SelectList(clothe.GetClothes, "ClotheID", "ClotheName");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Designer model)
        {
            if (ModelState.IsValid)
            {
                designer.Add(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int? ID)
        {
            if (ID == null)
            {
                return NotFound();
            }
            else
            {
                Designer model = designer.GetDesigner(ID);
                return View(model);
            }
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int? ID)
        {
            designer.Remove(ID);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int? ID)
        {
            var model = designer.GetDesigner(ID);
            ViewData["StoreID"] = new SelectList(store.GetStores, "StoreID", "StoreName");
            ViewData["ClotheID"] = new SelectList(clothe.GetClothes, "ClotheID", "ClotheName");
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(Designer model)
        {
            if (ModelState.IsValid)
            {
                db.Designers.Update(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
