using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mvc.HttpServices;
using Mvc.ViewModels;
using AutorViewModel = Mvc.ViewModels.AutorViewModel;
using LivroViewModel = Mvc.ViewModels.LivroViewModel;

namespace Mvc.Controllers
{
    public class LivroController : Controller
    {

        //TODO: Refatorar para LivroHttpService
        private readonly IAutorHttpService _autorHttpService;
        private readonly ILivroHttpService _livroHttpService;

        public LivroController(
            IAutorHttpService autorHttpService,
            ILivroHttpService livroHttpService)
        {
            _autorHttpService = autorHttpService;
            _livroHttpService = livroHttpService;
        }

        // GET: Livro
        public async Task<IActionResult> Index(
            string? search = null)
        {
            ViewBag.Search = search;

            return View(await _livroHttpService.GetAllAsync(search));
        }

        // GET: Livro/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livroViewModel = await _livroHttpService.GetByIdAsync(id.Value);
            if (livroViewModel == null)
            {
                return NotFound();
            }

            return View(livroViewModel);
        }

        private async Task PopulateSelectAutores(int? autorId = null)
        {
            var autores = await _autorHttpService.GetAllAsync(null);

            ViewBag.Autores = new SelectList(
                autores,
                nameof(AutorViewModel.Id),
                nameof(AutorViewModel.AutorNomeCompleto),
                autorId); //TODO: Exibir Nome + sobrenome + id
        }

        // GET: Livro/Create
        public async Task<IActionResult> Create()
        {
            await PopulateSelectAutores();

            return View();
        }

        // POST: Livro/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LivroAutorCreateViewModel livroAutorCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                await _livroHttpService.AddAsync(livroAutorCreateViewModel);
                return RedirectToAction(nameof(Index));
            }

            await PopulateSelectAutores(livroAutorCreateViewModel.AutorId);
            return View(livroAutorCreateViewModel);
        }

        // GET: Livro/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var livroViewModel = await _livroHttpService.GetByIdAsync(id.Value);
            if (livroViewModel == null)
            {
                return NotFound();
            }

            await PopulateSelectAutores(livroViewModel.AutorId);

            return View(livroViewModel);
        }

        // POST: Livro/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, LivroViewModel livroViewModel)
        {
            if (id != livroViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _livroHttpService.EditAsync(livroViewModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LivroViewModelExists(livroViewModel.Id))
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

            await PopulateSelectAutores(livroViewModel.AutorId);

            return View(livroViewModel);
        }

        // GET: Livro/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livroViewModel = await _livroHttpService.GetByIdAsync(id.Value);
            if (livroViewModel == null)
            {
                return NotFound();
            }

            return View(livroViewModel);
        }

        // POST: Livro/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var livroViewModel = await _livroHttpService.GetByIdAsync(id);
            await _livroHttpService.RemoveAsync(livroViewModel);
            return RedirectToAction(nameof(Index));
        }

        private bool LivroViewModelExists(int id)
        {
            return _livroHttpService.GetByIdAsync(id) != null;
        }

        [AcceptVerbs("GET", "POST")]
        public async Task<IActionResult> IsIsbnValid(string isbn, int? id = null)
        {
            if (!(await _livroHttpService.IsIsbnValidAsync(isbn, id)))
            {
                return Json($"Isbn {isbn} já está cadastrado e não pode ser repetido");
            }

            return Json(true);
        }
    }
}
