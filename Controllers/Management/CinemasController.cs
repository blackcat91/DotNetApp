using Microsoft.AspNetCore.Mvc;
using MVCIntermediate.Data;
using MVCIntermediate.Models;

namespace MVCIntermediate.Controllers.Management
{
    public class CinemasController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CinemasController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        //GET
        public IActionResult Create()
        {

            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Cinema obj)
        {
            if (ModelState.IsValid)
            {
                _db.Cinemas.Add(obj);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }


        public IActionResult Edit(int id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            Cinema obj = _db.Cinemas.FirstOrDefault(a => a.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Cinema obj)
        {
            if (ModelState.IsValid)
            {
                _db.Cinemas.Update(obj);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            Cinema obj = _db.Cinemas.FirstOrDefault(a => a.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }

        [HttpDelete]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Cinema obj)
        {
            if (obj != null)
            {
                _db.Cinemas.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);

        }
    }
}
