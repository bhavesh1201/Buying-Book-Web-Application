using BulkyWeb.Models;
using BulkyWeb.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _db;

        public CategoryController(ICategoryRepository db)
        {
            _db = db;

        }
        public IActionResult Index()
        {
            var cs = _db.GetAll();

            return View(cs);
        }
        public IActionResult Create() {

            return View();

        }
        [HttpPost]
        public IActionResult Create(Category ct)
        {

            if (ct.Name == ct.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "Name and Display order cannot be same");
            }

            if (ModelState.IsValid)
            {
                _db.Add(ct);
                _db.Save();
                TempData["Success"] = "Inserted Successfully";

                return RedirectToAction("Index");

            }





            return View();

        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id==0)
            {
                return NotFound();
            }

            var vx = _db.Get(a=>a.Id==id);
            if (vx == null) return NotFound();


            
            
            return View(vx);

        }
        [HttpPost]
        public IActionResult Edit(Category ct)
        {    
            if (ModelState.IsValid)
            {
                _db.Update(ct);
                _db.Save();
                TempData["SuccessD"] = "Updated Successfully";


                return RedirectToAction("Index");

            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var vx = _db.Get(a=>a.Id==id);
            if (vx == null) return NotFound();
            return View(vx);

        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteP(int? id)
        {

            Category ? vx = _db.Get(a => a.Id == id);
            if (vx == null) return NotFound();

            _db.Delete(vx);
            _db.Save();
            TempData["SuccessD"] = "Deleted Successfully";

            //if (ModelState.IsValid)
            //{
            //    _db.categories.Update(ct);
            //    _db.SaveChanges();
            //    return RedirectToAction("Index");

            //}
            return RedirectToAction("Index");
        }



    }
}
