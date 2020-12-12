using Mvc.HttpServices;
using Mvc.ViewModels;

namespace Mvc.Controllers
{
    public class AutorController : CrudController<AutorViewModel>
    {
        public AutorController(
            IAutorHttpService autorHttpService)
            : base(autorHttpService)
        {
        }
    }
}
