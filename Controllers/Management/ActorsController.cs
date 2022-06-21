using Microsoft.AspNetCore.Mvc;
using MVCIntermediate.Data;
using MVCIntermediate.Data.Services;
using MVCIntermediate.Models;

namespace MVCIntermediate.Controllers.Management
{
    public class ActorsController : Controller
    {
        private readonly IActorsService _service;

        public ActorsController(IActorsService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Actor> actors =await _service.GetAll();
            if (actors == null) return NotFound();
            return View(actors);
        }
        //GET
        public IActionResult Create()
        {

            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Actor obj)
        {
            if (ModelState.IsValid)
            {
                 await _service.Add(obj);
            

                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id == 0 || id == null) return NotFound();

            Actor obj = await _service.GetById(id);
            if (obj == null) return NotFound();

            return View(obj);
        }


        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0 || id == null) return NotFound();
           
            Actor obj = await _service.GetById(id);
            if (obj == null) return NotFound();
            
            return View(obj);
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Actor obj)
        {
            if (ModelState.IsValid)
            {
                _service.Update(id, obj);
         

                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0 || id == null) return NotFound();
           
            Actor obj = await _service.GetById(id);
            if (obj == null) return NotFound();
           
            return View(obj);

        }

        [HttpDelete]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Actor obj)
        {
            if (obj != null)
            {
                await _service.Remove(obj.Id);
               
                return RedirectToAction("Index");
            }
            return View(obj);

        }
    }
}
