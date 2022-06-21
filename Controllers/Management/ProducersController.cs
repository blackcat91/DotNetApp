using Microsoft.AspNetCore.Mvc;
using MVCIntermediate.Data;
using MVCIntermediate.Data.Services;
using MVCIntermediate.Models;

namespace MVCIntermediate.Controllers.Management
{
    public class ProducersController : Controller
    {
        private readonly IProducersService _service;

        public ProducersController(IProducersService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Producer> producers = await _service.GetAll();
            return View(producers);
        }
        //GET
        public IActionResult Create()
        {

            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Producer obj)
        {
            if (ModelState.IsValid)
            {
                _service.Add(obj);

                return RedirectToAction("Index");
            }

            return View();
        }


        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0 || id == null) return NotFound();

            Producer obj = await _service.GetById(id);
            if (obj == null) return NotFound();

            return View(obj);
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Producer obj)
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

            Producer obj = await _service.GetById(id);
            if (obj == null) return NotFound();

            return View(obj);

        }

        [HttpDelete]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Producer obj)
        {
            if (obj != null)
            {
                _service.Remove(obj.Id);

                return RedirectToAction("Index");
            }
            return View(obj);

        }
    }

}
