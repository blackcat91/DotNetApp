using Microsoft.AspNetCore.Mvc;
using MVCIntermediate.Data;
using MVCIntermediate.Models;

namespace MVCIntermediate.Controllers.Management
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public MoviesController(ApplicationDbContext db)
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
        public IActionResult Create(Movie obj)
        {
            if (ModelState.IsValid)
            {
                _db.Movies.Add(obj);
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
            Movie obj = _db.Movies.FirstOrDefault(a => a.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Movie obj)
        {
            if (ModelState.IsValid)
            {
                _db.Movies.Update(obj);
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
            Movie obj = _db.Movies.FirstOrDefault(a => a.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }

        [HttpDelete]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Movie obj)
        {
            if (obj != null)
            {
                _db.Movies.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);

        }
    }

}
