using System.Threading.Tasks;
using Application.AppServices;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Mvc.Controllers
{
    public class LivroController : Controller
    {
        private readonly IAutorAppService _autorAppService;
        private readonly ILivroAppService _livroAppService;

        public LivroController(
            IAutorAppService autorAppService,
            ILivroAppService livroAppService)
        {
            _autorAppService = autorAppService;
            _livroAppService = livroAppService;
        }

        // GET: Livro
        public async Task<IActionResult> Index()
        {
            return View(await _livroAppService.GetAllAsync(null));
        }

        // GET: Livro/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livroViewModel = await _livroAppService.GetByIdAsync(id.Value);
            if (livroViewModel == null)
            {
                return NotFound();
            }

            return View(livroViewModel);
        }

        private async Task PopulateSelectAutores(int? autorId = null)
        {
            var autores = await _autorAppService.GetAllAsync(null);

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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LivroViewModel livroViewModel)
        {
            if (ModelState.IsValid)
            {
                await _livroAppService.AddAsync(livroViewModel);
                return RedirectToAction(nameof(Index));
            }

            await PopulateSelectAutores(livroViewModel.AutorId);
            return View(livroViewModel);
        }

        // GET: Livro/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var livroViewModel = await _livroAppService.GetByIdAsync(id.Value);
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
                    await _livroAppService.EditAsync(livroViewModel);
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

            var livroViewModel = await _livroAppService.GetByIdAsync(id.Value);
            if (livroViewModel == null)
            {
                return NotFound();
            }

            return View(livroViewModel);
        }

        // POST: Livro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var livroViewModel = await _livroAppService.GetByIdAsync(id);
            await _livroAppService.RemoveAsync(livroViewModel);
            return RedirectToAction(nameof(Index));
        }

        private bool LivroViewModelExists(int id)
        {
            return _livroAppService.GetByIdAsync(id) != null;
        }

        [AcceptVerbs("GET", "POST")]
        public async Task<IActionResult> IsIsbnValid(string isbn, int? id = null)
        {
            if (!(await _livroAppService.IsIsbnValidAsync(isbn, id)))
            {
                return Json($"Isbn {isbn} já está cadastrado e não pode ser repetido");
            }

            return Json(true);
        }
    }
}
