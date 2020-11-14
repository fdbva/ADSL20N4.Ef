using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mvc.HttpServices;
using AutorViewModel = Mvc.ViewModels.AutorViewModel;

namespace Mvc.Controllers
{
    public class AutorController : Controller
    {
        //TODO: Refatorar para AutorHttpService
        private readonly IAutorHttpService _autorHttpService;

        public AutorController(
            IAutorHttpService autorHttpService)
        {
            _autorHttpService = autorHttpService;
        }

        // GET: Autor
        public async Task<IActionResult> Index()
        {
            return View(await _autorHttpService.GetAllAsync(null));
        }

        // GET: Autor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autorViewModel = await _autorHttpService.GetByIdAsync(id.Value);
            if (autorViewModel == null)
            {
                return NotFound();
            }

            return View(autorViewModel);
        }

        // GET: Autor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Autor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,UltimoNome,Nascimento")] AutorViewModel autorViewModel)
        {
            if (ModelState.IsValid)
            {
                await _autorHttpService.AddAsync(autorViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(autorViewModel);
        }

        // GET: Autor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var autorViewModel = await _autorHttpService.GetByIdAsync(id.Value);
            if (autorViewModel == null)
            {
                return NotFound();
            }
            return View(autorViewModel);
        }

        // POST: Autor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,UltimoNome,Nascimento")] AutorViewModel autorViewModel)
        {
            if (id != autorViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _autorHttpService.EditAsync(autorViewModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutorViewModelExists(autorViewModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(autorViewModel);
        }

        // GET: Autor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autorViewModel = await _autorHttpService.GetByIdAsync(id.Value);
            if (autorViewModel == null)
            {
                return NotFound();
            }

            return View(autorViewModel);
        }

        // POST: Autor/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var autorViewModel = await _autorHttpService.GetByIdAsync(id);
            await _autorHttpService.RemoveAsync(autorViewModel);
            return RedirectToAction(nameof(Index));
        }

        private bool AutorViewModelExists(int id)
        {
            return _autorHttpService.GetByIdAsync(id) != null;
        }
    }
}
