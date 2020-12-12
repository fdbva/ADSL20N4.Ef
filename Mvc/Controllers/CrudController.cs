using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mvc.HttpServices;
using Mvc.ViewModels;

namespace Mvc.Controllers
{
    public abstract class CrudController<TViewModel> : Controller
        where TViewModel : BaseViewModel
    {
        private readonly ICrudHttpService<TViewModel> _crudHttpService;

        protected CrudController(
            ICrudHttpService<TViewModel> crudHttpService)
        {
            _crudHttpService = crudHttpService;
        }

        public async Task<IActionResult> Index(
            string? search = null)
        {
            ViewBag.Search = search;

            return View(await _crudHttpService.GetAllAsync(search));
        }

        public virtual async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baseViewModel = await _crudHttpService.GetByIdAsync(id.Value);
            if (baseViewModel == null)
            {
                return NotFound();
            }

            return View(baseViewModel);
        }

        public virtual async Task<IActionResult> Create()
        {
            await PopulateSelectPrimary();

            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Create(TViewModel baseViewModel)
        {
            if (!ModelState.IsValid)
            {
                await PopulateSelectPrimary(baseViewModel.Id);
                return View(baseViewModel);
            }

            await _crudHttpService.AddAsync(baseViewModel);
            return RedirectToAction(nameof(Index));
        }

        public virtual async Task<IActionResult> Edit(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var baseViewModel = await _crudHttpService.GetByIdAsync(id.Value);
            if (baseViewModel == null)
            {
                return NotFound();
            }

            await PopulateSelectPrimary(baseViewModel.Id);

            return View(baseViewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Edit(int id, TViewModel baseViewModel)
        {
            if (id != baseViewModel.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                await PopulateSelectPrimary(baseViewModel.Id);
                return View(baseViewModel);
            }

            await _crudHttpService.EditAsync(baseViewModel);
            return RedirectToAction(nameof(Index));
        }

        public virtual async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baseViewModel = await _crudHttpService.GetByIdAsync(id.Value);
            if (baseViewModel == null)
            {
                return NotFound();
            }

            return View(baseViewModel);
        }

        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> DeleteConfirmed(int id)
        {
            var baseViewModel = await _crudHttpService.GetByIdAsync(id);
            await _crudHttpService.RemoveAsync(baseViewModel);
            return RedirectToAction(nameof(Index));
        }

        protected virtual async Task PopulateSelectPrimary(int? idViewModel = null) { }
    }
}
