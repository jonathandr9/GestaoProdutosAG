using Microsoft.AspNetCore.Mvc;

namespace GestaoProdutosAG.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
