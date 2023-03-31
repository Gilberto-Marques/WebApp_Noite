using Microsoft.AspNetCore.Mvc;

namespace WebApp_Noite.Controllers
{
    public class ProdutoController : Controller
    {
        public IActionResult Lista()
        {
            return View();
        }

        public IActionResult Cadastrar()
        {
            return View();
            //return view retorna a tela ao usuário, nesse caso, a tela cadastrar
        }
    }
}
