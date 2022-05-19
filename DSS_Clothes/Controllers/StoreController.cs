using DSS_Clothes.Models;
using DSS_Clothes.Repository;
using DSS_Clothes.Services;
using Microsoft.AspNetCore.Mvc;

namespace DSS_Clothes.Controllers
{
    public class StoreController : Controller
    {
        private readonly DBContext db;
        private readonly IStore store;
        
        public StoreController(DBContext _db, IStore _store)
        {
            db = _db;
            store = _store;
        }
        public IActionResult Index()
        {
            var model = db.Stores;
            return View(model.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Create(Store _store)
        {
            if (ModelState.IsValid)
            {
                store.Add(_store);
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Details(int? ID)
        {
            return View(store.GetStore(ID));
        }
        [HttpGet]
        public IActionResult Delete(int? ID)
        {
            return View(store.GetStore(ID));
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int? ID)
        {
            store.Remove(ID);

            return RedirectToAction("Index");
        }
        public IActionResult Edit(int? ID)
        {

            var model = store.GetStore(ID);
            return View("Edit", model);
        }
        [HttpPost]
        public IActionResult Edit(Store _store)
        {
            if (ModelState.IsValid)
            {

                db.Stores.Update(_store);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(store);
        }
    }
}
