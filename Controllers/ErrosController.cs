using Microsoft.AspNetCore.Mvc;

namespace Caixai.Web2.Controllers
{
    public class ErrosController : Controller
    {
        [Route("Erros/Status/{code}")]
        public IActionResult status(int code)
        {
            if(code == 404) { return View("~/Views/Shared/Errors/NotFound.cshtml"); }
            return View();
        }
    }
}
