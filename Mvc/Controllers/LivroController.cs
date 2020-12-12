using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mvc.HttpServices;
using Mvc.ViewModels;

namespace Mvc.Controllers
{
    public class LivroController : CrudController<LivroViewModel>
    {
        private readonly IAutorHttpService _autorHttpService;
        private readonly ILivroHttpService _livroHttpService;

        public LivroController(
            IAutorHttpService autorHttpService,
            ILivroHttpService livroHttpService)
            : base(livroHttpService)
        {
            _autorHttpService = autorHttpService;
            _livroHttpService = livroHttpService;
        }

        protected override async Task PopulateSelectPrimary(int? autorId = null)
        {
            var autores = await _autorHttpService.GetAllAsync(null);

            ViewBag.Autores = new SelectList(
                autores,
                nameof(AutorViewModel.Id),
                nameof(AutorViewModel.AutorNomeCompleto),
                autorId);
        }

        // POST: Livro/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateLivroAutor(LivroAutorCreateViewModel livroAutorCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                await _livroHttpService.AddAsync(livroAutorCreateViewModel);
                return RedirectToAction(nameof(Index));
            }

            await PopulateSelectPrimary(livroAutorCreateViewModel.AutorId);
            return View(nameof(Create), livroAutorCreateViewModel);
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
