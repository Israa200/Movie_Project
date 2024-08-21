using eTickects.Data;
using eTickects.Data.Services;
using eTickects.Models;
using Microsoft.AspNetCore.Mvc;

namespace eTickects.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsServices _service;
        public ActorsController(IActorsServices service)
        {

        _service = service; 
        
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
           await _service.AddAsync(actor); 
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Details(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);

            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }
		public async Task<IActionResult> Edit(int id)
		{
			var actorDetails = await _service.GetByIdAsync(id);
			if (actorDetails == null) return View("NotFound");
			return View(actorDetails);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ProfilePictureURL,Bio")] Actor actor)
		{
			if (!ModelState.IsValid)
			{
				return View(actor);
			}
			await _service.UpdateAsync(id, actor);
			return RedirectToAction(nameof(Index));
		}
        public async Task<IActionResult> Delete(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }

}
